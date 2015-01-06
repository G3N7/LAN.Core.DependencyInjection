using LAN.Core.DependencyInjection.SimpleInjector;
using NUnit.Framework;
using SimpleInjector;

namespace LAN.Core.DependencyInjection.Tests.SimpleInjector
{
	public class SimpleInjectorContainerTests
	{
		private SimpleInjectorContainer _container;

		[SetUp]
		public void Setup()
		{
			_container = new SimpleInjectorContainer(new Container());
		}

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
