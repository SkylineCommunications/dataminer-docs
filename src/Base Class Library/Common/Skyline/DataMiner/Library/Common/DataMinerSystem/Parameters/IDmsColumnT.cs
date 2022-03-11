namespace Skyline.DataMiner.Library.Common
{
	using Skyline.DataMiner.Library.Common.Subscription.Waiters;

	using System;

	/// <summary>
	/// DataMiner table column interface of a specific type.
	/// </summary>
	/// <typeparam name="T">The type of the column.</typeparam>
	public interface IDmsColumn<T> : IDmsColumn
	{
		/// <summary>
		/// Gets the value of the cell that corresponds with the specified primary key.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="primaryKey"/> is empty ("") or white space.
		/// </exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <returns>The cell value.</returns>
		T GetValue(string primaryKey);

		/// <summary>
		/// Sets the value of a cell in a table.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <param name="value">The value to set.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="primaryKey"/> or <paramref name="value"/> is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		void SetValue(string primaryKey, T value);
	}
}