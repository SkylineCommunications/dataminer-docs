using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// Represents a ticket history key comparer. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	public class TicketHistoryKeyComparer : IComparer<Tuple<DateTime, string>>
    {
		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>
		/// <para>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description><paramref name="x"/> is less than <paramref name="y"/>.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description><paramref name="x"/> equals <paramref name="y"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description><paramref name="x"/> is greater than <paramref name="y"/>.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int Compare(Tuple<DateTime, string> x, Tuple<DateTime, string> y)
        {
			return 1;
        }
    }
}
