using System.Collections.Generic;

namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	/// <summary>
	/// Contains the changed data from the monitored parameter.
	/// </summary>
	public class ValueChange<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ValueChange{T}"/> class.
		/// </summary>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The DataMiner System.</param>
		/// <param name="data">The actual changed data.</param>
		protected ValueChange(string sourceId, IDms dms, T data)
		{
			Dms = dms;
			MonitorSource = sourceId;
			Value = data;
		}

		/// <summary>
		/// Gets the DataMiner System.
		/// </summary>
		/// <value>The DataMiner System.</value>
		public IDms Dms { get; private set; }

		/// <summary>
		/// Gets the source that created the subscription.
		/// </summary>
		/// <value>The source that created the subscription.</value>
		/// <remarks>This will be "AgentId/ElementId" in case the source is an element.</remarks>
		public string MonitorSource { get; private set; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public T Value { get; private set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as ValueChange<T>;
			return change != null &&
				   EqualityComparer<T>.Default.Equals(Value, change.Value) &&
				   MonitorSource == change.MonitorSource;
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			var hashCode = -398654759;
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MonitorSource);
			return hashCode;
		}

		/// <summary>
		/// Textual representation in the format: MonitorSource/Value.
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return MonitorSource + "/" + Value;
		}
	}
}