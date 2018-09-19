using System;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class WeatherStation
	{
		public bool Active { get; set; }
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public string IconId { get; set; }
		public string Id { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Name { get; set; }
		public Geometry Geometry { get; set; }
		public int RoadNumberNumeric { get; set; }
		public Measurement Measurement { get; set; }
		public MeasurementHistory[] MeasurementHistory { get; set; }
	}
}