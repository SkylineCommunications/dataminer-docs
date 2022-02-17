using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents an e-mail address validator.
	/// </summary>
	[Serializable]
    public class EmailAddressValidator : IFieldValidator, IEquatable<EmailAddressValidator>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
		/// </summary>
		public EmailAddressValidator()
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
			return true;
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
            return 0;
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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(EmailAddressValidator other)
        {
            return true;
        }
    }
}
