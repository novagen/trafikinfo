using System;
using System.ComponentModel;
using Apparent.Trafikverket.Data;
using Apparent.Trafikverket.Util;

namespace Apparent.Trafikverket.Road
{
	public class Camera
	{
		public bool Active { get; set; }
		public string CameraGroup { get; set; }
		public string ContentType { get; set; }
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public string Description { get; set; }
		public int Direction { get; set; }
		public Geometry Geometry { get; set; }
		public bool HasFullSizePhoto { get; set; }
		public bool HasSketchImage { get; set; }
		public string IconId { get; set; }
		public string Id { get; set; }
		public string Location { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public DateTime PhotoTime { get; set; }
		public string PhotoUrl { get; set; }
		public string Status { get; set; }

		public enum PhotoType
		{
			Standard,

			[Description("fullsize")]
			Fullsize,

			[Description("sketch")]
			Sketch,

			[Description("thumbnail")]
			Thumbnail
		}

		public string GetPhotoUrl(PhotoType photoType = PhotoType.Standard, int maxAge = 0)
		{
			var age = "";
			var type = "";

			if (maxAge > 0)
			{
				age = $" maxage={maxAge}";
			}

			if (photoType != PhotoType.Standard)
			{
				type = $" type={photoType.GetEnumDescription()}";
			}

			return PhotoUrl + age;
		}
	}
}