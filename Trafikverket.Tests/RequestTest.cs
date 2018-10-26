using NUnit.Framework;
using Apparent.Trafikverket.Transfer;

namespace Apparent.Trafikverket.Tests
{
	[TestFixture, Category(nameof(RequestTest))]
	public class RequestTest
	{
		private readonly string apiKey;
		private readonly string apiReferer;

		public RequestTest()
		{
			apiKey = TestContext.Parameters.Get(nameof(apiKey));
			apiReferer = TestContext.Parameters.Get(nameof(apiReferer));
		}

		[Test]
		public void RequestStation()
		{
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