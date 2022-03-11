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
		/// <param name="primaryKey">The primary key.</param>
		/// <param name="defaultValue">The value to return if the HasValue property returns <c>false</c>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="primaryKey"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string primaryKey, T defaultValue)
            where T : struct
        {
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

            T? value = column.GetValue(primaryKey);

			return value == null ? defaultValue : value.Value;
		}

		/// <summary>
		/// Gets the cell value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the values the column holds.</typeparam>
		/// <param name="column">The column.</param>
		/// <param name="primaryKey">The primary key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="column"/> or <paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="primaryKey"/> is empty ("") or white space.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsColumn<T?> column, string primaryKey)
			where T : struct
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			T? value = column.GetValue(primaryKey);

			return value == null ? default(T) : value.Value;
		}
	}
}