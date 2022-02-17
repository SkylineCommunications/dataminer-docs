namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies the log type.
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// No logging.
		/// </summary>
		None = 0,
		/// <summary>
		/// Informational logging.
		/// </summary>
		Information = 1,
		/// <summary>
		/// Error logging.
		/// </summary>
		Error = 2,
		/// <summary>
		/// Debug logging.
		/// </summary>
		Debug = 4,
		/// <summary>
		/// Always.
		/// </summary>
		Always = 8
	}
}