using System;

namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Represents a credential holding a user name and a password.
	/// </summary>
	/// <remarks><note>Available from DataMiner 10.6.10/10.7.0 onwards.</note></remarks>
	/// <example>
	/// <code>
	/// var credential = engine.GetCredential("myCredential") as UserNameAndPasswordCredential;
	///
	/// string userName = credential.UserName;
	/// string password = credential.Password;
	/// </code>
	/// </example>
	public class UserNameAndPasswordCredential : ScriptCredential
	{
		/// <summary>
		/// Gets the user name stored in the credential library.
		/// </summary>
		/// <value>The user name stored in the credential library.</value>
		public string UserName { get; }

		/// <summary>
		/// Gets the password stored in the credential library.
		/// </summary>
		/// <value>The password stored in the credential library.</value>
		public string Password { get; }

        /// <summary>
        /// Gets the type of the credential, always <see cref="ScriptCredentialType.UserNameAndPassword"/>.
        /// </summary>
        /// <value>Always <see cref="ScriptCredentialType.UserNameAndPassword"/>.</value>
        public override ScriptCredentialType Type { get { return ScriptCredentialType.UserNameAndPassword; } }

		/// <summary>
		/// Gets the user name stored in the credential library.
		/// </summary>
		/// <returns>The user name stored in the credential library.</returns>
		public override string GetUserName() { return null; }

		/// <summary>
		/// Gets the password stored in the credential library.
		/// </summary>
		/// <returns>The password stored in the credential library.</returns>
		public override string GetPassword() { return null; }

		/// <summary>
		/// Not supported. A user name and password credential does not hold a token.
		/// </summary>
		/// <returns>This method never returns a value.</returns>
		/// <exception cref="NotSupportedException">Always thrown.</exception>
		public override string GetToken() { return null; }
	}
}
