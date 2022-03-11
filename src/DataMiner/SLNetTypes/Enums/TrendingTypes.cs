using System;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Defines about which timespan a GetAnalogTrendDataMessage needs to return info.
	/// </summary>
	public enum TrendingSpanType
	{
        /// <summary>
        /// Last hour (end time = current time)
        /// </summary>
		LastHour,

        /// <summary>
        /// Last day (end time = current time)
        /// </summary>
		LastDay,

        /// <summary>
        /// Last week (end time = current time)
        /// </summary>
		LastWeek,

        /// <summary>
        /// Last month (end time = current time)
        /// </summary>
		LastMonth,

        /// <summary>
        /// Last year (end time = current time)
        /// </summary>
		LastYear,

		/// <summary>
		/// A custom amount of hours (end time = current time). Specify the amount of hours in GetAnalogTrendDataMessage.CustomAmountHours.
		/// </summary>
		CustomAmountHours,

        /// <summary>
        /// Fully custom trending timespan
        /// </summary>
        Custom
	}

	/// <summary>
	/// Defines which type of data a GetAnalogTrendDataMessage needs to return.
	/// </summary>
	public enum TrendingType
	{
		/// <summary>
		/// Average trending data (min / max / average).
		/// </summary>
		Average,

		/// <summary>
		/// Real-time trending data.
		/// </summary>
		Realtime,

        /// <summary>
        /// Select automatically depending on the requested time interval.
        /// </summary>
        Auto
	}

    /// <summary>
    /// Defines which interval should be retrieved.
    /// </summary>
    public enum AverageTrendIntervalType
    { 
        /// <summary>
        /// Auto: Default value.
        /// </summary>
        Auto,

        /// <summary>
        /// 5 min trending (or what is specified in the settings).
        /// </summary>
        FiveMin,

        /// <summary>
        /// Hourly trending (or what is specified in the settings).
        /// </summary>
        OneHour,

        /// <summary>
        /// Daily trending (or what is specified in the settings).
        /// </summary>
        OneDay
    }

    /// <summary>
    /// Defines whether data should be filled with each record (new way 7.5.0+) or data should come as it is but with gaps returned
    /// </summary>
    [Flags]
    public enum TrendOptions
    {
        /// <summary>
        /// None: Default value.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Trend data should not be filled up.
        /// </summary>
        NoFill = 0x0001,

        /// <summary>
        /// Trend data should not be processed.
        /// </summary>
        Raw = 0x0002
    }

}
