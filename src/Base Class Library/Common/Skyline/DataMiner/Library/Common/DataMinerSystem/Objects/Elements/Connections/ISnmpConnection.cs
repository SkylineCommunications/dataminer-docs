using System;

namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Defines an SNMP connection.
	/// </summary>
	public interface ISnmpConnection : IRealConnection
	{

		/// <summary>
		/// Gets or sets the underlying connection.
		/// </summary>
		/// <value>The underlying connection.</value>
		IUdp UdpConfiguration { get; set; }

		// Credentials can currently be used with SNMP connections only.
		// When credentials are provided, then no community strings (snmpv1/snmpv2) or user name,level,authentication protocol,authentication key,encryption protocol, encryption key can be provided.
		// See http://devcore3/documentation/server/RC/html/e7dbdb35-9528-5b65-8436-6b3242a8076f.htm
		// Currently only Get implemented in order to detect if credentials are used or not because then the other fields should be empty and not be settable.

		/// <summary>
		/// Gets the library credentials Guid. When empty guid, the credentials are not used from the library.
		/// </summary>
		Guid LibraryCredentials { get; }

		/// <summary>
		/// Gets or sets the device address.
		/// </summary>
		/// <value>The device address.</value>
		string DeviceAddress { get; set; }

	}
}
