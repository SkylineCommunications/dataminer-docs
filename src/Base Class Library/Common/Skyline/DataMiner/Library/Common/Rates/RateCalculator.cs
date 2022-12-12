namespace Skyline.DataMiner.Library.Common.Rates
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.Library.Common.Interfaces;

	/// <summary>
	/// Generic class that gathers the basic methods to calculate rates and utilization.
	/// </summary>
	public static class RateCalculator
	{
		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the previous rate is used.</param>
		/// <param name="interfaceRate">Object that contains the interface counter values.</param>
		public static void CalculateRate(double delta, int minDelta, InterfaceRate interfaceRate)
		{
			if (interfaceRate.GetType() == typeof(InterfaceRate32BitCounters))
			{
				InterfaceRate32BitCounters counterValues = (InterfaceRate32BitCounters)interfaceRate;
				interfaceRate.NewRate = CalculateRate(delta, minDelta, counterValues.PreviousRate, counterValues.CurrentCounter, counterValues.PreviousCounter, counterValues.DataConversionType);
			}
			else if (interfaceRate.GetType() == typeof(InterfaceRate64BitCounters))
			{
				InterfaceRate64BitCounters counterValues = (InterfaceRate64BitCounters)interfaceRate;
				interfaceRate.NewRate = CalculateRate(delta, minDelta, counterValues.PreviousRate, counterValues.CurrentCounter, counterValues.PreviousCounter, counterValues.DataConversionType);
			}
			else
			{
				interfaceRate.NewRate = -1;
			}
		}

		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the previous rate is used.</param>
		/// <param name="interfaceRates">Collection that contains all the interfaces.</param>
		public static void CalculateRate(double delta, int minDelta, IEnumerable<InterfaceRate> interfaceRates)
		{
			foreach (InterfaceRate interfaceRate in interfaceRates)
			{
				CalculateRate(delta, minDelta, interfaceRate);
			}
		}

		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the previous rate is used.</param>
		/// <param name="previousRates">Array with the previous rate values.</param>
		/// <param name="currentCounters">Array with the current counter values.</param>
		/// <param name="previousCounters">Array with the previous counter values.</param>
		/// <param name="dataConversionType">Indicates the conversion to be executed on the counters.</param>
		/// <exception cref="ArgumentException"><paramref name="minDelta" /> is not larger than zero.</exception>
		/// <returns>Array with the rates in units per second. Unit depends on provided arguments, e.g. when values are in octets and <paramref name="dataConversionType"/> is OctetsToBits, the returned rate is bps.</returns>
		public static double[] CalculateRate(double delta, int minDelta, double[] previousRates, uint[] currentCounters, uint[] previousCounters, DataConversionType dataConversionType)
		{
			return CalculateRate<uint>(delta, minDelta, previousRates, currentCounters, previousCounters, dataConversionType);
		}

		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the previous rate is used.</param>
		/// <param name="previousRates">Array with the previous rate values.</param>
		/// <param name="currentCounters">Array with the current counter values.</param>
		/// <param name="previousCounters">Array with the previous counter values.</param>
		/// <param name="dataConversionType">Indicates the conversion to be executed on the counters.</param>
		/// <exception cref="ArgumentException"><paramref name="minDelta" /> is not larger than zero.</exception>
		/// <returns>Array with the rates in units per second. Unit depends on provided arguments, e.g. when values are in octets and <paramref name="dataConversionType"/> is OctetsToBits, the returned rate is bps.</returns>
		public static double[] CalculateRate(double delta, int minDelta, double[] previousRates, ulong[] currentCounters, ulong[] previousCounters, DataConversionType dataConversionType)
		{
			return CalculateRate<ulong>(delta, minDelta, previousRates, currentCounters, previousCounters, dataConversionType);
		}

		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the <paramref name="previousRate"/> is returned.</param>
		/// <param name="previousRate">The previous rate value.</param>
		/// <param name="currentCounter">The current counter value.</param>
		/// <param name="previousCounter">The previous counter value.</param>
		/// <param name="dataConversionType">Indicates the conversion to be executed on the counters.</param>
		/// <exception cref="ArgumentException"><paramref name="minDelta" /> is not larger than zero.</exception>
		/// <returns>Array with the rates in units per second. Unit depends on provided arguments, e.g. when values are in octets and <paramref name="dataConversionType"/> is OctetsToBits, the returned rate is bps.</returns>
		public static double CalculateRate(double delta, int minDelta, double previousRate, uint currentCounter, uint previousCounter, DataConversionType dataConversionType)
		{
			if (minDelta <= 0)
			{
				throw new ArgumentException("The specified minimum delta must be larger than zero.");
			}

			if (delta < minDelta)
			{
				return previousRate;
			}

			uint difference;
			unchecked
			{
				difference = currentCounter - previousCounter;
			}

			// Multiply by 1000 to convert from ms to s.
			double result = (difference / delta) * 1000;

			// Multiply by 8 to convert from octets to bits.
			if (dataConversionType == DataConversionType.OctetsToBits)
			{
				result = result * 8;
			}

			return result;
		}

		/// <summary>
		/// Calculates the rate in units per second.
		/// </summary>
		/// <param name="delta">Time interval between two consecutive group executions (in ms).</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms). If <paramref name="delta" /> is smaller than this value, the <paramref name="previousRate"/> is returned.</param>
		/// <param name="previousRate">The previous rate value.</param>
		/// <param name="currentCounter">The current counter value.</param>
		/// <param name="previousCounter">The previous counter value.</param>
		/// <param name="dataConversionType">Indicates the conversion to be executed on the counters.</param>
		/// <exception cref="ArgumentException"><paramref name="minDelta" /> is not larger than zero.</exception>
		/// <returns>Array with the rates in units per second. Unit depends on provided arguments, e.g. when values are in octets and <paramref name="dataConversionType"/> is OctetsToBits, the returned rate is bps.</returns>
		public static double CalculateRate(double delta, int minDelta, double previousRate, ulong currentCounter, ulong previousCounter, DataConversionType dataConversionType)
		{
			if (minDelta <= 0)
			{
				throw new ArgumentException("The specified minimum delta must be larger than zero.");
			}

			if (delta < minDelta)
			{
				return previousRate;
			}

			ulong difference;
			unchecked
			{
				difference = currentCounter - previousCounter;
			}

			// Multiply by 1000 to convert from ms to s.
			double result = (difference / delta) * 1000;

			// Multiply by 8 to convert from octets to bits.
			if (dataConversionType == DataConversionType.OctetsToBits)
			{
				result = result * 8;
			}

			return result;
		}

		/// <summary>
		/// Call this method to calculate the rates on the interfaces. SNMP agent restarts of the device and discontinuity times are not taken into account.
		/// </summary>
		/// <param name="interfaceTable">Object that represents the table with the interface data.</param>
		public static void CalculateRate(InterfaceTable interfaceTable)
		{
			if (interfaceTable.Delta == null)
			{
				foreach (InterfaceRow interfaceDataItem in interfaceTable.InterfaceRows)
				{
					interfaceDataItem.InputBitRate.NewRate = -1;
					interfaceDataItem.OutputBitRate.NewRate = -1;
				}

				return;
			}

			double totalDeltaInMs = interfaceTable.Delta.Value.TotalMilliseconds + interfaceTable.BufferedDeltaValue;
			foreach (InterfaceRow interfaceDataItem in interfaceTable.InterfaceRows)
			{
				CalculateRate(totalDeltaInMs, interfaceTable.MinDelta, interfaceDataItem.InputBitRate);
				CalculateRate(totalDeltaInMs, interfaceTable.MinDelta, interfaceDataItem.OutputBitRate);
			}
		}

		/// <summary>
		/// Call this method to calculate the rates on the interfaces.
		/// </summary>
		/// <param name="interfaceTable">Object that represents the table with the interface data.</param>
		/// <param name="isAgentRestarted">True indicates that the SNMP agent of the device was restarted.</param>
		/// <param name="discontinuityTimes">Collection that contains the primary keys of all interfaces that have discontinuity times.</param>
		public static void CalculateRate(InterfaceTable interfaceTable, bool isAgentRestarted, ICollection<string> discontinuityTimes)
		{
			if (interfaceTable.Delta == null || isAgentRestarted)
			{
				foreach (InterfaceRow interfaceDataItem in interfaceTable.InterfaceRows)
				{
					interfaceDataItem.InputBitRate.NewRate = -1;
					interfaceDataItem.OutputBitRate.NewRate = -1;
				}

				return;
			}

			double totalDeltaInMs = interfaceTable.Delta.Value.TotalMilliseconds + interfaceTable.BufferedDeltaValue;
			foreach (InterfaceRow interfaceDataItem in interfaceTable.InterfaceRows)
			{
				if (discontinuityTimes.Contains(interfaceDataItem.Key))
				{
					interfaceDataItem.InputBitRate.NewRate = -2;
					interfaceDataItem.OutputBitRate.NewRate = -2;
					continue;
				}

				CalculateRate(totalDeltaInMs, interfaceTable.MinDelta, interfaceDataItem.InputBitRate);
				CalculateRate(totalDeltaInMs, interfaceTable.MinDelta, interfaceDataItem.OutputBitRate);
			}
		}

		/// <summary>
		/// Calculates the utilization in percent.
		/// </summary>
		/// <param name="interfaceDataItems">Collection that contains all the interfaces.</param>
		public static void CalculateUtilization(IEnumerable<InterfaceRow> interfaceDataItems)
		{
			foreach (InterfaceRow interfaceDataItem in interfaceDataItems)
			{
				CalculateUtilization(interfaceDataItem);
			}
		}

		/// <summary>
		/// Calculates the utilization in percent.
		/// </summary>
		/// <param name="interfaceDataItem">Object that contains the rate values.</param>
		public static void CalculateUtilization(InterfaceRow interfaceDataItem)
		{
			interfaceDataItem.NewUtilization = CalculateUtilization(interfaceDataItem.InputBitRate.NewRate, interfaceDataItem.OutputBitRate.NewRate, interfaceDataItem.InterfaceSpeed, interfaceDataItem.DuplexStatus);
		}

		/// <summary>
		/// Calculates the utilization in percent. InputRates, outputRates, and interfaceSpeeds need to have the same unit.
		/// </summary>
		/// <param name="inputRates">Collection that contains the input rates.</param>
		/// <param name="outputRates">Collection that contains the output rates.</param>
		/// <param name="interfaceSpeeds">Collection that contains the speed of the interfaces.</param>
		/// <param name="duplexStatuses">Collection that indicates if the interface is half or full duplex.</param>
		/// <returns>The utilization in percent.</returns>
		public static double[] CalculateUtilization(double[] inputRates, double[] outputRates, double[] interfaceSpeeds, DuplexStatus[] duplexStatuses)
		{
			if (inputRates == null || outputRates == null || interfaceSpeeds == null || duplexStatuses == null)
			{
				throw new ArgumentException("The passed utilization arrays cannot be null.");
			}

			if (inputRates.Length != outputRates.Length || inputRates.Length != interfaceSpeeds.Length || inputRates.Length != duplexStatuses.Length)
			{
				throw new ArgumentException("The size of all utilization arrays needs to be the same.");
			}

			double[] result = new double[inputRates.Length];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = CalculateUtilization(inputRates[i], outputRates[i], interfaceSpeeds[i], duplexStatuses[i]);
			}

			return result;
		}

		/// <summary>
		/// Calculates the utilization in percent. <paramref name="inputRate"/>, <paramref name="outputRate"/>, and <paramref name="interfaceSpeed"/> need to have the same unit.
		/// </summary>
		/// <param name="inputRate">The input rate.</param>
		/// <param name="outputRate">The output rate.</param>
		/// <param name="interfaceSpeed">The speed of the interface.</param>
		/// <param name="duplexStatus">Indicates if the interface is half or full duplex.</param>
		/// <returns>The utilization in percent.</returns>
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
		/// Call this method to calculate the utilizations of the interfaces.
		/// </summary>
		/// <param name="interfaceTable">Object that represents the table with the interface data.</param>
		public static void CalculateUtilization(InterfaceTable interfaceTable)
		{
			if (interfaceTable.Delta == null)
			{
				return;
			}

			double totalDeltaInMs = interfaceTable.Delta.Value.TotalMilliseconds + interfaceTable.BufferedDeltaValue;
			if (totalDeltaInMs < interfaceTable.MinDelta)
			{
				// Delta is smaller than minimum delta, use previous value.
				foreach (InterfaceRow interfaceDataItem in interfaceTable.InterfaceRows)
				{
					interfaceDataItem.NewUtilization = interfaceDataItem.PreviousUtilization;
				}
			}
			else
			{
				CalculateUtilization(interfaceTable.InterfaceRows);
			}
		}

		private static double[] CalculateRate<T>(double delta, int minDelta, double[] previousRates, T[] currentCounters, T[] previousCounters, DataConversionType dataConversionType) where T : IConvertible
		{
			if (previousRates == null || currentCounters == null || previousCounters == null)
			{
				throw new ArgumentException("The passed rate arrays cannot be null.");
			}

			if (previousRates.Length != currentCounters.Length || previousRates.Length != previousCounters.Length)
			{
				throw new ArgumentException("The size of all rate arrays needs to be the same.");
			}

			double[] result = new double[previousRates.Length];
			for (int i = 0; i < result.Length; i++)
			{

				if (typeof(T) == typeof(uint))
				{
					result[i] = CalculateRate(delta, minDelta, previousRates[i], Convert.ToUInt32(currentCounters[i]), Convert.ToUInt32(previousCounters[i]), dataConversionType);
				}
				else
				{
					result[i] = CalculateRate(delta, minDelta, previousRates[i], Convert.ToUInt64(currentCounters[i]), Convert.ToUInt64(previousCounters[i]), dataConversionType);
				}
			}

			return result;
		}
	}
}