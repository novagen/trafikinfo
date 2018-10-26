namespace Apparent.Trafikverket.Data
{
	public class Timetable
	{
		public int Priority { get; set; }
		public string Description { get; set; }
		public Period Period { get; set; }
		public Valid Valid { get; set; }
	}
}