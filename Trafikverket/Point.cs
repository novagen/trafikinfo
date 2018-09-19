using System;
using System.Collections.Generic;
using System.Linq;
using Trafikverket.Data;

namespace Trafikverket
{
	public class Point
	{
		public double x, y;

		private Point(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public static Point GetPointFromGeometry(Geometry geo)
		{
			if (string.IsNullOrWhiteSpace(geo.Sweref99Tm))
			{
				return null;
			}

			var data = geo.Sweref99Tm.Replace("POINT (", "").Replace(")", "").Split(' ');

			var resultX = double.TryParse(data[0].Replace('.', ','), out double x);
			var resultY = double.TryParse(data[1].Replace('.', ','), out double y);

			if (resultX && resultY)
			{
				return new Point(x, y);
			}

			return null;
		}

		public static Point GetClosest(List<Point> points, Point to)
		{
			Point closestPoint = null;
			var closestDistanceSquared = double.MaxValue;

			foreach (var point in points.Where(c => c != null))
			{
				var distanceSquared = Math.Pow(point.x - to.x, 2) + Math.Pow(point.y - to.y, 2);

				if (distanceSquared < closestDistanceSquared)
				{
					closestDistanceSquared = distanceSquared;
					closestPoint = point;
				}
			}

			return closestPoint;
		}
	}
}