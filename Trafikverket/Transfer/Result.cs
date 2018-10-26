using Newtonsoft.Json;
using Apparent.Trafikverket.Railroad;
using Apparent.Trafikverket.Road;

namespace Apparent.Trafikverket.Transfer
{
	public class Result
	{
		[JsonProperty("ERROR")]
		public Error Error { get; set; }

		[JsonProperty("INFO")]
		public Info Info { get; set; }

		public Situation[] Situation { get; set; }
		public TrainStation[] TrainStation { get; set; }
		public TrainMessage[] TrainMessage { get; set; }
		public TrainAnnouncement[] TrainAnnouncement { get; set; }
		public Icon[] Icon { get; set; }
		public RoadCondition[] RoadCondition { get; set; }
		public RoadConditionOverview[] RoadConditionOverview { get; set; }
		public WeatherStation[] WeatherStation { get; set; }
		public Camera[] Camera { get; set; }
		public Parking[] Parking { get; set; }
		public FerryAnnouncement[] FerryAnnouncement { get; set; }
		public FerryRoute[] FerryRoute { get; set; }
	}
}