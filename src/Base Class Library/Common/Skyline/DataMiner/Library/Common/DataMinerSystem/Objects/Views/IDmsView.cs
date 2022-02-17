namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;
	using Properties;
	using System;

	/// <summary>
	/// DataMiner view interface.
	/// </summary>
	public interface IDmsView : IDmsObject, IUpdateable
    {
		/// <summary>
		/// Gets all child views.
		/// </summary>
		/// <value>The child views.</value>
		IList<IDmsView> ChildViews { get; }

        /// <summary>
        /// Gets the display string.
        /// </summary>
		/// <value>The display string.</value>
        string Display { get; }

		/// <summary>
		/// Gets all elements that are immediate children of this view.
		/// </summary>
		/// <value>The elements that are immediate children of this view.</value>
		IList<IDmsElement> Elements { get; }

		/// <summary>
		/// Gets the ID of this view.
		/// </summary>
		/// <value>The view ID.</value>
		int Id { get; }

		/// <summary>
		/// Gets or sets the name of the view.
		/// </summary>
		/// <value>The view name.</value>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The value of a set operation is invalid.</exception>
		/// <remarks>
		/// <para>The following restrictions apply to view names:</para>
		/// <list type="bullet">
		/// <item><para>Must not be empty ("") or white space.</para></item>
		/// <item><para>Must not exceed 200 characters.</para></item>
		/// <item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
		/// <item><para>Names may not contain the following character: '|' (pipe).</para></item>
		/// <item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
		/// </list>
		/// </remarks>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the parent view.
		/// </summary>
		/// <value>The parent view.</value>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <exception cref="NotSupportedException">The root view is assigned a parent view.</exception>
		/// <exception cref="NotSupportedException">The parent view is a self-reference.</exception>
		IDmsView Parent { get; set; }

        /// <summary>
        /// Gets the properties of this view.
        /// </summary>
        /// <value>The view properties.</value>
        IPropertyCollection<IDmsViewProperty, IDmsViewPropertyDefinition> Properties { get; }

		/// <summary>
		/// Removes the view from the DataMiner System.
		/// </summary>
		void Delete();
    }
}