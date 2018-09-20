using System.Collections.Generic;

namespace Trafikverket.Transfer
{
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

		public Request AddQuery(Query query)
		{
			Queries.Add(query);
			return this;
		}

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