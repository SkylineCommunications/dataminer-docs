namespace Skyline.DataMiner.Library.Common.Selectors
{
	using System;

	/// <summary>
	/// Represents a cell selection.
	/// </summary>
	public class Cell : Param
	{
		private readonly int tableId;
		private readonly string primaryKey;

		/// <summary>
		/// Initializes a new instance of the <see cref="Cell"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="tableId">The table ID.</param>
		/// <param name="columnId">The column ID.</param>
		/// <param name="primaryKey">The primary key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		public Cell(int agentId, int elementId, int tableId, int columnId, string primaryKey) : base(agentId, elementId, columnId)
		{
			if(primaryKey == null)
			{
				throw new ArgumentNullException("primaryKey");
			}

			this.tableId = tableId;
			this.primaryKey = primaryKey;
		}

		/// <summary>
		/// Gets the primary key.
		/// </summary>
		/// <value>The primary key.</value>
		public string PrimaryKey { get { return primaryKey; } }

		/// <summary>
		/// Gets the table ID.
		/// </summary>
		/// <value>The table ID.</value>
		public int TableId { get { return tableId; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as Cell;
			return data != null && data.ToString() == this.ToString();
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		/// <summary>
		/// A textual representation in the format: DmaId/ElementId/TableId/Pid/PrimaryKey.
		/// </summary>
		/// <returns>The textual representation.</returns>
		public override string ToString()
		{
			return AgentId + "/" + ElementId + "/" + TableId + "/" + ParameterId + "/" + PrimaryKey;
		}
	}
}