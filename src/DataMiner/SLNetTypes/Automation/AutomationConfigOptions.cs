using System;
using System.Globalization;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Abstract class from which the other Automation options classes are derived.
	/// </summary>
	/// <remarks>
	/// <para>The structure of these classes is as follows, with the subclasses inheriting all properties of the classes above them:</para>
	/// <img src="~/develop/images/AutomationUIConfigOptions_diagram.png" />
	/// </remarks>
	public abstract class AutomationConfigOptions
	{
		/// <summary>
		/// Gets the class splitter character.
		/// </summary>
		/// <value>The class splitter character.</value>
		protected static char ClassSplitter { get; private set; }

		/// <summary>
		/// Gets the options splitter character.
		/// </summary>
		/// <value>The options splitter character.</value>
		protected static char OptionSplitter { get; private set; }

		/// <summary>
		/// Gets the property splitter character.
		/// </summary>
		/// <value>The property splitter character.</value>
		protected static char PropertySplitter { get; private set; }

		/// <summary>
		/// Gets the global date time format.
		/// </summary>
		/// <value>The global date time format.</value>
		public static string GlobalDateTimeFormat { get; private set; }

		/// <summary>
		/// Gets the global time span format.
		/// </summary>
		/// <value>The global time span format.</value>
		public static string GlobalTimeSpanFormat { get; private set; }

		/// <summary>
		/// Sets the default options.
		/// </summary>
		public abstract void SetDefaultOptions();

		/// <summary>
		/// Gets the options as a string.
		/// </summary>
		/// <param name="includeClass"><c>true</c> to include the class; otherwise, <c>false</c>.</param>
		/// <returns>The options as a string.</returns>
		public abstract string GetOptionsAsString(bool includeClass);

		/// <summary>
		/// Sets the specified property to the specified value.
		/// </summary>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <returns><c>true</c> if the property was set; otherwise, <c>false</c>.</returns>
		public abstract bool SetNewValueOnPropertySucceeded(string propertyName, string propertyValue);

		/// <summary>
		/// Gets the specified options as a string.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns>The options as a string</returns>
		public static string GetOptionsAsString(AutomationConfigOptions options)
		{
			return "";
		}

		/// <summary>
		/// Creates an instance from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The corresponding instance.</returns>
		public static AutomationConfigOptions CreateInstanceFromDataString(
		  string data)
		{
			return null;
		}

		/// <summary>
		/// Converts the specified value to a DateTime? or returns <paramref name="defaultValue"/> if the conversion failed.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The converted DateTime? or the specified default value.</returns>
		public static DateTime? GetDateTimeFromData(string value, DateTime? defaultValue)
		{
			DateTime? nullable = defaultValue;
			return nullable;
		}

		/// <summary>
		/// Returns a string representation of the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The string representation of the specified value.</returns>
		public static string GetDataFromDateTime(DateTime? value)
		{
			string empty = string.Empty;
			return empty;
		}
	}
}
