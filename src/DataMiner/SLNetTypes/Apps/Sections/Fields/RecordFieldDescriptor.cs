using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.Records;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a record field descriptor. This <see cref="FieldDescriptor"/> has a reference to a <see cref="RecordDefinition"/>.
	/// </summary>
	/// <remarks>The value of a <see cref="RecordFieldDescriptor"/> is always a GUID that is a reference to a <see cref="Record"/> complying with the <see cref="RecordDefinition"/>.</remarks>
	[Serializable]
    //[DataContract]
    public sealed class RecordFieldDescriptor : FieldDescriptor, IEquatable<RecordFieldDescriptor>
    {
		/// <summary>
		/// The supported record key types.
		/// </summary>
		public static readonly IReadOnlyList<Type> SupportedRecordKeyTypes;

		/// <summary>
		/// Gets or sets the record definition ID.
		/// </summary>
		/// <value>The record definition ID.</value>
		public RecordDefinitionID RecordDefinitionID
        {
			get; set;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordFieldDescriptor"/> class.
		/// </summary>
		public RecordFieldDescriptor()
            : base()
        {
        }

		/// <summary>
		/// Determines whether the field type is supported.
		/// </summary>
		/// <param name="error">The error if the field type is not supported, otherwise <see langword="null"/>.</param>
		/// <returns><c>true</c> if the field type is supported; otherwise, <c>false</c>.</returns>
		public override bool ContainsValidSupportedType(out SectionDefinitionError error)
        {
            error = null;

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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(RecordFieldDescriptor other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the field descriptor is changed in a safe way.
		/// </summary>
		/// <param name="other">The other field descriptor.</param>
		/// <returns><c>true</c> if it is changed in a safe way; otherwise, <c>false</c>.</returns>
		public override bool IschangedInASafeWay(FieldDescriptor other)
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
    }
}
