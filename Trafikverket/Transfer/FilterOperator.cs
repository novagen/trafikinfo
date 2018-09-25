using System;
using Trafikverket.Util;

namespace Trafikverket.Transfer
{
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
}