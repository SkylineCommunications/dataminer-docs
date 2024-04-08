namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Contains extension methods for the <see cref="SLProtocol"/> interface.
	/// </summary>
	public static class ProtocolExtenders
	{
		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="protocol">Object implementing SLProtocol instance.</param>
		/// <param name="message">The message to be logged.</param>
		/// <param name="logType">The logging type (default value: LogType.Allways).</param>
		/// <param name="logLevel">The logging level (default value: LogLevel.DevelopmentLogging).</param>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>The message will be logged in the log file of the element (located in C:\Skyline DataMiner\logging).</description>
		///			</item>
		///			<item>
		///				<description>The message will only be logged when the element logging has been configured to include messages of the specified type and level.</description>
		///			</item>
		///			<item>
		///				<description>This method is an extension method. The use of this extension method is preferred over the use of the Log method defined in the ISLProtocol interface as the parameters of type LogType and LogLevel increase readability.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.3.1 onwards (RN 34801), the message is limited to 5120 characters. When a larger message is provided, it will be truncated to this limit.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public static void Log(this SLProtocol protocol, string message, LogType logType = LogType.Allways, LogLevel logLevel = LogLevel.DevelopmentLogging)
		{
		}
	}
}