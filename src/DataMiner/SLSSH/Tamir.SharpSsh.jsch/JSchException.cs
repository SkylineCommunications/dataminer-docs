using Tamir.SharpSsh.java;

namespace Tamir.SharpSsh.jsch
{
	/// <summary>
	/// Will be thrown if anything goes wrong with the SSH protocol.
	/// </summary>
	public class JSchException : java.Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JSchException"/> class.
		/// </summary>
		public JSchException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JSchException"/> class with the specified message.
		/// </summary>
		/// <param name="msg">The message.</param>
		public JSchException(string msg)
		  //: base(msg)
		{
		}
	}
}
