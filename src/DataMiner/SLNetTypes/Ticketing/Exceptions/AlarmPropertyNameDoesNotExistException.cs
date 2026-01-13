using System;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// The exception that is thrown when no alarm property exists with the specified name. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	public class AlarmPropertyNameDoesNotExistException : Exception
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmPropertyNameDoesNotExistException"/> class.
		/// </summary>
		public AlarmPropertyNameDoesNotExistException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmPropertyNameDoesNotExistException"/> class using the specified message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public AlarmPropertyNameDoesNotExistException(string message) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmPropertyNameDoesNotExistException"/> class using the specified message and inner exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not <see langword="null"/>, the current exception is raised in a catch block that handles the inner exception.</param>
		public AlarmPropertyNameDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
