using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// The exception that is thrown when user interaction is attempted on a script that has been detached from the client.
	/// </summary>
	public class InteractiveUserDetachedException : DataMinerException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InteractiveUserDetachedException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public InteractiveUserDetachedException(string message) { }
	}
}
