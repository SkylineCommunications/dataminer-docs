using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLLoggerUtil
{
	/// <summary>
	/// Log info event class.
	/// </summary>
	public class LogEventInfo
	{
		/// <summary>
		/// Gets the time stamp.
		/// </summary>
		/// <value>The time stamp.</value>
		public DateTimeOffset Timestamp { get; }

		/// <summary>
		/// Gets the logger that created this event.
		/// </summary>
		/// <value>The logger that created this event.</value>
		public ILogger Logger { get; }

		/// <summary>
		/// Gets the log level.
		/// </summary>
		/// <value>The log level.</value>
		public LogLevel LogLevel { get; }

		/// <summary>
		/// Gets the logger scope.
		/// </summary>
		/// <value>The logger scope.</value>
		public ILoggerScope LoggerScope { get; }

		/// <summary>
		/// Gets the arguments.
		/// </summary>
		/// <value>The arguments.</value>
		public object[] Args { get; }

		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; }

		/// <summary>
		/// Creates a new instance of LogEventInfo.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="logLevel">The log level.</param>
		/// <param name="message">The message.</param>
		/// <param name="loggerScope">The logger scope.</param>
		/// <param name="args">The arguments.</param>
		/// <returns>The <see cref="LogEventInfo"/> instance.</returns>
		public static LogEventInfo Create(
			ILogger logger,
			LogLevel logLevel,
			string message,
			ILoggerScope loggerScope,
			params object[] args)
		{
			return null;
		}
	}
}
