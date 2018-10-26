using Newtonsoft.Json;
using System;

namespace Apparent.Trafikverket.Transfer
{
	public class Info
	{
		[JsonProperty("LASTMODIFIED")]
		public DateTime LastModified { get; set; }
	}
}