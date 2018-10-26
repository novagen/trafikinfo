using System;
using Apparent.Trafikverket.Data;

namespace Apparent.Trafikverket.Road
{
	public class FerryAnnouncement
	{
		public bool Deleted { get; set; }
		public DateTime DepartureTime { get; set; }
		public string DeviationId { get; set; }
		public string Id { get; set; }
		public string[] Info { get; set; }
		public DateTime ModifiedTime { get; set; }

		public HarborLocation FromHarbor { get; set; }
		public HarborLocation ToHarbor { get; set; }
		public Route Route { get; set; }
	}
}