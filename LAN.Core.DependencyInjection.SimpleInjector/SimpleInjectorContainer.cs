using System;
using Container = SimpleInjector.Container;

namespace LAN.Core.DependencyInjection.SimpleInjector
{
	public class SimpleInjectorContainer : IContainer
	{
		private readonly Container _container;

		public SimpleInjectorContainer(Container container)
		{
			_container = container;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Simple Injector has a requirement that your class have a single constructor, this is an optimization on the frameworks part, but also just a reasonable thing to ask.
		///   If your injecting a concrete that has more than one ctor, either bind a singleton or create a subclass that specifies the constructor to use.
		/// </remarks>
		/// <typeparam name="TAbstract">The abstract type you intend to use in your code.</typeparam>
		/// <typeparam name="TConcrete">Which concrete implementation to provide given an occurance of the <see cref="TAbstract"/> being injected</typeparam>
		/// <param name="singleton">Indicates if the type should be singleton, instead of being instanciated each injection</param>
		public void Bind<TAbstract, TConcrete>(bool singleton)
			where TConcrete : class, TAbstract
			where TAbstract : class
		{
			if (singleton)
			{
				_container.RegisterSingle<TAbstract, TConcrete>();
			}
			else
			{
				_container.Register<TAbstract, TConcrete>();
			}
		}

		/// <summary>
		/// Gets an instance of a specific type (<see cref="TAbstract"/>) out of the container.  This is for usecases where the type is known at compile time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type of to get a concrete implemenation for.</typeparam>
		/// <returns></returns>
		public TAbstract GetInstance<TAbstract>() where TAbstract : class
		{
			return _container.GetInstance<TAbstract>();
		}

		/// <summary>
		/// Gets an instance of a specific type (<see cref="abstractType"/>) out of the container.  This is for usecases where the type is not known until runtime.
		/// </summary>
		/// <param name="abstractType">The abstract type of to get a concrete implemenation for.</param>
		/// <returns></returns>
		public object GetInstance(Type abstractType)
		{
			return _container.GetInstance(abstractType);
		}

		/// <summary>
		/// Will register a given <see cref="singletonOfConcrete"/> to any <see cref="TAbstract"/> that is required at injection time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type you intend to use in your code.</typeparam>
		/// <param name="singletonOfConcrete">The specific instance of a class you wish to be used at injection time for all usages of <see cref="TAbstract"/></param>
		public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
		{
			this._container.Register(() => singletonOfConcrete);
		}
	}
}
