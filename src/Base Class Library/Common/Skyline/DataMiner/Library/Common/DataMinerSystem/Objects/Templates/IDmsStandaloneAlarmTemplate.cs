namespace Skyline.DataMiner.Library.Common.Templates
{
	/// <summary>
	/// DataMiner standalone alarm template interface.
	/// </summary>
	public interface IDmsStandaloneAlarmTemplate : IDmsAlarmTemplate
	{
		/// <summary>
		/// Gets or sets the alarm template description.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Gets a value indicating whether the alarm template is used in a group.
		/// </summary>
		bool IsUsedInGroup { get; }
	}
}