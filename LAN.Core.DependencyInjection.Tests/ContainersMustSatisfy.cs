using System;
using NUnit.Framework;

namespace LAN.Core.DependencyInjection.Tests
{
	public abstract class ContainersMustSatisfy<TContainer> where TContainer : IContainer
	{
		private TContainer _container;
		private DateTime _startInitialization;
		private DateTime _initializationComplete;
		private DateTime _testComplete;
		private DateTime _testFixtureRunStart;
		private DateTime _testFixtureRunEnd;

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			_testFixtureRunStart = DateTime.Now;
		}

		[TestFixtureTearDown]
		public void FixtureTearDown()
		{
			_testFixtureRunEnd = DateTime.Now;
			Console.WriteLine("Full Test Run: {0}ms", _testFixtureRunEnd.Subtract(_testFixtureRunStart).TotalMilliseconds);
		}

		[SetUp]
		public void Setup()
		{
			_startInitialization = DateTime.Now;
			_container = this.CreateContainer();
			_initializationComplete = DateTime.Now;
		}

		[TearDown]
		public void TearDown()
		{
			_testComplete = DateTime.Now;

			Console.WriteLine("Initialization Took: {0}ms", _initializationComplete.Subtract(_startInitialization).TotalMilliseconds);
			Console.WriteLine("Test Run Time: {0}ms", _testComplete.Subtract(_initializationComplete).TotalMilliseconds);
		}

		protected abstract TContainer CreateContainer();

		[Test]
		public void RegisterByTypeCanBeRetrieved()
		{
			_container.Bind<ExampleType, ExampleType>(true);
			var instance = _container.GetInstance<ExampleType>();

			Assert.That(instance, Is.Not.Null);
			Assert.That(instance, Is.TypeOf<ExampleType>());
		}

		[Test]
		public void RegisterByInstanceCanBeRetrieved()
		{
			var testInstance = new ExampleType();
			_container.RegisterSingleton(testInstance);
			var instance = _container.GetInstance<ExampleType>();

			Assert.That(instance, Is.Not.Null);
			Assert.That(instance, Is.TypeOf<ExampleType>());
			Assert.That(instance, Is.SameAs(testInstance));
		}

		/// <exception cref="InconclusiveException">Instance could not be instantiated</exception>
		[Test]
		public void SingletonsAreOnlyInstantiatedOnce()
		{
			_container.Bind<ExampleType, ExampleType>(true);
			var countBeforeTest = ExampleType.InstantiationCount;
			var instance = _container.GetInstance<ExampleType>();

			if (instance == null) throw new InconclusiveException("Instance could not be instantiated");
			Assert.That(ExampleType.InstantiationCount, Is.EqualTo(countBeforeTest + 1));
		}

		/// <exception cref="InconclusiveException">Instance could not be instantiated</exception>
		[Test]
		public void NonSingletonsAreOnlyInstantiatedEachTime()
		{
			_container.Bind<ExampleType, ExampleType>(false);
			var countBeforeTest = ExampleType.InstantiationCount;
			// ReSharper disable once RedundantAssignment
			var instance = _container.GetInstance<ExampleType>();
			instance = _container.GetInstance<ExampleType>();

			if (instance == null) throw new InconclusiveException("Instance could not be instantiated");
			Assert.That(ExampleType.InstantiationCount, Is.EqualTo(countBeforeTest + 2));
		}

		[Test]
		public void InstancesCanBeRetrievedByRuntimeType()
		{
			_container.Bind<ExampleType, ExampleType>(true);
			var instance = _container.GetInstance(typeof(ExampleType));

			Assert.That(instance, Is.Not.Null);
		}

		[Test]
		public void AreAllRequiredDependenciesRegisteredWhenRegistrationIsFulfilled()
		{
			_container.Bind<DependentService, DependentService>(true);
			_container.Bind<IServiceDependency, ServiceDependency>(true);

			var result = _container.AreAllRequiredDependenciesRegistered();

			Assert.That(result.IsMissingDependencies, Is.False);
		}

		[Test]
		public void AreAllRequiredDependenciesRegisteredWhenRegistrationAreNotFulfilled()
		{
			_container.Bind<DependentService, DependentService>(true);

			var result = _container.AreAllRequiredDependenciesRegistered();

			Assert.That(result.IsMissingDependencies, Is.True);
			Assert.That(result.Message, Is.Not.Empty);
		}

		private class ExampleType
		{
			public static int InstantiationCount { get; private set; }

			public ExampleType()
			{
				InstantiationCount++;
			}
		}

		private class DependentService
		{
			public DependentService(IServiceDependency service)
			{

			}
		}

		private class ServiceDependency : IServiceDependency
		{
		}

		private interface IServiceDependency
		{

		}
	}
}