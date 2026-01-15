using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a type validator for validating the type of a specified object. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	/// <typeparam name="T">The type to validate against.</typeparam>
	[Serializable]
    public class TypeValidator<T> : ITicketFieldValidator
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="TypeValidator{T}" /> class.
		/// </summary>
		public TypeValidator()
        {
        }

		/// <summary>
		/// Verifies whether the specified object is of the expected type.
		/// </summary>
		/// <param name="ticket">The ticket.</param>
		/// <param name="obj">The item to validate.</param>
		/// <returns>If <paramref name="obj"/> is not <see langword="null"/>, <c>true</c> is returned if the type of <paramref name="obj"/> equals the type of <typeparamref name="T"/>; otherwise, <c>false</c>.
		/// If <paramref name="obj"/> is <see langword="null"/>, <c>true</c> is returned if the type of <typeparamref name="T"/> is either a reference type or a nullable type; otherwise, <c>false</c>.
		/// </returns>
		public virtual bool Validate(Ticket ticket, object obj)
        {
            return false;
        }
    }
}
