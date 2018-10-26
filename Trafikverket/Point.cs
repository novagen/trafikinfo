using MightyLittleGeodesy.Positions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Apparent.Trafikverket.Data;

namespace Apparent.Trafikverket
{
	public class Point
	{
		public double Longitude { get; private set; }
		public double Latitude { get; private set; }

		private static readonly Regex regex = new Regex("^POINT \\(([0-9.]+) ([0-9.]+)\\)$");

		public Point(double longitude, double latitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}

		public static Point GetPointFromSweref(Geometry geo)
		{
			if (!string.IsNullOrWhiteSpace(geo.Sweref99Tm))
			{
				return PointFromString(geo.Sweref99Tm);
			}

			return null;
		}

		public static Point GetPointFromWgs(Geometry geo)
		{
			if (!string.IsNullOrWhiteSpace(geo.Wgs84))
			{
				var point = PointFromString(geo.Wgs84);
				var wgsPos = new WGS84Position(point.Latitude, point.Longitude);
				var rtPos = new SWEREF99Position(wgsPos, SWEREF99Position.SWEREFProjection.sweref_99_tm);

				return new Point(rtPos.Longitude, rtPos.Latitude);
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

		public override bool Equals(object obj)
		{
			if (obj is Point)
			{
				var item = obj as Point;
				return Longitude == item.Longitude && Latitude == item.Latitude;
			}

			return false;
		}

		private static Point PointFromString(string values)
		{
			if (!string.IsNullOrWhiteSpace(values))
			{
				var match = regex.Match(values.ToUpper());
				if (match.Success && match.Groups.Count > 2)
				{
					return new Point(DoubleFromString(match.Groups[1].Value), DoubleFromString(match.Groups[2].Value));
				}
			}

			return null;
		}

		private static double DoubleFromString(string value)
		{
			if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
			{
				return result;
			}

			throw new Exception("Unable to convert string to double");
		}
	}
}