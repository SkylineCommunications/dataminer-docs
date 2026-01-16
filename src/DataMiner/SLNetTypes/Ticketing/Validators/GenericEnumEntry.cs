using System;
using Newtonsoft.Json;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents an entry of a <see cref="GenericEnum{T}"/> instance. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	/// <typeparam name="T">The underlying type of the entry.</typeparam>
	[JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class GenericEnumEntry<T> : IEquatable<GenericEnumEntry<T>>, IGenericEnumEntry
    {
		/// <summary>
		/// Gets or sets the name of the entry.
		/// </summary>
		/// <value>The name of the entry.</value>
		[JsonProperty]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the value of the entry.
		/// </summary>
		/// <value>The value of the entry.</value>
		[JsonProperty]
        public T Value { get; set; }

		/// <summary>
		/// Gets the type of the enum entry value.
		/// </summary>
		/// <value>The type of the enum entry value.</value>
		Type IGenericEnumEntry.ValueType => typeof(T);

		/// <summary>
		/// Gets the value of the enum entry.
		/// </summary>
		/// <value>The value of the enum entry.</value>
		object IGenericEnumEntry.Value => Value;

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnumEntry{T}"/> class.
		/// </summary>
		public GenericEnumEntry()
        {
        }

		/// <summary>
		/// Creates a new entry with the specified name and value.
		/// </summary>
		/// <param name="name">The name of the entry.</param>
		/// <param name="value">The value of the entry.</param>
		/// <returns>The newly created entry.</returns>
		public static GenericEnumEntry<T> Create(string name, T value)
        {
			return null;
		}

		/// <summary>
		/// Conversion operator from <see cref="GenericEnumEntry{T}"/> to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="entry">The entry to convert.</param>
		/// <returns>The converted entry.</returns>
		public static implicit operator T (GenericEnumEntry<T> entry)
        {
			return default(T);
		}

		/// <summary>
		/// Returns a string formatted as follows: name/value.
		/// </summary>
		/// <returns>A string formatted as follows: name/value.</returns>
		public string ToFormattedString()
        {
			return null;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>If <paramref name="obj"/> is of type <typeparamref name="T"/>, then this method returns <c>true</c> if the value is equal; otherwise, <c>false</c>.</para>
		/// <para>If <paramref name="obj"/> is of type <see cref="GenericEnumEntry{T}"/>, then this method returns <c>true</c> if the name and value are equal; otherwise, <c>false</c></para>
		/// </remarks>
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
		///  Determines whether the specified <see cref="GenericEnumEntry{T}"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Entries are considered equal if their name and value are the same.</para>
		/// </remarks>
		public bool Equals(GenericEnumEntry<T> other)
        {
			return true;
		}
    }
}