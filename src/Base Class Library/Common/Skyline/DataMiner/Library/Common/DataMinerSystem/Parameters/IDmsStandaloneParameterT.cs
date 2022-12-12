namespace Skyline.DataMiner.Library.Common
{
	using System;

	using Skyline.DataMiner.Library.Common.Subscription.Waiters;

	/// <summary>
	/// DataMiner standalone parameter interface for a parameter of a specific type.
	/// </summary>
	/// <typeparam name="T">The type of the standalone parameter.</typeparam>
	public interface IDmsStandaloneParameter<T> : IDmsStandaloneParameter
	{
		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The parameter value.</returns>
		T GetValue();

		/// <summary>
		/// Sets the value of this parameter.
		/// </summary>
		/// <param name="value">The value to set.</param>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void SetValue(T value);

		/// <summary>
		/// Sets the value of this parameter. Waits on specified expected changes.
		/// </summary>
		/// <param name="value">The value to set.</param>
		/// <param name="timeout">Maximum time to wait for each expected change.</param>
		/// <param name="expectedChanges">One or more expected changes.</param>
		/// <returns>Every expected change as it happens on the system.</returns>
		/// <exception cref="ElementNotFoundException">The element was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="TimeoutException">Expected change took too long.</exception>
		/// <exception cref="FormatException">One of the provided parameters is missing data.</exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="expectedChanges"/> or <paramref name="value"/> is <see langword="null"/>.
		/// </exception>
		void SetValue(T value, TimeSpan timeout, ExpectedChanges expectedChanges);
	}
}