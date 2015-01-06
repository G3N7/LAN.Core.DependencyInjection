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
		/// <typeparam name="TConcrete">Which concrete implementation to provide given an occurrence of the <see cref="TAbstract"/> being injected</typeparam>
		/// <param name="singleton">Indicates if the type should be singleton, instead of being instantiated each injection</param>
		void Bind<TAbstract, TConcrete>(bool singleton)
			where TConcrete : class, TAbstract
			where TAbstract : class;

		/// <summary>
		/// Gets an instance of a specific type (<see cref="TAbstract"/>) out of the container.  This is for usecases where the type is known at compile time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type of to get a concrete implementation for.</typeparam>
		/// <returns></returns>
		TAbstract GetInstance<TAbstract>() where TAbstract : class;
		
		/// <summary>
		/// Gets an instance of a specific type (<see cref="abstractType"/>) out of the container.  This is for usecases where the type is not known until runtime.
		/// </summary>
		/// <param name="abstractType">The abstract type of to get a concrete implementation for.</param>
		/// <returns></returns>
		object GetInstance(Type abstractType);

		/// <summary>
		/// Will register a given <see cref="singletonOfConcrete"/> to any <see cref="TAbstract"/> that is required at injection time.
		/// </summary>
		/// <typeparam name="TAbstract">The abstract type you intend to use in your code.</typeparam>
		/// <param name="singletonOfConcrete">The specific instance of a class you wish to be used at injection time for all usages of <see cref="TAbstract"/></param>
		void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class;

		/// <summary>
		/// This will check that all currently registered members can be created.  Ensuring that all types can be instantiated and returned.
		/// </summary>
		/// <returns></returns>
		RegistrationResult AreAllRequiredDependenciesRegistered();
	}
}