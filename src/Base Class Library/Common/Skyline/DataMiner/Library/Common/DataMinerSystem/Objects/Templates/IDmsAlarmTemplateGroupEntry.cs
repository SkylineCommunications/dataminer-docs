namespace Skyline.DataMiner.Library.Common.Templates
{
	/// <summary>
	/// DataMiner alarm template group entry interface.
	/// </summary>
	public interface IDmsAlarmTemplateGroupEntry
	{
		/// <summary>
		/// Gets a value indicating whether the entry is enabled.
		/// </summary>
		bool IsEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the entry is scheduled.
		/// </summary>
		bool IsScheduled { get; }

		/// <summary>
		/// Gets the alarm template.
		/// </summary>
		IDmsAlarmTemplate AlarmTemplate { get; }
	}
}