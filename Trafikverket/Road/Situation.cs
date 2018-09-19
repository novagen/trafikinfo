using System;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class Situation
	{
		public string CountryCode { get; set; }
		public bool Deleted { get; set; }
		public Deviation[] Deviation { get; set; }
		public string Id { get; set; }
		public DateTime ModifiedTime { get; set; }
		public DateTime PublicationTime { get; set; }
		public DateTime VersionTime { get; set; }
	}
}