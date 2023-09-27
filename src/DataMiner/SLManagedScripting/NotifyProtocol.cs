using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// This class defines a number of methods for the SLProtocol interface. Most extension methods just wrap a specific NotifyProtocol method call to improve readability.
	/// </summary>
	/// <remarks>
	/// <para>Prior to DataMiner 10.1.1 (RN 27995), these methods are all defined as extension methods on the SLProtocol interface. However, from DataMiner 10.1.1 onwards, the <see cref="SLProtocol"/> interface itself has been extended with these methods, which should be used instead of the static methods defined in this class.</para>
	/// </remarks>
	public class NotifyProtocol
	{
		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="row">The primary key of the row.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 149 call [NT_ADD_ROW](xref:NT_ADD_ROW).
		/// </remarks>
		[Obsolete("Use protocol.AddRow instead", false)]
		public static int AddRow(SLProtocol protocol, int tableId, string row)
		{
			return 0;
		}

		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="row">The row data.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 149 call [NT_ADD_ROW](xref:NT_ADD_ROW).
		/// </remarks>
		[Obsolete("Use protocol.AddRow instead", false)]
		public static int AddRow(SLProtocol protocol, int tableId, object[] row)
		{
			return 0;
		}

		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="row">The row data.</param>
		/// <param name="KeyMask">Sets are done in two calls. The first call only sets the columns where the corresponding mask position is set to true, the second call then sets the other columns.</param>
		/// <exception cref="ArgumentException">The row and key mask arrays have different length.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="row"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 149 call [NT_ADD_ROW](xref:NT_ADD_ROW).
		/// </remarks>
		[Obsolete("Use protocol.AddRow instead", false)]
		public static void AddRow(SLProtocol protocol, int tableId, object[] row, bool[] KeyMask)
		{
		}

		/// <summary>
		/// Adds a row to the table and returns the primary key.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <returns>The primary key of the added row.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 240 call [NT_ADD_ROW_RETURN_KEY](xref:NT_ADD_ROW_RETURN_KEY).
		/// <note type="note">This method overload is intended to be used with a table that has an auto-incrementing key.</note>
		/// </remarks>

		[Obsolete("Use protocol.AddRowReturnKey instead", false)]
		public static string AddRowReturnKey(SLProtocol protocol, int tableId)
		{
			return "";
		}

		/// <summary>
		/// Adds a row to the table and returns the primary key.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="row">The row data.</param>
		/// <returns>The primary key of the added row.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 240 call [NT_ADD_ROW_RETURN_KEY](xref:NT_ADD_ROW_RETURN_KEY).
		/// </remarks>
		[Obsolete("Use protocol.AddRowReturnKey instead", false)]
		public static string AddRowReturnKey(SLProtocol protocol, int tableId, object[] row)
		{
			return "";
		}

		/// <summary>
		/// Removes all rows from the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <returns>The number of rows left. In case the ClearAllKeys method has been invoked specifying an empty table, -1 is returned.</returns>
		/// <remarks>This method first retrieves all primary keys from the table using a NotifyProtocol type 168 [NT_GET_INDEXES](xref:NT_GET_INDEXES) call. If there is at least one primary key present, the method performs a NofityProtoocl type 156 call [NT_DELETE_ROW](xref:NT_DELETE_ROW), removing all rows.</remarks>
		[Obsolete("Use protocol.ClearAllKeys instead", false)]
		public static object ClearAllKeys(SLProtocol protocol, int tableId)
		{
			return null;
		}

		/// <summary>
		/// Removes the specified rows from the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="rows">The primary keys of the rows to remove.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 156 call [NT_DELETE_ROW](xref:NT_DELETE_ROW) call.
		/// </remarks>
		public static int DeleteRow(SLProtocol protocol, int tableId, string[] rows)
		{
			return 0;
		}

		/// <summary>
		/// Removes the specified row from the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="row">The index of the row.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 156 call [NT_DELETE_ROW](xref:NT_DELETE_ROW) call.
		/// </remarks>
		public static int DeleteRow(SLProtocol protocol, int tableId, int row)
		{
			return 0;
		}

		/// <summary>
		/// Removes the specified row from the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="rowKey">The primary key of the row to remove.</param>
		/// <returns>The number of remaining rows in the table.</returns>
		/// <remarks>
		/// This method acts as a wrapper for a NotifyProtocol type 156 call [NT_DELETE_ROW](xref:NT_DELETE_ROW) call.
		/// </remarks>
		public static int DeleteRow(SLProtocol protocol, int tableId, string rowKey)
		{
			return 0;
		}

		/// <summary>
		/// Determines whether a row with the specified primary key exists in the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <returns>Indication of whether the table contains a row with the specified primary key. <c>true</c> means a row with the primary key is present, <c>false</c> otherwise.</returns>
		public static bool Exists(SLProtocol protocol, int tableId, string key)
		{
			return false;
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		/// </item>
		/// <item>
		/// <description>In case the data contains null references, the corresponding cells will be cleared.</description>
		/// </item>
		/// <item>
		/// <description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		/// </item>
		/// <item>
		/// <description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		/// </item>
		/// </list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, object[] columns)
		{
			return null;
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>This overload is currently not supported.</description>
		/// </item>
		/// <item>
		/// <description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		/// </item>
		/// <item>
		/// <description>In case the data contains null references, the corresponding cells will be cleared.</description>
		/// </item>
		/// <item>
		/// <description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		/// </item>
		/// <item>
		/// <description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		/// </item>
		/// </list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, List<object[]> columns)
		{
			return protocol.FillArray(tableId, columns);
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		/// </item>
		/// <item>
		/// <description>In case the data contains null references, the corresponding cells will be cleared.</description>
		/// </item>
		/// <item>
		/// <description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		/// </item>
		/// <item>
		/// <description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		/// </item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		/// </list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, object[] columns, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>This overload is currently not supported.</description>
		/// </item>
		/// <item>
		/// <description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		/// </item>
		/// <item>
		/// <description>In case the data contains null references, the corresponding cells will be cleared.</description>
		/// </item>
		/// <item>
		/// <description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		/// </item>
		/// <item>
		/// <description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		/// </item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		/// </list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, List<object[]> columns, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="option">SaveOption.Full = unspecified primary keys are removed, SaveOption .Partial = rows with unspecified primary keys are preserved.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method overload with the SaveOption parameter accepts table rows instead of columns (whereas the other method overloads accept table columns). The implementation of this overload takes the provided list of rows and constructs an array where each element represents a column.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, List<object[]> rows, SaveOption option)
		{
			return null;
		}

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="option">SaveOption.Full = unspecified primary keys are removed, SaveOption .Partial = rows with unspecified primary keys are preserved.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 call NT_FILL_ARRAY.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the <c>autoincrement</c> column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type <c>retrieved</c>. In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method overload with the SaveOption parameter accepts table rows instead of columns (whereas the other method overloads accept table columns). The implementation of this overload takes the provided list of rows and constructs an array where each element represents a column.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArray(SLProtocol protocol, int tableId, List<object[]> rows, SaveOption option, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This overload is currently not supported.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 call ("NT_FILL_ARRAY_NO_DELETE").</description>
		///			</item>
		///			<item>
		///				<description>In case the column data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArrayNoDelete(SLProtocol protocol, int tableId, List<object[]> columns)
		{
			return null;
		}

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This overload is currently not supported.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 call ("NT_FILL_ARRAY_NO_DELETE").</description>
		///			</item>
		///			<item>
		///				<description>In case the column data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArrayNoDelete(SLProtocol protocol, int tableId, List<object[]> columns, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 call ("NT_FILL_ARRAY_NO_DELETE").</description>
		///			</item>
		///			<item>
		///				<description>In case the column data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArrayNoDelete(SLProtocol protocol, int tableId, object[] columns)
		{
			return null;
		}

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 call ("NT_FILL_ARRAY_NO_DELETE").</description>
		///			</item>
		///			<item>
		///				<description>In case the column data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.FillArray instead", false)]
		public static object FillArrayNoDelete(SLProtocol protocol, int tableId, object[] columns, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Sets the specified cells of a column with the provided values.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columnPid">The ID of the column parameter.</param>
		/// <param name="keys">The primary keys of the rows for which the column has to be updated.</param>
		/// <param name="values">The values to set.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <exception cref="ArgumentException">The length of 'keys' is not equal to the length of 'values' and the length of the values array does not equal 1.</exception>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item><description>This method acts as a wrapper for a NotifyProtocol type 220 call ("NT_FILL_ARRAY_WITH_COLUMN").</description></item>
		///			<item><description>In case the values array only contains one value, this value will be used for all specified primary keys.</description></item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		public static object FillArrayWithColumn(SLProtocol protocol, int tableId, int columnPid, object[] keys, object[] values, DateTime? timeInfo)
		{
			return null;
		}

		/// <summary>
		/// Sets the specified cells of a column with the provided values.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="columnPid">The ID of the column parameter.</param>
		/// <param name="keys">The primary keys of the rows for which the column has to be updated.</param>
		/// <param name="values">The values to set.</param>
		/// <exception cref="ArgumentException">The length of 'primaryKeys' is not equal to the length of 'values' and the length of the values array does not equal 1.</exception>
		/// <returns></returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item><description>This method acts as a wrapper for a NotifyProtocol type 220 call ("NT_FILL_ARRAY_WITH_COLUMN").</description></item>
		///			<item><description>In case the values array only contains one value, this value will be used for all specified primary keys.</description></item>
		///		</list>
		/// </remarks>
		public static object FillArrayWithColumn(SLProtocol protocol, int tableId, int columnPid, object[] keys, object[] values)
		{
			return null;
		}

		/// <summary>
		/// Gets the position of the row with the specified primary key in the table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the column parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <returns>The position of the row in the table.</returns>
		/// <remarks>
		/// <para>This method acts as a wrapper for a NotifyProtocol type 163 call ("NT_GET_KEY_POSITION").</para>
		/// </remarks>
		[Obsolete("Use protocol.GetKeyPosition instead", false)]
		public static int GetKeyPosition(SLProtocol protocol, int tableId, string key)
		{
			return 0;
		}

		/// <summary>
		/// Gets the primary keys or display keys of the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <param name="type">Specify KeyType.DisplayKey to retrieve the display keys.</param>
		/// <returns>The primary keys or display keys of the rows present in the table.</returns>
		/// <remarks>
		/// <para>Avoid using the GetKeys method to retrieve the primary keys (NotifyProtocol.KeyType.Index) for DataMiner versions prior to DataMiner 9.0. Up to DataMiner 9.0, the implementation to retrieve the primary keys is based on the SLElement process (a NotifyProtocol type 168 call "NT_GET_INDEXES" is executed, which retrieves both the primary keys and the display keys.).</para>
		///<para>From DataMiner version 9.0 onwards, the implementation of the GetKeys method has been updated, so that retrieving the primary keys no longer involves the SLElement process. (This now results in a NotifyProtocol type 397 call "NT_GET_KEYS_SLPROTOCOL"). However, note that obtaining the display keys(NotifyProtocol.KeyType.DisplayKey) is still based on SLElement(a NotifyProtocol type 168 call "NT_GET_INDEXES" call).</para>
		/// </remarks>
		[Obsolete("Use protocol.GetKeys instead", false)]
		public static string[] GetKeys(SLProtocol protocol, int tableId, KeyType type = KeyType.Index)
		{
			return null;
		}

		/// <summary>
		/// Retrieves the primary keys of the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table parameter</param>
		/// <returns>The primary keys of the rows present in the table.</returns>
		/// <remarks>
		/// <para>Avoid using the GetKeys method to retrieve the primary keys (NotifyProtocol.KeyType.Index) for DataMiner versions prior to DataMiner 9.0. Up to DataMiner 9.0, the implementation to retrieve the primary keys is based on the SLElement process (a NotifyProtocol type 168 call "NT_GET_INDEXES" is executed, which retrieves both the primary keys and the display keys.).</para>
		///<para>From DataMiner version 9.0 onwards, the implementation of the GetKeys method has been updated, so that retrieving the primary keys no longer involves the SLElement process. (This now results in a NotifyProtocol type 397 call "NT_GET_KEYS_SLPROTOCOL"). However, note that obtaining the display keys(NotifyProtocol.KeyType.DisplayKey) is still based on SLElement(a NotifyProtocol type 168 call "NT_GET_INDEXES" call).</para>
		/// </remarks>
		[Obsolete("Use protocol.GetKeys instead", false)]
		public static string[] GetKeys(SLProtocol protocol, int tableId)
		{
			return null;
		}

		/// <summary>
		/// Gets the primary keys of all rows that have the specified value for the specified column.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="columnPid">The ID of the column parameter.</param>
		/// <param name="value">The value to match.</param>
		/// <returns>The primary keys of the rows that have the specified value for the specified column.</returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>In order for this method to work, the column must either be a foreign key column or it must have the option ‘indexColumn’.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 196 call (“NT_GET_KEYS_FOR_INDEX”).</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 9.0.0 [CU14] (Main Release) and DataMiner 9.0.5 [CU1] (Feature Release) (RN 15333) onwards, this call does no longer perform a case sensitive lookup. In case a case-sensitive lookup is required, use the NT_GET_KEYS_FOR_INDEX_CASED notify type (411).</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.GetKeysForIndex instead", false)]
		public static string[] GetKeysForIndex(SLProtocol protocol, int columnPid, string value)
		{
			return null;
		}

		/// <summary>
		/// Gets the number of rows of the specified table.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="tableId">The ID of the table.</param>
		/// <returns>The number of rows in the table. If the table was not found, a value of -1 is returned.</returns>
		/// <remarks>
		/// <para>This is a wrapper method for a NotifyProtocol type 195 call ("NT_ARRAY_ROW_COUNT").</para>
		/// </remarks>
		[Obsolete("Use protocol.RowCount instead", false)]
		public static int RowCount(SLProtocol protocol, int tableId)
		{
			return 0;
		}

		/// <summary>
		/// Sets the value of the specified parameter to the specified byte array.
		/// </summary>
		/// <param name="protocol">Instance that implements <see cref="SLProtocol"/>.</param>
		/// <param name="pid">The ID of the parameter.</param>
		/// <param name="data">The binary data to set.</param>
		/// <remarks>
		///		<list type="bullet">
		///		<item>
		///			<description>This method acts as a wrapper for a NotifyProtocol type 177 call ("NT_SET_BINARY_DATA").</description>
		///		</item>
		///			<item>
		///				<description>Setting a parameter value using this method does not trigger a change event.</description>
		///			</item>
		///		</list>
		/// </remarks>
		[Obsolete("Use protocol.SetParameterBinary instead", false)]
		public static void SetParameterBinary(SLProtocol protocol, int pid, byte[] data)
		{
		}

		/// <summary>
		/// Defines the key type.
		/// </summary>
		/// <remarks>
		/// <para>This enum is used with the <see cref="SLProtocol.GetKeys(int, KeyType)"/> method.</para>
		/// </remarks>
		public enum KeyType
		{
			/// <summary>
			/// Primary key.
			/// </summary>
			Index,
			/// <summary>
			/// Display key.
			/// </summary>
			DisplayKey,
		}

		/// <summary>
		/// Defines the save option.
		/// </summary>
		/// <remarks>SaveOption is used by the <see cref="SLProtocol.FillArray(int, List{object[]}, SaveOption, DateTime?)"/> method.</remarks>
		public enum SaveOption
		{
			/// <summary>
			/// Full: Unspecified primary keys are removed.
			/// </summary>
			Full = 193, // 0x000000C1
			/// <summary>
			/// Partial: Unspecified primary keys remain untouched.
			/// </summary>
			Partial = 194, // 0x000000C2
		}
	}
}
