using Skyline.DataMiner.Library.Common.Subscription.Waiters;

using System;

namespace Skyline.DataMiner.Library.Common
{
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
	}
}