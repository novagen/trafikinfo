using NUnit.Framework;
using System;
using Trafikverket.Transfer;

namespace Trafikverket.Tests
{
	[TestFixture]
	public class RequestTest
	{
		private static readonly string _apiKey = "";
		private static readonly string _apiReferer = "";

		[Test]
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
