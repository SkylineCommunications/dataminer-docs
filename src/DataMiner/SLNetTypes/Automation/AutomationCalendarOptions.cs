namespace Skyline.DataMiner.Automation
{

	/// <summary>
	/// This class allows you to set specific options for a calendar control in an interactive automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIBlockDefinition blockCalendar = new UIBlockDefinition();
	/// blockCalendar.Type = UIBlockType.Calendar;
	/// AutomationCalendarOptions configOptionsCalendarShowSeconds = new AutomationCalendarOptions
	/// {
	///		ShowSeconds = true,
	/// };
	/// blockCalendar.ConfigOptions = configOptionsCalendarShowSeconds;
	/// </code>
	/// </example>
	/// <remarks>
	/// <note type="note">
	/// <para>Only available from DataMiner 10.6.0/10.6.3 onwards.</para> <!-- RN 44487 -->
	/// </note>
	/// </remarks>
	public class AutomationCalendarOptions : AutomationConfigOptions, IAutomationTimeOfDayConfigOptions
    {
	    /// <summary>
	    /// Gets or sets if the seconds are shown.
	    /// </summary>
	    /// <value><c>true</c> to show the seconds; otherwise, <c>false</c>.</value>
	    /// <remarks>
	    /// <para>Default: <c>false</c>.</para>
	    /// <para>Only applicable to Web UI version, from V2 onwards; available from DataMiner 10.6.0/10.6.3 onwards.</para> <!-- RN 44487 / RN 44521 -->
	    /// </remarks>
	    public bool ShowSeconds { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationCalendarOptions"/> class.
		/// </summary>
		public AutomationCalendarOptions()
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