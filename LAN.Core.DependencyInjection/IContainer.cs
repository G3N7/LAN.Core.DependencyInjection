using System;
using System.Diagnostics.Contracts;

namespace LAN.Core.DependencyInjection
{
	[ContractClass(typeof(ContractContainer))]
	public interface IContainer
	{
		
		/// <summary>
		/// Will register a given <see cref="TConcrete"/> to any <see cref="TAbstract"/> that is required at injection time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type you intend to use in your code.</typeparam>
		/// <typeparam name="TConcrete">Which concrete implementation to provide given an occurance of the <see cref="TAbstract"/> being injected</typeparam>
		/// <param name="singleton">Indicates if the type should be singleton, instead of being instanciated each injection</param>
		void Bind<TAbstract, TConcrete>(bool singleton)
			where TConcrete : class, TAbstract
			where TAbstract : class;

		/// <summary>
		/// Gets an instance of a specific type (<see cref="TAbstract"/>) out of the container.  This is for usecases where the type is known at compile time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type of to get a concrete implemenation for.</typeparam>
		/// <returns></returns>
		TAbstract GetInstance<TAbstract>() where TAbstract : class;
		
		/// <summary>
		/// Gets an instance of a specific type (<see cref="abstractType"/>) out of the container.  This is for usecases where the type is not known until runtime.
		/// </summary>
		/// <param name="abstractType">The abstract type of to get a concrete implemenation for.</param>
		/// <returns></returns>
		object GetInstance(Type abstractType);

		/// <summary>
		/// Will register a given <see cref="singletonOfConcrete"/> to any <see cref="TAbstract"/> that is required at injection time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type you intend to use in your code.</typeparam>
		/// <param name="singletonOfConcrete">The specific instance of a class you wish to be used at injection time for all usages of <see cref="TAbstract"/></param>
		void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class;
	}

	[ContractClassFor(typeof(IContainer))]
	class ContractContainer : IContainer
	{
		public void Bind<TAbstract, TConcrete>(bool singleton) where TAbstract : class where TConcrete : class, TAbstract
		{
			throw new NotImplementedException();
		}

		public TAbstract GetInstance<TAbstract>() where TAbstract : class
		{
			throw new NotImplementedException();
		}

		public object GetInstance(Type abstractType)
		{
			Contract.Requires(abstractType != null);
			throw new NotImplementedException();
		}

		public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
		{
			Contract.Requires(singletonOfConcrete != null);

			throw new NotImplementedException();
		}
	}
}