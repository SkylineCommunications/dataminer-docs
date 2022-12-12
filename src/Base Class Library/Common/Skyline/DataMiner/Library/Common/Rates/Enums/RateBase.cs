namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Determines whether the rate should be calculated per second, minute, hour or day.
	/// </summary>
	public enum RateBase
	{
		/// <summary>Rates will be calculated per second.</summary>
		Second,

		/// <summary>Rates will be calculated per minute.</summary>
		Minute,

		/// <summary>Rates will be calculated per hour.</summary>
		Hour,

		/// <summary>Rates will be calculated per day.</summary>
		Day,
	}
}
