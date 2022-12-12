namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Defines extension methods for <see cref="IDmsColumn{T}"/>.
	/// </summary>
	public static class ExtensionsIDmsColumn
    {
		/// <summary>
		/// Gets the cell value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the values the column holds.</typeparam>
		/// <param name="column">The column.</param>
		/// <param name="key">The key.</param>
		/// <param name="defaultValue">The value to return if the HasValue property returns <c>false</c>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		/// <remarks>
		/// <para>The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned (only the case when the naming option or NamingFormat is in the protocol XML is used, not for the deprecated displayColumn attribute).</para>
		/// <para>Do not use this call with primary keys in case the primary key value is also used as display key of another row.</para>
		/// <para>This overload is deprecated. Use the overload with the additional KeyType argument instead.</para>
		/// </remarks>
		[Obsolete("Use the overload with the additional KeyType argument instead.")]
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string key, T defaultValue)
            where T : struct
        {
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

            T? value = column.GetValue(key);

			return value == null ? defaultValue : value.Value;
		}

		/// <summary>
		/// Gets the cell value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the values the column holds.</typeparam>
		/// <param name="column">The column.</param>
		/// <param name="key">The key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		/// <remarks>
		/// <para>The key is assumed to be the display key. If no display key was found with the specified value, but a row exists with a primary key with the specified value, then the value of that row will be returned (only the case when the naming option or NamingFormat is in the protocol XML is used, not for the deprecated displayColumn attribute).</para>
		/// <para>Do not use this call with primary keys in case the primary key value is also used as display key of another row.</para>
		/// <para>This overload is deprecated. Use the overload with the additional KeyType argument instead.</para>
		/// </remarks>
		[Obsolete("Use the overload with the additional KeyType argument instead.")]
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string key)
			where T : struct
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			T? value = column.GetValue(key);

			return value == null ? default(T) : value.Value;
		}

		/// <summary>
		/// Gets the cell value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the values the column holds.</typeparam>
		/// <param name="column">The column.</param>
		/// <param name="key">The key.</param>
		/// <param name="keyType">The key type.</param>
		/// <param name="defaultValue">The value to return if the HasValue property returns <c>false</c>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string key, KeyType keyType, T defaultValue)
			where T : struct
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			T? value = column.GetValue(key, keyType);

			return value == null ? defaultValue : value.Value;
		}

		/// <summary>
		/// Gets the cell value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the values the column holds.</typeparam>
		/// <param name="column">The column.</param>
		/// <param name="key">The key.</param>
		/// <param name="keyType">The key type.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="key"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string key, KeyType keyType)
			where T : struct
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			T? value = column.GetValue(key, keyType);

			return value == null ? default(T) : value.Value;
		}
	}
}