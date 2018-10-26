using System;
using Apparent.Trafikverket.Data;

namespace Apparent.Trafikverket.Road
{
	public class Parking
	{
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public string Description { get; set; }
		public string DistanceToNearestCity { get; set; }
		public string IconId { get; set; }
		public string Id { get; set; }
		public string LocationDescription { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Name { get; set; }
		public string OpenStatus { get; set; }
		public string OperationStatus { get; set; }
		public string[] UsageSenario { get; set; }
		public AccessibilityInfo Equipment { get; set; }
		public AccessibilityInfo Facility { get; set; }
		public Geometry Geometry { get; set; }
		public Operator Operator { get; set; }
		public Geometry ParkingAccess { get; set; }
		public Photo Photo { get; set; }
		public TariffsAndPayment TariffsAndPayment { get; set; }
		public VehicleCharacteristics VehicleCharacteristics { get; set; }
	}
}