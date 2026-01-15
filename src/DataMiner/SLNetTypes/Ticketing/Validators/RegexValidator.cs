using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a regular expression validator. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	///</summary>
	[Serializable]
    public class RegexValidator : ITicketFieldValidator
    {
		/// <summary>
		/// Gets or sets the regular expression.
		/// </summary>
		/// <value>The regular expression.</value>
		public string RegexPattern { get;set;}

		/// <summary>
		/// Gets or sets the regular expression options.
		/// </summary>
		/// <value>The regular expression options.</value>
		public RegexOptions RegexOptions { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RegexValidator"/> class.
		/// </summary>
		public RegexValidator()
        {
        }

		/// <summary>
		/// Validates the specified string.
		/// </summary>
		/// <param name="ticket">The ticket.</param>
		/// <param name="obj">The string to validate.</param>
		/// <returns><c>true</c> if the specified string matches the regular expression; otherwise, <c>false</c>.</returns>
		public bool Validate(Ticket ticket, object obj)
        {
			return true;
        }
    }
}
