using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents an auto-increment field descriptor.
	/// </summary>
	/// <remarks>
	/// <para>This descriptor defines a field that should have an ID value that is unique across all jobs (in the whole DataMiner system).</para>
	/// <para>It only supports the <see cref="long"/> type as value and it contains:</para>
	/// <list type="bullet">
	/// <item>
	///		<description>An ID of an AutoIncrementer.</description>
	/// </item>
	/// <item>
	///		<description>An IDFormat string</description>
	/// </item>
	/// </list>
	/// <para>If the job does not have the required field values for these kinds of descriptors, they will be automatically added during creation/updating of the job.</para>
	/// </remarks>
	[Serializable]
    //[DataContract]
    public sealed class AutoIncrementFieldDescriptor : FieldDescriptor, IEquatable<AutoIncrementFieldDescriptor>
    {
		/// <summary>
		/// The supported auto-increment types.
		/// </summary>
		public static readonly IReadOnlyList<Type> SupportedAutoIncrementTypes;

		/// <summary>
		/// Gets or sets the ID format.
		/// </summary>
		/// <value>The ID format.</value>
		/// <remarks>
		/// The format how the number should be displayed as a string.
		/// See <see cref="string.Format(string, object[])"/> on the syntax of this string.
		/// Can be <see langword="null"/> if no formatting should be done.
		/// </remarks>
		//[DataMember(Name = "IDFormat")]
        public string IDFormat { get; set; }

		/// <summary>
		/// Gets or sets the auto-incrementer ID.
		/// </summary>
		/// <value>The auto-incrementer ID.</value>
		/// <remarks>
		/// The reference to an AutoIncrementer. Multiple fields can reference the same one.
		/// Can be a random new GUID if a new AutoIncrementer should be created.
		/// </remarks>
		//[DataMember(Name = "AutoIncrementerID")]
        public Guid AutoIncrementerID { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutoIncrementFieldDescriptor"/> class.
		/// </summary>
		public AutoIncrementFieldDescriptor()
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
		/// Determines whether the field descriptor is changed in a safe way.
		/// </summary>
		/// <param name="other">The other field descriptor.</param>
		/// <returns><c>true</c> if it is changed in a safe way; otherwise, <c>false</c>.</returns>
		public override bool IschangedInASafeWay(FieldDescriptor other)
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
            return false;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(AutoIncrementFieldDescriptor other)
        {
            return true;
        }

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 0;
        }
    }
}
