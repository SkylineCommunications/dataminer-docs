namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Defines extension methods for <see cref="IDmsStandaloneParameter{T}"/> .
	/// </summary>
	public static class ExtensionsIDmsStandaloneParameter
    {
		/// <summary>
		/// Gets the parameter value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the standalone parameter value.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="defaultValue">The value to return if the HasValue property returns <c>false</c>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <see langword="null"/>.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsStandaloneParameter<T?> parameter, T defaultValue)
            where T : struct
        {
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}

            T? value = parameter.GetValue();

			return value == null ? defaultValue : value.Value;
		}

		/// <summary>
		/// Gets the parameter value or the specified default value.
		/// </summary>
		/// <typeparam name="T">The type of the standalone parameter value.</typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <see langword="null"/>.</exception>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The parameter value.</returns>
		public static T GetValueOrDefault<T>(this IDmsStandaloneParameter<T?> parameter)
			where T : struct
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}

			T? value = parameter.GetValue();

			return value == null ? default(T) : value.Value;
		}
	}
}