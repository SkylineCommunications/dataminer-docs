using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Generic enum entry interface. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
    public interface IGenericEnumEntry
    {
		/// <summary>
		/// Gets the name of the enum entry.
		/// </summary>
		/// <value>The name of the enum entry.</value>
		string Name { get; }

		/// <summary>
		/// Gets the value of the enum entry.
		/// </summary>
		/// <value>The value of the enum entry.</value>
		object Value { get; }

		/// <summary>
		/// Gets the type of the enum entry value.
		/// </summary>
		/// <value>The type of the enum entry value.</value>
		Type ValueType { get; }

		/// <summary>
		/// Returns a string formatted as follows: name/value.
		/// </summary>
		/// <returns>A string formatted as follows: name/value.</returns>
		string ToFormattedString();
    }
}