namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;

	/// <summary>
	/// Property configuration collection interface.
	/// </summary>
	public interface IPropertConfigurationCollection : IEnumerable<PropertyConfiguration>
	{
		/// <summary>
		/// Gets the number of properties in this collection.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Gets the property configuration associated with the specified name.
		/// </summary>
		/// <param name="property">The name of the property.</param>
		/// <returns>The property configuration.</returns>
		PropertyConfiguration this[string property] { get; }
	}
}