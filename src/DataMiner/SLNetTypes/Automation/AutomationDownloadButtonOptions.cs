using Skyline.DataMiner.Automation;

namespace SLNetTypes.Automation
{
    /// <summary>
    /// This class allows you to create a download button in an interactive Automation script.
    /// </summary>
    /// <example>
    /// <code>
    /// var downloadButtonOptions = new AutomationDownloadButtonOptions()
    /// {
    ///     URL = @"/Documents/DMA_COMMON_DOCUMENTS/DailyReport.pdf",
    ///     StartDownloadImmediately = false
    ///     ReturnWhenDownloadIsStarted = false,
    ///     FileNameToSave = "Report.PDF",
    /// };
    /// UIBlockDefinition blockItem = new UIBlockDefinition
    /// {
    ///     Type = UIBlockType.DownloadButton,
    ///     Width = 125,
    ///     Text = "Get report of today",
    ///     Style = Style.Button.CallToAction,
    ///     ConfigOptions = downloadButtonOptions,
    /// };
    /// uiBuilder.AppendBlock(blockItem);
    /// </code>
    /// </example>
    /// <remarks>
    /// <note type="note">
    /// <para>If the name of a variable starts with the following prefix, IntelliSense in DataMiner Cube will list the object properties: downloadButtonConfig, downloadButtonOptions*</para>
    /// </note>
    /// </remarks>
    public class AutomationDownloadButtonOptions : AutomationDateTimeUpDownOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the download will start immediately when the component is displayed.
        /// </summary>
        /// <value><c>true</c> to immediately start the download without clicking the button; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// <para>Default: <c>false</c>.</para>
        /// </remarks>
        public bool StartDownloadImmediately { get; set; }

        /// <summary>
        /// Gets or sets a value indicating which file must be downloaded. This URL can be either an absolute path or a relative path.
        /// For example, the absolute path "https://dataminer.services/install/DataMinerCube.exe" will download the latest Cube version from dataminer.services, and the relative path "/Documents/DMA_COMMON_DOCUMENTS/DailyReport.pdf" will download the file "DailyReport.PDF" hosted on the connected DMA, which is located in the Documents module.
        /// </summary>
        /// <remarks>
        /// <para>Default: <c>null</c>.</para>
        /// </remarks>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets a value indicating what the file name is that will be saved. By default, this is the same as the file name of the document.
        /// </summary>
        /// <remarks>
        /// <para>Default: <c>null</c>.</para>
        /// </remarks>
        public string FileNameToSave { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the engine.ShowUI() method will return as soon as the download is started (either immediately or when clicked by the user, depending on <see cref="StartDownloadImmediately"/>). 
        /// When both the <see cref="StartDownloadImmediately"/> property and the <see cref="ReturnWhenDownloadIsStarted"/> property are set to true, the script will start the download and exit immediately.
        /// </summary>
        /// <value><c>true</c> to return as soon as possible when download is started; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// <para>Default: <c>false</c>.</para>
        /// </remarks>
        public bool ReturnWhenDownloadIsStarted { get; set; }

        /// <summary>
        /// Sets the default options.
        /// </summary>
        public override void SetDefaultOptions()
        {
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
    }
}
