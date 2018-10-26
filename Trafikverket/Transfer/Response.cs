using Newtonsoft.Json;

namespace Apparent.Trafikverket.Transfer
{
	public class Response
	{
		[JsonProperty("RESULT")]
		public Result[] Result { get; set; }
	}
}