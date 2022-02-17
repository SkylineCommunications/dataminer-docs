namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Class that contains the values needed to calculate the rate of an interface.
	/// </summary>
	public class InterfaceRate
	{
		private readonly string key;
		private readonly DataConversionType dataConversionType;
		private readonly double previousRate;

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceRate"/> class.
		/// </summary>
		/// <param name="key">Key of the interface.</param>
		/// <param name="dataConversionType">The type of conversion that needs to be executed on the counters when calculating the rate.</param>
		/// <param name="previousRate">Value of the previous rate.</param>
		internal InterfaceRate(string key, DataConversionType dataConversionType, double previousRate)
		{
			this.key = key;
			this.dataConversionType = dataConversionType;
			this.previousRate = previousRate;
			NewRate = -1;
		}

		/// <summary>
		/// Gets the key of the interface.
		/// </summary>
		public string Key
		{
			get
			{
				return key;
			}
		}

		/// <summary>
		/// Gets the previous rate value.
		/// </summary>
		public double PreviousRate
		{
			get
			{
				return previousRate;
			}
		}

		/// <summary>
		/// Gets or sets the new calculated rate value.
		/// </summary>
		public double NewRate
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the data conversion type.
		/// </summary>
		public DataConversionType DataConversionType
		{
			get
			{
				return dataConversionType;
			}
		}
	}
}
