namespace Skyline.DataMiner.Library.Common.Properties
{
	using System.Collections.ObjectModel;

	/// <summary>
	/// DataMiner property definition interface.
	/// </summary>
	public interface IDmsPropertyDefinition : IDmsObject
    {
		/// <summary>
		/// Gets the property name.
		/// </summary>
        string Name { get; }

		/// <summary>
		/// Gets the property entries.
		/// </summary>
        ReadOnlyCollection<IDmsPropertyEntry> Entries { get; }

		/// <summary>
		/// Gets the property ID.
		/// </summary>
        int Id { get; }

		/// <summary>
		/// Gets a value indicating whether the property is available for alarm filtering.
		/// </summary>
        bool IsAvailableForAlarmFiltering { get; }

		/// <summary>
		/// Gets a value indicating whether the property is read-only.
		/// </summary>
		bool IsReadOnly { get; }

		/// <summary>
		/// Gets a value indicating whether the property is visible in the Surveyor.
		/// </summary>
		bool IsVisibleInSurveyor { get; }

		/// <summary>
		/// Gets the regular expression the property value must conform to.
		/// </summary>
        string Regex { get; }

        /// <summary>
        /// Checks if the provided input value matches the definition of the property.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
        bool IsValidInput(string value);
    }
}