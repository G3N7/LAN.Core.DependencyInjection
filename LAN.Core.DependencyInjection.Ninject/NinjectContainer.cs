using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Core.DependencyInjection.Ninject
{
    public class NinjectContainer : IContainer
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
		    throw new NotImplementedException();
	    }

	    public void RegisterSingleton<TAbstract>(TAbstract singletonOfConcrete) where TAbstract : class
	    {
		    throw new NotImplementedException();
	    }

	    public RegistrationResult AreAllRequiredDependenciesRegistered()
	    {
		    throw new NotImplementedException();
	    }
    }
}
