using System;
using Trafikverket.Transfer;
using Xunit;

namespace Trafikverket.Tests
{
	public class TrafikinfoTest
	{
		private static readonly string _apiKey = "de27ad22706b4cd085762ac5ab1f4d22";
		private static readonly string _apiReferer = "C# library test";

		[Fact]
		public void RequestStation()
		{
			using (var api = new Trafikinfo(new Configuration { Key = _apiKey, Referer = _apiReferer }))
			{
				var request = new Request();
				request.AddQuery(new Query(ObjectType.TrainStation));
				request.Queries[0].Filter.AddOperator(new FilterOperator(OperatorType.Equals, "LocationSignature", "cst"));

				var response = api.Request(request);

				Assert.True(response.Result != null && response.Result[0].TrainStation != null);
			}
		}
	}
}
