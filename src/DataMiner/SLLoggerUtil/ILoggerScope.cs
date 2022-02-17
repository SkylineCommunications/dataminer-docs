using System.Collections.Generic;

using SLLoggerUtil.ProvidedLoggerUtil.Types;

namespace SLLoggerUtil
{
	/// <summary>
	/// Represents a logger scope.
	/// </summary>
	public interface ILoggerScope
	{
		/// <summary>
		/// Checks whether the specified log level is enabled.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <returns><c>true</c> if enabled; otherwise, <c>false</c>.</returns>
		bool IsEnabled(LogLevel level);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="level"></param>
		/// <returns></returns>
		IEnumerable<IProvidedLogger> GetTargetsFor(LogLevel level);
	}
}