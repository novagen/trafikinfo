using Newtonsoft.Json;
using System;

namespace Trafikverket.Transfer
{
	public class Info
	{
		[JsonProperty("LASTMODIFIED")]
		public DateTime LastModified { get; set; }
	}
}