using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a URI validator.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class UriValidator : IFieldValidator, IEquatable<UriValidator>
    {
		/// <summary>
		/// Gets or sets the kind of URI.
		/// </summary>
		/// <value>The kind of URI.</value>
		/// <remarks>
		/// <c>System.UriKind</c> to check:
		/// <list type="bullet">
		///     <item><description>System.UriKind.Absolute</description></item>
		///     <item><description>System.UriKind.Relative</description></item>
		///     <item><description>System.UriKind.RelativeOrAbsolute</description></item>
		/// </list>
		/// </remarks>
		//[DataMember(Name = "Kind")]
		public UriKind Kind { get; set; }

		/// <summary>
		/// Gets or sets the accepted URI schemes.
		/// </summary>
		/// <value>The accepted URI schemes.</value>
		/// <remarks>
		/// Set of accepted uri schemes.
		/// <list type="bullet">
		///     <item><description>System.Uri.UriSchemeFile</description></item>
		///     <item><description>System.Uri.UriSchemeFtp</description></item>
		///     <item><description>System.Uri.UriSchemeGopher</description></item>
		///     <item><description>System.Uri.UriSchemeHttp</description></item>
		///     <item><description>System.Uri.UriSchemeHttps</description></item>
		///     <item><description>System.Uri.UriSchemeMailto</description></item>
		///     <item><description>System.Uri.UriSchemeNetPipe</description></item>
		///     <item><description>System.Uri.UriSchemeNetTcp</description></item>
		///     <item><description>System.Uri.UriSchemeNews</description></item>
		///     <item><description>System.Uri.UriSchemeNntp</description></item>
		/// </list>
		/// </remarks>
		public HashSet<string> AcceptedUriSchemes { get; set; }


		/// <summary>
		/// Gets or sets the value indicating whether this validator checks for well-formedness.
		/// </summary>
		/// <value><c>true</c> to check for well-formedness; otherwise, <c>false</c>.</value>
		//[DataMember(Name = "CheckWellFormed")]
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
		/// Validates the specified value against the specified field descriptor.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		/// <param name="descriptor">The field descriptor to validate against.</param>
		/// <returns><c>true</c> if the specified value validates against the specified field descriptor; otherwise, <c>false</c>.</returns>
		public bool Validate(IValueWrapper value, FieldDescriptor descriptor)
        {
            return false;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(UriValidator other)
        {
            return true;
        }
    }
}
