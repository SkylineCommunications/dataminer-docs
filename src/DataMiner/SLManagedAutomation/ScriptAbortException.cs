using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// The exception that is thrown when the script is aborted.
	/// </summary>
	public class ScriptAbortException : DataMinerException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptAbortException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public ScriptAbortException(string message)
		  : base(message)
		{
		}
	}
}
