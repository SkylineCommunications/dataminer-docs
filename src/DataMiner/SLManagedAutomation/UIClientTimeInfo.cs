namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies how the client will handle extra time info.
	/// </summary>
	public enum UIClientTimeInfo
	{
		/// <summary>
		/// Disabled: no extra information will be available.
		/// </summary>
		Disabled = 0,
		/// <summary>
		/// Return: the <see cref="UIResults.GetClientTimeZoneInfo"/> and <see cref="UIResults.GetClientDateTime"/> will be available when supported by the client.
		/// </summary>
		Return = 1,
	}
}
