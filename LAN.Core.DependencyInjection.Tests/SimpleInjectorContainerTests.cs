using LAN.Core.DependencyInjection.SimpleInjector;
using SimpleInjector;

namespace LAN.Core.DependencyInjection.Tests
{
	public class SimpleInjectorContainerTests : ContainersMustSatisfy<SimpleInjectorContainer>
	{
		protected override SimpleInjectorContainer CreateContainer()
		{
			return new SimpleInjectorContainer(new Container());
		}
	}
}
