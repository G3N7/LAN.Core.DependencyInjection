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

		public T GetInstance<T>() where T : class
		{
			return _container.GetInstance<T>();
		}

		public object GetInstance(Type type)
		{
			return _container.GetInstance(type);
		}

		public void RegisterSingleton<T>(T service) where T : class
		{
			this._container.Register(() => service);
		}
	}
}
