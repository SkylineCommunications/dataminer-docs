namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Specifies the SNMPv3 authentication protocol.
	/// </summary>
	public enum SnmpV3AuthenticationAlgorithm
	{
		/// <summary>
		/// Message Digest 5 (MD5).
		/// </summary>
		Md5 = 0,

		/// <summary>
		/// Secure Hash Algorithm (SHA).
		/// </summary>
		Sha1 = 1,

		/// <summary>
		/// Secure Hash Algorithm (SHA) 224.
		/// </summary>
		Sha224 = 2,

		/// <summary>
		/// Secure Hash Algorithm (SHA) 256.
		/// </summary>
		Sha256 = 3,

		/// <summary>
		/// Secure Hash Algorithm (SHA) 384.
		/// </summary>
		Sha384 = 4,

		/// <summary>
		/// Secure Hash Algorithm (SHA) 512.
		/// </summary>
		Sha512 = 5,

		/// <summary>
		/// Algorithm is defined in the Credential Library.
		/// </summary>
		DefinedInCredentialsLibrary = 6,

		/// <summary>
		/// No algorithm selected.
		/// </summary>
		None = 7,

	}

	/// <summary>
	/// Allows adapting the enum to other library equivalents.
	/// </summary>
	public class SnmpV3AuthenticationAlgorithmAdapter
	{
		/// <summary>
		/// Converts SLNet parity string into the enum.
		/// </summary>
		/// <param name="parity">Parity string received from SLNet.</param>
		/// <returns>The equivalent enum.</returns>
		public static SnmpV3AuthenticationAlgorithm FromSLNetParity(string parity)
		{
			string noCaseParity = parity.ToUpper();
			switch (noCaseParity)
			{
				case "MD5":
				case "HMAC-MD5":
					return SnmpV3AuthenticationAlgorithm.Md5;
				case "SHA":
				case "SHA1":
				case "HMAC-SHA":
					return SnmpV3AuthenticationAlgorithm.Sha1;
				case "SHA224":
					return SnmpV3AuthenticationAlgorithm.Sha224;
				case "SHA256":
					return SnmpV3AuthenticationAlgorithm.Sha256;
				case "SHA384":
					return SnmpV3AuthenticationAlgorithm.Sha384;
				case "SHA512":
					return SnmpV3AuthenticationAlgorithm.Sha512;
				case "DEFINEDINCREDENTIALSLIBRARY":
					return SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary;
				case "NONE":
				default:
					return SnmpV3AuthenticationAlgorithm.None;
			}
		}

		/// <summary>
		/// Converts the enum into the equivalent SLNet string value.
		/// </summary>
		/// <param name="value">The enum you wish to convert.</param>
		/// <returns>The equivalent string value.</returns>
		public static string ToSLNetParity(SnmpV3AuthenticationAlgorithm value)
		{
			switch (value)
			{
				case SnmpV3AuthenticationAlgorithm.Md5:
					// Verified with server side: SLSNMPManager can handle both MD5 or HMAC-MD5 as input.
					return "MD5";
				case SnmpV3AuthenticationAlgorithm.Sha1:
					return "SHA";
				case SnmpV3AuthenticationAlgorithm.Sha224:
					return "SHA224";
				case SnmpV3AuthenticationAlgorithm.Sha256:
					return "SHA256";
				case SnmpV3AuthenticationAlgorithm.Sha384:
					return "SHA384";
				case SnmpV3AuthenticationAlgorithm.Sha512:
					return "SHA512";
				case SnmpV3AuthenticationAlgorithm.None:
					return "None";
				case SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary:
				default:
					return value.ToString();
			}
		}
	}
}
