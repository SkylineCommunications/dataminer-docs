namespace Skyline.DataMiner.Library.Common.Selectors.Data
{
	using Skyline.DataMiner.Library.Common.Selectors;

	using System;

	/// <summary>
	/// Represents the cell data.
	/// </summary>
	public class CellValue
	{
		private readonly Cell cell;
		private readonly object value;

		/// <summary>
		/// Initializes a new instance of the <see cref="CellValue"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="tableId">The table ID.</param>
		/// <param name="columnId">The parameter ID.</param>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <param name="value">The parameter value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		public CellValue(int agentId, int elementId, int tableId, int columnId, string primaryKey, object value)
		{
			cell = new Cell(agentId, elementId, tableId, columnId, primaryKey);
			this.value = value;
		}

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <value>The cell.</value>
		public Cell Cell { get { return cell; } }

		/// <summary>
		/// Gets the cell value.
		/// </summary>
		/// <value>The cell value.</value>
		public object Value { get { return value; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as CellValue;
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
		/// A textual representation in the format: DmaId/ElementId/TableId/Pid/PrimaryKey/Value
		/// </summary>
		/// <returns>The textual representation.</returns>
		public override string ToString()
		{
			return Cell.AgentId + "/" + Cell.ElementId + "/" + Cell.TableId + "/" + Cell.ParameterId + "/" + Cell.PrimaryKey + "/" + Value;
		}
	}
}