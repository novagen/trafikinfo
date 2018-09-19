using System;
using System.ComponentModel;

namespace Trafikverket.Data
{
	public class Deviation
	{
		public int[] CountyNo { get; set; }
		public string Creator { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime EndTime { get; set; }
		public Geometry Geometry { get; set; }
		public string IconId { get; set; }
		public string Id { get; set; }
		public bool ManagedCause { get; set; }
		public string Message { get; set; }
		public string MessageCode { get; set; }
		public string MessageType { get; set; }
		public int NumberOfLanesRestricted { get; set; }
		public int SeverityCode { get; set; }
		public string SeverityText { get; set; }
		public DateTime StartTime { get; set; }
		public string LocationDescriptor { get; set; }
		public string TrafficRestrictionType { get; set; }
		public string RoadNumber { get; set; }
		public int RoadNumberNumeric { get; set; }

		public enum MessageCodeType
		{
			[Description("Viktig trafikinformation")]
			ImportantInformation,

			[Description("Färjor")]
			Ferry,

			[Description("Hinder")]
			Obstacle,

			[Description("Olycka")]
			Accident,

			[Description("Restriktion")]
			Restriction,

			[Description("Trafikmeddelande")]
			TrafficMessage,

			[Description("Vägarbete")]
			Roadwork
		}

		public enum SeverityCodeType
		{
			[Description("Ingen påverkan")]
			None = 1,

			[Description("Liten påverkan")]
			Small = 2,

			[Description("Stor påverkan")]
			Large = 3,

			[Description("Mycket stor påverkan")]
			Major = 4
		}
	}
}