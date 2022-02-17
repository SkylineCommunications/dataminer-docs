namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Represents the state of the crosspoint.
	/// </summary>
	public enum MatrixCrossPointConnectionState
	{
		/// <summary>
		/// The output port is connected with the input port.
		/// </summary>
		Connected,

		/// <summary>
		/// The output port is not connected with the input port.
		/// </summary>
		Disconnected
	}
}
