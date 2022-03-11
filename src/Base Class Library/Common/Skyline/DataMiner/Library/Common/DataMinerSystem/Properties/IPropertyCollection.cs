namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using Skyline.DataMiner.Library.Common.Properties;

	/// <summary>
	/// Property collection interface.
	/// </summary>
	/// <typeparam name="TProperty">The property type.</typeparam>
	/// <typeparam name="TPropertyDefinition">The property definition type.</typeparam>
	public interface IPropertyCollection<TProperty, TPropertyDefinition> : IEnumerable<TProperty> where TProperty : IDmsProperty<TPropertyDefinition> where TPropertyDefinition : IDmsPropertyDefinition
	{
		/// <summary>
		/// Gets the number of properties in this collection.
		/// </summary>
		/// <value>The number of properties in this collection.</value>
		int Count { get; }

		/// <summary>
		/// Gets the property associated with the specified name.
		/// </summary>
		/// <param name="property">The name of the property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="property"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException">An invalid value that is not a member of the set of values.</exception>
		/// <returns>The property.</returns>
		TProperty this[string property] { get; }
	}
}