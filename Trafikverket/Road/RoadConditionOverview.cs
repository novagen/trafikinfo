using System;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class RoadConditionOverview
	{
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public DateTime EndTime { get; set; }
		public Geometry Geometry { get; set; }
		public string Id { get; set; }
		public string LocationText { get; set; }
		public DateTime ModifiedTime { get; set; }
		public DateTime StartTime { get; set; }
		public string Text { get; set; }
		public bool ValidUntilFurtherNotice { get; set; }
	}
}