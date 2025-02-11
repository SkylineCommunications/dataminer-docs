using System;
using System.Globalization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a (index, displaykey) pair of a dynamic table.
	/// </summary>
	[Serializable]
	public class DynamicTableIndex : IComparable<DynamicTableIndex>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicTableIndex"/> class.
		/// </summary>
		public DynamicTableIndex() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicTableIndex"/> class using the specified index and display key.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="display">The display key.</param>
		public DynamicTableIndex(string index, string display)
		{
		}

		private string _displayValue;

		/// <summary>
		/// Gets or sets the display key value.
		/// </summary>
		/// <value>The display key value.</value>
		public string DisplayValue
		{
			get => _displayValue;
			set => _displayValue = value;
		}

		private string _indexValue;

		/// <summary>
		/// Gets or sets the primary key value.
		/// </summary>
		/// <value>The primary key value.</value>
		public string IndexValue
		{
			get => _indexValue;
			set => _indexValue = value;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return String.Format(CultureInfo.InvariantCulture, "{0} [{1}]", DisplayValue, IndexValue);
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared.</returns>
		public int CompareTo(DynamicTableIndex other)
		{
			if (ReferenceEquals(other, null))
				return 1;

			if (ReferenceEquals(this, other))
				return 0;

			var result = String.Compare(IndexValue, other.IndexValue, StringComparison.OrdinalIgnoreCase);
			if (result != 0)
				return result;

			return String.Compare(DisplayValue, other.DisplayValue, StringComparison.OrdinalIgnoreCase);
		}
	}
}
