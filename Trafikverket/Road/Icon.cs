using System;
using System.ComponentModel;
using Trafikverket.Util;

namespace Trafikverket.Road
{
	public class Icon
	{
		public bool Deleted { get; set; }
		public string Description { get; set; }
		public string Id { get; set; }
		public string Url { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string Base64 { get; set; }

		public enum IconType
		{
			Standard,

			[Description("svg")]
			Svg,

			[Description("png16x16")]
			Png16,

			[Description("png32x32")]
			Png32
		}

		public string GetUrl(IconType iconType = IconType.Standard)
		{
			var type = "";

			if (iconType != IconType.Standard)
			{
				type = $"type={iconType.GetEnumDescription()}";
			}

			return Url + type;
		}
	}
}