namespace Skyline.DataMiner.Library.Common
{
    /// <summary>
    /// Specifies the protocol type.
    /// </summary>
    public enum ProtocolType
    {
        /// <summary>
        /// Undefined protocol type.
        /// </summary>
        Undefined = 0,

		/// <summary>
		/// The SNMP protocol type.
		/// </summary>
		Snmp = 1,

		/// <summary>
		/// The SNMPv1 protocol type.
		/// </summary>
		SnmpV1 = 1,

		/// <summary>
		/// The serial protocol type.
		/// </summary>
		Serial = 2,

		/// <summary>
		/// The smart serial protocol type.
		/// </summary>
		SmartSerial = 3,

		/// <summary>
		/// The virtual protocol type.
		/// </summary>
		Virtual = 4,

		/// <summary>
		/// The General Purpose Interface Bus (GPIB) protocol type.
		/// </summary>
		Gpib = 5,

		/// <summary>
		/// The OLE Process Controller (OPC) protocol type.
		/// </summary>
		Opc = 6,

		/// <summary>
		/// The Service Level Agreement (SLA) protocol type.
		/// </summary>
		Sla = 7,

		/// <summary>
		/// The SNMPv2 protocol type.
		/// </summary>
		SnmpV2 = 8,

		/// <summary>
		/// The SNMPv3 protocol type.
		/// </summary>
		SnmpV3 = 9,

		/// <summary>
		/// The HTTP protocol type.
		/// </summary>
		Http = 10,

		/// <summary>
		/// The service protocol type.
		/// </summary>
		Service = 11,

		/// <summary>
		/// The serial single protocol type.
		/// </summary>
		SerialSingle = 12,

		/// <summary>
		/// The smart serial single protocol type.
		/// </summary>
		SmartSerialSingle = 13,

		/// <summary>
		/// The smart serial raw protocol type.
		/// </summary>
		SmartSerialRaw = 14,

		/// <summary>
		/// The smart serial raw single protocol type.
		/// </summary>
		SmartSerialRawSingle = 15,

		/// <summary>
		/// The websocket protocol type.
		/// </summary>
		WebSocket = 16
	}
}