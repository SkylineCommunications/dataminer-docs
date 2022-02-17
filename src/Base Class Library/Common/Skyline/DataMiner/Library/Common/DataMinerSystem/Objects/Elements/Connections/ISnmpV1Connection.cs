namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Defines an SNMPv1 Connection
	/// </summary>
	public interface ISnmpV1Connection : ISnmpConnection
	{
		/// <summary>
		/// Gets or sets the get community string.
		/// </summary>
		/// <value>The get community string.</value>
		string GetCommunityString { get; set; }

		/// <summary>
		/// Gets or sets the set community string.
		/// </summary>
		/// <value>The set community string.</value>
		string SetCommunityString { get; set; }
	}
}
