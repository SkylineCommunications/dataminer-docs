namespace Skyline.DataMiner.Library.Common
{
    /// <summary>
    /// Specifies the connection type.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// Undefined connection type.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// SNMPv1 connection.
        /// </summary>
        SnmpV1 = 1,

        /// <summary>
        /// Serial connection.
        /// </summary>
        Serial = 2,

        /// <summary>
        /// Smart-serial connection.
        /// </summary>
        SmartSerial = 3,

        /// <summary>
        /// Virtual connection.
        /// </summary>
        Virtual = 4,

        /// <summary>
        /// GBIP (General Purpose Interface Bus) connection.
        /// </summary>
        Gpib = 5,

        /// <summary>
        /// OPC (OLE for Process Control) connection.
        /// </summary>
        Opc = 6,

        /// <summary>
        /// SLA (Service Level Agreement).
        /// </summary>
        Sla = 7,

        /// <summary>
        /// SNMPv2 connection.
        /// </summary>
        SnmpV2 = 8,

        /// <summary>
        /// SNMPv3 connection.
        /// </summary>
        SnmpV3 = 9,

        /// <summary>
        /// HTTP connection.
        /// </summary>
        Http = 10,

        /// <summary>
        /// Service.
        /// </summary>
        Service = 11,

        /// <summary>
        /// Serial single connection.
        /// </summary>
        SerialSingle = 12,

        /// <summary>
        /// Smart-serial single connection.
        /// </summary>
        SmartSerialSingle = 13,

		/// <summary>
		/// Web Socket connection.
		/// </summary>
		WebSocket = 14
    }
}