namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents a connection using the Internet Protocol (IP).
	/// </summary>
	public interface IIpBased : IPortConnection
	{
		/// <summary>
		/// Gets or sets the host name or IP address of the host to connect to.
		/// </summary>
		/// <value>The host name or IP address of the host to connect to.</value>
		string RemoteHost { get; set; }

		/// <summary>
		/// Gets or sets the network interface card (NIC).
		/// </summary>
		/// <value>The network interface card (NIC). A value of 0 means the network interface card will be selected automatically.</value>

		int NetworkInterfaceCard { get; set; }
	}
}