namespace LAN.Core.DependencyInjection
{
	public class RegistrationResult
	{
		public RegistrationResult(string message, bool isMissingDependencies)
		{
			Message = message;
			IsMissingDependencies = isMissingDependencies;
		}
		
		public string Message { get; private set; }
		public bool IsMissingDependencies { get; private set; }
	}
}