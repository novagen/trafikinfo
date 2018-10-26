namespace Apparent.Trafikverket.Data
{
	public class ScheduleDeviation
	{
		public string Description { get; set; }
		public string FromDate { get; set; }
		public string Id { get; set; }
		public string SpecDate { get; set; }
		public string ToDate { get; set; }
		public DeviationType Type { get; set; }
	}
}