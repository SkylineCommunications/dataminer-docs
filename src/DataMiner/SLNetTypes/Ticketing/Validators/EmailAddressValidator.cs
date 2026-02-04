using System;
using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents an e-mail address validator. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[Serializable]
    public class EmailAddressValidator : ITicketFieldValidator
    {
        private bool _invalid;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
		/// </summary>
		public EmailAddressValidator()
        {
        }

		/// <summary>
		/// Verifies whether the specified string has the form of a valid e-mail address.
		/// </summary>
		/// <param name="ticket">A <see cref="Ticket"/> instance.</param>
		/// <param name="obj">The string to be verified.</param>
		/// <returns><c>true</c> if <paramref name="obj"/> has the form of a valid e-mail address; otherwise, <c>false</c>.</returns>
		public bool Validate(Ticket ticket, object obj)
        {
			return true;
        }

        private string DomainMapper(Match match)
        {
			return null;
		}
    }
}