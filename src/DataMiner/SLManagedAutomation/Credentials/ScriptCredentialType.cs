namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Specifies the type of a credential stored in the credential library.
	/// </summary>
	/// <remarks><note>Available from DataMiner 10.6.10/10.7.0 onwards.</note></remarks>
	public enum ScriptCredentialType
	{
		/// <summary>
		/// The credential type is unknown, i.e. the credential is not correctly defined in the Automation script.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// A credential holding a user name and a password.
		/// </summary>
		UserNameAndPassword = 1,

		/// <summary>
		/// A credential holding a single access token.
		/// </summary>
		Token = 2
	}
}
