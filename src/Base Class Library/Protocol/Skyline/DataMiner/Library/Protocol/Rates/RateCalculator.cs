namespace Skyline.DataMiner.Library.Protocol.Rates
{
	using Skyline.DataMiner.Scripting;
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// This class is used to load the parameter values into objects or set the object results back to the parameters.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	public class RateCalculator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RateCalculator"/> class. All used parameter IDs and column indexes are passed in this constructor.
		/// </summary>
		/// <param name="tablePid">Parameter ID of the table to interact with.</param>
		/// <param name="bufferedDeltaPid">Parameter ID where the buffered delta value can be found.</param>
		/// <param name="speedType">Indicates whether these are 32 bit counters (Low Speed) or 64 bit counters (High Speed) are used.</param>
		/// <param name="dataConversionType">Indicates if the rate calculation should be multiplied with eight (OctetsToBits) or not (NoConversion).</param>
		/// <param name="inputColumns">Collection with all used input parameter columns.</param>
		/// <param name="outputColumns">Collection with all used output parameter columns.</param>
		public RateCalculator(int tablePid, int bufferedDeltaPid, SpeedType speedType, DataConversionType dataConversionType, ValuesToRatesColumns inputColumns, ValuesToRatesColumns outputColumns)
		{
		}

		/// <summary>
		/// Gets a boolean indicating if the SNMP Agent of the device has been restarted since the previous poll cycle. The value is only valid if the CurrentSysUptimePid and PreviousSysUptimePid have been filled in and CalculateAndSetTable method has been executed.
		/// </summary>
		public bool IsAgentRestarted
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets or sets the parameter information of the utilization column.
		/// </summary>
		public UtilizationColumns Utilization
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the parameter information of the discontinuity time column.
		/// </summary>
		public ValueColumns Discontinuity
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the parameter ID of the polled SysUptime.
		/// </summary>
		public uint CurrentSysUptimePid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the parameter ID where the previous SysUptime value is stored.
		/// </summary>
		public uint PreviousSysUptimePid
		{
			get;
			set;
		}

		/// <summary>
		/// This method gets called when a timeout occurred.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol.</param>
		/// <param name="pidBufferedDelta">Parameter ID of the BufferedDelta.</param>
		/// <param name="groupId">The ID of the SNMP group.</param>
		public static void TimeoutOrError(SLProtocol protocol, int pidBufferedDelta, int groupId)
		{
			TimeSpan? lastDelta = GetSnmpGroupExecutionDelta(protocol, groupId);
			if (lastDelta != null)
			{
				double lastDeltaInMs = lastDelta.Value.TotalMilliseconds;

				double bufferedDelta = Convert.ToDouble(protocol.GetParameter(pidBufferedDelta));
				double totalDelta = bufferedDelta + lastDeltaInMs;

				protocol.SetParameter(pidBufferedDelta, totalDelta);
			}
		}

		/// <summary>
		/// Retrieves the delta between two consecutive executions of the specified SNMP group.
		/// </summary>
		/// <param name="protocol">SLProtocol instance.</param>
		/// <param name="groupId">The ID of the SNMP group.</param>
		/// <exception cref="ArgumentException">The group ID is negative.</exception>
		/// <returns>The delta between two consecutive executions of the group.</returns>
		public static TimeSpan? GetSnmpGroupExecutionDelta(SLProtocol protocol, int groupId)
		{
			if (groupId < 0)
			{
				throw new ArgumentException("The group ID must not be negative.", "groupId");
			}

			int result = Convert.ToInt32(protocol.NotifyProtocol(269 /*NT_GET_BITRATE_DELTA*/, groupId, null));

			if (result != -1)
			{
				return TimeSpan.FromMilliseconds(result);
			}

			return null;
		}

		/// <summary>
		/// This method will read out the current table values, perform the calculations, and sets the result in the table.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol.</param>
		/// <param name="delta">Time span between this and previous executed poll group.</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms).</param>
		public void CalculateAndSetTable(SLProtocol protocol, TimeSpan? delta, int minDelta)
		{
		}
	}
}