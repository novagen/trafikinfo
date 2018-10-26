using NUnit.Framework;
using System.Collections.Generic;
using Apparent.Trafikverket.Data;

namespace Apparent.Trafikverket.Tests
{
	[TestFixture, Category(nameof(PointTest))]
	public class PointTest
	{
		private static readonly Point expected = new Point(570452.99d, 6953233.9d);

		private static Point GetPointFromSweref()
		{
			var geo = new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" };
			return Point.GetPointFromSweref(geo);
		}

		[Test]
		public void GetPointFromSwerefLat()
		{
			var point = GetPointFromSweref();
			Assert.AreEqual(expected.Latitude, point.Latitude, 0.01d);
		}

		[Test]
		public void GetPointFromSwerefLng()
		{
			var point = GetPointFromSweref();
			Assert.AreEqual(expected.Longitude, point.Longitude, 0.01d);
		}

		private static Point GetPointFromWgs()
		{
			var geo = new Geometry { Wgs84 = "POINT (16.3770065 62.7028427)" };
			return Point.GetPointFromWgs(geo);
		}

		[Test]
		public void GetPointFromWgsLat()
		{
			var point = GetPointFromWgs();
			Assert.AreEqual(expected.Latitude, point.Latitude, 0.01d);
		}

		[Test]
		public void GetPointFromWgsLng()
		{
			var point = GetPointFromWgs();
			Assert.AreEqual(expected.Longitude, point.Longitude, 0.01d);
		}

		public static Point GetPointFromGeometry()
		{
			var geo = new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" };
			return Point.GetPointFromGeometry(geo);
		}

		[Test]
		public void GetPointFromGeometryLat()
		{
			var point = GetPointFromGeometry();
			Assert.AreEqual(expected.Latitude, point.Latitude, 0.01d);
		}

		[Test]
		public void GetPointFromGeometryLng()
		{
			var point = GetPointFromGeometry();
			Assert.AreEqual(expected.Longitude, point.Longitude, 0.01d);
		}

		public static Point GetClosest()
		{
			var points = new List<Point>
			{
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (297160.02 6460440)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (785909.97 7092019.94)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (690189.02 6694314.07)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (592554.96 6500334.15)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (461668.98 6432526.84)" })
			};

			var closestTo = Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" });
			return Point.GetClosest(points, closestTo);
		}

		[Test]
		public void GetClosestLat()
		{
			var point = GetClosest();
			var e = Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (785909.97 7092019.94)" });

			Assert.AreEqual(e.Latitude, point.Latitude, 0.01d);
		}

		[Test]
		public void GetClosestLng()
		{
			var point = GetClosest();
			var e = Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (785909.97 7092019.94)" });

			Assert.AreEqual(e.Longitude, point.Longitude, 0.01d);
		}
	}
}