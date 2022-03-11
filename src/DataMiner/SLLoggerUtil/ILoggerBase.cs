using System;

namespace SLLoggerUtil
{
	/// <summary>
	/// Logger base interface.
	/// </summary>
	public interface ILoggerBase : IDisposable
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name</value>
		string Name { get; }

		/// <summary>
		/// Check if the logger is enabled for the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns><c>true</c> if logging is enabled for this level, otherwise <c>false</c>.</returns>
		bool IsEnabled(LogLevel level);

		/// <summary>
		/// Logs an event
		/// </summary>
		/// <param name="logEvent">
		/// The log event.
		/// </param>
		void Log(LogEventInfo logEvent);
	}
}