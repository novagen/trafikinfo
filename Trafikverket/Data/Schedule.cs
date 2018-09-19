namespace Trafikverket.Data
{
	public class Schedule
	{
		public int SortOrder { get; set; }
		public string Time { get; set; }
		public ScheduleDeviation Deviation { get; set; }
		public Harbor Harbor { get; set; }
		public StopType StopType { get; set; }
	}
}