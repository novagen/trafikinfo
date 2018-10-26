using System.Collections.Generic;

namespace Apparent.Trafikverket.Transfer
{
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
}