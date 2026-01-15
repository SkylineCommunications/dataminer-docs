using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a "generic" custom enum. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	/// <typeparam name="T">The underlying type of the enum.</typeparam>
	///// <remarks>
	///// Credit to Vulpes: http://www.c-sharpcorner.com/members/vulpes
	///// GenericEnum class: http://www.c-sharpcorner.com/uploadfile/b942f9/creating-generic-enums-using-C-Sharp/
	///// </remarks>
	[JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class GenericEnum<T>
    {
		#region Properties & fields
		/// <summary>
		/// Gets or sets the name of the enum.
		/// </summary>
		/// <value>The name of the enum.</value>
		[JsonProperty(Order = 1)]
        public string EnumName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether instance exceptions are allowed.
		/// </summary>
		/// <value><c>true</c> if instance exceptions are allowed; otherwise, <c>false</c>.</value>
		public bool AllowInstanceExceptions
        {
			get; set;
        }

		/// <summary>
		/// Gets the number of entries this generic enum contains.
		/// </summary>
		/// <value>The number of entries this generic enum contains.</value>
		public int Count => 0;

        protected int _index;

		/// <summary>
		/// Gets or sets the index.
		/// </summary>
		/// <value>The index.</value>
		/// <exception cref="ArgumentException">The value of a set operation is not between 0 and <see cref="Count"/> -1 (only in case <see cref="GenericEnum{T}.AllowInstanceExceptions"/> is <c>true</c>).</exception>
		[JsonProperty(Order = 3)]
        public int Index
        {
			get; set;
        }

		/// <summary>
		/// Gets the name of the entry at the index specified in <see cref="Index"/> or updates the <see cref="Index"/> with the index that corresponds with the set name.
		/// </summary>
		/// <value>The name of the entry.</value>
		/// <exception cref="ArgumentException">The value of a set operation is not a defined name (only in case <see cref="GenericEnum{T}.AllowInstanceExceptions"/> is <c>true</c>).</exception>
		public string Name
        {
			get; set;
        }

		/// <summary>
		/// Gets the value of the entry at the currently selected index or updates the <see cref="Index"/> with the index that corresponds with the set value.
		/// </summary>
		/// <value>The value of the entry.</value>
		/// <exception cref="ArgumentException">The value of a set operation is not a defined value (only in case <see cref="GenericEnum{T}.AllowInstanceExceptions"/> is <c>true</c>).</exception>
		public T Value
        {
			get; set;
        }

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEnum{T}"/> class.
		/// </summary>
		/// <remarks><see cref="AllowInstanceExceptions"/> is <c>true</c> by default.</remarks>
		public GenericEnum()
        {
        }

		/// <summary>
		/// Retrieves the names of the entries defined in this enum.
		/// </summary>
		/// <returns>The names of the entries defined in this enum.</returns>
		public string[] GetNames()
        {
			return null;
        }

		/// <summary>
		/// Retrieves the names of the entries that have the specified value as value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The names of the entries that have the specified value as value. In case no entries have the specified value, an empty array is returned</returns>
		public string[] GetNames(T value)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the values for the entries defined in this enum.
		/// </summary>
		/// <returns>The values for the entries defined in this enum.</returns>
		public T[] GetValues()
        {
			return null;
		}

		/// <summary>
		/// Retrieves the entries defined in this enum.
		/// </summary>
		/// <returns>The entries defined in this enum.</returns>
		public GenericEnumEntry<T>[] GetEntries()
        {
			return null;
		}

		/// <summary>
		/// Retrieves the indices of the entries that have the specified value as value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The indices of the entries that have the specified value as value.</returns>
		public int[] GetIndices(T value)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the index of the entry with the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>The index of the entry with the specified name. If there is no entry with the specified name, -1 is returned.</returns>
		public int IndexOf(string name)
        {
			return 0;
		}

		/// <summary>
		/// Retrieves the value of the entry with the specified name.
		/// </summary>
		/// <param name="name">The name of the entry for which the value must be retrieved.</param>
		/// <returns>The value of the entry with the specified name.</returns>
		/// <exception cref="ArgumentException">There is no entry with the specified name.</exception>
		public T ValueOf(string name)
        {
			return default(T);
		}

		/// <summary>
		/// Retrieves the name of the first entry with the specified value.
		/// </summary>
		/// <param name="value">The value of the entry.</param>
		/// <returns>The name of the first entry with the specified value.</returns>
		/// <exception cref="ArgumentException">There is no entry with the specified value.</exception>
		public string FirstNameWith(T value)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the index of the first entry with the specified value.
		/// </summary>
		/// <param name="value">The value of the entry.</param>
		/// <returns>The index of the first entry with the specified value.</returns>
		/// <exception cref="ArgumentException">There is no entry with the specified value.</exception>
		public int FirstIndexWith(T value)
        {
			return 0;
		}

		/// <summary>
		/// Retrieves the name of the entry at the specified index.
		/// </summary>
		/// <param name="index">The index of the entry.</param>
		/// <returns>The name of the entry at the specified index.</returns>
		/// <exception cref="IndexOutOfRangeException">The specified index is not in the range [0, <see cref="Count"/> -1].</exception>
		public string NameAt(int index)
        {
			return "";
		}

		/// <summary>
		/// Retrieves the value of the entry at the specified index.
		/// </summary>
		/// <param name="index">The index of the entry.</param>
		/// <returns>The value of the entry at the specified index.</returns>
		/// <exception cref="IndexOutOfRangeException">The specified index is not in the range [0, <see cref="Count"/> -1].</exception>
		public T ValueAt(int index)
        {
			return default(T);
		}

		/// <summary>
		/// Retrieves a value indicating whether this enum has an entry with the specified name.
		/// </summary>
		/// <param name="name">The name of the entry.</param>
		/// <returns><c>true</c> if this enum has an entry with the specified name; otherwise, <c>false</c>.</returns>
		public bool IsDefinedName(string name)
        {
            return false;
        }

		/// <summary>
		/// Retrieves a value indicating whether this enum has an entry with the specified value.
		/// </summary>
		/// <param name="value">The value of the entry.</param>
		/// <returns><c>true</c> if this enum has an entry with the specified value; otherwise, <c>false</c>.</returns>
		public bool IsDefinedValue(T value)
        {
			return true;
		}

		/// <summary>
		/// Gets a value indicating whether this enum has an entry with the specified index.
		/// </summary>
		/// <param name="index">The index of the entry.</param>
		/// <returns><c>true</c> if this enum has an entry with the specified index; otherwise, <c>false</c>.</returns>
		public bool IsDefinedIndex(int index)
        {
			return false;
		}

		/// <summary>
		/// Adds an entry with the specified name and value.
		/// </summary>
		/// <param name="name">The name of the entry.</param>
		/// <param name="value">The value of the entry.</param>
		/// <exception cref="InvalidOperationException">There is already an entry with the specified name.</exception>
		public void DynamicAdd(string name, T value)
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
    }
}