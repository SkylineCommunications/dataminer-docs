using System;

namespace Tamir.SharpSsh
{
	/// <summary>
	/// The exception that is thrown when an error occurs during the SSH transfer.
	/// </summary>
	public class SshTransferException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SshTransferException"/> with a specified error message.
		/// </summary>
		/// <param name="msg">The error message.</param>
		public SshTransferException(string msg)
		  : base(msg)
		{
		}
	}
}