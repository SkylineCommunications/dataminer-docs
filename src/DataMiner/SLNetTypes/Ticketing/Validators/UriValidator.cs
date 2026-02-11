using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a URI validator. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[Serializable]
    public class UriValidator : ITicketFieldValidator
    {
		/// <summary>
		/// Gets or sets the kind of URI.
		/// </summary>
		/// <value>The kind of URI.</value>
		/// <remarks>
		/// <c>System.UriKind</c> to check:
		/// <list type="bullet">
		///     <item>System.UriKind.Absolute</item>
		///     <item>System.UriKind.Relative</item>
		///     <item>System.UriKind.RelativeOrAbsolute</item>
		/// </list>
		/// </remarks>
		public UriKind Kind { get; set; }

		/// <summary>
		/// Gets or sets the accepted URI schemes.
		/// </summary>
		/// <value>The accepted URI schemes.</value>
		/// <remarks>
		/// <para>The following values can be used:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>System.Uri.UriSchemeFile</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeFtp</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeGopher</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeHttp</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeHttps</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeMailto</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeNetPipe</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeNetTcp</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeNews</description>
		/// </item>
		/// <item>
		/// <description>System.Uri.UriSchemeNntp</description>
		/// </item>
		/// </list>
		/// <para>In case no schemes are set, this validator will not validate against URI schemes.</para>
		/// </remarks>
		public HashSet<string> AcceptedUriSchemes { get; set; }

		/// <summary>
		/// Gets or sets the value indicating whether this validator checks for well-formedness.
		/// </summary>
		/// <value><c>true</c> to check for well-formedness; otherwise, <c>false</c>.</value>
		public bool CheckWellFormed { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="UriValidator"/> class.
		/// </summary>
		/// <remarks>The instance created by this constructor allows relative or absolute URIs, does not check for well-formedness and has no schemes set.</remarks>
		public UriValidator()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="UriValidator"/> class using the specified URI kinds and schemes allowed and well-formedness indication.
		/// </summary>
		/// <param name="uriKind">The kind of URIs allowed.</param>
		/// <param name="acceptedUriSchemes">The accepted URI schemes.</param>
		/// <param name="checkWellFormed"><c>true</c> to check for well-formedness; otherwise, <c>false</c>.</param>
		public UriValidator(UriKind uriKind, HashSet<string> acceptedUriSchemes, bool checkWellFormed)
        {
        }

		/// <summary>
		/// Verifies whether the specified string represents valid URI.
		/// </summary>
		/// <param name="ticket">The ticket.</param>
		/// <param name="obj">The string to validate.</param>
		/// <returns><c>true</c> if <paramref name="obj"/> is valid; otherwise, <c>false</c>.
		/// </returns>
		public bool Validate(Ticket ticket, object obj)
        {
			return false;
        }
    }
}
