namespace Skyline.DataMiner.Library.Common.Selectors.Data
{
	using System;

	/// <summary>
	/// Represents the alarm level of a table cell.
	/// </summary>
	public class CellAlarmLevel
	{
		private readonly AlarmLevel alarmLevel;

		private readonly Cell cell;

		/// <summary>
		/// Initializes a new instance of the <see cref="CellAlarmLevel"/> class./>
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="tableId">The table ID.</param>
		/// <param name="columnId">The column ID.</param>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <param name="alarmLevel">The alarm level.</param>
		/// <exception cref="ArgumentNullException"><paramref name="primaryKey"/> is <see langword="null"/>.</exception>
		public CellAlarmLevel(int agentId, int elementId, int tableId, int columnId, string primaryKey, AlarmLevel alarmLevel)
		{
			cell = new Cell(agentId, elementId, tableId, columnId, primaryKey);
			this.alarmLevel = alarmLevel;
		}

		/// <summary>
		/// Gets the alarm level of the cell.
		/// </summary>
		/// <value>The alarm level of the cell.</value>
		public AlarmLevel AlarmLevel { get { return alarmLevel; } }

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <value>The cell.</value>
		public Cell Cell { get { return cell; } }

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
		/// A textual representation in the format: AgentId/ElementId/TableId/ParameterId/PrimaryKey/AlarmLevel.
		/// </summary>
		/// <returns>The textual representation.</returns>
		public override string ToString()
		{
			return Cell.AgentId + "/" + Cell.ElementId + "/" + Cell.TableId + "/" + Cell.ParameterId + "/" + Cell.PrimaryKey + "/" + AlarmLevel;
		}
	}
}