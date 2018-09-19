using Newtonsoft.Json;
using System.Linq;

namespace Trafikverket.Transfer
{
	public class QueryResponse
	{
		[JsonProperty("RESPONSE")]
		public Response Response { get; set; }

		public bool IsError()
		{
			if (Response?.Result == null || !Response.Result.Any()) return false;
			return Response.Result.First().Error != null;
		}
	}
}