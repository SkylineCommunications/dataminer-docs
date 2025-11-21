using Skyline.DataMiner.Net.AutomationUI;
using System;
using System.Text;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// This class allows you to create an up-down control to select a date and time in an interactive Automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIBlockDefinition blockDateTimeUpDownDefault = new UIBlockDefinition();
	/// blockDateTimeUpDownDefault.Type = UIBlockType.Time;
	/// AutomationDateTimeUpDownOptions configOptionsDateTimeUpDownDefault = new AutomationDateTimeUpDownOptions();
	/// blockDateTimeUpDownDefault.ConfigOptions = configOptionsDateTimeUpDownDefault;
	/// </code>
	/// <img src="~/develop/images/datetimeupdown_example.png" />
	/// </example>
	/// <remarks>
	/// <para>Applicable only when <see cref="Type"/> is set to Time.</para>
	/// <note type="note">
	/// <para>If the name of a variable starts with the following prefix, IntelliSense in DataMiner Cube will list the object properties: dateTimeUpDownConfig*</para>
	/// </note>
	/// </remarks>
	public class AutomationDateTimeUpDownOptions : AutomationConfigOptions
	{
		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.Format"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.Format"/> property.</value>
		public static DateTimeFormat DEFAULT_FORMAT { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.FormatString"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.FormatString"/> property.</value>
		public static string DEFAULT_FORMATSTRING { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.Kind"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.Kind"/> property.</value>
		public static DateTimeKind DEFAULT_KIND { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.Minimum"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.Minimum"/> property.</value>
		public static DateTime? DEFAULT_MINIMUM { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.Maximum"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.Maximum"/> property.</value>
		public static DateTime? DEFAULT_MAXIMUM { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.ClipValueToMinMax"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.ClipValueToMinMax"/> property.</value>
		public static bool DEFAULT_CLIPVALUE_TOMINMAX { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.UpdateValueOnEnterKey"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.UpdateValueOnEnterKey"/> property.</value>
		public static bool DEFAULT_VALUE_ON_ENTERKEY { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.ShowButtonSpinner"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.ShowButtonSpinner"/> property.</value>
		public static bool DEFAULT_SHOW_BUTTONSPINNER { get; protected set; }

		/// <summary>
		/// Gets the default value for the <see cref="AutomationDateTimeUpDownOptions.AllowSpin"/> property.
		/// </summary>
		/// <value>The default value for the <see cref="AutomationDateTimeUpDownOptions.AllowSpin"/> property.</value>
		public static bool DEFAULT_ALLOW_SPINNER { get; protected set; }

		/// <summary>
		/// Gets or sets the date and time format used by the date-time up-down control.
		/// </summary>
		/// <value>The date and time format used by the date-time up-down control.</value>
		/// <remarks>
		/// <para>Default:</para>
		/// <list type="bullet">
		/// <item><description>In DataMiner 9.5.3: FullDateTime</description></item>
		/// <item><description>From DataMiner 9.5.4 onwards: general datetime</description></item>
		/// </list>
		/// </remarks>
		public DateTimeFormat Format { get; set; }

		/// <summary>
		/// Gets or sets the date-time format to be used by the control when Format is set to 'Custom'.
		/// </summary>
		/// <value>The date-time format to be used by the control when Format is set to 'Custom'.</value>
		/// <remarks>
		/// <para>Default: G (from DataMiner 9.5.4 onwards; previously the default value was null)</para>
		/// </remarks>
		public string FormatString { get; set; }

		/// <summary>
		/// Gets or sets the DateTimeKind (.NET) used by the datetime up-down control.
		/// </summary>
		/// <value>The DateTimeKind (.NET) used by the datetime up-down control.</value>
		/// <remarks>
		/// <para>Default: <c>DateTimeKind.Unspecified</c>.</para>
		/// </remarks>
		public DateTimeKind Kind { get; set; }

		/// <summary>
		/// Gets or sets the maximum timestamp.
		/// </summary>
		/// <value>The maximum allowed timestamp. If <c>null</c>, no upper limit is enforced.</value>
		/// <remarks>
		/// <para>This setting can be applied via the <see cref="AutomationDateTimeUpDownOptions"/>, <see cref="AutomationDateTimePickerOptions"/>, and <see cref="AutomationTimePickerOptions"/> when the <see cref="Type"/> is set to <see href="xref:UIBlockTypesOverview#time">Time</see>.</para>
		/// <para>Default: <c>DateTime.MaxValue</c>.</para>
		/// <note type="note">Available from DataMiner 10.5.9/10.6.0 onwards (RN 43014). A <see cref="DateTimeKind"/> will be taken into account on the DateTime of the Maximum. This can be set using <see cref="DateTime.SpecifyKind"/> :
		/// 	 <list type="bullet">
		///   		<item><description><see cref="DateTimeKind.Unspecified"/>: Based on the client's local time. This is the default behavior. This is also the behavior prior to 10.5.9/10.6.0 regardless of DateTimeKind.</description></item>
		///   		<item><description><see cref="DateTimeKind.Local"/>: Based on the server's local time, then adjusted to the client's local time.</description></item>
		///   		<item><description><see cref="DateTimeKind.Utc"/>: Interpreted as UTC, then adjusted to the client's local time. Using UTC is recommended to have full consistency regardless of the server and client time zone.</description></item>
		/// 	</list>
		/// </note> <!-- RN 43014 -->
		/// </remarks>
		/// <example>
		/// <code>
		/// var timeComponent = new UIBlockDefinition
		/// {
		///     Type = UIBlockType.Time,
		///     ConfigOptions = new AutomationDateTimeUpDownOptions()
		///     {
		///         Maximum = new DateTime(2025, 5, 15, 20, 30, 0)
		///     },
		///     DestVar = "TimeComponent"
		/// };
		/// uib.AppendBlock(timeComponent);
		/// </code>
		/// </example>
		public DateTime? Maximum { get; set; }

		/// <summary>
		/// Gets or sets the minimum timestamp.
		/// </summary>
		/// <value>The minimum allowed timestamp. If <c>null</c>, no lower limit is enforced.</value>
		/// <remarks>
		/// <para>This setting can be applied via the <see cref="AutomationDateTimeUpDownOptions"/>, <see cref="AutomationDateTimePickerOptions"/>, and <see cref="AutomationTimePickerOptions"/> when the <see cref="Type"/> is set to <see href="xref:UIBlockTypesOverview#time">Time</see>.</para>
		/// <para>Default: <c>DateTime.MinValue</c>.</para>
		/// <note type="note">Available from DataMiner 10.5.9/10.6.0 onwards (RN 43014). A <see cref="DateTimeKind"/> will be taken into account on the DateTime of the Minimum. This can be set using <see cref="DateTime.SpecifyKind"/> :
		/// 	 <list type="bullet">
		///   		<item><description><see cref="DateTimeKind.Unspecified"/>: Based on the client's local time. This is the default behavior. This is also the behavior prior to 10.5.9/10.6.0 regardless of DateTimeKind.</description></item>
		///   		<item><description><see cref="DateTimeKind.Local"/>: Based on the server's local time, then adjusted to the client's local time.</description></item>
		///   		<item><description><see cref="DateTimeKind.Utc"/>: Interpreted as UTC, then adjusted to the client's local time. Using UTC is recommended to have full consistency regardless of the server and client time zone.</description></item>
		/// 	</list>
		/// </note> <!-- RN 43014 -->
		/// </remarks>
		/// <example>
		/// <code>
		/// var timeComponent = new UIBlockDefinition
		/// {
		///     Type = UIBlockType.Time,
		///     ConfigOptions = new AutomationDateTimeUpDownOptions()
		///     {
		///         Minimum = new DateTime(2025, 5, 10, 12, 30, 0)
		///     },
		///     DestVar = "TimeComponent"
		/// };
		/// uib.AppendBlock(timeComponent);
		/// </code>
		/// </example>
		public DateTime? Minimum { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to clip the value to the minimum and maximum.
		/// </summary>
		/// <value><c>true</c> to clip the value to the minimum and maximum; otherwise, <c>false</c>.</value>
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
		/// Gets or sets a value indicating whether to enable the spinner button.
		/// </summary>
		/// <value><c>true</c> to enable the spinner button; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// </remarks>
		public bool AllowSpin { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationDateTimeUpDownOptions"/> class.
		/// </summary>
		public AutomationDateTimeUpDownOptions()
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
