namespace Apparent.Trafikverket.Data
{
	public class Route
	{
		public string Description { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Shortname { get; set; }
		public RouteType Type { get; set; }
	}
}