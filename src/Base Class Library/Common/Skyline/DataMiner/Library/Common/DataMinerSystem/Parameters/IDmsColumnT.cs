namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// DataMiner table column interface of a specific type.
	/// </summary>
	/// <typeparam name="T">The type of the column.</typeparam>
	public interface IDmsColumn<T> : IDmsColumn
	{
		/// <summary>
		/// Gets the value of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="key"/> is empty ("") or white space.
		/// </exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">
		/// The element was not found in the DataMiner System.
		/// </exception>
		/// <returns>The cell value.</returns>
		/// <remarks>
		/// The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned.
		/// </remarks>
		T GetValue(string key);

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