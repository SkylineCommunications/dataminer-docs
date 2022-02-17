using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.GenericEnums
{
    public interface IGenericEnum
    {
        string EnumName { get; }
        Type ValueType { get; }
        IReadOnlyList<IGenericEnumEntry> Entries { get; }
    }

    public interface IGenericEnumEntry
    {
        string DisplayName { get; }
        object Value { get; }
        Type ValueType { get; }
        bool IsHidden { get; }
    }

	/// <summary>
	/// Represents a generic enum.
	/// </summary>
	/// <typeparam name="T">The underlying type.</typeparam>
	[Serializable]
    //[DataContract]
    public class GenericEnum<T> : IEquatable<GenericEnum<T>>, IGenericEnum
    {
		/// <summary>
		/// Gets or sets the enum name.
		/// </summary>
		/// <value>The enum name.</value>
		//[DataMember(Name = "EnumName")]
        public string EnumName { get; set; }

		/// <summary>
		/// Gets the enum entries.
		/// </summary>
		/// <value>The enum entries.</value>
		//[DataMember(Name = "Entries")]
        public IReadOnlyList<GenericEnumEntry<T>> Entries
        {
			get;
        }

		/// <summary>
		/// Gets the enum entries.
		/// </summary>
		/// <value>The enum entries.</value>
		IReadOnlyList<IGenericEnumEntry> IGenericEnum.Entries { get; }

		/// <summary>
		/// Gets the underlying type.
		/// </summary>
		/// <value>The underlying type.</value>
		Type IGenericEnum.ValueType { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnum{T}"/> class.
		/// </summary>
		public GenericEnum()
        {
        }

		/// <summary>
		/// Adds a new entry to the enum with the specified display name and value.
		/// </summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="value">The value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="displayName"/> or <paramref name="value"/> is <see langword="null" />.</exception>
		/// <exception cref="InvalidOperationException">The specified display name or value is already added.</exception>
		public void AddEntry(string displayName, T value)
        {
        }

		/// <summary>
		/// Adds a new entry to the enum with the specified display name and value.
		/// </summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="value">The value.</param>
		/// <param name="isHidden">Value indicating whether this entry is hidden.</param>
		/// <exception cref="ArgumentNullException"><paramref name="displayName"/> or <paramref name="value"/> is <see langword="null" />.</exception>
		/// <exception cref="InvalidOperationException">The specified display name or value is already added.</exception>
		/// <remarks>Feature introduced in DataMiner 9.6.11 (RN 22628).</remarks>
		public void AddEntry(string displayName, T value, bool isHidden)
        {
        }

		/// <summary>
		/// Removes the entry with the specified display name.
		/// </summary>
		/// <param name="displayName">The display name of the entry to remove.</param>
		public void RemoveEntryByName(string displayName)
        {
        }

		/// <summary>
		/// Removes the entry with the specified value.
		/// </summary>
		/// <param name="value">The value of the entry to remove.</param>
		public void RemoveEntryByValue(T value)
        {
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
		public bool Equals(GenericEnum<T> other)
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
    }

	/// <summary>
	/// Represents a generic enum entry.
	/// </summary>
	/// <typeparam name="T">The underlying type.</typeparam>
	[Serializable]
    //[DataContract]
    public class GenericEnumEntry<T> : IEquatable<GenericEnumEntry<T>>, IGenericEnumEntry
    {
		/// <summary>
		/// Gets or sets the display name.
		/// </summary>
		/// <value>The display name.</value>
		//[DataMember(Name = "DisplayName")]
        public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		//[DataMember(Name = "Value")]
        public T Value { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this entry is hidden.
		/// </summary>
		/// <value><c>true</c> if this entry is hidden; otherwise, <c>false</c>.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.11 (RN 22628).</remarks>
		//[DataMember(Name = "IsHidden")]
        public bool IsHidden { get; set; }

		/// <summary>
		/// Gets the underlying type.
		/// </summary>
		/// <value>The underlying type.</value>
		Type IGenericEnumEntry.ValueType { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		object IGenericEnumEntry.Value { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnumEntry{T}"/> class.
		/// </summary>
		public GenericEnumEntry() : this(string.Empty, default(T))
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnumEntry{T}"/> class using the specified display name and value.
		/// </summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="value">The value.</param>
		public GenericEnumEntry(string displayName, T value) : this(displayName, value, false)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnumEntry{T}"/> class using the specified display name and value.
		/// </summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="value">The value.</param>
		/// <param name="isHidden">Value indicating whether this entry is hidden.</param>
		/// <remarks>Feature introduced in DataMiner 9.6.11 (RN 22628).</remarks>
		public GenericEnumEntry(string displayName, T value, bool isHidden)
        {
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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(GenericEnumEntry<T> other)
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
    }
}
