namespace Apparent.Trafikverket.Data
{
	public class Period
	{
		public string Name { get; set; }
		public int SortOrder { get; set; }
		public Schedule Schedule { get; set; }
		public WeekDay WeekDay { get; set; }
	}
}