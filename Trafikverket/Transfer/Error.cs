using Newtonsoft.Json;

namespace Trafikverket.Transfer
{
	public class Error
	{
		[JsonProperty("SOURCE")]
		public string Source { get; set; }

		[JsonProperty("MESSAGE")]
		public string Message { get; set; }
	}
}