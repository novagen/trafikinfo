using System.Collections.Generic;
using Trafikverket.Util;

namespace Trafikverket.Transfer
{
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