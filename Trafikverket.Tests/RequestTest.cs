using NUnit.Framework;
using System;
using Trafikverket.Transfer;

namespace Trafikverket.Tests
{
	[TestFixture]
	public class RequestTest
	{
		[Test]
		public void RequestStation()
		{
			var apiKey = TestContext.Parameters.Get("apiKey");
			var apiReferer = TestContext.Parameters.Get("apiReferer");

			using (var api = new Trafikinfo(new Configuration { Key = apiKey.Trim(), Referer = apiReferer.Trim() }))
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
