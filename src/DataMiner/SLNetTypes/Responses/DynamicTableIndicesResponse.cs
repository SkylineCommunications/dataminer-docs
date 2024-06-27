using System;
using System.Globalization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Response to a <see cref="GetDynamicTableIndices"/> message.
	/// </summary>
	[Serializable]
	public class DynamicTableIndicesResponse : ResponseMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicTableIndicesResponse"/> class.
		/// </summary>
		public DynamicTableIndicesResponse()
		{
			this.Indices = new DynamicTableIndex[0];
		}

		/// <summary>
		/// The indices present in the table.
		/// </summary>
		public DynamicTableIndex[] Indices;

		/// <summary>
		/// Gets or sets the DataMier Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int DataMinerID { get; set; }

		/// <summary>
		/// Gets or sets the element ID.
		/// </summary>
		/// <value>The element ID.</value>
		public int ElementID { get; set; }

		/// <summary>
		/// Gets or sets the parameter ID.
		/// </summary>
		/// <value>The parameter ID.</value>
		public int ParameterID { get; set; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return String.Empty;
		}

		/// <summary>
		/// Retrieves the display key that corresponds with the specified primary key.
		/// </summary>
		/// <param name="key">The primary key.</param>
		/// <returns>The display key that corresponds with the specified primary key or <see langword="null"/> if <see cref="Indices"/> does not contain an entry with a primary key that equals <paramref name="key"/>.</returns>
		public string MapToDisplay(string key)
		{
			if ((key == null) || (Indices == null))
				return null;

			foreach (DynamicTableIndex info in Indices)
			{
				if (info == null)
					continue;

				if (String.Compare(info.IndexValue, key, true, CultureInfo.InvariantCulture) == 0)
					return info.DisplayValue;
			}

			return null;
		}

		/// <summary>
		/// Retrieves the primary key that corresponds with the specified display key.
		/// </summary>
		/// <param name="key">The display key.</param>
		/// <returns>The primary key that corresponds with the specified display key or <see langword="null"/> if <see cref="Indices"/> does not contain an entry with a display key that equals <paramref name="display"/>.</returns>
		public string MapToKey(string display)
		{
			if ((display == null) || (Indices == null))
				return null;

			foreach (DynamicTableIndex info in Indices)
			{
				if (info == null)
					continue;

				if (String.Compare(info.DisplayValue, display, true, CultureInfo.InvariantCulture) == 0)
					return info.IndexValue;
			}

			return null;
		}
	}
}

