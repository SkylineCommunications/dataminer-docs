namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents a UDP/IP connection.
	/// </summary>
	public interface IUdp : IIpBased
	{
		/// <summary>
		/// Gets or sets the local port number.
		/// </summary>
		/// <value>The local port number.</value>
		/// <remarks>Configuring the local port is only supported for <see cref="ISerialConnection"/> connections.</remarks>
		int? LocalPort { get; set; }

		/// <summary>
		/// Gets or set the remote port number.
		/// </summary>
		/// <value>The remote port number.</value>
		int? RemotePort { get; set; }

		/// <summary>
		/// Indicates if SSL/TLS is enabled on the connection.
		/// </summary>
		bool IsSslTlsEnabled { get; set; }

		/// <summary>
		/// Gets or sets if a dedicated connection is used.
		/// </summary>
		bool IsDedicated { get; }
	}
}