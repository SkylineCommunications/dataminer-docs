namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	using System.Collections.Generic;
	using Skyline.DataMiner.Library.Common.Selectors;

	/// <summary>
	/// Contains the changed data from the monitored parameter.
	/// </summary>
	public class ElementNameChange
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNameChange"/> class.
		/// </summary>
		/// <param name="dataSource">The source of the event.</param>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The dms system.</param>
		/// <param name="name">The changed name.</param>
		public ElementNameChange(Element dataSource, string sourceId, IDms dms, string name)
		{
			DataSource = dataSource;
			Dms = dms;
			MonitorSource = sourceId;
			Name = name;
		}

		/// <summary>
		/// The source of the event.
		/// </summary>
		public Element DataSource { get; private set; }

		/// <summary>
		/// The Dms system.
		/// </summary>
		public IDms Dms { get; private set; }

		/// <summary>
		/// The source that created the subscription. Will be AgentId/ElementId when this was an element.
		/// </summary>
		public string MonitorSource { get; private set; }

		/// <summary>
		/// The name of the element.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as ElementNameChange;
			if (change == null) return false;
			return Name == change.Name &&
				   EqualityComparer<Element>.Default.Equals(DataSource, change.DataSource) &&
				   MonitorSource == change.MonitorSource;
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			var hashCode = -1109524427;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<Element>.Default.GetHashCode(DataSource);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MonitorSource);
			return hashCode;
		}

		/// <summary>
		/// A textual representation in the format of: DataSource/Name.
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return DataSource + "/" + Name;
		}
	}
}