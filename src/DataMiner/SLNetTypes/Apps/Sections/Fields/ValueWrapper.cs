using System;
using System.Collections;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a wrapped value.
	/// </summary>
	/// <typeparam name="T">The type of the value that is wrapped.</typeparam>
	[Serializable]
    //[DataContract]
    public class ValueWrapper<T> : IEquatable<ValueWrapper<T>>, IValueWrapper
    {
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		//[DataMember(Name = "Value")]
        public T Value { get; private set; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <alue>The value.</alue>
		//[IgnoreDataMember]
        object IValueWrapper.Value => Value;

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		//[IgnoreDataMember]
        Type IValueWrapper.Type => typeof(T);

		/// <summary>
		/// Initializes a new instance of the <see cref="ValueWrapper{T}"/> class.
		/// </summary>
		public ValueWrapper()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ValueWrapper{T}"/> class using the specified value.
		/// </summary>
		/// <param name="value">The value to wrap.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
		public ValueWrapper(T value)
        {
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(ValueWrapper<T> other)
        {
            return false;
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

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Adds the value of this object to the specified collection.
		/// </summary>
		/// <param name="collection">The collection to add this object to.</param>
		/// <returns>The specified collection with this item added.</returns>
		public IList Collect(IList collection)
        {
			return null;
		}
    }
}