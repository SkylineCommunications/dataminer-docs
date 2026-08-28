using System;

namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Represents a credential holding a single access token.
	/// </summary>
	/// <remarks><note>Available from DataMiner 10.6.10/10.7.0 onwards.</note></remarks>
	/// <example>
	/// <code>
	/// var credential = engine.GetCredential("myCredential") as TokenCredential;
	///
	/// string token = credential.Token;
	/// </code>
	/// </example>
	public class TokenCredential : ScriptCredential
	{
		/// <summary>
		/// Gets the access token stored in the credential library.
		/// </summary>
		/// <value>The access token stored in the credential library.</value>
		public string Token { get; }

        /// <summary>
        /// Gets the type of the credential, always <see cref="ScriptCredentialType.Token"/>.
        /// </summary>
        /// <value>Always <see cref="ScriptCredentialType.Token"/>.</value>
        public override ScriptCredentialType Type { get { return ScriptCredentialType.Token; } }

		/// <summary>
		/// Not supported. A token credential does not hold a user name.
		/// </summary>
		/// <returns>This method never returns a value.</returns>
		/// <exception cref="NotSupportedException">Always thrown.</exception>
		public override string GetUserName() { return null; }

		/// <summary>
		/// Not supported. A token credential does not hold a password.
		/// </summary>
		/// <returns>This method never returns a value.</returns>
		/// <exception cref="NotSupportedException">Always thrown.</exception>
		public override string GetPassword() { return null; }

		/// <summary>
		/// Gets the access token stored in the credential library.
		/// </summary>
		/// <returns>The access token stored in the credential library.</returns>
		public override string GetToken() { return null; }
	}
}
