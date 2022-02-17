namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies the time format.
	/// </summary>
	public enum DateTimeFormat
	{
		/// <summary>
		/// Full date time.
		/// </summary>
		FullDateTime,
		/// <summary>
		/// Long date.
		/// </summary>
		LongDate,
		/// <summary>
		/// Long time.
		/// </summary>
		LongTime,
		/// <summary>
		/// Short date.
		/// </summary>
		ShortDate,
		/// <summary>
		/// Short time.
		/// </summary>
		ShortTime,
		/// <summary>
		/// Sortable date time.
		/// </summary>
		SortableDateTime,
		/// <summary>
		/// Universal sortable date time.
		/// </summary>
		UniversalSortableDateTime,
		/// <summary>
		/// Month day.
		/// </summary>
		MonthDay,
		/// <summary>
		/// Year month.
		/// </summary>
		YearMonth,
		/// <summary>
		/// RFC 1123.
		/// </summary>
		RFC1123,
		/// <summary>
		/// Custom.
		/// </summary>
		Custom,
	}
}
