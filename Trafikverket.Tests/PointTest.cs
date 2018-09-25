﻿using System.Collections.Generic;
using Trafikverket.Data;
using NUnit.Framework;

namespace Trafikverket.Tests
{
	[TestFixture]
	public class PointTest
	{
		[Test]
		public void GetPointFromSweref()
		{
			var geo = new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" };
			var point = Point.GetPointFromSweref(geo);

			var expected = new Point(570452.99d, 6953233.9d);

			Assert.AreEqual(expected.Latitude, point.Latitude);
			Assert.AreEqual(expected.Longitude, point.Longitude);
		}

		[Test]
		public void GetPointFromWgs()
		{
			var geo = new Geometry { Wgs84 = "POINT (16.3770065 62.7028427)" };
			var point = Point.GetPointFromWgs(geo);

			var expected = new Point(570452.992d, 6953233.903d);

			Assert.AreEqual(expected.Latitude, point.Latitude);
			Assert.AreEqual(expected.Longitude, point.Longitude);
		}

		[Test]
		public void GetPointFromGeometry()
		{
			var geo = new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" };
			var point = Point.GetPointFromGeometry(geo);

			var expected = new Point(570452.99d, 6953233.9d);

			Assert.AreEqual(expected.Latitude, point.Latitude);
			Assert.AreEqual(expected.Longitude, point.Longitude);
		}

		[Test]
		public void GetClosest()
		{
			var points = new List<Point>
			{
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (297160.02 6460440)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (785909.97 7092019.94)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (690189.02 6694314.07)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (592554.96 6500334.15)" }),
				Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (461668.98 6432526.84)" })
			};

			var point = Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (570452.99 6953233.9)" });
			var closest = Point.GetClosest(points, point);

			var expected = Point.GetPointFromSweref(new Geometry { Sweref99Tm = "POINT (785909.97 7092019.94)" });

			Assert.AreEqual(expected.Latitude, closest.Latitude);
			Assert.AreEqual(expected.Longitude, closest.Longitude);
		}
	}
}
