namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents a serial connection.
	/// </summary>
	public interface ISerialConnection : IRealConnection
	{
		// TODO: Model serial single.
		// bool IsDedicatedConnection { get; } or make subclass?

		/// <summary>
		/// Gets or sets the port connection.
		/// </summary>
		/// <value>The port connection.</value>
		IPortConnection Connection { get; set; }

		/// <summary>
		/// Gets or sets the bus address.
		/// </summary>
		string BusAddress { get; set; }

		//bool IsSecure { get; set; }
	}
}
