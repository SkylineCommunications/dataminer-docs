namespace Skyline.DataMiner.Library.Common.Templates
{
	using System.Collections.ObjectModel;

	/// <summary>
	/// DataMiner alarm template group interface.
	/// </summary>
	public interface IDmsAlarmTemplateGroup : IDmsAlarmTemplate
	{
		/// <summary>
		/// Gets the entries of the alarm template group.
		/// </summary>
		ReadOnlyCollection<IDmsAlarmTemplateGroupEntry> Entries { get; }
	}
}