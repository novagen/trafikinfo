using System;
using System.Collections.Generic;
using Trafikverket.Util;

namespace Trafikverket.Transfer
{
	public class Query
	{
		public ObjectType ObjectType { get; set; }
		public long Limit { get; set; }
		public string Id { get; set; }
		public bool IncludeDeletedObjects { get; set; }
		public string OrderBy { get; set; }
		public long Skip { get; set; }
		public DateTime LastModified { get; set; }
		public bool Count { get; set; }

		public Filter Filter { get; set; }

		public string Distinct { get; set; }
		public List<string> Include { get; set; }
		public List<string> Exclude { get; set; }

		public Query(ObjectType objectType)
		{
			ObjectType = objectType;
			Filter = new Filter();
		}

		public string Build()
		{
			var id = "";
			var includedeletedobjects = "";
			var limit = "";
			var orderby = "";
			var skip = "";
			var lastmodified = "";
			var count = "";

			if (!string.IsNullOrWhiteSpace(Id))
			{
				id = $" id=\"{Id}\"";
			}

			if (IncludeDeletedObjects)
			{
				includedeletedobjects = $" includedeletedobjects=\"true\"";
			}

			if (Limit > 0)
			{
				limit = $" limit=\"{Limit}\"";
			}

			if (!string.IsNullOrWhiteSpace(OrderBy))
			{
				orderby = $" orderby=\"{OrderBy}\"";
			}

			if (Skip > 0)
			{
				skip = $" limit=\"{Skip}\"";
			}

			if (LastModified != DateTime.MinValue)
			{
				lastmodified = $" lastmodified=\"{LastModified.ToUtcString()}\"";
			}

			if (Count)
			{
				count = $" count=\"true\"";
			}

			return $"<QUERY objecttype=\"{ObjectType.GetEnumDescription()}\"{id}{includedeletedobjects}{limit}{orderby}{skip}{lastmodified}{count}>{Filter.Build()}</QUERY>";
		}
	}
}