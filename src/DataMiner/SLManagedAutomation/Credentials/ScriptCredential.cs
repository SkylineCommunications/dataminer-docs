using System;

namespace Skyline.DataMiner.Automation.Credentials
{
	/// <summary>
	/// Represents a set of credentials declared by an automation script and resolved against the Credentials Library.
	/// </summary>
	/// <remarks>
	/// <para>For more information about credentials in Automation, refer to <see href="xref:Script_variables#creating-a-set-of-credentials">Creating a set of credentials</see>.</para>
	/// <note>Available from DataMiner 10.6.10/10.7.0 onwards.</note>
	/// </remarks>
	public abstract class ScriptCredential
	{
        /// <summary>
        /// Gets the ID used to refer to the set of credentials in the script XML.
        /// </summary>
        /// <value>The ID used to refer to the set of credentials in the script XML.</value>
        public int Id { get; }

        /// <summary>
        /// Gets the name used to refer to the set of credentials in the script XML.
        /// </summary>
        /// <value>The name used to refer to the set of credentials in the script XML.</value>
        public string Name { get; }

		/// <summary>
		/// Gets the ID of the linked credentials in the Credentials Library.
		/// </summary>
		/// <value>The ID of the linked credentials in the Credentials Library.</value>
		public Guid LibraryCredentialId { get; }

		/// <summary>
		/// Gets the type of the credentials.
		/// </summary>
		/// <value>The type of the credentials.</value>
		public abstract ScriptCredentialType Type { get; }

		/// <summary>
		/// Gets the username stored in the Credentials Library.
		/// </summary>
		/// <returns>The username stored in the Credentials Library.</returns>
		/// <exception cref="NotSupportedException">The credentials do not include a username.</exception>
		public abstract string GetUserName();

		/// <summary>
		/// Gets the password stored in the Credentials Library.
		/// </summary>
		/// <returns>The password stored in the Credentials Library.</returns>
		/// <exception cref="NotSupportedException">The credentials do not include a password.</exception>
		public abstract string GetPassword();

		/// <summary>
		/// Gets the token stored in the Credentials Library.
		/// </summary>
		/// <returns>The token stored in the Credentials Library.</returns>
		/// <exception cref="NotSupportedException">The credentials do not include a token.</exception>
		public abstract string GetToken();
	}
}
