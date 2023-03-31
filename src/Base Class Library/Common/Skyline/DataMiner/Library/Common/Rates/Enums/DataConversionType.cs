namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Represents how the unit should be converted when calculating the rate.
	/// </summary>
	public enum DataConversionType
	{
		/// <summary>
		/// When the rate is calculated, the result will be multiplied by eight to have bps as unit.
		/// </summary>
		OctetsToBits,

		/// <summary>
		/// When the rate is calculated, the result will not be multiplied. The result will have units per second as counter. E.g. if counter represents packets, then rate will be packets per second.
		/// </summary>
		NoConversion,
	}
}
