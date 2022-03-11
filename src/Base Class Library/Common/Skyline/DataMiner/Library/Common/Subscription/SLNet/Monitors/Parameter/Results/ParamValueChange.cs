namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	using Skyline.DataMiner.Library.Common.Selectors;

	using System.Collections.Generic;

	/// <summary>
	/// Contains the changed data from the monitored parameter.
	/// </summary>
	public class ParamValueChange<T> : ValueChange<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ParamValueChange{T}"/> class.
		/// </summary>
		/// <param name="dataSource">The source of the data change.</param>
		/// <param name="data">The changed data.</param>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The DataMiner System.</param>
		public ParamValueChange(Param dataSource, T data, string sourceId, IDms dms) : base(sourceId, dms, data)
		{
			DataSource = dataSource;
		}

		/// <summary>
		/// The data from the monitored parameter.
		/// </summary>
		public Param DataSource { get; private set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var change = obj as ParamValueChange<T>;

			return change != null &&
				base.Equals(change) &&
				   EqualityComparer<Param>.Default.Equals(DataSource, change.DataSource);
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			int hashCode = 1015019191;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1015019192 + EqualityComparer<Param>.Default.GetHashCode(DataSource);
			return hashCode;
		}

		/// <summary>
		/// Textual representation in the format: DataSource/Value.
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return DataSource + "/" + Value;
		}
	}
}