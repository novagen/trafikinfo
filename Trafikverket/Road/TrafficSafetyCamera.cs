using System;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class TrafficSafetyCamera
	{
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public int Bearing { get; set; }
		public string IconId { get; set; }
		public string Id { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Name { get; set; }
		public string RoadNumber { get; set; }
		public Geometry Geometry { get; set; }
	}
}