namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents a WebSocket connection.
	/// </summary>
	interface IWebSocketConnection : IRealConnection
	{
		/// <summary>
		/// Gets or sets the underlying connection.
		/// </summary>
		ITcp Connection { get; set; }

		string BusAddress { get; set; }

		// Has dedicated field in ElementInfoResponseMessage. Only seems applicable in case of HTTP (WebSocket) connections.
		/// <summary>
		/// Gets or sets a value indicating whether the proxy server should be bypassed.
		/// </summary>
		/// <value><c>true</c> if the proxy server should be bypassed; otherwise, <c>false</c>.</value>
		bool BypassProxy { get; set; }

		// For WebSocket, this will chang from ws:// to wss://. For serial (and smart-serial), this will set the IsSslTlsEnabled.
		bool IsSecure { get; set; } // TODO: Could also be provided in the TCP and UDP underlying connection. 
	}
}
