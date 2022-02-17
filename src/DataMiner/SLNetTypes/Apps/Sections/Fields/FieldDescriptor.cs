using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Skyline.DataMiner.Net.Jobs;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a field descriptor. A field descriptor defines the behavior and look of a field.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class FieldDescriptor : IEquatable<FieldDescriptor>
    {
		/// <summary>
		/// The supported types.
		/// </summary>
		public static readonly IReadOnlyList<Type> SupportedTypes;

        //[DataMember(Name = "ID")]
        private FieldDescriptorID _id;

		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		/// <value>The ID.</value>
		public FieldDescriptorID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
        {
			get; set;
        }

		/// <summary>
		/// Gets the field validators.
		/// </summary>
		/// <value>The field validators.</value>
		public List<IFieldValidator> Validators
        {
			get;
        }

		/// <summary>
		/// Gets or sets the type of the field.
		/// </summary>
		/// <value>The field type.</value>
		//[DataMember(Name = "FieldType")]
        public Type FieldType { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this field is optional.
		/// </summary>
		/// <value><c>true</c> if this field is optional; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>When set to <c>false</c>, the sections must always contain a value for this field.</para>
		/// <para>Since DataMiner 9.6.11 (RN 22824, RN 23048), when you configure a job section, it is now possible to turn mandatory fields into optional fields and vice versa, even if those fields are in use.</para>
		/// </remarks>
		//[DataMember(Name = "IsOptional")]
        public bool IsOptional { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this field is hidden.
		/// </summary>
		/// <value><c>true</c> if this field is hidden; otherwise, <c>false</c>.</value>
		/// <remarks>When set to <c>true</c>, the fields that use this <see cref="FieldDescriptor"/> will not be displayed when viewing a <see cref="Job"/>.</remarks>
		//[DataMember(Name = "IsHidden")]
        public bool IsHidden { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this field is read-only.
		/// </summary>
		/// <value><c>true</c> if this field is read-only; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Read-only fields can only be updated from a script, not from the UI. Also, read-only fields will be ignored when you apply a job template.</para>
		/// <para>Feature introduced in DataMiner 9.6.11 (RN 22758).</para>
		/// </remarks>
		//[DataMember(Name = "IsReadonly")]
        public bool IsReadonly { get; set; }

		/// <summary>
		/// Gets or sets the tooltip.
		/// </summary>
		/// <value>The tooltip.</value>
		/// <remarks>The client will display this tooltip when the user hovers over the name of the field.
		/// Feature introduced in DataMiner 9.6.9 (RN 22204).</remarks>
		//[DataMember(Name = "Tooltip")]
        public string Tooltip { get; set; }

		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value.</value>
		//[DataMember(Name = "DefaultValue")]
        public IValueWrapper DefaultValue { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldDescriptor"/> class.
		/// </summary>
		public FieldDescriptor()
        {
        }

		/// <summary>
		/// Determines whether the specified type in <see cref="FieldType"/> is a supported type.
		/// </summary>
		/// <returns><c>true</c> if the specified type is supported; otherwise, <c>false</c>.</returns>
		public bool ContainsValidSupportedType()
        {
			return true;
        }

		/// <summary>
		/// Retrieves the ID string.
		/// </summary>
		/// <returns>The ID string.</returns>
		public string GetDictFieldName()
        {
            return "";
        }

		/// <summary>
		/// Determines whether the specified value has the valid type.
		/// </summary>
		/// <param name="valueWrapper">The value to check for the valid type.</param>
		/// <returns><c>true</c> if the type of value is valid; otherwise, <c>false</c>.</returns>
		public virtual bool IsValueOfValidType(IValueWrapper valueWrapper)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified type in <see cref="FieldType"/> is a supported type.
		/// </summary>
		/// <param name="error">The error message in case the type is unsupported; otherwise <see langword="null" />.</param>
		/// <returns><c>true</c> if the specified type is supported; otherwise, <c>false</c>.</returns>
		public virtual bool ContainsValidSupportedType(out SectionDefinitionError error)
        {
            error = null;

            return true;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(FieldDescriptor other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the field descriptor is changed in a safe way.
		/// </summary>
		/// <param name="other">The other field descriptor.</param>
		/// <returns><c>true</c> if it is changed in a safe way; otherwise, <c>false</c>.</returns>
		public virtual bool IschangedInASafeWay(FieldDescriptor other)
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
    }
}