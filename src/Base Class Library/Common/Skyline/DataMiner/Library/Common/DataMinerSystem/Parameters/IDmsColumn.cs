namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// DataMiner table column interface.
	/// </summary>
	public interface IDmsColumn
	{
		/// <summary>
		/// Gets the column parameter ID.
		/// </summary>
		/// <value>The column parameter ID.</value>
		int Id { get; }

		/// <summary>
		/// Gets the table this column is part of.
		/// </summary>
		/// <value>The table this column is part of.</value>
		IDmsTable Table { get; }

		/// <summary>
		/// Retrieves the alarm level.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="primaryKey"/> is empty ("") or white space.
		/// </exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The alarm level.</returns>
		AlarmLevel GetAlarmLevel(string primaryKey);

		/// <summary>
		/// Gets the displayed value.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="primaryKey"/> is empty ("") or white space.
		/// </exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The displayed value.</returns>
		/// <remarks>Typically used for parameters that provide a discrete entry mapping.</remarks>
		string GetDisplayValue(string primaryKey);

		/// <summary>
		/// Gets the primary keys of the rows that have one of the specified values for the specified column.
		/// </summary>
		/// <param name="values">The values to find.</param>
		/// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="values"/> contains a null reference.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <returns>
		/// The primary keys of the rows that have the specified value for the specified column.
		/// </returns>
		string[] Lookup(IEnumerable<string> values);

		/// <summary>
		/// Gets the primary keys of the rows that have the specified value for the specified column.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <returns>
		/// The primary keys of the rows that have the specified value for the specified column.
		/// </returns>
		string[] Lookup(string value);
	}
}