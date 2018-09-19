using System;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class FerryRoute
	{
		public bool Deleted { get; set; }
		public string DeviationId { get; set; }
		public string Id { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Name { get; set; }
		public string Shortname { get; set; }
		public Geometry Geometry { get; set; }
		public Harbor Harbor { get; set; }
		public Timetable Timetable { get; set; }
		public HarborType Type { get; set; }
	}
}