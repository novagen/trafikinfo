using System;
using Trafikverket.Data;

namespace Trafikverket.Railroad
{
	public class TrainStation
	{
		public bool Advertised { get; set; }
		public string AdvertisedLocationName { get; set; }
		public string AdvertisedShortLocationName { get; set; }
		public string CountryCode { get; set; }
		public int[] CountyNo { get; set; }
		public bool Deleted { get; set; }
		public string LocationInformationText { get; set; }
		public string LocationSignature { get; set; }
		public DateTime ModifiedTime { get; set; }
		public string[] PlatformLine { get; set; }
		public bool Prognosticated { get; set; }
		public Geometry Geometry { get; set; }

		private string[] _tracks { get; set; }

		public string[] Tracks
		{
			get
			{
				if (_tracks == null)
				{
					var tracks = PlatformLine ?? new string[0];
					Array.Sort(tracks, new AlphanumComparator());

					_tracks = tracks;
				}

				return _tracks;
			}
		}
	}
}