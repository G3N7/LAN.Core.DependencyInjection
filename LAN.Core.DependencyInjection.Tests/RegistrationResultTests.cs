using NUnit.Framework;

namespace LAN.Core.DependencyInjection.Tests
{
    public class RegistrationResultTests
    {
	    [Test]
	    public void MapsCorrectly()
	    {
		    var result = new RegistrationResult("Any message", true);

			Assert.That(result.Message, Is.Not.Empty);
			Assert.That(result.IsMissingDependencies, Is.True);
	    }
    }
}
