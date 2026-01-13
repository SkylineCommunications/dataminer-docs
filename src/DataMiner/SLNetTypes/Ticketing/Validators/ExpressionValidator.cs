using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a validator validating against an expression. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    public class ExpressionValidator : ITicketFieldValidator
    {
		/// <summary>
		/// Gets or sets the validating expression.
		/// </summary>
		/// <value>The validating expression.</value>
		public Expression<Func<Ticket, object, bool>> Validator
        {
			get; set;
        }

        [NonSerialized]
        protected Func<Ticket, object, bool> ValidateFunc;

        protected byte[] SerializedValidator;


		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionValidator"/> class.
		/// </summary>
		public ExpressionValidator()
        {
        }

		/// <summary>Validates the specified object against the expression.</summary>
		/// <param name="obj">The object to validate.</param>
		/// <param name="ticket">The ticket to use with the expression.</param>
		/// <returns><c>true</c> if <paramref name="obj"/> is valid; otherwise, <c>false</c>.</returns>
		public bool Validate(Ticket ticket, object obj)
        {
			return false;
        }
    }
}
