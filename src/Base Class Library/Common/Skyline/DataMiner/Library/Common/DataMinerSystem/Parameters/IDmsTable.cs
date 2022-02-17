namespace Skyline.DataMiner.Library.Common
{
	using System;
    using System.Collections.Generic;

    /// <summary>
    /// DataMiner table interface.
    /// </summary>
    public interface IDmsTable
    {
		/// <summary>
		/// Gets the element this table is part of.
		/// </summary>
		/// <value>The element this table is part of.</value>
		IDmsElement Element { get; }

		/// <summary>
		/// Gets the table parameter ID.
		/// </summary>
		/// <value>The table parameter ID.</value>
		int Id { get; }

		/// <summary>
		/// Adds the provided row to this table.
		/// </summary>
		/// <param name="data">The row data.</param>
		/// <exception cref="ArgumentNullException"><paramref name="data"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="IncorrectDataException">Invalid data was provided.</exception>
		void AddRow(object[] data);

		/// <summary>
		/// Removes the row with the specified primary key from the table.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row to remove.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="IncorrectDataException">Invalid data was provided.</exception>
		/// <remarks>If the table does not contain a row with the specified primary key, the table remains unchanged. No exception is thrown.</remarks>
		void DeleteRow(string primaryKey);

		/// <summary>
		/// Removes the rows with the specified primary keys from the table.
		/// </summary>
		/// <param name="primaryKeys">The primary keys of the rows to remove.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKeys"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">One of the primary keys is <see langword="null"/>.</exception>
		/// <exception cref="IncorrectDataException">Invalid data was provided.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <remarks>
		/// No exception is thrown when one or more of the provided primary keys does not exist in the table.
		/// In this case, only the rows with the provided primary keys that exist in the table are deleted.
		/// </remarks>
		void DeleteRows(IEnumerable<string> primaryKeys);

		/// <summary>
		/// Gets the specified column.
		/// </summary>
		/// <param name="parameterId">The parameter ID.</param>
		/// <typeparam name="T">The type of the column.</typeparam>
		/// <exception cref="ArgumentException"><paramref name="parameterId"/> is invalid.</exception>
		/// <exception cref="NotSupportedException">A type other than string, int?, double? or DateTime? was provided.</exception>
		/// <returns>The standalone parameter that corresponds with the specified ID.</returns>
		IDmsColumn<T> GetColumn<T>(int parameterId);

		/// <summary>
		/// Gets the table data.
		/// </summary>
		/// <param name="keyColumnIndex">The 0-based index of the key column.</param>
		/// <exception cref="ArgumentException"><paramref name="keyColumnIndex"/> is invalid.</exception>
		/// <exception cref="ParameterNotFoundException">The table parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The table data.</returns>
		IDictionary<string, object[]> GetData(int keyColumnIndex = 0);

		/// <summary>
		/// Gets the display key that corresponds with the specified primary key.
		/// </summary>
		/// <param name="primaryKey">The primary key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <returns>The display key that corresponds with the specified primary key.</returns>
		string GetDisplayKey(string primaryKey);

		/// <summary>
		/// Gets the display keys.
		/// </summary>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <returns>The display keys.</returns>
		string[] GetDisplayKeys();

		/// <summary>
		/// Retrieves the primary key that corresponds with the specified display key.
		/// </summary>
		/// <param name="displayKey">The display key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="displayKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <returns>The primary key that corresponds with the specified display key.</returns>
		string GetPrimaryKey(string displayKey);

		/// <summary>
		/// Retrieves the primary keys.
		/// </summary>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <returns>The primary keys.</returns>
		string[] GetPrimaryKeys();

		/// <summary>
		/// Retrieves the row with the specified primary key.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The provided value is the empty string ("") or white space.</exception>
		/// <exception cref="ParameterNotFoundException">The table parameter was not found.</exception>
		/// <exception cref="KeyNotFoundInTableException">The specified <paramref name="primaryKey"/> does not exist in the table.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The row formatted as an object array.</returns>
		object[] GetRow(string primaryKey);

		/// <summary>
		/// Retrieves the table rows.
		/// </summary>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The table formatted as an object array of columns.</returns>
		object[][] GetRows();

		/// <summary>
		/// Determines whether a row with the specified primary key exists in the table.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="primaryKey"/> is the empty string ("") or white space.</exception>
		/// <exception cref="IncorrectDataException">The provided data is invalid.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns><c>true</c> if the table contains a row with the specified primary key; otherwise, <c>false</c>.</returns>
		bool RowExists(string primaryKey);

		/// <summary>
		/// Updates the row with the provided data.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row that must be updated.</param>
		/// <param name="data">The new row data.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="data"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The provided primary key is the empty string ("") or white space.</exception>
		/// <exception cref="ParameterNotFoundException">The table parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void SetRow(string primaryKey, object[] data);

		/// <summary>
		/// Retrieves the rows that match the specified filters.
		/// </summary>
		/// <param name="filters">Filters used to filter rows.</param>
		/// <exception cref="ParameterNotFoundException">The table parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The rows that match the specified filters.</returns>
		/// <remarks>
		/// <para>Partial tables will be queried in the background per page, which has less impact on performance.</para>
		/// </remarks>
		IEnumerable<object[]> QueryData(IEnumerable<ColumnFilter> filters);
	}
}