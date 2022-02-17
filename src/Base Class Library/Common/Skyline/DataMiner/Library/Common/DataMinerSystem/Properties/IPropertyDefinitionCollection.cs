namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;
	using Skyline.DataMiner.Library.Common.Properties;

	/// <summary>
	/// Property definition collection interface.
	/// </summary>
	/// <typeparam name="T">The property definition type.</typeparam>
	public interface IPropertyDefinitionCollection<out T> : IEnumerable<T> where T : IDmsPropertyDefinition
	{
		/// <summary>
		/// Gets the number of property definitions in this collection.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Gets the property definition associated with the specified name.
		/// </summary>
		/// <param name="property">The name of the property.</param>
		/// <returns>The property definition.</returns>
		T this[string property] { get; }
	}
}