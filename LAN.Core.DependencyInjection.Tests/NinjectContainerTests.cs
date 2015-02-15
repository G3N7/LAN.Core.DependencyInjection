using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAN.Core.DependencyInjection.Ninject;
using Ninject;

namespace LAN.Core.DependencyInjection.Tests
{
	public class NinjectContainerTests : ContainersMustSatisfy<NinjectContainer>
	{
		protected override NinjectContainer CreateContainer()
		{
			return new NinjectContainer(new StandardKernel());
		}
	}
}
