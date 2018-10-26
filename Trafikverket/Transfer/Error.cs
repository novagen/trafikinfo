using Newtonsoft.Json;

namespace Apparent.Trafikverket.Transfer
{
	public class Error
	{
		[JsonProperty("SOURCE")]
		public string Source { get; set; }

		[JsonProperty("MESSAGE")]
		public string Message { get; set; }
	}
}