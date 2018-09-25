namespace Trafikverket.Transfer
{
	public class Login
	{
		public string AuthenticationKey { get; set; }

		public Login(string authenticationKey)
		{
			AuthenticationKey = authenticationKey;
		}

		public string Build()
		{
			return $"<LOGIN authenticationkey=\"{AuthenticationKey}\" />";
		}
	}
}