using Skyline.DataMiner.Net.AutomationUI;
using System;
using System.Text;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// This class allows you to create a date and time picker control in an interactive automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIBlockDefinition blockDateTimePickerDefault = new UIBlockDefinition();
	/// blockDateTimePickerDefault.Type = UIBlockType.Time;
	/// AutomationDateTimePickerOptions configOptionsDateTimePickerDefault = new AutomationDateTimePickerOptions();
	/// blockDateTimePickerDefault.ConfigOptions = configOptionsDateTimePickerDefault;
	/// </code>
	/// <img src="~/develop/images/datetimepicker_example.png" />
	/// </example>
	/// <remarks>
	/// <para>Applicable only when <see cref="Type"/> is set to Time.</para>
	/// <note type="note">
	/// <para>If the name of a variable starts with the following prefix, IntelliSense in DataMiner Cube will list the object properties: dateTimePickerConfig*</para>
	/// </note>
	/// </remarks>
	public class AutomationDateTimePickerOptions : AutomationDateTimeUpDownOptions
	{
		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.AutoCloseCalendar"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.AutoCloseCalendar"/> property.</value>
		public static bool DEFAULT_AUTOCLOSE_CALENDAR { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.CalendarDisplayMode"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.CalendarDisplayMode"/> property.</value>
		public static CalendarMode DEFAULT_CALENDAR_DISPLAYMODE { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.ShowDropDownButton"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.ShowDropDownButton"/> property.</value>
		public static bool DEFAULT_SHOWDROPDOWNBUTTON { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.TimeFormat"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.TimeFormat"/> property.</value>
		public static DateTimeFormat DEFAULT_TIMEFORMAT { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.TimeFormatString"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.TimeFormatString"/> property.</value>
		public static string DEFAULT_TIMEFORMATSTRING { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.TimePickerAllowSpin"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.TimePickerAllowSpin"/> property.</value>
		public static bool DEFAULT_TIMEPICKER_ALLOWSPIN { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.TimePickerShowButtonSpinner"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.TimePickerShowButtonSpinner"/> property.</value>
		public static bool DEFAULT_TIMEPICKER_SHOWBUTTONSPINNER { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimePickerOptions.TimePickerVisible"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimePickerOptions.TimePickerVisible"/> property.</value>
		public static bool DEFAULT_TIMEPICKER_VISIBLE { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether to close the calendar pop-up when the user clicks a new date.
		/// </summary>
		/// <value><c>true</c> to close the calendar pop-up when the user clicks a new date; otherwise, <c>false</c>.</value>
		/// <remarks>Default: <c>false</c>.</remarks>
		public bool AutoCloseCalendar { get; set; }

		/// <summary>
		/// Gets or sets the display mode of the calendar inside the date-time picker control.
		/// </summary>
		/// <value>The display mode of the calendar inside the date-time picker control.</value>
		/// <remarks>
		/// <para>Default: <c>Calendar.Month</c>.</para>
		/// </remarks>
		public CalendarMode CalendarDisplayMode { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to show the dropdown button to show the calendar control.
		/// </summary>
		/// <value><c>true</c> to show the dropdown button; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// </remarks>
		public bool ShowDropDownButton { get; set; }

		/// <summary>
		/// Gets or sets the date time format.
		/// </summary>
		/// <value>The date time format.</value>
		/// <remarks>
		/// <para>Default: <c>DateTime.ShortTime</c>.</para>
		/// </remarks>
		public DateTimeFormat TimeFormat { get; set; }

		/// <summary>
		/// Gets or sets the time format string used when TimeFormat is set to “Custom”.
		/// </summary>
		/// <value>The time format string used when TimeFormat is set to “Custom”.</value>
		public string TimeFormatString { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to show the spin box of the calendar control.
		/// </summary>
		/// <value><c>true</c> to shows the spin box of the calendar control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>false</c>.</para>
		/// </remarks>
		public bool TimePickerShowButtonSpinner { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable the spinner button of the calendar control.
		/// </summary>
		/// <value><c>true</c> to enable the spinner button of the calendar control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: true.</para>
		/// </remarks>
		public bool TimePickerAllowSpin { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to show the time picker within the calendar control.
		/// </summary>
		/// <value><c>true</c> to show the time picker within the calendar control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: true.</para>
		/// </remarks>
		public bool TimePickerVisible { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationDateTimePickerOptions"/> class.
		/// </summary>
		public AutomationDateTimePickerOptions()
		{
		}

		/// <summary>
		/// Sets the default options.
		/// </summary>
		public override void SetDefaultOptions()
		{
		}

		/// <summary>
		/// Creates an instance from the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
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
