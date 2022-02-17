using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies the mail report parameter flags.
	/// </summary>
	[Flags]
	public enum MailReportParameterFlags
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,
		/// <summary>
		/// Include average value.
		/// </summary>
		IncludeAvg = 1,
		/// <summary>
		/// Include minimum value.
		/// </summary>
		IncludeMin = 2,
		/// <summary>
		/// Include maximum value.
		/// </summary>
		IncludeMax = 4,
		/// <summary>
		/// Include average, minimum and maximum value.
		/// </summary>
		IncludeMinMaxAvg = 7,
		/// <summary>
		/// Include real-time, minimum and maximum value.
		/// </summary>
		IncludeRTNextToMinMax = 8,
	}
}