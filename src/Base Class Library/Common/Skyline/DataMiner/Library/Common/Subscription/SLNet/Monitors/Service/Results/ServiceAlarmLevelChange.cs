namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	using System.Collections.Generic;
	using Skyline.DataMiner.Library.Common.Selectors;
	
	/// <summary>
	/// Contains the changed data from the monitored parameter.
	/// </summary>
	public class ServiceAlarmLevelChange
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceAlarmLevelChange"/> class.
		/// </summary>
		/// <param name="dataSource">The source of the event.</param>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The dms system.</param>
		/// <param name="state">The service state.</param>
		public ServiceAlarmLevelChange(Service dataSource, string sourceId, IDms dms, AlarmLevel state)
		{
			DataSource = dataSource;
			State = state;
			Dms = dms;
			MonitorSource = sourceId;
		}

		/// <summary>
		/// Gets the source of the event.
		/// </summary>
		public Service DataSource { get; private set; }

		/// <summary>
		/// Gets the Dms system.
		/// </summary>
		public IDms Dms { get; private set; }

		/// <summary>
		/// Gets the source that created the subscription. Will be AgentId/ElementId when this was an element.
		/// </summary>
		public string MonitorSource { get; private set; }

		/// <summary>
		/// Gets the state.
		/// </summary>
		public AlarmLevel State { get; private set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as ServiceAlarmLevelChange;
			if (change == null) return false;
			return State == change.State &&
				   EqualityComparer<Service>.Default.Equals(DataSource, change.DataSource) &&
				   MonitorSource == change.MonitorSource;
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			var hashCode = -318106939;
			hashCode = (hashCode * -1521134295) + State.GetHashCode();
			hashCode = (hashCode * -1521134295) + EqualityComparer<Service>.Default.GetHashCode(DataSource);
			hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(MonitorSource);
			return hashCode;
		}

		/// <summary>
		/// A textual representation in the format of: DataSource/State.
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return DataSource + "/" + State;
		}
	}
}