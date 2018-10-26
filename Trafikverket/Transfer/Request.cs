using System.Collections.Generic;

namespace Apparent.Trafikverket.Transfer
{
	/// <summary>
	/// Request is used for all calls to the API.
	/// </summary>
	public class Request
	{
		public Login Login { get; set; }
		public List<Query> Queries { get; set; }

		public Request()
		{
			Queries = new List<Query>();
		}

		public Request(string authenticationKey)
		{
			Login = new Login(authenticationKey);
			Queries = new List<Query>();
		}

		/// <summary>
		/// Add a query to the request.
		/// Each query will result in a Result in the Response.
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public Request AddQuery(Query query)
		{
			Queries.Add(query);
			return this;
		}

		/// <summary>
		/// Generates the XML used in the API call.
		/// </summary>
		/// <returns></returns>
		public string Build()
		{
			var builder = new System.Text.StringBuilder();

			foreach (var q in Queries)
			{
				builder.Append(q.Build());
			}

			var result = $"<REQUEST>{Login.Build()}{builder.ToString()}</REQUEST>";
			return result;
		}
	}
}