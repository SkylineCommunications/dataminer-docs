using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Serves as a base class from which new classes representing protocol tables are derived.
	/// </summary>
	public class QActionTable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QActionTable"/> class.
		/// </summary>
		/// <param name="protocol"><see cref="SLProtocol"/> interface used to interact with the SLProtocol process.</param>
		/// <param name="tableId">The ID of the table.</param>
		/// <param name="tableName">The name of the table.</param>
		/// <remarks>Instances of this base class should never be created. It is used to automatically generate derived classes for tables defined in the protocol. Consider it an abstract class.</remarks>
		public QActionTable(SLProtocol protocol, int tableId, string tableName) { }

		/// <summary>
		/// Gets or sets the row at the specified index (0-based).
		/// </summary>
		/// <param name="row">The 0-based index of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>The implementation of this indexer uses the GetRow and SetRow methods defined in the SLProtocol interface.</remarks>
		public object[] this[int row] { get { return null; } set { } }

		/// <summary>
		/// Gets or sets the row with the specified primary key.
		/// </summary>
		/// <param name="row">The primary key of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>The implementation of this indexer uses the GetRow and SetRow methods defined in the SLProtocol interface.</remarks>
		public object[] this[string row] { get { return null; } set { } }

		/// <summary>
		/// Gets or sets the cell at the specified row and column index (0-based).
		/// </summary>
		/// <param name="row">The 0-based index of the row.</param>
		/// <param name="column">The 0-based index of the column.</param>
		/// <returns>The cell value.</returns>
		/// <remarks>The implementation of this indexer uses the GetParameterIndex and SetParameterIndex methods defined in the SLProtocol interface.</remarks>
		public object this[int row, int column] { get { return null; } set { } }

		/// <summary>
		/// Gets or sets the cell at the specified row and column index (0-based).
		/// </summary>
		/// <param name="row">The primary key of the row.</param>
		/// <param name="column">The 0-based index of the column.</param>
		/// <returns>The cell value.</returns>
		/// <remarks>The implementation of this indexer uses the GetParameterIndexByKey and SetParameterIndexByKey methods defined in the SLProtocol interface.</remarks> 
		public object this[string row, int column] { get { return null; } set { } }

		/// <summary>
		/// Gets the display keys of all rows in the table.
		/// </summary>
		/// <value>The display keys of all the rows in the table.</value>
		/// <remarks>The implementation of this property uses the GetKeys extension method defined in the NotifyProtocol class.</remarks>
		public string[] DisplayKeys { get { return null; } }

		/// <summary>
		/// Gets the primary keys of all rows in the table.
		/// </summary>
		/// <value>The primary keys of all the rows in the table.</value>
		/// <remarks>The implementation of this property uses the GetKeys extension method defined in the NotifyProtocol class.</remarks>
		public string[] Keys { get { return null; } }

		/// <summary>
		/// Gets the <see cref="SLProtocol"/> interface used to interact with the SLProtocol process.
		/// </summary>
		/// <value>The <see cref="SLProtocol"/> interface used to interact with the SLProtocol process.</value>
		/// <remarks>
		/// <note type="caution">
		/// This property is obsolete. Use the protocol object provided in the entry point method of the QAction instead.
		/// </note>
		/// </remarks>
		public SLProtocol Protocol { get { return null; } }

		/// <summary>
		/// Gets the number of rows present in the table.
		/// </summary>
		/// <value>The number of rows present in the table.</value>
		/// <remarks>The implementation of this property uses the RowCount method defined in the SLProtocol class.</remarks>
		public int RowCount { get { return 0; } }

		/// <summary>
		/// Gets the ID of the table parameter.
		/// </summary>
		/// <value>The ID of the table parameter.</value>
		public int TableId { get { return 0; } }

		/// <summary>
		/// Gets the name of the table.
		/// </summary>
		/// <value>The name of the table.</value>
		public string TableName { get { return null; } }

		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="row">The primary key of the row.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		public int AddRow(string row) { return 0; }

		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="row">The row data.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		public int AddRow(QActionTableRow row) { return 0; }

		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="row">The row data.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		public int AddRow(object[] row) { return 0; }

		/// <summary>
		/// Adds a row to the table and returns the primary key of the new row.
		/// </summary>
		/// <returns>The primary key of the added row.</returns>
		public string AddRowReturnKey() { return ""; }

		/// <summary>
		/// Adds a row to the table and returns the primary key of the new row.
		/// </summary>
		/// <param name="row">The row data.</param>
		/// <returns>The primary key of the added row.</returns>
		public string AddRowReturnKey(QActionTableRow row) { return ""; }

		/// <summary>
		/// Adds a row to the table and returns the primary key of the new row.
		/// </summary>
		/// <param name="row">The row data.</param>
		/// <returns>The primary key of the added row.</returns>
		public string AddRowReturnKey(object[] row) { return ""; }

		/// <summary>
		/// Removes the specified rows from the specified table.
		/// </summary>
		/// <param name="rows">The primary keys of the rows to remove.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		public int DeleteRow(List<string> rows) { return 0; }

		/// <summary>
		/// Removes the specified rows from the specified table.
		/// </summary>
		/// <param name="rows">The primary keys of the rows to remove.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		public int DeleteRow(string[] rows) { return 0; }

		/// <summary>
		/// Removes the specified row from the specified table.
		/// </summary>
		/// <param name="row">The 0-based index of the row.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		public int DeleteRow(int row) { return 0; }

		/// <summary>
		/// Removes the specified row from the specified table.
		/// </summary>
		/// <param name="row">The primary key of the row to remove.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		public int DeleteRow(string row) { return 0; }

		/// <summary>
		/// Determines whether a row with the specified primary key exists in the table.
		/// </summary>
		/// <param name="key">The primary key of the row.</param>
		/// <returns><c>true</c> if a row with the primary key is present; otherwise, <c>false</c>.</returns>
		public bool Exists(string key) { return false; }

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the table did contain rows with other primary keys than the ones provided in the method call, these rows will be removed. In case this is undesired, use the FillArrayNoDelete method instead.</description>
		///			</item>	
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArray(List<QActionTableRow> rows, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="columns">The <b>columns</b> of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This overload is supported from DataMiner 10.2.7 onwards (RN 28573).</description>
		///			</item>
		///			<item>
		///				<description>In case the table did contain rows with other primary keys than the ones provided in the method call, these rows will be removed. In case this is undesired, use the FillArrayNoDelete method instead.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArray(List<object[]> columns, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="columns">The <b>columns</b> of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the table did contain rows with other primary keys than the ones provided in the method call, these rows will be removed. In case this is undesired, use the FillArrayNoDelete method instead.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArray(object[] columns, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the table did contain rows with other primary keys than the ones provided in the method call, these rows will be removed. In case this is undesired, use the FillArrayNoDelete method instead.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArray(QActionTableRow[] rows, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Adds the provided content to the table.
		/// </summary>
		/// <param name="columns">The <b>columns</b> of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArrayNoDelete(object[] columns, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Adds the provided content to the table.
		/// </summary>
		/// <param name="columns">The <b>columns</b> of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This overload is supported from DataMiner 10.2.7 onwards (RN 28573).</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArrayNoDelete(List<object[]> columns, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Adds the provided content to the table.
		/// </summary>
		/// <param name="rows">The rows of the table.</param>3
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArrayNoDelete(QActionTableRow[] rows, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Adds the provided content to the table.
		/// </summary>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public object FillArrayNoDelete(List<QActionTableRow> rows, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Gets the primary keys of all rows that have the specified value for the specified column.
		/// </summary>
		/// <param name="columnPid">The ID of the column parameter.</param>
		/// <param name="value">The value to search.</param>
		/// <returns>The primary keys of the rows that have the specified value for the specified column.</returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In order for this method to work, the column must either be a foreign key column or it must have the option ‘indexColumn’.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public string[] GetKeysForIndex(int columnPid, string value) { return null; }

		/// <summary>
		/// Gets the 1-based position of the row with the specified primary key in the table.
		/// </summary>
		/// <param name="key">The primary key of the row.</param>
		/// <returns>The 1-based position of the row in the table.</returns>
		public int GetPosition(string key) { return 0; }

		/// <summary>
		/// Gets a row from the table.
		/// </summary>
		/// <param name="row">The primary key of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>This method acts as an alternative for and wraps the corresponding indexer defined in this class.</remarks>
		public object[] GetRow(string row) { return null; }

		/// <summary>
		/// Gets a row from the table.
		/// </summary>
		/// <param name="row">The 0-based index of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>This method acts as an alternative for and wraps the corresponding indexer defined in this class.</remarks>
		public object[] GetRow(int row) { return null; }

		/// <summary>
		/// Converts an array of QActionTableRows to an object array where each element of the array represents a table row.
		/// </summary>
		/// <param name="rows">The rows to convert.</param>
		/// <returns>The data organized as an object array where each element of the array represents a table row.</returns>
		/// <remarks>Each element of the array represents a table row (e.g. result[0] represents the first row). In case it is desired to have each element of the array represent a table column, use the QActionRowsToObjectFillArray method instead.</remarks>
		public object[] QActionRowsToObjectArray(QActionTableRow[] rows) { return null; }

		/// <summary>
		/// Converts an array of QActionTableRows to an object array where each element of the array represents a table column.
		/// </summary>
		/// <param name="rows">The rows to convert.</param>
		/// <returns>The data organized as an object array where each element of the array represents a table column.</returns>
		/// <remarks></remarks>
		public object[] QActionRowsToObjectFillArray(QActionTableRow[] rows) { return null; }

		/// <summary>
		/// Sets the specified cells of a column with the provided values.
		/// </summary>
		/// <param name="columnPid">The ID of the column parameter.</param>
		/// <param name="Keys">The primary keys of the rows for which the column has to be updated.</param>
		/// <param name="Values">The values to set.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <exception cref="ArgumentException">The length of 'Keys' is not equal to the length of 'Values'.</exception>
		/// <returns></returns>
		public object SetColumn(int columnPid, string[] Keys, object[] Values, DateTime? timeInfo = null) { return null; }

		/// <summary>
		/// Sets the content of the specified row to the provided content.
		/// </summary>
		/// <param name="row">The 0-based index of the row.</param>
		/// <param name="data">The row data. A null reference as cell value will preserve the value of the cell.</param>
		/// <exception cref="ArgumentException">The index is smaller than 0 or larger than the number of rows in the table.</exception>
		/// <returns></returns>
		public object[] SetRow(int row, object[] data) { return null; }

		/// <summary>
		/// Sets the content of the specified row to the provided content.
		/// </summary>
		/// <param name="row">The row to set. A null reference as cell value will preserve the value of the cell.</param>
		/// <param name="createRow">Indicates whether a row must be created if the table does not contain a row with the specified primary key.</param>
		/// <exception cref="ArgumentException">When the row does not exist and the create row option is set to false.</exception>
		/// <returns></returns>
		public object[] SetRow(QActionTableRow row, bool createRow = false) { return null; }

		/// <summary>
		/// Sets the content of the specified row to the provided content.
		/// </summary>
		/// <param name="row">Primary key of the row.</param>
		/// <param name="data">The row data. A null reference as cell value will preserve the value of the cell.</param>
		/// <param name="createRow">Indicates whether a row must be created if the table does not contain a row with the specified primary key.</param>
		/// <exception cref="ArgumentException">When the row does not exist and the create row option is set to false.</exception>
		/// <returns></returns>
		public object[] SetRow(string row, object[] data, bool createRow = false) { return null; }
	}
}
