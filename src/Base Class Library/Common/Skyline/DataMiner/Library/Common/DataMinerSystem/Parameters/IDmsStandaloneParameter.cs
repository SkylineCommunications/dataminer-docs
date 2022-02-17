namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner standalone parameter interface.
	/// </summary>
	public interface IDmsStandaloneParameter
	{
		/// <summary>
		/// Gets the element this parameter is part of.
		/// </summary>
		/// <value>The element this parameter is part of.</value>
		IDmsElement Element { get; }

		/// <summary>
		/// Gets the ID of this parameter.
		/// </summary>
		/// <value>The ID of this parameter.</value>
		int Id { get; }

		/// <summary>
		/// Retrieves the alarm level.
		/// </summary>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The alarm level.</returns>
		AlarmLevel GetAlarmLevel();

		/// <summary>
		/// Gets the displayed value.
		/// </summary>
		/// <exception cref="ParameterNotFoundException">The parameter was not found.</exception>
		/// <exception cref="ElementStoppedException">The element is stopped.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The displayed value.</returns>
		string GetDisplayValue();
	}
}