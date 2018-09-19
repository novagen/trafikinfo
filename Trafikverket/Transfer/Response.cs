using Newtonsoft.Json;

namespace Trafikverket.Transfer
{
	public class Response
	{
		[JsonProperty("RESULT")]
		public Result[] Result { get; set; }
	}
}