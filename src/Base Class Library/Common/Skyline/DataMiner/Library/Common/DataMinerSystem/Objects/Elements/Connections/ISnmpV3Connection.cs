namespace Skyline.DataMiner.Library.Common
{

	/// <summary>
	/// Defines an SNMPv3 Connection.
	/// </summary>
	public interface ISnmpV3Connection : ISnmpConnection
	{
		/// <summary>
		/// Gets or sets the SNMPv3 security configuration.
		/// </summary>
		ISnmpV3SecurityConfig SecurityConfig { get; set; }
	}
}
