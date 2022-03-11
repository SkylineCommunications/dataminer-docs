namespace Skyline.DataMiner.Library.Protocol.Rates
{
	/// <summary>
	/// Represents how the unit should be converted when calculating the rate.
	/// </summary>
	public enum DataConversionType
	{
		/// <summary>
		/// When calculating the rate, the result will be multiplied by eight to have bps as unit.
		/// </summary>
		OctetsToBits,

		/// <summary>
		/// When calculating the rate, the result will not be multiplied. Result will have as counter units per second. E.g. if counter represents packets then rate will be packets per second.
		/// </summary>
		NoConversion
	}
}
