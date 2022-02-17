using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.Records;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// This field descriptor has a <see cref="StaticText"/> property. Every field of this type will always have this string as value.
	/// </summary>
	/// <remarks>
	/// <para>The value itself is not saved in the job, which makes sure that the <see cref="StaticText"/> can always be changed freely. When a job is displayed, the value for this kind of field should always be retrieved from the <see cref="StaticTextFieldDescriptor"/> itself.</para>
	/// <para>The FieldValue for this type of FieldDescriptor must not contain any values, it should be empty, but if something were to be present, it can always be safely ignored.</para>
	/// <para>Feature introduced in DataMiner 9.6.9 (RN 22207).</para>
	/// </remarks>
	[Serializable]
    //[DataContract]
    public sealed class StaticTextFieldDescriptor : FieldDescriptor, IEquatable<StaticTextFieldDescriptor>
    {
		/// <summary>
		/// Gets or sets the static text.
		/// </summary>
		/// <value>The static text.</value>
		//[DataMember(Name = "StaticText")]
        public string StaticText { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StaticTextFieldDescriptor"/> class.
		/// </summary>
		public StaticTextFieldDescriptor()
            : base()
        {
        }

		/// <summary>
		/// Determines whether the specified type in <see cref="FieldDescriptor.FieldType"/> is a supported type.
		/// </summary>
		/// <param name="error">The section definition error.</param>
		/// <returns><c>true</c> if the specified type is supported; otherwise, <c>false</c>.</returns>
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
		public bool Equals(StaticTextFieldDescriptor other)
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
