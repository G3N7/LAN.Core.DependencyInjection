using LAN.Core.DependencyInjection.StructureMap;
using StructureMap;

namespace LAN.Core.DependencyInjection.Tests
{
	public class StructureMapContainerTests : ContainersMustSatisfy<StructureMapContainer>
	{
		protected override StructureMapContainer CreateContainer()
		{
			return new StructureMapContainer(new Container());
		}
	}
}
