using Skyline.DataMiner.Net.AutomationUI;
using System;
using System.Text;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// This class allows you to create an up-down control to select a time in an interactive Automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIBlockDefinition blockTimeUpDownDefault = new UIBlockDefinition();
	/// blockTimeUpDownDefault.Type = UIBlockType.Time;
	/// AutomationTimeUpDownOptions configOptionsTimeUpDownDefault = new AutomationTimeUpDownOptions();
	/// blockTimeUpDownDefault.ConfigOptions = configOptionsTimeUpDownDefault;
	/// </code>
	/// <img src="~/develop/images/timeupdown_example.png" />
	/// </example>
	/// <remarks>
	/// <note type="note">
	/// <para>If the name of a variable starts with the following prefix, IntelliSense in DataMiner Cube will list the object properties: timeUpDownConfig*</para>
	/// </note>
	/// </remarks>
	public class AutomationTimeUpDownOptions : AutomationConfigOptions
	{
		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.FractionalSecondsDigitsCount"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.FractionalSecondsDigitsCount"/> property.</value>
		public static int DEFAULT_FRACTIONAL_SECONDS_DIGITSCOUNT { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.Minimum"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.Minimum"/> property.</value>
		public static TimeSpan? DEFAULT_MINIMUM { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.Maximum"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.Maximum"/> property.</value>
		public static TimeSpan? DEFAULT_MAXIMUM { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.ClipValueToMinMax"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.ClipValueToMinMax"/> property.</value>
		public static bool DEFAULT_CLIPVALUE_TOMINMAX { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.UpdateValueOnEnterKey"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.UpdateValueOnEnterKey"/> property.</value>
		public static bool DEFAULT_VALUE_ON_ENTERKEY { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.ShowButtonSpinner"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.ShowButtonSpinner"/> property.</value>
		public static bool DEFAULT_SHOW_BUTTONSPINNER { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.AllowSpin"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.AllowSpin"/> property.</value>
		public static bool DEFAULT_ALLOW_SPINNER { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.ShowSeconds"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.ShowSeconds"/> property.</value>
		public static bool DEFAULT_SHOW_SECONDS { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimeUpDownOptions.ShowTimeUnits"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimeUpDownOptions.ShowTimeUnits"/> property.</value>
		public static bool DEFAULT_SHOW_TIMEUNITS { get; protected set; }

		/// <summary>
		/// Gets or sets the number of digits to be used in order to represent the fractions of seconds.
		/// </summary>
		/// <value>The number of digits to be used in order to represent the fractions of seconds.</value>
		/// <remarks>
		/// <para>Default: 0.</para>
		/// </remarks>
		public int FractionalSecondsDigitsCount { get; set; }

		/// <summary>
		/// Gets or sets the maximum time span.
		/// </summary>
		/// <value>The maximum time span.</value>
		/// <remarks>
		/// <para>Default: <c>Timespan.MaxValue</c>.</para>
		/// </remarks>
		public TimeSpan? Maximum { get; set; }

		/// <summary>
		/// Gets or sets the minimum time span.
		/// </summary>
		/// <value>The minimum time span.</value>
		/// <remarks>
		/// <para>Default: <c>Timespan.MinValue</c>.</para>
		/// </remarks>
		public TimeSpan? Minimum { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable the ClipValueToMinMax option.
		/// </summary>
		/// <value><c>true</c> to enable the ClipValueToMinMax option; otherwise, <c>false</c>.</value>
		/// <remarks>Default: <c>false</c>.</remarks>
		public bool ClipValueToMinMax { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable the option to trigger an update with the control when the Enter key is pressed.
		/// </summary>
		/// <value><c>true</c> to enable the option to trigger an update with the control when the Enter key is pressed; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// <note type="note">
		/// <para>From 9.5.4 onwards, the functionality of this property has been updated. If it is set to true, the control will now only update when the Enter key is pressed. If it is set to false, the control will also update when the focus is moved to somewhere else.</para>
		/// </note>
		/// </remarks>
		public bool UpdateValueOnEnterKey { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to show the spinner button.
		/// </summary>
		/// <value><c>true</c> to show the spinner button; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// </remarks>
		public bool ShowButtonSpinner { get; set; }

		/// <summary>
		///  Gets or sets a value indicating whether to enable the spinner button.
		/// </summary>
		/// <value><c>true</c> to enable the spinner button; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// </remarks>
		public bool AllowSpin { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable showing seconds in the control.
		/// </summary>
		/// <value><c>true</c> to enable showing seconds in the control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// </remarks>
		public bool ShowSeconds { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to display time labels in web component control. From DataMiner 10.3.0 [CU1]/10.3.4 onwards, the `ShowTimeUnits` property displays labels indicating the days, hours, minutes, and seconds. The `ShowTimeUnits` property is only supported in the DataMiner web apps and not in DataMiner Cube.
		/// </summary>
		/// <value><c>true</c> to display time labels in web component control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>false</c>.</para>
		/// </remarks>
		public bool ShowTimeUnits { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationTimeUpDownOptions"/> class.
		/// </summary>
		public AutomationTimeUpDownOptions()
		{
		}

		/// <summary>
		/// Sets the default options.
		/// </summary>
		public override void SetDefaultOptions()
		{
		}

		/// <summary>
		/// Creates an instance from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The corresponding instance.</returns>
		public new static AutomationConfigOptions CreateInstanceFromDataString(
		  string data)
		{
			return null;
		}

		/// <summary>
		/// Sets the specified property to the specified value.
		/// </summary>
		/// <param name="propertyName">The property name.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <returns><c>true</c> if the property was set; otherwise, <c>false</c>.</returns>
		public override bool SetNewValueOnPropertySucceeded(string propertyName, string propertyValue)
		{
			return true;
		}

		/// <summary>
		/// Gets the options as a string.
		/// </summary>
		/// <param name="includeClass"><c>true</c> to include the class; otherwise, <c>false</c>.</param>
		/// <returns>The options as a string.</returns>
		public override string GetOptionsAsString(bool includeClass)
		{
			return null;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return this.GetOptionsAsString(true);
		}
	}
}
