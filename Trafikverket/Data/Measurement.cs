using System;

namespace Trafikverket.Data
{
	public class Measurement
	{
		public DateTime MeasureTime { get; set; }
		public Precipitation Precipitation { get; set; }
		public Road Road { get; set; }
		public Air Air { get; set; }
		public Wind Wind { get; set; }
	}
}