using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a value wrapper.
	/// </summary>
	public interface IValueWrapper : ICloneable
    {
		/// <summary>
		/// Gets the type of the value.
		/// </summary>
		/// <value>The type of the value.</value>
		Type Type { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		object Value { get; }

		/// <summary>
		/// Adds this object to the specified collection.
		/// </summary>
		/// <param name="collection">The collection to add this object to.</param>
		/// <returns>The specified collection with this item added.</returns>
		IList Collect(IList collection);
    }

}
