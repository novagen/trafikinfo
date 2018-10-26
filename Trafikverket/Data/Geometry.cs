using Newtonsoft.Json;
using System;

namespace Apparent.Trafikverket.Data
{
	public class Geometry
	{
		[JsonProperty("SWEREF99TM")]
		public string Sweref99Tm { get; set; }

		[JsonProperty("WGS84")]
		public string Wgs84 { get; set; }

		[JsonProperty("ModifiedTime")]
		public DateTime ModifiedTime { get; set; }
	}
}