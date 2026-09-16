namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Specifies the type of a set of credentials stored in the Credentials Library.
	/// </summary>
	/// <remarks><note>Available from DataMiner 10.6.10/10.7.0 onwards.</note></remarks>
	public enum ScriptCredentialType
	{
		/// <summary>
		/// The credentials type is unknown, i.e., the set of credentials is not correctly defined in the automation script.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// A set of credentials containing a username and a password.
		/// </summary>
		UserNameAndPassword = 1,

		/// <summary>
		/// A set of credentials containing a single access token.
		/// </summary>
		Token = 2
	}
}
