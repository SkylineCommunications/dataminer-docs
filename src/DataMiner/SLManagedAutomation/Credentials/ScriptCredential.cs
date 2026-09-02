using System;

namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Represents a credential that is declared by an Automation script and that is resolved against the credential library.
	/// </summary>
	/// <remarks>
	/// <para>For more information about credentials in Automation, refer to <see href="xref:Script_variables#creating-a-set-of-credentials">Creating a credential</see>.</para>
	/// <note>Available from DataMiner 10.6.10/10.7.0 onwards.</note>
	/// </remarks>
	public abstract class ScriptCredential
	{
        /// <summary>
        /// Gets the ID by which the credential is referred to in the script XML.
        /// </summary>
        /// <value>The ID by which the credential is referred to in the script XML.</value>
        public int Id { get; }

        /// <summary>
        /// Gets the name by which the credential is referred to in the script XML.
        /// </summary>
        /// <value>The name by which the credential is referred to in the script XML.</value>
        public string Name { get; }

		/// <summary>
		/// Gets the ID of the linked credential in the credential library.
		/// </summary>
		/// <value>The ID of the linked credential in the credential library.</value>
		public Guid LibraryCredentialId { get; }

		/// <summary>
		/// Gets the type of the credential.
		/// </summary>
		/// <value>The type of the credential.</value>
		public abstract ScriptCredentialType Type { get; }

		/// <summary>
		/// Gets the user name stored in the credential library.
		/// </summary>
		/// <returns>The user name stored in the credential library.</returns>
		/// <exception cref="NotSupportedException">The credential does not hold a user name.</exception>
		public abstract string GetUserName();

		/// <summary>
		/// Gets the password stored in the credential library.
		/// </summary>
		/// <returns>The password stored in the credential library.</returns>
		/// <exception cref="NotSupportedException">The credential does not hold a password.</exception>
		public abstract string GetPassword();

		/// <summary>
		/// Gets the token stored in the credential library.
		/// </summary>
		/// <returns>The token stored in the credential library.</returns>
		/// <exception cref="NotSupportedException">The credential does not hold a token.</exception>
		public abstract string GetToken();
	}
}
