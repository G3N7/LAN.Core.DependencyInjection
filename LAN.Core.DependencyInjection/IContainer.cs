using System;
using System.Diagnostics.Contracts;

namespace LAN.Core.DependencyInjection
{
	[ContractClass(typeof(ContractContainer))]
	public interface IContainer
	{
		void Bind<TAbstract, TConcrete>(bool singleton)
			where TConcrete : class, TAbstract
			where TAbstract : class;
		T GetInstance<T>() where T : class;
		object GetInstance(Type type);
		void RegisterSingleton<T>(T service) where T : class;
	}

	[ContractClassFor(typeof(IContainer))]
	class ContractContainer : IContainer
	{
		public void Bind<TAbstract, TConcrete>(bool singleton) where TAbstract : class where TConcrete : class, TAbstract
		{
			throw new NotImplementedException();
		}

		public T GetInstance<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public object GetInstance(Type type)
		{
			Contract.Requires(type != null);
			throw new NotImplementedException();
		}

		public void RegisterSingleton<T>(T service) where T : class
		{
			Contract.Requires(service != null);

			throw new NotImplementedException();
		}
	}
}