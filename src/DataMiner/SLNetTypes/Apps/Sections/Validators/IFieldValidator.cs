using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a field validator.
	/// </summary>
	public interface IFieldValidator
    {
		/// <summary>
		/// Validates the specified value against the specified field descriptor.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		/// <param name="descriptor">The field descriptor to validate against.</param>
		/// <returns><c>true</c> if the specified value validates against the specified field descriptor; otherwise, <c>false</c>.</returns>
		bool Validate(IValueWrapper value, FieldDescriptor descriptor);
    }
}