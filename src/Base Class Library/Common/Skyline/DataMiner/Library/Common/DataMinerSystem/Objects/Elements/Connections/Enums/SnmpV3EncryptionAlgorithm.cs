namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Specifies the SNMPv3 encryption algorithm.
	/// </summary>
	public enum SnmpV3EncryptionAlgorithm
	{
		/// <summary>
		/// Data Encryption Standard (DES).
		/// </summary>
		Des = 0,

		/// <summary>
		/// Advanced Encryption Standard (AES) 128 bit.
		/// </summary>
		Aes128 = 1,

		/// <summary>
		/// Advanced Encryption Standard (AES) 192 bit.
		/// </summary>
		Aes192 = 2,

		/// <summary>
		/// Advanced Encryption Standard (AES) 256 bit.
		/// </summary>
		Aes256 = 3,

		/// <summary>
		/// Advanced Encryption Standard is defined in the Credential Library.
		/// </summary>
		DefinedInCredentialsLibrary = 4,

		/// <summary>
		/// No algorithm selected.
		/// </summary>
		None = 5,
	}
}