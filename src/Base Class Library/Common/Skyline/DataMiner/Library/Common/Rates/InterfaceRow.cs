namespace Skyline.DataMiner.Library.Common.Rates
{
	/// <summary>
	/// Class that contains the data of one interface. This can be seen as an object that contains the data of one row in a table.
	/// </summary>
	public class InterfaceRow
	{
		private readonly string key;
		private readonly InterfaceRate inputBitRate;
		private readonly InterfaceRate outputBitRate;
		private readonly double previousUtilization;
		private readonly double interfaceSpeed;
		private readonly DuplexStatus duplexStatus;

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceRow"/> class.
		/// </summary>
		/// <param name="key">Key of the interface.</param>
		/// <param name="inputBitRate">Object that contains the input values of the interface.</param>
		/// <param name="outputBitRate">Object that contains the output values of the interface.</param>
		/// <param name="previousUtilization">Previous utilization value of the interface.</param>
		/// <param name="interfaceSpeed">Speed of the interface.</param>
		/// <param name="duplexStatus">Duplex status of the interface.</param>
		public InterfaceRow(string key, InterfaceRate inputBitRate, InterfaceRate outputBitRate, double previousUtilization, double interfaceSpeed, DuplexStatus duplexStatus)
		{
			this.key = key;
			this.inputBitRate = inputBitRate;
			this.outputBitRate = outputBitRate;
			this.previousUtilization = previousUtilization;
			this.interfaceSpeed = interfaceSpeed;
			this.duplexStatus = duplexStatus;
			NewUtilization = -1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceRow"/> class. This can only be used to calculate utilizations.
		/// </summary>
		/// <param name="key">Key of the interface.</param>
		/// <param name="inputBitRate">The current input bit rate.</param>
		/// <param name="outputBitRate">The current output bit rate.</param>
		/// <param name="interfaceSpeed">Speed of the interface.</param>
		/// <param name="duplexStatus">Duplex status of the interface.</param>
		public InterfaceRow(string key, double inputBitRate, double outputBitRate, double interfaceSpeed, DuplexStatus duplexStatus)
		{
			this.key = key;
			this.inputBitRate = new InterfaceRate(key, DataConversionType.NoConversion, inputBitRate);
			this.inputBitRate.NewRate = inputBitRate;
			this.outputBitRate = new InterfaceRate(key, DataConversionType.NoConversion, outputBitRate);
			this.outputBitRate.NewRate = outputBitRate;
			this.previousUtilization = 0;
			this.interfaceSpeed = interfaceSpeed;
			this.duplexStatus = duplexStatus;
			NewUtilization = -1;
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
		/// Gets the object that contains the input values of the interface.
		/// </summary>
		public InterfaceRate InputBitRate
		{
			get
			{
				return inputBitRate;
			}
		}

		/// <summary>
		/// Gets the object that contains the output values of the interface.
		/// </summary>
		public InterfaceRate OutputBitRate
		{
			get
			{
				return outputBitRate;
			}
		}

		/// <summary>
		/// Gets the previous utilization value of the interface.
		/// </summary>
		public double PreviousUtilization
		{
			get
			{
				return previousUtilization;
			}
		}

		/// <summary>
		/// Gets or sets the new calculated utilization value of the interface.
		/// </summary>
		public double NewUtilization
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the speed of the interface.
		/// </summary>
		public double InterfaceSpeed
		{
			get
			{
				return System.Convert.ToDouble(interfaceSpeed);
			}
		}

		/// <summary>
		/// Gets the duplex status of the interface.
		/// </summary>
		public DuplexStatus DuplexStatus
		{
			get
			{
				return duplexStatus;
			}
		}
	}
}
