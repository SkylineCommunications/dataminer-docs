namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Inherited class of the InterfaceRate that contains the 32-bit counter values.
	/// </summary>
	public class InterfaceRate32BitCounters : InterfaceRate
	{
		private readonly uint currentCounter;
		private readonly uint previousCounter;

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceRate32BitCounters"/> class.
		/// </summary>
		/// <param name="key">Key of the interface.</param>
		/// <param name="dataConversionType">The type of conversion that needs to be executed on the counters when calculating the rate.</param>
		/// <param name="currentCounter">Current value of the counter.</param>
		/// <param name="previousCounter">Previous value of the counter.</param>
		/// <param name="previousRate">Value of the previous rate.</param>
		public InterfaceRate32BitCounters(string key, DataConversionType dataConversionType, uint currentCounter, uint previousCounter, double previousRate) : base(key, dataConversionType, previousRate)
		{
			this.currentCounter = currentCounter;
			this.previousCounter = previousCounter;
		}

		/// <summary>
		/// Gets the current value of the counter.
		/// </summary>
		public uint CurrentCounter
		{
			get
			{
				return currentCounter;
			}
		}

		/// <summary>
		/// Gets the previous value of the counter.
		/// </summary>
		public uint PreviousCounter
		{
			get
			{
				return previousCounter;
			}
		}
	}
}
