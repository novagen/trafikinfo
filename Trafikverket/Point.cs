using MightyLittleGeodesy.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using Trafikverket.Data;

namespace Trafikverket
{
	public class Point
	{
		public double Longitude { get; private set; }
		public double Latitude { get; private set; }

		public Point(double longitude, double latitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}

		public static Point GetPointFromSweref(Geometry geo)
		{
			if (!string.IsNullOrWhiteSpace(geo.Sweref99Tm))
			{
				var data = geo.Sweref99Tm.Replace("POINT (", "").Replace(")", "").Split(' ');

				if (data != null)
				{
					if (double.TryParse(data[0].Replace('.', ','), out double x) && double.TryParse(data[1].Replace('.', ','), out double y))
					{
						return new Point(x, y);
					}
				}
			}

			return null;
		}

		public static Point GetPointFromWgs(Geometry geo)
		{
			if (!string.IsNullOrWhiteSpace(geo.Wgs84))
			{
				var data = geo.Wgs84.Replace("POINT (", "").Replace(")", "").Split(' ');

				if (data != null && double.TryParse(data[0].Replace('.', ','), out double x) && double.TryParse(data[1].Replace('.', ','), out double y))
				{
					var wgsPos = new WGS84Position(y, x);
					var rtPos = new SWEREF99Position(wgsPos, SWEREF99Position.SWEREFProjection.sweref_99_tm);

					return new Point(rtPos.Longitude, rtPos.Latitude);
				}
			}

			return null;
		}

		public static WGS84Position WgsFromSweref(SWEREF99Position position)
		{
			return position.ToWGS84();
		}

		public static SWEREF99Position SwerefFromWgs(WGS84Position position)
		{
			return new SWEREF99Position(position, SWEREF99Position.SWEREFProjection.sweref_99_tm);
		}

		public static Point GetPointFromGeometry(Geometry geo)
		{
			if (!string.IsNullOrWhiteSpace(geo.Sweref99Tm))
			{
				return GetPointFromSweref(geo);
			}

			if (!string.IsNullOrWhiteSpace(geo.Wgs84))
			{
				return GetPointFromWgs(geo);
			}

			return null;
		}

		public static Point GetClosest(List<Point> points, Point to)
		{
			return points.OrderBy(p => GetDistance(to, p)).First();
		}

		public static double GetDistance(Point a, Point b)
		{
			var dx = a.Longitude - b.Longitude;
			var dy = a.Latitude - b.Latitude;

			return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
		}

		public override int GetHashCode()
		{
			var hash = Longitude.GetHashCode();
			hash ^= Latitude.GetHashCode();
			return hash;
		}

		public override bool Equals(Object obj)
		{
			if (obj is Point)
			{
				var item = obj as Point;
				return Longitude == item.Longitude && Latitude == item.Latitude;
			}

			return false;
		}
	}
}