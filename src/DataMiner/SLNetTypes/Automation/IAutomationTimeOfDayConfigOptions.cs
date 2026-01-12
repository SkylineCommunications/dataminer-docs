namespace Skyline.DataMiner.Automation
{
    public interface IAutomationTimeOfDayConfigOptions
    {
		/// <summary>
		/// Gets if the seconds are shown.
		/// </summary>
		/// <remarks>
		/// <note type="note">Only applicable to Web UI version, from V2 onwards; available from DataMiner 10.6.3/10.6.0 onwards.</note> <!-- RN 44487 -->
		/// </remarks>
		bool ShowSeconds { get; }
    }
}
