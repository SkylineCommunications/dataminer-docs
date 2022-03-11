
namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Defines closing mode values.
	/// </summary>
	public enum ClosingMode
    {
        /// <summary>
        /// This value is seen as the 'True' state. Closing a window must continue.
        /// </summary>
        Continue = 0,
        /// <summary>
        /// This value is seen as the 'False' state. Closing a window must be prevented.
        /// </summary>
        Stop,
        /// <summary>
        /// This value is seen as the 'Undefined' state. The window will be closed, but it is caused by external reasons (connection problems, invalid arguments, exceptions, undesired (UI) behavior, etc.).
        /// </summary>
        Abort,
    }
}
