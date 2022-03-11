using System;
using System.Collections.Generic;

namespace SLLoggerUtil.LoggerCategoryUtil
{
	/// <summary>
	/// Represents a logger category.
	/// </summary>
	public interface ILoggerCategory : IEquatable<ILoggerCategory>
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <value>The parent.</value>
		ILoggerCategory Parent { get; }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		IEnumerable<ILoggerCategory> Children { get; }

		/// <summary>
		/// Adds the specified child category.
		/// </summary>
		/// <param name="child">The child category.</param>
		void AddChild(ILoggerCategory child);

		/// <summary>
		/// Determines whether this category contains the specified category.
		/// </summary>
		/// <param name="category">The category.</param>
		/// <returns><c>true</c> if this category has the specified category; otherwise, <c>false</c>.</returns>
		bool Contains(ILoggerCategory category);
	}
}