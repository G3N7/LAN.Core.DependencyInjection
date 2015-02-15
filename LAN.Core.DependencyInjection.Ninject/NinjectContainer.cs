using System;
using System.Linq;
using System.Reflection;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Planning.Bindings;

namespace LAN.Core.DependencyInjection.Ninject
{
	public class NinjectContainer : IContainer
	{
		private readonly IKernel _kernel;

		public NinjectContainer(IKernel kernel)
		{
			this._kernel = kernel;
		}

		public void Bind<TAbstract, TConcrete>(bool singleton)
			where TAbstract : class
			where TConcrete : class, TAbstract
		{
			var binding = this._kernel.Bind<TAbstract>().To<TConcrete>();

			if (singleton)
			{
				binding.InSingletonScope();
			}
			else
			{
				binding.InTransientScope();
			}
		}

		public TAbstract GetInstance<TAbstract>() where TAbstract : class
		{
			return this._kernel.Get<TAbstract>();
		}

		public object GetInstance(Type abstractType)
		{
			return this._kernel.Get(abstractType);
		}

		public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
		{
			this._kernel.Bind<TAbstract>().ToConstant(singletonOfConcrete);
		}

		public RegistrationResult AreAllRequiredDependenciesRegistered()
		{
			try
			{
				var allRegisteredTypes = this._kernel.GetBindings();
				foreach (var t in allRegisteredTypes)
				{
					this._kernel.Get(t);
				}
				return new RegistrationResult("Success", false);
			}
			catch (Exception ex)
			{
				return new RegistrationResult(ex.ToString(), true);
			}
		}
	}

	public static class KernelExtensions
	{
		public static Type[] GetBindings(this IKernel kernel)
		{
			var fieldInfo = typeof(KernelBase)
				.GetField("bindings", BindingFlags.NonPublic | BindingFlags.Instance);
			
			if (fieldInfo == null) return new Type[0];

			return ((Multimap<Type, IBinding>)fieldInfo
				.GetValue(kernel)).Select(x => x.Key).ToArray();
		}
	}
}
