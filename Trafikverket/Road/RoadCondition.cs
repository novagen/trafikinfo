using System;
using System.ComponentModel;
using Trafikverket.Data;

namespace Trafikverket.Road
{
	public class RoadCondition
	{
		public string Id { get; set; }
		public string IconId { get; set; }
		public Geometry Geometry { get; set; }
		public DateTime ModifiedTime { get; set; }
		public int ConditionCode { get; set; }
		public string[] Cause { get; set; }
		public string[] ConditionInfo { get; set; }
		public string ConditionText { get; set; }
		public int[] CountyNo { get; set; }
		public string Creator { get; set; }
		public bool Deleted { get; set; }
		public string LocationText { get; set; }
		public string RoadNumber { get; set; }
		public int RoadNumberNumeric { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string[] Measurement { get; set; }
		public bool SafetyRelatedMessage { get; set; }
		public string[] Warning { get; set; }

		public enum ConditionCodeType
		{
			[Description("normalt")]
			Normal,

			[Description("besvärligt (risk för)")]
			Difficult,

			[Description("mycket besvärligt")]
			VeryDifficult,

			[Description("is- och snövägbana")]
			IceAndSnow
		}
	}
}