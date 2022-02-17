namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Represents the duplex status of the interface. This is needed to calculate the utilization.
	/// </summary>
	public enum DuplexStatus
	{
		/// <summary>
		/// The duplex status is not known yet. Calculating the utilization will not be possible.
		/// </summary>
		NotInitialized = 0,

		/// <summary>
		/// The duplex status is a value that is neither half duplex nor full duplex. Calculating the utilization will not be possible.
		/// </summary>
		Unknown = 1,

		/// <summary>
		/// The duplex status is half duplex. Calculating the utilization will be based on the sum of the input rate and output rate.
		/// </summary>
		HalfDuplex = 2,

		/// <summary>
		/// The duplex status is full duplex. Calculating the utilization will be based on the rate that is the highest: input or output rate.
		/// </summary>
		FullDuplex = 3
	}
}
