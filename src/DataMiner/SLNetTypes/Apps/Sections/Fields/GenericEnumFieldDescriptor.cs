using Skyline.DataMiner.Net.GenericEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a generic enum field descriptor. This is a collection of display key pairs.
	/// </summary>
	/// <remarks><para>The supported types for display key pairs are (Note: these cannot be mixed):</para>
	/// <list type="bullet">
	/// <item>
	/// <description>display: <see cref="String"/>, key: <see cref="String"/></description>
	/// </item>
	/// <item>
	/// <description>display: <see cref="String"/>, key: <see cref="Int32"/></description>
	/// </item>
	/// </list>
	/// <para>Each value of this field descriptor must have one of the available key values of the generic enum.</para>
	/// <para>Note: A <see cref="IGenericEnumEntry"/> can be set to hidden, e.g. to implement a soft delete of options.</para>
	/// </remarks>
	[Serializable]
    //[DataContract]
    public class GenericEnumFieldDescriptor : FieldDescriptor, IEquatable<GenericEnumFieldDescriptor>
    {
		/// <summary>
		/// The supported generic enum types.
		/// </summary>
		public static readonly IReadOnlyList<Type> SupportedGenericEnumTypes = new List<Type>()
        {
            typeof(GenericEnum<string>),
            typeof(GenericEnum<int>),
        };

		/// <summary>
		/// Gets or sets the generic enum instance.
		/// </summary>
		//[DataMember(Name = "GenericEnumInstance")]
        public IGenericEnum GenericEnumInstance { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnumFieldDescriptor"/> class.
		/// </summary>
		public GenericEnumFieldDescriptor()
            : base()
        {
        }

		/// <summary>
		/// Determines whether the specified value has the valid type.
		/// </summary>
		/// <param name="valueWrapper">The value to check for the valid type.</param>
		/// <returns><c>true</c> if the type of value is valid; otherwise, <c>false</c>.</returns>
		public override bool IsValueOfValidType(IValueWrapper valueWrapper)
        {
			return true;
        }

		/// <summary>
		/// Determines whether the specified type in <see cref="FieldDescriptor.FieldType"/> is a supported type.
		/// </summary>
		/// <param name="error">The section definition error.</param>
		/// <returns><c>true</c> if the specified type is supported; otherwise, <c>false</c>.</returns>
		/// <remarks>If the type is supported, <paramref name="error"/> is <see langword="null" />.</remarks>
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
		public bool Equals(GenericEnumFieldDescriptor other)
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
