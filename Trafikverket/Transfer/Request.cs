using System;
using System.Collections.Generic;
using Trafikverket.Util;

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

	public class Login
	{
		public string AuthenticationKey { get; set; }

		public Login(string authenticationKey)
		{
			AuthenticationKey = authenticationKey;
		}

		public string Build()
		{
			return $"<LOGIN authenticationkey=\"{AuthenticationKey}\" />";
		}
	}

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

	public class Filter
	{
		public List<FilterOperator> Operators { get; set; }
		public List<FilterGroup> Groups { get; set; }

		public Filter()
		{
			Operators = new List<FilterOperator>();
			Groups = new List<FilterGroup>();
		}

		public Filter AddGroup(FilterGroup group)
		{
			Groups.Add(group);
			return this;
		}

		public Filter AddOperator(FilterOperator oprator)
		{
			Operators.Add(oprator);
			return this;
		}

		public string Build()
		{
			var builder = new System.Text.StringBuilder();

			foreach (var g in Groups)
			{
				builder.Append(g.Build());
			}

			foreach (var o in Operators)
			{
				builder.Append(o.Build());
			}

			if (builder.Length > 0)
			{
				return $"<FILTER>{builder}</FILTER>";
			}

			return "";
		}
	}

	public class FilterOperator
	{
		public OperatorType Type { get; set; }
		public string Name { get; set; }
		public object Value { get; set; }
		public Shape Shape { get; set; }
		public string Radius { get; set; }

		public FilterOperator(OperatorType type, string name, object value, Shape shape = Shape.None, string radius = null)
		{
			Type = type;
			Name = name;
			Value = value;
			Shape = shape;
			Radius = radius;
		}

		public FilterOperator SetShape(Shape shape)
		{
			Shape = shape;
			return this;
		}

		public FilterOperator SetRadius(string radius)
		{
			Radius = radius;
			return this;
		}

		public string Build()
		{
			var value = "";

			value = Value is Enum ? ((Enum)Value).GetEnumDescription() : Value is Boolean ? ((bool)Value).ToString() : (string)Value;

			var shape = "";
			var radius = "";

			if (Shape != Shape.None)
			{
				shape = $" shape=\"{Shape.GetEnumDescription()}\"";
			}

			if (!string.IsNullOrWhiteSpace(Radius))
			{
				radius = $" radius=\"{Radius}\"";
			}

			return $"<{Type.GetEnumDescription()} name=\"{Name}\" value=\"{value}\"{shape}{radius} />";
		}
	}

	public class FilterGroup
	{
		public OperatorGroup Group { get; set; }
		public List<FilterOperator> Operators { get; set; }
		public List<FilterGroup> Groups { get; set; }

		public FilterGroup(OperatorGroup group)
		{
			Group = group;
			Operators = new List<FilterOperator>();
			Groups = new List<FilterGroup>();
		}

		public FilterGroup AddOperator(FilterOperator oprator)
		{
			Operators.Add(oprator);
			return this;
		}

		public FilterGroup AddGroup(FilterGroup group)
		{
			Groups.Add(group);
			return this;
		}

		public string Build()
		{
			var builder = new System.Text.StringBuilder();

			foreach (var g in Groups)
			{
				builder.Append(g.Build());
			}

			foreach (var o in Operators)
			{
				builder.Append(o.Build());
			}

			return $"<{Group.GetEnumDescription()}>{builder}</{Group.GetEnumDescription()}>";
		}
	}
}