using System.ComponentModel;

namespace Trafikverket
{
	public enum ObjectType
	{
		[Description(nameof(TrainMessage))]
		TrainMessage,

		[Description(nameof(TrainStation))]
		TrainStation,

		[Description(nameof(TrainAnnouncement))]
		TrainAnnouncement,

		[Description(nameof(Camera))]
		Camera,

		[Description(nameof(FerryAnnouncement))]
		FerryAnnouncement,

		[Description(nameof(FerryRoute))]
		FerryRoute,

		[Description(nameof(Icon))]
		Icon,

		[Description(nameof(Parking))]
		Parking,

		[Description(nameof(RoadCondition))]
		RoadCondition,

		[Description(nameof(RoadConditionOverview))]
		RoadConditionOverview,

		[Description(nameof(Situation))]
		Situation,

		[Description(nameof(WeatherStation))]
		WeatherStation,

		[Description(nameof(Error))]
		Error
	}

	public enum OperatorGroup
	{
		[Description("AND")]
		And,

		[Description("OR")]
		Or,

		[Description("ELEMENTMATCH")]
		ElementMatch
	}

	public enum OperatorType
	{
		[Description("EQ")]
		Equals,

		[Description("EXISTS")]
		Exists,

		[Description("GT")]
		GreaterThan,

		[Description("GTE")]
		GreaterThanOrEqual,

		[Description("LT")]
		LessThan,

		[Description("LTE")]
		LessThanOrEqual,

		[Description("NE")]
		NotEqual,

		[Description("LIKE")]
		Like,

		[Description("NOTLIKE")]
		NotLike,

		[Description("IN")]
		In,

		[Description("NOTIN")]
		NotIn,

		[Description("WITHIN")]
		Within
	}

	public enum Shape
	{
		None,

		[Description("box")]
		Box,

		[Description("polygon")]
		Polygon,

		[Description("center")]
		Center
	}

	public enum County
	{
		[Description("Alla")]
		All = 0,

		[Description("Stockholm")]
		Stockholm = 1,

		[Description("Stockholm (DEPRECATED)")]
		Stockholm_DEPRECATED = 2,

		[Description("Uppsala län")]
		Uppsala = 3,

		[Description("Södermanland")]
		Sodermanland = 4,

		[Description("Östergötland")]
		Ostergotland = 5,

		[Description("Jönköping")]
		Jonkoping = 6,

		[Description("Kronoberg")]
		Kronoberg = 7,

		[Description("Kalmar")]
		Kalmar = 8,

		[Description("Gotland")]
		Gotland = 9,

		[Description("Blekinge")]
		Blekinge = 10,

		[Description("Skåne")]
		Skane = 12,

		[Description("Halland")]
		Halland = 13,

		[Description("Västra Götaland")]
		VastraGotaland = 14,

		[Description("Värmland")]
		Varmland = 17,

		[Description("Örebro")]
		Orebro = 18,

		[Description("Västmanland")]
		Vastmanland = 19,

		[Description("Dalarna")]
		Dalarna = 20,

		[Description("Gävleborg")]
		Gavleborg = 21,

		[Description("Västernorrland")]
		Vasternorrland = 22,

		[Description("Jämtland")]
		Jamtland = 23,

		[Description("Västerbotten")]
		Vasterbotten = 24,

		[Description("Norrbotten")]
		Norrbotten = 25
	}
}