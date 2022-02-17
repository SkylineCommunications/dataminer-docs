using System.Collections.Generic;

using SLLoggerUtil.LoggerCategoryUtil;
using SLLoggerUtil.ProvidedLoggerUtil.Types;

namespace SLLoggerUtil
{
	/// <summary>
	/// Logger interface.
	/// </summary>
	public interface ILogger : ILoggerBase
	{
		/// <summary>
		/// Gets the category for which the logger was created.
		/// </summary>
		/// <value>The category for which the logger was created.</value>
		ILoggerCategory Category { get; }

		/// <summary>
		/// Gets the additional name, i.e. something providing more details about the object for which the logger is created, e.g. some subject ID or instance name.
		/// </summary>
		/// <value>The additional name, i.e. something providing more details about the object for which the logger is created, e.g. some subject ID or instance name.</value>
		string AdditionalName { get; }

		/// <summary>
		/// Gets a value indicating whether is trace enabled.
		/// </summary>
		bool IsTraceEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether debug is enabled.
		/// </summary>
		/// <value><c>true</c> if debug is enabled; otherwise, <c>false</c>.</value>
		bool IsDebugEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether info is enabled.
		/// </summary>
		/// <value><c>true</c> if info is enabled; otherwise, <c>false</c>.</value>
		bool IsInfoEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether warning is enabled.
		/// </summary>
		/// <value><c>true</c> if warning is enabled; otherwise, <c>false</c>.</value>
		bool IsWarnEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether error is enabled.
		/// </summary>
		/// <value><c>true</c> if error is enabled; otherwise, <c>false</c>.</value>
		bool IsErrorEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether fatal is enabled.
		/// </summary>
		/// <value><c>true</c> if fatal is enabled; otherwise, <c>false</c>.</value>
		bool IsFatalEnabled { get; }

		/// <summary>
		/// Logs a trace message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Trace(string message, params object[] args);

		/// <summary>
		/// Logs a trace message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Trace(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Logs a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Debug(string message, params object[] args);

		/// <summary>
		/// Logs a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Debug(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Info(string message, params object[] args);

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Info(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Logs a warning  message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Warn(string message, params object[] args);

		/// <summary>
		/// Logs a warning message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Warn(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Error(string message, params object[] args);

		/// <summary>
		/// Logs an error message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Error(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Logs an error message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The arguments.</param>
		void Fatal(string message, params object[] args);

		/// <summary>
		/// Logs a fatal message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="args">The arguments.</param>
		void Fatal(string message, ILoggerScope scope, params object[] args);

		/// <summary>
		/// Performs a flush.
		/// </summary>
		void Flush();

		/// <summary>
		/// Begins a scope so that all logging contained in this scope will be logged if the category for which the scope is started is also enabled.
		/// </summary>
		ILoggerScope BeginScope(ILoggerScope parentScope = null);

		/// <summary>
		/// Gets the targets for the specified log level and scope.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="fromScope">The scope.</param>
		/// <returns>The targets.</returns>
		IEnumerable<IProvidedLogger> GetTargetsFor(LogLevel level, bool fromScope);
	}
}