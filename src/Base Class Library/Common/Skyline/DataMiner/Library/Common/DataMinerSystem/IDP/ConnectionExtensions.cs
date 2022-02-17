namespace Skyline.DataMiner.Library.Common.Idp
{
	using System;

	/// <summary>
	///     Class containing extension methods on Connection classes to offer extra custom functionality.
	/// </summary>
	public static class ConnectionExtensions
	{

		/// <summary>
		///     Converts the connection into the JSON Structure expected by IDP's Configuration Item type (CIType).
		/// </summary>
		/// <param name="connection">The connection which needs to be converted to a Configuration Item Type.</param>
		/// <param name="connectionIndex">Zero-based index of the connection in an element.</param>
		/// <returns>JSON string to match CIType.</returns>
		public static string ToCITypeJson(this IElementConnection connection, int connectionIndex)
		{
			if (connection is IHttpConnection)
			{
				return (connection as IHttpConnection).ToCITypeJson(connectionIndex);
			}
			else if (connection is ISnmpV1Connection)
			{
				return (connection as ISnmpV1Connection).ToCITypeJson(connectionIndex);

			}else if (connection is ISnmpV2Connection)
			{
				return (connection as ISnmpV2Connection).ToCITypeJson(connectionIndex);

			}else if (connection is ISnmpV3Connection)
			{
				return (connection as ISnmpV3Connection).ToCITypeJson(connectionIndex);

			}else if (connection is IVirtualConnection)
			{
				return (connection as IVirtualConnection).ToCITypeJson(connectionIndex);

			}else if (connection is ISerialConnection)
			{
				return (connection as ISerialConnection).ToCITypeJson(connectionIndex);

			}else
			{
				return (connection as IRealConnection).ToCITypeJson(connectionIndex);
			}
		}

		/// <summary>
		///  Converts the connection into the JSON Structure expected by IDP's Configuration Item type (CIType).
		/// </summary>
		/// <param name="connection">The connection which needs to be converted to a Configuration Item Type.</param>
		/// <param name="connectionIndex">Zero-based index of the connection in an element.</param>
		/// <returns>JSON string to match CIType.</returns>
		public static string ToCITypeJson(this IVirtualConnection connection, int connectionIndex)
		{
			return String.Empty;
		}
	}
}