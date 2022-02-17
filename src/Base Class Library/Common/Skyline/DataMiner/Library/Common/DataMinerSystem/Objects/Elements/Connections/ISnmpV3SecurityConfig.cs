namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Interface for SnmpV3 Security configurations.
	/// </summary>
	public interface ISnmpV3SecurityConfig
	{
		/// <summary>
		/// Gets or sets the EncryptionAlgorithm.
		/// </summary>
		SnmpV3EncryptionAlgorithm EncryptionAlgorithm { get; set; }

		/// <summary>
		/// Gets or sets the AuthenticationProtocol.
		/// </summary>
		SnmpV3AuthenticationAlgorithm AuthenticationAlgorithm { get; set; }

		/// <summary>
		/// Gets or sets the EncryptionKey.
		/// </summary>
		string EncryptionKey { get; set; }

		/// <summary>
		/// Gets or sets the AuthenticationKey.
		/// </summary>
		string AuthenticationKey { get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		string Username { get; set; }

		/// <summary>
		/// Gets or sets the SecurityLevelAndProtocol.
		/// </summary>
		SnmpV3SecurityLevelAndProtocol SecurityLevelAndProtocol { get; set; }
	}
}