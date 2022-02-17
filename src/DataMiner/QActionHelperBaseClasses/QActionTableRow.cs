using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Serves as a base class from which new classes will be derived.
	/// </summary>
	public class QActionTableRow
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QActionTableRow"/> class that represents a table row with the specified number of columns.
		/// </summary>
		/// <param name="index">The index of the column that holds the primary key.</param>
		/// <param name="columnCount">The number of columns.</param>
		public QActionTableRow(int index, int columnCount) { }

		/// <summary>
		/// Initializes a new instance of the QActionTableRow class that represents a table row with the specified number of columns and initializes it with the provided data.
		/// </summary>
		/// <param name="index">The index of the column that holds the primary key.</param>
		/// <param name="columnCount">The number of columns.</param>
		/// <param name="oRow">The row data.</param>
		public QActionTableRow(int index, int columnCount, object[] oRow) { }

		/// <summary>
		/// Gets the number of columns.
		/// </summary>
		/// <value>The number of columns.</value>
		public int ColumnCount { get; }

		/// <summary>
		/// Gets the contents of the columns.
		/// </summary>
		/// <value>The contents of the columns.</value>
		public Dictionary<int, object> Columns { get { return null; } set { } }

		/// <summary>
		/// Gets the index of the column that holds the primary key.
		/// </summary>
		/// <value>The index of the column that holds the primary key.</value>
		public int Index { get { return 0; } }

		/// <summary>
		/// Gets the primary key of the row.
		/// </summary>
		/// <value>The primary key of the row.</value>
		public string Key { get { return ""; } }

		/// <summary>
		/// Converts the row to an object array.
		/// </summary>
		/// <returns>The row data.</returns>
		public object[] ToObjectArray() { return null; }

		/// <summary>
		/// Implicitly converts the row to an object array.
		/// </summary>
		/// <param name="source">The row to convert.</param>
		/// <example>
		/// <code language="c#">
		///	<![CDATA[
		///	MasterTableQActionRow row = new MasterTableQActionRow();
		/// row.MasterIndex = "1";
		/// row.MasterDescription = "Main";
		/// object[] rowData = row;
		/// ]]>
		///	</code>
		///	</example>
		public static implicit operator object[] (QActionTableRow source) { return null; }
	}
}