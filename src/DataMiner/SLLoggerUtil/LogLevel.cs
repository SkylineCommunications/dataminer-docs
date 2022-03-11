#region Assembly SLLoggerUtil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9789b1eac4cb1b12
// C:\Server Code Debugging\RC\server\Import\Skyline\bin\SLLoggerUtil.dll
#endregion

using System;
using System.Collections.Generic;

namespace SLLoggerUtil
{
	/// <summary>
	/// Represents a log level.
	/// </summary>
	public sealed class LogLevel : IEquatable<LogLevel>, IComparable
	{
		/// <summary>
		/// Gets all log levels.
		/// </summary>
		/// <value>All log levels.</value>
		public static IEnumerable<LogLevel> AllLogLevels { get; }

		/// <summary>
		/// Gets the log level representing the 'Off' level.
		/// </summary>
		/// <value>The log level representing the 'Off' level.</value>
		public static LogLevel Off { get; }

		/// <summary>
		/// Gets the log level representing the 'Fatal' level.
		/// </summary>
		/// <value>The log level representing the 'Fatal' level.</value>
		public static LogLevel Fatal { get; }

		/// <summary>
		/// Gets the log level representing the 'Error' level.
		/// </summary>
		/// <value>The log level representing the 'Error' level.</value>
		public static LogLevel Error { get; }

		/// <summary>
		/// Gets the log level representing the 'Warning' level.
		/// </summary>
		/// <value>The log level representing the 'Warning' level.</value>
		public static LogLevel Warn { get; }

		/// <summary>
		/// Gets the log level representing the 'Trace' level.
		/// </summary>
		/// <value>The log level representing the 'Trace' level.</value>
		public static LogLevel Trace { get; }

		/// <summary>
		/// Gets the log level representing the 'Debug' level.
		/// </summary>
		/// <value>The log level representing the 'Debug' level.</value>
		public static LogLevel Debug { get; }

		/// <summary>
		/// Gets the log level representing the 'Info' level.
		/// </summary>
		/// <value>The log level representing the 'Info' level.</value>
		public static LogLevel Info { get; }

		/// <summary>
		/// Gets the level.
		/// </summary>
		/// <value>The level.</value>
		public int Level { get; }

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; }

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// <para>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="obj"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(object obj) { return 0; }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) { return true; }

		/// <summary>
		/// Determines whether the specified <see cref="LogLevel"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public bool Equals(LogLevel other) { return true; }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode() { return 0; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object, formatted as follows: [Name]/[Version].</returns>
		public override string ToString() { return ""; }

		public static bool operator ==(LogLevel level1, LogLevel level2) { return true; }
		public static bool operator !=(LogLevel level1, LogLevel level2) { return true; }
		public static bool operator <(LogLevel level1, LogLevel level2) { return true; }
		public static bool operator >(LogLevel level1, LogLevel level2) { return true; }
		public static bool operator <=(LogLevel level1, LogLevel level2) { return true; }
		public static bool operator >=(LogLevel level1, LogLevel level2) { return true; }
	}
}