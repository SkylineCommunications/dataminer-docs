namespace Skyline.DataMiner.Library.Common.Subscription.Monitors
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.Library.Common.Selectors;

	/// <summary>
	/// Represents a table value change.
	/// </summary>
	public class TableValueChange
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TableValueChange"/> class.
		/// </summary>
		/// <param name="dataSource">The source of the changed data.</param>
		/// <param name="sourceId">The identifier of the subscription owner.</param>
		/// <param name="dms">The dms system.</param>
		/// <param name="primaryKeyColumnIdx">The IDX of the table index column.</param>
		/// <param name="updatedRows">Changes in the table.</param>
		/// <param name="deletedRows">Rows that are deleted in the table.</param>
		/// <param name="isInitial"><c>true</c> it this is an initial value; otherwise, <c>false</c>.</param>
		public TableValueChange(Param dataSource, string sourceId, IDms dms, int primaryKeyColumnIdx, IDictionary<string, object[]> updatedRows, string[] deletedRows, bool isInitial)
		{
			DataSource = dataSource;
			MonitorSource = sourceId;
			Dms = dms;

			PrimaryKeyColumnIdx = primaryKeyColumnIdx;
			UpdatedRows = updatedRows;
			DeletedRows = deletedRows;
			IsInitialData = isInitial;
		}

		/// <summary>
		/// Gets an object implementing the <see cref="IDms"/> interface.
		/// </summary>
		/// <value>An object implementing the <see cref="IDms"/> interface.</value>
		public IDms Dms { get; private set; }

		/// <summary>
		/// Gets the source that created the subscription.
		/// </summary>
		/// <value>The source that created the subscription.</value>
		/// <remarks>This will be "AgentId/ElementId" in case the source is an element.</remarks>
		public string MonitorSource { get; private set; }

		/// <summary>
		/// The data from the monitored parameter.
		/// </summary>
		public Param DataSource { get; private set; }

		/// <summary>
		/// Gets the IDX of the table index column.
		/// </summary>
		public int PrimaryKeyColumnIdx { get; private set; }

		/// <summary>
		/// Gets the rows that are deleted in the table.
		/// </summary>
		public string[] DeletedRows { get; private set; }

		/// <summary>
		/// Gets if this is the initial data that is received after creating the subscription.
		/// </summary>
		public bool IsInitialData { get; private set; }

		/// <summary>
		/// Gets the updated rows.
		/// </summary>
		public IDictionary<string, object[]> UpdatedRows { get; private set; }

		/// <summary>
		/// Determines whether two object instances are equal.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		protected bool Equals(TableValueChange other)
		{
			return this.MonitorSource == other.MonitorSource
				   && Equals(this.DataSource, other.DataSource)
				   && this.PrimaryKeyColumnIdx == other.PrimaryKeyColumnIdx &&
				   Equals(this.DeletedRows, other.DeletedRows) &&
				   Equals(this.UpdatedRows, other.UpdatedRows);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TableValueChange)obj);
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = MonitorSource != null ? MonitorSource.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (DataSource != null ? DataSource.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ PrimaryKeyColumnIdx;
				hashCode = (hashCode * 397) ^ (DeletedRows != null ? DeletedRows.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (UpdatedRows != null ? UpdatedRows.GetHashCode() : 0);
				return hashCode;
			}
		}

		/// <summary>
		/// Textual representation of this <see cref="TableValueChange" />
		/// </summary>
		/// <returns>A textual representation.</returns>
		public override string ToString()
		{
			return String.Format("TableValueChange ({0} updated, {1} removed)", UpdatedRows.Count, DeletedRows != null ? DeletedRows.Length : 0);
		}
	}
}
