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
		/// Retrieves the alarm level of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The alarm level.</returns>
		/// <remarks>
		/// <para>The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned (only the case if the naming option or NamingFormat is in the protocol XML is used, not for the deprecated displayColumn attribute).</para>
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
		/// var alarmLevel = column.GetAlarmLevel(displayKey);
		/// </code>
		/// </example>
		[Obsolete("Use the overload with the additional KeyType argument instead.")]
		AlarmLevel GetAlarmLevel(string key);

		/// <summary>
		/// Retrieves the alarm level of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <param name="keyType">The key type.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The alarm level.</returns>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// string primaryKey = "PK 1";
		/// var alarmLevel = column.GetAlarmLevel(primaryKey, KeyType.PrimaryKey);
		/// </code>
		/// </example>
		AlarmLevel GetAlarmLevel(string key, KeyType keyType);

		/// <summary>
		/// Gets the displayed value of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The displayed value.</returns>
		/// <remarks>
		/// <para>Typically used for parameters that provide a discrete entry mapping.</para>
		/// <para>The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned (only the case when the naming option or NamingFormat is in the protocol XML is used, not for the deprecated displayColumn attribute).</para>
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
		/// var displayValue = column.GetDisplayValue(displayKey);
		/// </code>
		/// </example>
		[Obsolete("Use the overload with the additional KeyType argument instead.")]
		string GetDisplayValue(string key);

		/// <summary>
		/// Gets the displayed value of the cell that corresponds with the specified key.
		/// </summary>
		/// <param name="key">The key of the row.</param>
		/// <param name="keyType">The key type.</param>
		/// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The displayed value.</returns>
		/// <remarks>
		/// <para>Typically used for parameters that provide a discrete entry mapping.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDmsElement element = myDms.GetElement(new DmsElementId(346, 100));
		/// var table = element.GetTable(1000);
		/// var column = table.GetColumn&lt;double?&gt;(1004);
		///
		/// string primaryKey = "PK 1";
		/// var displayValue = column.GetDisplayValue(primaryKey, KeyType.PrimaryKey);
		/// </code>
		/// </example>
		string GetDisplayValue(string key, KeyType keyType);

		/// <summary>
		/// Gets the primary keys of the rows that have one of the specified values for the specified indexed column.
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
		/// <remarks>
		/// Important: the column used for lookup needs to have the attribute indexColumn defined in the table ArrayOptions.
		/// Consider using the IDmsTable.QueryData as it may provide a more stable and efficient performance.
		/// </remarks>
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
		/// <remarks>
		/// Important: the column used for lookup needs to have the attribute indexColumn defined in the table ArrayOptions.
		/// Consider using the IDmsTable.QueryData as it may provide a more stable and efficient performance.
		/// </remarks>
		string[] Lookup(string value);
	}
}