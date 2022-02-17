using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// The exception that is thrown when an Automation Script timed out.
	/// </summary>
	public class ScriptTimeoutException : DataMinerException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptTimeoutException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public ScriptTimeoutException(string message)
		  : base(message)
		{
		}
	}
}
