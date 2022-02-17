namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents an HTTP Connection
	/// </summary>
	public interface IHttpConnection : IRealConnection
	{
		/// <summary>
		/// Gets or sets the TCP connection configuration.
		/// </summary>
		/// <value>The TCP connection configuration.</value>
		ITcp TcpConfiguration { get; set; }

		/// <summary>
		/// Gets the bus address.
		/// </summary>
		/// <value>The buss address.</value>
		string BusAddress { get;}

		/// <summary>
		/// Gets a value indicating whether to bypass the proxy.
		/// </summary>
		/// <value><c>true</c> if the proxy needs to be bypassed; otherwise, <c>false</c>.</value>
		bool IsBypassProxyEnabled { get; set; }
	}
}
