using Skyline.DataMiner.Library.Common.Selectors;

using System.Collections.Generic;

namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	/// <summary>
	/// Contains the changed alarm state of the monitored parameter.
	/// </summary>
	public class ParamAlarmLevelChange : AlarmLevelChange
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ParamAlarmLevelChange"/> class.
		/// </summary>
		/// <param name="dataSource">The source of the data change.</param>
		/// <param name="alarmLevel">The changed alarm level.</param>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The DataMiner System.</param>
		public ParamAlarmLevelChange(Param dataSource, AlarmLevel alarmLevel, string sourceId, IDms dms) : base(sourceId, dms, alarmLevel)
		{
			DataSource = dataSource;
		}

		/// <summary>
		/// The monitored parameter.
		/// </summary>
		public Param DataSource { get; private set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as ParamAlarmLevelChange;
			return change != null &&
				   base.Equals(obj) &&
				   EqualityComparer<Param>.Default.Equals(DataSource, change.DataSource);
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			var hashCode = -1933872498;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Param>.Default.GetHashCode(DataSource);
			return hashCode;
		}

		/// <summary>
		/// Textual representation in the format: DataSource/AlarmLevel.
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return DataSource + "/" + AlarmLevel;
		}
	}
}