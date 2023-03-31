namespace Skyline.DataMiner.Library.Common
{

    using System;

	using Skyline.DataMiner.Library.Common.Selectors.Data;
	using Skyline.DataMiner.Library.Common.Subscription.Waiters;


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
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The cell value.</returns>
		/// <remarks>
		/// <para>The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned. This is only the case when the naming option or NamingFormat in the protocol XML is used, not for the deprecated displayColumn attribute.</para>
		/// <para>Do not use this call with primary keys in case the primary key value is also used as display key of another row.</para>
		/// <para>This overload is deprecated. Use the overload with the additional KeyType argument instead.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// string displayKey = "DK 1";
		/// var value = column.GetValue(displayKey);
		/// </code>
		/// </example>
		[Obsolete("Use the overload with the additional KeyType argument instead.")]
		T GetValue(string key);

		/// <summary>
		/// Gets the value of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <param name="keyType">The key type.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The cell value.</returns>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// string primaryKey = "PK 1";
		/// var value = column.GetValue(primaryKey, KeyType.PrimaryKey);
		/// </code>
		/// </example>
		T GetValue(string key, KeyType keyType);

		/// <summary>
		/// Sets the value of a cell in a table.
		/// </summary>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <param name="value">The value to set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// column.SetValue("PK 1", 10.0);
		/// </code>
		/// </example>
		void SetValue(string primaryKey, T value);


		/// <summary>
		/// Sets the value of a cell in a table.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <param name="keyType">The key type.</param>
		/// <param name="value">The value to set.</param>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// column.SetValue("PK 1", KeyType.PrimaryKey, 10.0);
		/// </code>
		/// </example>
		void SetValue(string key, KeyType keyType, T value);

		/// <summary>
		/// Sets the value of a cell in a table and waits on specified expected changes.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <param name="keyType">The key type.</param>
		/// <param name="value">The value to set.</param>
		/// <param name="timeout">The maximum time to wait on the expected change.</param>
		/// <param name="expectedChanges">One or more expected changes. Can be <see cref="CellValue"/> or <see cref="ParamValue"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/>, <paramref name="expectedChanges"/> is <see langword="null"/>.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="TimeoutException">Expected change took too long.</exception>
		/// <exception cref="FormatException">One of the provided parameters is missing data.</exception>
		void SetValue(string key, KeyType keyType, T value, TimeSpan timeout, ExpectedChanges expectedChanges);
	}
}
