using System;
using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a field value.
	/// </summary>
	/// <remarks>A <see cref="FieldValue"/> contains a value and a reference its corresponding field descriptor (<see cref="FieldDescriptor"/>).</remarks>
	[Serializable]
    //[DataContract]
    public class FieldValue : IEquatable<FieldValue>, ICloneable
    {
        #region Fields & Properties

		/// <summary>
		/// Gets or sets the field descriptor ID.
		/// </summary>
		/// <value>The field descriptor ID.</value>
		public FieldDescriptorID FieldDescriptorID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		//[DataMember(Name = "Value")]
        public IValueWrapper Value { get; set; }

		#endregion Fields & Properties

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValue"/> class.
		/// </summary>
		public FieldValue()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValue"/> class using the specified field descriptor ID.
		/// </summary>
		/// <param name="existingDescriptorID">The field descriptor ID.</param>
		public FieldValue(FieldDescriptorID existingDescriptorID)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValue"/> class using the specified field descriptor ID and value.
		/// </summary>
		/// <param name="existingDescriptorID">The field descriptor ID.</param>
		/// <param name="value">The value.</param>
		public FieldValue(FieldDescriptorID existingDescriptorID, IValueWrapper value)
            : this(existingDescriptorID)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValue"/> class using the specified field descriptor.
		/// </summary>
		/// <param name="existingDescriptor">The field descriptor.</param>
		/// <exception cref="ArgumentNullException"><paramref name="existingDescriptor"/> is <see langword="null"/>.</exception>
		public FieldValue(FieldDescriptor existingDescriptor)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldValue"/> class using the specified field descriptor.
		/// </summary>
		/// <param name="existingDescriptor">The field descriptor.</param>
		/// <param name="value">The value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="existingDescriptor"/> is <see langword="null"/>.</exception>
		public FieldValue(FieldDescriptor existingDescriptor, IValueWrapper value)
            : this(existingDescriptor)
        {
        }

		#endregion Constructors

		#region Public methods
		/// <summary>
		/// Retrieves the ID string.
		/// </summary>
		/// <returns>The ID string.</returns>
		public string GetDictFieldName()
        {
			return "";
        }

		/// <summary>
		/// Retrieves the field descriptor.
		/// </summary>
		/// <returns>The field descriptor.</returns>
		/// <exception cref="DataMinerException">The FieldValue was not yet stitched to the FieldDescriptor.</exception>
		public FieldDescriptor GetFieldDescriptor()
        {
			return null;
		}

		/// <summary>
		/// Stitches the FieldValue to the corresponding FieldDescriptor.
		/// </summary>
		/// <param name="fieldDescriptorProvider">The corresponding field description provider.</param>
		public void Stitch(Func<FieldDescriptorID, FieldDescriptor> fieldDescriptorProvider)
        {
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		#endregion Public methods

		#region Equals, Hash & ToString
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(FieldValue other)
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
            return 1;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

        #endregion Equals, Hash & ToString
    }
}