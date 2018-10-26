using System;
using System.Collections.Generic;
using Apparent.Trafikverket.Data;

namespace Apparent.Trafikverket.Railroad
{
	public class TrainMessage
	{
		public string[] AffectedLocation { get; set; }
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public DateTime EndDateTime { get; set; }
		public int EventId { get; set; }
		public string ExternalDescription { get; set; }
		public string Header { get; set; }
		public DateTime LastUpdateDateTime { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string ReasonCodeText { get; set; }
		public DateTime StartDateTime { get; set; }
		public Geometry Geometry { get; set; }
		public IEnumerable<TrafficImpact> TrafficImpact { get; set; }
	}
}