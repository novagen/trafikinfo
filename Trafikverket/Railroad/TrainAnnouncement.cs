using System;
using Trafikverket.Data;

namespace Trafikverket.Railroad
{
	public class TrainAnnouncement
	{
		public string ActivityId { get; set; }
		public string ActivityType { get; set; }
		public bool Advertised { get; set; }
		public DateTime AdvertisedTimeAtLocation { get; set; }
		public string AdvertisedTrainIdent { get; set; }
		public string[] Booking { get; set; }
		public bool Canceled { get; set; }
		public bool Deleted { get; set; }
		public string[] Deviation { get; set; }
		public DateTime EstimatedTimeAtLocation { get; set; }
		public bool EstimatedTimeIsPreliminary { get; set; }
		public Location[] FromLocation { get; set; }
		public string InformationOwner { get; set; }
		public string LocationSignature { get; set; }
		public string MobileWebLink { get; set; }
		public DateTime ModifiedTime { get; set; }
		public int NewEquipment { get; set; }
		public string[] OtherInformation { get; set; }
		public DateTime PlannedEstimatedTimeAtLocation { get; set; }
		public bool PlannedEstimatedTimeAtLocationIsValid { get; set; }
		public string[] ProductInformation { get; set; }
		public DateTime ScheduledDepartureDateTime { get; set; }
		public string[] Service { get; set; }
		public string TechnicalTrainIdent { get; set; }
		public DateTime TimeAtLocation { get; set; }
		public Location[] ToLocation { get; set; }
		public string TrackAtLocation { get; set; }
		public string[] TrainComposition { get; set; }
		public string TypeOfTraffic { get; set; }
		public string WebLink { get; set; }
		public string WebLinkName { get; set; }
		public Location[] ViaFromLocation { get; set; }
		public Location[] ViaToLocation { get; set; }
	}
}