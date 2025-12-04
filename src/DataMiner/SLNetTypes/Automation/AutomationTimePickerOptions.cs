using Skyline.DataMiner.Net.AutomationUI;
using System;
using System.Text;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// This class allows you to create a time picker control in an interactive Automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIBlockDefinition blockTimePickerDefault = new UIBlockDefinition();
	/// blockTimePickerDefault.Type = UIBlockType.Time;
	/// AutomationTimePickerOptions configOptionsTimePickerDefault = new AutomationTimePickerOptions();
	/// blockTimePickerDefault.ConfigOptions = configOptionsTimePickerDefault;
	/// </code>
	/// <img src="~/develop/images/timepicker_example.png" />
	/// </example>
	/// <remarks>
	/// <para>Applicable only when <see cref="Type"/> is set to Time.</para>
	/// <note type="note">
	/// <para>If the name of a variable starts with the following prefix, IntelliSense in DataMiner Cube will list the object properties: timePickerConfig*</para>
	/// </note>
	/// </remarks>
	public class AutomationTimePickerOptions : AutomationDateTimeUpDownOptions
	{
		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.Format"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.Format"/> property.</value>
		public new static DateTimeFormat DEFAULT_FORMAT { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.FormatString"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.FormatString"/> property.</value>
		public new static string DEFAULT_FORMATSTRING { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimePickerOptions.StartTime"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimePickerOptions.StartTime"/> property.</value>
		public static TimeSpan DEFAULT_STARTTIME { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimePickerOptions.EndTime"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimePickerOptions.EndTime"/> property.</value>
		public static TimeSpan DEFAULT_ENDTIME { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimePickerOptions.TimeInterval"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimePickerOptions.TimeInterval"/> property.</value>
		public static TimeSpan DEFAULT_TIME_INTERVAL { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimePickerOptions.MaxDropDownHeight"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimePickerOptions.MaxDropDownHeight"/> property.</value>
		public static double DEFAULT_MAX_DROPDOWN_HEIGHT { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationTimePickerOptions.ShowDropDownButton"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationTimePickerOptions.ShowDropDownButton"/> property.</value>
		public static bool DEFAULT_SHOW_DROPDOWNBUTTON { get; protected set; }

		/// <summary>
		/// Gets or sets the earliest time listed in the time picker control.
		/// </summary>
		/// <value>The earliest time listed in the time picker control.</value>
		/// <remarks>
		/// <para>Default: <c>TimeSpan.Zero</c>.</para>
		/// </remarks>
		public TimeSpan StartTime { get; set; }

		/// <summary>
		/// Gets or sets the last time listed in the time picker control.
		/// </summary>
		/// <value>The last time listed in the time picker control.</value>
		/// <remarks>
		/// <para>Default: <c>TimeSpan.FromMinutes(1439)</c>.</para>
		/// <note type="note">
		/// <para>1439 = 1440 minutes (1 day) minus a minute</para>
		/// </note>
		/// </remarks>
		public TimeSpan EndTime { get; set; }

		/// <summary>
		/// Gets or sets the time interval between two time items in the time picker control.
		/// </summary>
		/// <value>The time interval between two time items in the time picker control.</value>
		/// <remarks>
		/// <para>Default: <c>TimeSpan.FromHours(1)</c>.</para>
		/// </remarks>
		public TimeSpan TimeInterval { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable the dropdown button of the time picker control.
		/// </summary>
		/// <value><c>true</c> to enable the dropdown button of the time picker control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: true.</para>
		/// </remarks>
		public bool ShowDropDownButton { get; set; }

		/// <summary>
		/// Gets or sets the height of the time picker control.
		/// </summary>
		/// <value>The height of the time picker control.</value>
		/// <remarks>
		/// <para>Default: 130.</para>
		/// </remarks>
		public double MaxDropDownHeight { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationTimePickerOptions"/> class.
		/// </summary>
		public AutomationTimePickerOptions()
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
			return "";
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
