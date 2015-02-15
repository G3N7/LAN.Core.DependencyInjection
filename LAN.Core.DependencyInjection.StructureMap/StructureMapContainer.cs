using System;
using StructureMap.Diagnostics.TreeView;
using IStructureMapContainer = StructureMap.IContainer;

namespace LAN.Core.DependencyInjection.StructureMap
{
	public class StructureMapContainer : IContainer
	{
		private readonly IStructureMapContainer _container;

		public StructureMapContainer(IStructureMapContainer container)
		{
			_container = container;
		}

		public void Bind<TAbstract, TConcrete>(bool singleton)
			where TAbstract : class
			where TConcrete : class, TAbstract
		{
			_container.Configure(x =>
					{
						var binding = x.For<TAbstract>().Use<TConcrete>();
						if (singleton)
						{
							binding.Singleton();
						}
						else
						{
							binding.AlwaysUnique();
						}
					}
				);
		}

		public TAbstract GetInstance<TAbstract>() where TAbstract : class
		{
			return _container.GetInstance<TAbstract>();
		}

		public object GetInstance(Type abstractType)
		{
			return _container.GetInstance(abstractType);
		}

		public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
		{
			_container.Configure(x => x.For<TAbstract>().Use(singletonOfConcrete));
		}

		public RegistrationResult AreAllRequiredDependenciesRegistered()
		{
			try
			{
				this._container.AssertConfigurationIsValid();
				return new RegistrationResult("Success", false);
			}
			catch (Exception ex)
			{
				return new RegistrationResult(ex.ToString(), true);
			}
		}
	}
}
