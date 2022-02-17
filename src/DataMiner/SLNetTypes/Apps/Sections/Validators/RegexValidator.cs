using System;
using System.Text.RegularExpressions;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a validator that validates against a regular expression.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class RegexValidator : IFieldValidator, IEquatable<RegexValidator>
    {
		/// <summary>
		/// Gets or sets the regular expression pattern.
		/// </summary>
		/// <value>The regular expression pattern.</value>
		//[DataMember(Name = "RegexPattern")]
        public string RegexPattern { get; set; }

		/// <summary>
		/// Gets or sets the regular expression options.
		/// </summary>
		/// <value>The regular expression options.</value>
		//[DataMember(Name = "RegexOptions")]
        public RegexOptions RegexOptions { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RegexValidator"/> class.
		/// </summary>
		public RegexValidator()
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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(RegexValidator other)
        {
            return true;
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
            return false;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }
    }
}