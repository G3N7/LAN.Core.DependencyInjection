using System;
using System.Diagnostics.Contracts;

namespace LAN.Core.DependencyInjection
{
	[ContractClassFor(typeof(IContainer))]
	class ContractContainer : IContainer
	{
		public void Bind<TAbstract, TConcrete>(bool singleton) where TAbstract : class where TConcrete : class, TAbstract
		{
			throw new NotImplementedException();
		}

		public TAbstract GetInstance<TAbstract>() where TAbstract : class
		{
			Contract.Ensures(Contract.Result<TAbstract>() != null);
			throw new NotImplementedException();
		}

		public object GetInstance(Type abstractType)
		{
			Contract.Requires(abstractType != null);
			Contract.Ensures(Contract.Result<object>() != null);
			throw new NotImplementedException();
		}

		public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
		{
			Contract.Requires(singletonOfConcrete != null);
			throw new NotImplementedException();
		}

		public RegistrationResult AreAllRequiredDependenciesRegistered()
		{
			Contract.Ensures(Contract.Result<RegistrationResult>() != null);
			throw new NotImplementedException();
		}
	}
}