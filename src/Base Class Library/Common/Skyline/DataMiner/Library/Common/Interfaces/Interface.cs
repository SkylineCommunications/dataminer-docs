namespace Skyline.DataMiner.Library.Common.Interfaces
{
	using System;

	/// <summary>
	/// Class containing code that relates to interfaces.
	/// </summary>
	public static class Interface
	{
		/// <summary>
		/// Calculates an interface utilization.
		/// </summary>
		/// <param name="inputRate">The input rate of the interface.<br/>
		/// The unit should be consistent between <paramref name="inputRate"/>, <paramref name="outputRate"/> and <paramref name="interfaceSpeed"/>.</param>
		/// <param name="outputRate">The output rate of the interface.<br/>
		/// The unit should be consistent between <paramref name="inputRate"/>, <paramref name="outputRate"/> and <paramref name="interfaceSpeed"/>.</param>
		/// <param name="interfaceSpeed">The speed of the interface (the max rate supported).<br/>
		/// The unit should be consistent between <paramref name="inputRate"/>, <paramref name="outputRate"/> and <paramref name="interfaceSpeed"/>.</param>
		/// <param name="duplexStatus">The current mode of operation of the MAC entity.</param>
		/// <returns>The interface utilization in percent.</returns>
		public static double CalculateUtilization(double inputRate, double outputRate, double interfaceSpeed, DuplexStatus duplexStatus)
		{
			if (inputRate < 0 || outputRate < 0 || interfaceSpeed <= 0)
			{
				return -1;
			}

			if (duplexStatus == DuplexStatus.HalfDuplex)
			{
				return (inputRate + outputRate) * 100 / interfaceSpeed;
			}

			if (duplexStatus == DuplexStatus.FullDuplex)
			{
				return Math.Max(inputRate, outputRate) * 100 / interfaceSpeed;
			}

			return -1;
		}

		/// <summary>
		/// Allows to detect discontinuity based on discontinuity times.
		/// </summary>
		/// <param name="currentDiscontinuityTime">Time of the most recent occasion at which some of this interface's counters suffered a discontinuity.</param>
		/// <param name="previousDiscontinuityTime">Time of the previous occasion at which some of this interface's counters suffered a discontinuity.</param>
		/// <returns></returns>
		public static bool HasDiscontinuity(string currentDiscontinuityTime, string previousDiscontinuityTime)
		{
			return !String.IsNullOrEmpty(previousDiscontinuityTime) && currentDiscontinuityTime != previousDiscontinuityTime;
		}
	}
}
