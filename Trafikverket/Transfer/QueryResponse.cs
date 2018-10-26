using Newtonsoft.Json;
using System.Linq;

namespace Apparent.Trafikverket.Transfer
{
	public class QueryResponse
	{
		[JsonProperty("RESPONSE")]
		public Response Response { get; set; }

		public bool HasError()
		{
			if (Response?.Result == null || !Response.Result.Any()) return false;
			return Response.Result.First().Error != null;
		}
	}
}