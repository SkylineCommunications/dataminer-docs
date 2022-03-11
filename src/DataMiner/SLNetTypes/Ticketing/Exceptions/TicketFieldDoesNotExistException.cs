using System;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// The exception that is thrown when the ticket field does not exist.
	/// </summary>
	public class TicketFieldDoesNotExistException : Exception
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldDoesNotExistException"/> class.
		/// </summary>
		public TicketFieldDoesNotExistException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldDoesNotExistException"/> class using the specified message.
		/// </summary>
		public TicketFieldDoesNotExistException(string message) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldDoesNotExistException"/> class using the specified message and inner exception.
		/// </summary>
		public TicketFieldDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
