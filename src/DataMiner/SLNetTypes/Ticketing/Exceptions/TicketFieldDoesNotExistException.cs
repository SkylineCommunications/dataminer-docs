using System;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// The exception that is thrown when the ticket field does not exist. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
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
