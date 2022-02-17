using System;

namespace Tamir.SharpSsh.jsch
{
	/// <summary>
	/// The exception that is thrown when an exception occurs during an SFTP operation.
	/// </summary>
	public class SftpException //: Tamir.SharpSsh.java.Exception
	{
		/// <summary>
		/// The error ID of the exception.
		/// </summary>
		public int id;

		/// <summary>
		/// The error message.
		/// </summary>
		[Obsolete("Use Message instead", false)]
		public string message;

		/// <summary>
		/// Initializes a new instance of the <see cref="SftpException"/> class with the specified error ID and message.
		/// </summary>
		/// <param name="id">The error ID.</param>
		/// <param name="message">The error message.</param>
		public SftpException(int id, string message)
		  : this(id, message, (System.Exception)null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SftpException"/> class with the specified error ID, message and inner exception.
		/// </summary>
		/// <param name="id">The error ID.</param>
		/// <param name="message">The error message.</param>
		/// <param name="innerException">The inner exception.</param>
		public SftpException(int id, string message, System.Exception innerException)
		  //: base(message, innerException)
		{
			this.message = message;
			this.id = id;
		}
	}
}
