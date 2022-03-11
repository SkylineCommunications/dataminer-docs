namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Specifies the SNMP v3 security level and protocol.
	/// </summary>
	public enum SnmpV3SecurityLevelAndProtocol
	{
		/// <summary>
		/// Authentication and privacy.
		/// </summary>
		AuthenticationPrivacy = 0,

		/// <summary>
		/// Authentication but no privacy.
		/// </summary>
		AuthenticationNoPrivacy = 1,

		/// <summary>
		/// No authentication and no privacy.
		/// </summary>
		NoAuthenticationNoPrivacy = 2,

		/// <summary>
		/// Security Level and Protocol is defined in the Credential library.
		/// </summary>
		DefinedInCredentialsLibrary = 3,

		/// <summary>
		/// No algorithm selected.
		/// </summary>
		None = 4
	}
}
