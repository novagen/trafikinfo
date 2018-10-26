namespace Apparent.Trafikverket.Data
{
	public class Harbor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SortOrder { get; set; }

		public StopType StopType { get; set; }
	}
}