using System.Collections.Generic;

namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	/// <summary>
	/// Contains the changed data from the monitored parameter.
	/// </summary>
	public class AlarmLevelChange
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmLevelChange"/> class.
		/// </summary>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The dms system.</param>
		/// <param name="alarmLevel">The alarm level.</param>
		public AlarmLevelChange(string sourceId, IDms dms, AlarmLevel alarmLevel)
		{
			AlarmLevel = alarmLevel;
			Dms = dms;
			MonitorSource = sourceId;
		}

		/// <summary>
		/// Gets the alarm level.
		/// </summary>
		/// <value>The alarm level.</value>
		public AlarmLevel AlarmLevel { get; private set; }

		/// <summary>
		/// Gets an object implementing the <see cref="IDms"/> interface.
		/// </summary>
		/// <value>An object implementing the <see cref="IDms"/> interface.</value>
		public IDms Dms { get; private set; }

		/// <summary>
		/// The source that created the subscription. Will be AgentId/ElementId when this was an element.
		/// </summary>
		/// <value>The source that created the subscription</value>
		public string MonitorSource { get; private set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as AlarmLevelChange;
			return change != null &&
				   AlarmLevel == change.AlarmLevel &&
				   EqualityComparer<IDms>.Default.Equals(Dms, change.Dms) &&
				   MonitorSource == change.MonitorSource;
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			var hashCode = 1647658303;
			hashCode = hashCode * -1521134295 + AlarmLevel.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<IDms>.Default.GetHashCode(Dms);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MonitorSource);
			return hashCode;
		}
	}
}