using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Automation;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// SLProtocol interface allowing communication with the SLProtocol process.
	/// </summary>
	/// <remarks>
	/// <note type="note">SLProtocol is an interface from DMA 10.0.1 onwards (RN 23787). In earlier DataMiner versions, it is a concrete class.</note>
	/// <para>All methods are blocking, except for the <see cref="SLProtocol.NotifyDataMinerQueued"/> method.</para>
	/// <para>Many methods defined in this class also act as a wrapper for a specific <see cref="SLProtocol.NotifyProtocol"/>, <see cref="SLProtocol.NotifyDataMiner"/> or <see cref="SLProtocol.NotifyDataMinerQueued"/> method call. Using these methods is generally preferred over using the specific notify calls as this improves readability and type safety.</para>
	/// <para>From DataMiner 10.2.9 onwards (RN 33965), the SLProtocol(Ext) object in QActions will retain all of its data members outside of the Run scope. This means that, while Notifies were already available out of scope earlier, members such as the QActionID will now also remain available when a QAction run ends. In addition, the SLNet connection can now be set up at any time.</para>
	/// </remarks>
	public interface SLProtocol
	{
		/// <summary>
		/// Adds a row to the table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="row">The row data.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 149 call ("NT_ADD_ROW").</description>
		///			</item>
		///			<item>
		///				<description>Available from DataMiner 10.1.1 (RN 27995) onwards. Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///			<description>
		///			<para>To add a row with a specific time stamp:</para>
		///			<para>row (object[]):</para>
		///			<list type="bullet">
		///			<item><description>row[0] (object[]): the row data</description></item>
		///			<item><description>row[1] (DateTime): the time stamp</description></item>
		///			</list>
		///			<code>
		///			int tableID = 1000;
		///			object rowData = new object[] { "Key 200", "S", "20.20" };
		///			DateTime timeStamp = DateTime.Now - TimeSpan.FromDays(2);
		///			
		///			protocol.AddRow(tableId, new object[] { rowData, timeStamp});
		///			</code>
		///			</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// 
		int AddRow(int tableID, object[] row);

		/// <summary>
		/// Adds a row to the specified table with the specified primary key.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <returns>The 1-based internal position of the row in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 149 call ("NT_ADD_ROW").</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///		</list>
		/// </remarks>
		int AddRow(int tableID, string primaryKey);

		/// <summary>
		/// Adds the specified row to the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="row">The row data.</param>
		/// <param name="keyMasks">Sets are done in two calls. The first call only sets the columns where the corresponding mask position is set to true, the second call then sets the other columns.</param>
		/// <exception cref="ArgumentException">The row and key mask arrays have a different length.</exception>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 149 call ("NT_ADD_ROW").</description>
		///			</item>
		///			<item>
		///				<description>Available from DataMiner 10.1.1 (RN 27995) onwards. Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///		</list>
		/// </remarks>
		void AddRow(int tableID, object[] row, bool[] keyMasks);

		/// <summary>
		/// Adds a row to the specified table and returns the primary key.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <returns>The primary key of the added row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method overload is intended to be used with a table that has an auto-incrementing key.</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 240 call ("NT_ADD_ROW_RETURN_KEY"). See NT_ADD_ROW_RETURN_KEY (240).</description>
		///			</item>
		///		</list>
		/// </remarks>
		string AddRowReturnKey(int tableID);

		/// <summary>
		/// Removes all rows from the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <returns>The number of rows left. In case the ClearAllKeys method has been invoked specifying an empty table, -1 is returned.</returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method first retrieves all primary keys from the table using a NotifyProtocol type 168 (<see href="xref:NT_GET_INDEXES">NT_GET_INDEXES</see>) call. If there is at least one primary key present, the method performs a NotifyProtocol type 156 <see href="xref:NT_DELETE_ROW">NT_DELETE_ROW</see> call, removing all rows.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object ClearAllKeys(int tableID);

		/// <summary>
		/// Removes the specified row(s) from the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="rowIndex">The index of the row.</param>
		/// <returns>Number of remaining rows in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 156 <see href="xref:NT_DELETE_ROW">NT_DELETE_ROW</see> call.</description>
		///			</item>
		///		</list>
		/// </remarks>
		int DeleteRow(int tableID, int rowIndex);

		/// <summary>
		/// Removes the specified row(s) from the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="primaryKey">The primary key of the row to remove.</param>
		/// <returns>Number of remaining rows in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 156 <see href="xref:NT_DELETE_ROW">NT_DELETE_ROW</see> call.</description>
		///			</item>
		///		</list>
		/// </remarks>
		int DeleteRow(int tableID, string primaryKey);

		/// <summary>
		/// The ID of the table parameter.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="primaryKeys">The primary keys of the rows to remove.</param>
		/// <returns>Number of remaining rows in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 156 <see href="xref:NT_DELETE_ROW">NT_DELETE_ROW</see> call.</description>
		///			</item>
		///		</list>
		/// </remarks>
		int DeleteRow(int tableID, string[] primaryKeys);

		/// <summary>
		/// Executes the specified Automation script.
		/// </summary>
		/// <param name="message">Information about the script to execute.</param>
		/// <returns>Information about the execution of the Automation script.</returns>
		/// <remarks>
		/// <para>The script will be executed by the user who is performing the QAction. It will return an <see cref="ExecuteScriptResponseMessage"/>, containing information about the execution of the script.</para>
		/// <para>Using this overload of the ExecuteScript method is particularly useful when the script in question needs a dummy or protocol information to run.</para>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 24475).</para>
		/// </remarks>
		/// <examples>
		/// <code>
		/// try
		/// {
		///		string[] scriptOptions = { "OPTIONS:0", "CHECKSETS:TRUE", "EXTENDED_ERROR_INFO", "DEFER:TRUE" };
		///
		///		 ExecuteScriptMessage message = new ExecuteScriptMessage
		///		 {
		///			ScriptName = "Automation script",
		///			Options = new SA(scriptOptions),
		///			DataMinerID = -1,
		///			 HostingDataMinerID = -1
		///		};
		///		
		///		var response = protocol.ExecuteScript(message);
		///		bool succeeded = response != null &amp;&amp; !response.HadError;
		///		
		///		if (!succeeded)
		///		{
		///			// Script did not succeed.
		///		}
		/// }
		/// catch (Exception ex)
		/// {
		///		protocol.Log("QA" + protocol.QActionID + "|" + protocol.GetTriggerParameter() + "|Run|Exception thrown:" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
		/// }
		/// </code>
		/// <para>In the example above, note the use of the options "EXTENDED_ERROR_INFO" and "DEFER:TRUE".</para>
		/// <para>The ErrorMessages property of ExecuteScriptResponseMessage can contain error strings from two stages of executing a script:</para>
		/// <list type="number">
		/// <item>
		/// <description>When something went wrong while the script was being loaded and prepared for execution.</description>
		/// </item>
		/// <item>
		/// <description>Errors that occurred in the script.</description>
		/// </item>
		/// </list>
		/// <para>When you send an ExecuteScriptMessage, the script will by default be executed asynchronously. This means that the script will be scheduled, and a response message is returned with only the errors of stage 1. When you enable synchronous execution, the call will wait until the script is finished, and return the errors from the script (stage 2) as well.</para>
		/// <para>You can enable this by adding the option string “DEFER:FALSE'” to the Options property of ExecuteScriptMessage.</para>
		/// <para>You should also include the "EXTENDED_ERROR_INFO" option as this will make sure that the errors are returned in the response message. (Otherwise SLAutomation will throw an exception when the script fails and the errors are lost).</para>
		/// <para>The HadError property will return true when the ErrorCode property has a code (int) lower than 0, indicating that something went wrong.</para>
		/// <para>For another example that illustrates the execution of an Automation script with a custom entry point, refer to <see cref="AutomationEntryPoint"/> class.</para>
		/// </examples>
		ExecuteScriptResponseMessage ExecuteScript(ExecuteScriptMessage message);

		/// <summary>
		/// Executes the Automation script with the specified name.
		/// </summary>
		/// <param name="scriptName">The name of the Automation script to execute.</param>
		/// <returns>Information about the execution of the Automation script.</returns>
		/// <remarks>
		/// <para>The script will be executed by the user who is performing the QAction. It will return an <see cref="ExecuteScriptResponseMessage"/>, containing information about the execution of the script.</para>
		/// <para>If you execute a script using this method, it will be executed with all script execution settings set to the default values. If more control is needed, then use the <see cref="SLProtocol.ExecuteScript(ExecuteScriptMessage)"/> overload.</para>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 24475).</para>
		/// </remarks>
		ExecuteScriptResponseMessage ExecuteScript(string scriptName);

		/// <summary>
		/// Determines whether a row with the specified primary key exists in the specified table.
		/// </summary>
		/// <param name="tableID">ID of the table parameter</param>
		/// <param name="primaryKey">The primary key of the row.</param>
		/// <returns>Indication of whether the table contains a row with the specified primary key. True means that a row with the primary key is present, false means otherwise.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 265 <see href="xref:NT_EXISTS_ROW">NT_EXISTS_ROW</see> call.</description>
		///			</item>
		///		</list>
		/// </remarks>
		bool Exists(int tableID, string primaryKey);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="option">SaveOption.Full = unspecified primary keys are removed; SaveOption .Partial = rows with unspecified primary keys are preserved.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method overload with the saveOption parameter accepts table rows instead of columns (whereas the other method overloads accept table columns). The implementation of this overload takes the provided list of rows and constructs an array where each element represents a column.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, List<object[]> rows, NotifyProtocol.SaveOption option);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="rows">The rows of the table.</param>
		/// <param name="option">SaveOption.Full = unspecified primary keys are removed; SaveOption .Partial = rows with unspecified primary keys are preserved.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method overload with the saveOption parameter accepts table rows instead of columns (whereas the other method overloads accept table columns). The implementation of this overload takes the provided list of rows and constructs an array where each element represents a column.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, List<object[]> rows, NotifyProtocol.SaveOption option, DateTime? timeInfo);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///			<description>This overload is supported from DataMiner 10.2.7 (RN 28573) onwards.</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, List<object[]> columns, DateTime? timeInfo);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, object[] columns, DateTime? timeInfo);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, object[] columns);

		/// <summary>
		/// Sets the content of the table to the provided content.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///			<description>This overload is supported from DataMiner 10.2.7 onwards (RN 28573).</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 193 <see href="xref:NT_FILL_ARRAY">NT_FILL_ARRAY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArray method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArray(int tableID, List<object[]> columns);

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method is defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 <see href="xref:NT_FILL_ARRAY_NO_DELETE">NT_FILL_ARRAY_NO_DELETE</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArrayNoDelete(int tableID, object[] columns);

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This overload is supported from DataMiner 10.2.7 onwards (RN 28573).</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method is defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 <see href="xref:NT_FILL_ARRAY_NO_DELETE">NT_FILL_ARRAY_NO_DELETE</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
		///			</item>
		///			<item>
		///				<description>The FillArrayNoDelete method cannot be used together with the "autoincrement" column type.</description>
		///			</item>
		///			<item>
		///				<description>This call is to be used with columns of type "retrieved". In case other column types are present between the specified columns (e.g. columns of type "custom"), these other columns will be skipped.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArrayNoDelete(int tableID, List<object[]> columns);

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This overload is supported from DataMiner 10.2.7 onwards (RN 28573).</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method is defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 <see href="xref:NT_FILL_ARRAY_NO_DELETE">NT_FILL_ARRAY_NO_DELETE</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
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
		object FillArrayNoDelete(int tableID, List<object[]> columns, DateTime? timeInfo);

		/// <summary>
		/// Adds the provided rows to the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columns">The columns of the table.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method is defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 194 <see href="xref:NT_FILL_ARRAY_NO_DELETE">NT_FILL_ARRAY_NO_DELETE</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the data contains null references, the corresponding cells will be cleared.</description>
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
		object FillArrayNoDelete(int tableID, object[] columns, DateTime? timeInfo);

		/// <summary>
		/// Sets the specified cells of a column with the provided values.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columnID">The ID of the column parameter.</param>
		/// <param name="primaryKeys">The primary keys of the rows for which the column has to be updated.</param>
		/// <param name="values">The values to set.</param>
		/// <param name="timeInfo">Time stamp</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">The length of "primaryKeys" is not equal to the length of "values" and the length of the values array does not equal 1.</exception>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 220 <see href="xref:NT_FILL_ARRAY_WITH_COLUMN">NT_FILL_ARRAY_WITH_COLUMN</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the values array only contains one value, this value will be used for all specified primary keys.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArrayWithColumn(int tableID, int columnID, object[] primaryKeys, object[] values, DateTime? timeInfo);

		/// <summary>
		/// Sets the specified cells of a column with the provided values.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="columnID">The ID of the column parameter.</param>
		/// <param name="primaryKeys">The primary keys of the rows for which the column has to be updated.</param>
		/// <param name="values">The values to set.</param>
		/// <returns></returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 220 <see href="xref:NT_FILL_ARRAY_WITH_COLUMN">NT_FILL_ARRAY_WITH_COLUMN</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the values array only contains one value, this value will be used for all specified primary keys.</description>
		///			</item>
		///		</list>
		/// </remarks>
		object FillArrayWithColumn(int tableID, int columnID, object[] primaryKeys, object[] values);

		/// <summary>
		/// Gets the primary keys or display keys of the specified table.
		/// </summary>
		/// <param name="tableID">The ID of the table parameter.</param>
		/// <param name="keyType">Specify KeyType.DisplayKey to retrieve the display keys.</param>
		/// <returns>The primary keys or display keys of the rows present in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///		</list>
		/// </remarks>
		string[] GetKeys(int tableID, NotifyProtocol.KeyType keyType);

		/// <summary>
		/// Gets the primary keys of the specified table.
		/// </summary>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <returns>The primary keys of the rows present in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///		</list>
		/// </remarks>
		string[] GetKeys(int tableId);

		/// <summary>
		/// Gets the primary keys of all rows that have the specified value for the specified column. 
		/// </summary>
		/// <param name="columnID">The ID of the column parameter.</param>
		/// <param name="value">The value to match.</param>
		/// <returns>The primary keys of the rows that have the specified value for the specified column.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In order for this method to work, the column must either be a foreign key column or it must have the option 'indexColumn'.</description>
		///			</item>
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 196 <see href="xref:NT_GET_KEYS_FOR_INDEX">NT_GET_KEYS_FOR_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>This call does not perform a case-sensitive lookup. In case a case-sensitive lookup is required, use the <see href="xref:NT_GET_KEYS_FOR_INDEX_CASED">NT_GET_KEYS_FOR_INDEX_CASED</see> notify type (411).</description>
		///			</item>
		///		</list>
		/// </remarks>
		string[] GetKeysForIndex(int columnID, string value);

		/// <summary>
		/// Retrieves the value of the parameter with the specified ID.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <returns>The value of the parameter. If no parameter with the specified ID exists in the protocol, <see langword="null"/> is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the Notify type 73 <see href="xref:NT_GET_PARAMETER">NT_GET_PARAMETER</see> call.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameter call is executed for a parameter that does not exist in the protocol, <see langword="null"/> is returned and the following message will be logged “NT_GET_PARAMETER for [parameterID] failed. 0x80040239”.</description>
		///			</item>
		///			<item>
		///				<description>When calling this method on a numeric standalone parameter(i.e.a parameter having RawType set to either numeric text, signed number or unsigned number) that is not initialized, 0 will be returned.To determine whether a standalone parameter is uninitialized, the <see cref="IsEmpty"/> method should be used.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string myValue = Convert.ToString(protocol.GetParameter(100));
		/// </code>
		/// </example>
		object GetParameter(int iID);

		/// <summary>
		/// Sets the parameter with the specified ID to the specified value.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In case multiple parameters need to be set, it is preferred to use a single SetParameters method call in order to reduce the inter-process communication between the SLScripting and SLProtocol processes.</description>
		///			</item>
		///			<item>
		///				<description>The method SetParameter(int parameterID, object value, DateTime timestamp) acts a wrapper method for a NotifyProtocol type 256 <see href="xref:NT_SET_PARAMETER_WITH_HISTORY">NT_SET_PARAMETER_WITH_HISTORY</see> call.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///			<item>
		///				<description>A <see langword="null"/> value will not clear the parameter but keep its current value. To clear a parameter, see <see href="xref:LogicActionClear" />.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	protocol.SetParameter(100, "myValue", DateTime.Now);
		/// </code>
		/// </example>
		int SetParameter(int iID, object value, ValueType timeInfo);

		/// <summary>
		/// Sets the value of the specified parameter to the specified byte array.
		/// </summary>
		/// <param name="parameterID">The ID of the parameter.</param>
		/// <param name="data">The binary data to set.</param>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 177 call <see href="xref:NT_SET_BINARY_DATA">NT_SET_BINARY_DATA</see>.</description>
		///			</item>
		///			<item>
		///				<description>Only supported for parameters with <see href="xref:Protocol.Params.Param.Interprete.LengthType">LengthType</see> set to <c>fixed</c>, <c>next param</c> or <c>last next param</c>. For parameters with LengthType set to <c>fixed</c>, the number of bytes that will be set is limited to the value specified in <see href="xref:Protocol.Params.Param.Interprete.Length">Length</see>.</description>
		///			</item>
		///			<item>
		///				<description>Setting a parameter value using this method does not trigger a change event. Refer to <see href="xref:LogicParameters#parameter-change-events"/> for more information on the implications.</description>
		///			</item>
		///		</list>
		/// </remarks>
		void SetParameterBinary(int parameterID, byte[] data);

		/// <summary>
		/// Sets the parameter with the specified ID to the specified value.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In case multiple parameters need to be set, it is preferred to use a single SetParameters method call in order to reduce the inter-process communication between the SLScripting and SLProtocol processes.</description>
		///			</item>
		///			<item>
		///				<description>A <see langword="null"/> value will not clear the parameter but keep its current value. To clear a parameter, see <see href="xref:LogicActionClear" />.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	protocol.SetParameter(100, "myValue");
		/// </code>
		/// </example>
		int SetParameter(int iID, object value);

		/// <summary>
		/// Sets the parameters with the specified IDs to the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the parameters to set.</param>
		/// <param name="values">The values to set.</param>
		/// <param name="timeInfos">Time stamps.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error (e.g. when the size of the parameterIDs array does not match the size of the values array) or an array of HRESULT values (uint[]) (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of an entry in <paramref name="timeInfos"/> is unspecified, the timestamp entry will be handled as local time.</description>
		///			</item>
		///			<item>
		///				<description>A <see langword="null"/> value will not clear the parameter but keep its current value. To clear a parameter, see <see href="xref:LogicActionClear" />.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	DateTime timeStamp = DateTime.Now;
		///	protocol.SetParameters(new int[] { 31, 32 }, new object[] { "value A", "value B" }, new DateTime[]{ timeStamp, timeStamp });
		/// </code>
		/// </example>
		object SetParameters(int[] ids, object[] values, DateTime[] timeInfos);

		/// <summary>
		/// Sets the parameters with the specified IDs to the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the parameters to set.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error (e.g. when the size of the parameterIDs array does not match the size of the values array) or an array of HRESULT values (uint[])  (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>A <see langword="null"/> value will not clear the parameter but keep its current value. To clear a parameter, see <see href="xref:LogicActionClear" />.</description>
		///			</item>		
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	protocol.SetParameters(new int[] { 31, 32 }, new object[] { "value A", "value B" });
		/// </code>
		/// </example>
		object SetParameters(int[] ids, object[] values);

		/// <summary>
		/// Retrieves the value of the parameter with the specified name.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <returns>The parameter value.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> This is a wrapper method for the NotifyProtocol type 85 <see href="xref:NT_GET_PARAMETER_BY_NAME">NT_GET_PARAMETER_BY_NAME</see> call.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameter call is executed for a parameter name that does not exist in the protocol a null reference is returned and the following message will be logged “NT_GET_PARAMETER_BY_NAME for [name] failed. 0x80040239”.</description>
		///			</item>
		///			<item>
		///				<description>In case there is both a read and write parameter with the specified name, the value of the write parameter will be returned.</description>
		///			</item>
		///			<item>
		///				<description>When calling this method on a numeric parameter (i.e.a parameter having RawType set to either numeric text, signed number or unsigned number) that is not initialized, 0 will be returned.To determine whether a standalone parameter is uninitialized, the IsEmpty method should be used.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string myValue = Convert.ToString(protocol.GetParameterByName("myParameter"));
		/// </code>
		/// </example>
		object GetParameterByName(string name);

		/// <summary>
		/// Gets the values of multiple standalone parameters.
		/// </summary>
		/// <param name="ids">The IDs of the parameters to retrieve.</param>
		/// <returns>The values of the retrieved parameters.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<para> This is a wrapper method for the NotifyProtocol type 73 <see href="xref:NT_GET_PARAMETER">NT_GET_PARAMETER</see> call.</para>
		///			</item>
		///			<item>
		///				<para>In case a provided parameter ID in the parameterIDs array does not exist in the protocol, the returned object array will contain a null reference.</para>
		///			</item>
		///			<item>
		///				<para>When calling this method on a numeric parameter(i.e.a parameter having RawType set to either numeric text, signed number or unsigned number) that is not initialized, 0 will be returned.To determine whether a standalone parameter is uninitialized, the <see cref="IsEmpty"/> method should be used.</para>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	object[] parameters = (object[])protocol.GetParameters(new uint[] { 631, 831, 31 });
		/// </code>
		/// </example>
		object GetParameters(object ids);

		/// <summary>
		/// Sets the parameter with the specified name to the specified value.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 84 NT_SET_PARAMETER_BY_NAME call.</description>
		///			</item>
		///			<item>
		///				<description>In case there are both a read and write parameter with the specified name, the set will be performed on the write parameter.In case the read parameter needs to be set, use the SetReadParameterByName method instead.</description>
		///			</item>
		///			<item>
		///				<description>In case multiple parameters need to be set, it is preferred to use a single SetParametersByName method call in order to reduce the inter-process communication between the SLScripting and SLProtocol processes.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	int result = protocol.SetParameterByName("myParameter", "myValue");
		/// </code>
		/// </example>
		int SetParameterByName(string name, object value);

		/// <summary>
		/// Sets the parameters with the specified names to the specified values.
		/// </summary>
		/// <param name="names">The names of the parameters to set.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error (e.g. when the size of the names array does not match the size of the values array) or an array of HRESULT values (uint[]) (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set. In case the value in the array is 0 (S_OK), this indicates that the set for the corresponding parameter succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 84 NT_SET_PARAMETER_BY_NAME call.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersByName(string[] names, object[] values);

		/// <summary>
		/// Sets the read parameter with the specified name to the specified value.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>Feature introduced in DataMiner version 7.5.4.1 (RN 5177).</description>
		///			</item>
		///		</list>
		///	</remarks>
		int SetReadParameterByName(string name, object value);

		/// <summary>
		/// Sets the write parameter with the specified name to the specified value.
		/// </summary>
		/// <param name="name">The name of the write parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		///<remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner version 7.5.4.1 (RN 5177).</description>
		///			</item>
		///		</list>
		///	</remarks>
		int SetWriteParameterByName(string name, object value);

		/// <summary>
		/// Sets the read parameters with the specified name to the specified values.
		/// </summary>
		/// <param name="names">The names of the parameters.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error (e.g. when the size of the names array does not match the size of the values array) or an array of HRESULT values (uint[]) (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set. In case the value in the array is 0 (S_OK), this indicates that the set for the corresponding parameter succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetReadParametersByName(string[] names, object[] values);

		/// <summary>
		/// Sets the write parameters with the specified names to the specified values.
		/// </summary>
		/// <param name="names">The names of the write parameter.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error (e.g. when the size of the names array does not match the size of the values array) or an array of HRESULT values (uint[]) (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set. In case the value in the array is 0 (S_OK), this indicates that the set for the corresponding parameter succeeded.</returns>
		/// <remarks>
		/// 	<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetWriteParametersByName(string[] names, object[] values);

		/// <summary>
		///	Gets the Agent ID of the element executing the QAction.
		///	</summary>
		///	<value>The Agent ID of the element executing the QAction.</value>
		///	<remarks>
		///	<note type="note">This is the ID of the Agent where the element was originally created, which can be different from the ID of the Agent that is currently hosting the element because of DELT. (DELT stands for DataMiner Element Location Transparency. It is the feature that allows exporting and importing packages as well as migration of elements across Agents in a DataMiner System.)</note>
		/// </remarks>
		///	<example>
		///	<code>
		///	int agentId = protocol.DataMinerID;
		/// </code>
		/// </example>
		int DataMinerID { get; }

		/// <summary>
		/// Gets the ID of the element that triggered this QAction execution.
		///	</summary>
		///	<value>The element ID.</value>
		///	<example>
		///	<code>
		///	int elementId = protocol.ElementID;
		/// </code>
		/// </example>
		int ElementID { get; }

		/// <summary>
		/// Gets the name of the element that triggered this QAction execution.
		///	</summary>
		///	<value>The element name.</value>
		///	<example>
		///	<code>
		///	string elementName = protocol.ElementName;
		/// </code>
		/// </example>
		string ElementName { get; }

		/// <summary>
		/// Gets the username of the user who triggered the QAction.
		/// </summary>
		/// <value>The user name.</value>
		/// <remarks>
		///		<para>Returns the userInfo on who triggered the QAction.This can be useful for write parameters if you want to know who did the set.</para>
		///		<para>In case the "Full Name" field of the user has not been filled in, the content of the "Name" field of the user is returned.</para>
		///	</remarks>
		string UserInfo { get; }

		/// <summary>
		/// Gets the user cookie.
		/// </summary>
		/// <value>The user cookie.</value>
		string UserCookie { get; }

		/// <summary>
		/// Gets or sets the QAction metrics key.
		/// </summary>
		/// <value>In case QAction metrics are enabled (see QAction metrics), this will return the metrics key for this QAction. Otherwise, <see langword="null"/> is returned.</value>
		/// <remarks>For more information about QAction metrics, refer to QAction metrics.</remarks>
		string MetricsKey { get; set; }

		/// <summary>
		/// Gets or sets the protocol name.
		/// </summary>
		/// <value>The protocol name.</value>
		string ProtocolName { get; set; }

		/// <summary>
		/// Gets or sets the protocol version.
		/// </summary>
		/// <value>The protocol version.</value>
		string ProtocolVersion { get; set; }

		/// <summary>
		/// Gets the protocol version of the element.
		/// </summary>
		/// <value>The protocol version.</value>
		///	<remarks>
		///	<para>In case the element uses the production version, 'Production' is returned. If the actual version number is needed, use the <see cref="SLProtocol.ProtocolVersion"/> property.</para>
		///	</remarks>
		///	<example>
		///	<code>
		///	string protocolVersion = protocol.ElementProtocolVersion;
		/// </code>
		/// </example>
		string ElementProtocolVersion { get; set; }

		/// <summary>
		/// Gets the ID of the QAction.
		/// </summary>
		/// <value>The ID of the QAction.</value>
		int QActionID { get; set; }

		/// <summary>
		///	Gets the SLNet object used for communicating with the SLNet process.
		///	</summary>
		///	<value>The SLNet object used for communicating with the SLNet process.</value>
		SLNetConnection SLNet { get; }

		/// <summary>
		/// Gets the element state.
		/// </summary>
		/// <value>1 if the element is active (i.e. the element is not stopped); otherwise, 0.</value>
		///	<remarks>
		///	<para>This feature is useful in queued QActions, since the element might have been stopped before the QAction is actually run.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// int isActive = protocol.IsActive;
		/// </code>
		/// </example>
		int IsActive { get; }

		/// <summary>
		/// Retrieves the parameter value corresponding with the parameter that has the specified data is stored in the ElementData.xml file.
		/// </summary>
		/// <param name="data">The data value stored in the ElementData.xml for the parameter.</param>
		/// <returns>The parameter value. In case ElementData.xml does not contain a parameter with the specified data, a null reference is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 87 <see href="xref:NT_GET_PARAMETER_BY_DATA">NT_GET_PARAMETER_BY_DATA</see> call.</description>
		///			</item>
		///			<item>
		///				<description>This method is intended to be used when the data stored in the ElementData.xml file is unique for all parameters. If this is not the case, the method will return the value of one of the parameters that has the specified value in the ElementData.xml file.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<para>Consider the following parameter with default value ‘A’:</para>
		///	<code language = "xml" >
		///			<![CDATA[
		///<Param id = "1" trending = "false">
		///	<Name> ExampleParameter</Name>
		///	<Description>AnExampleParameter</Description>
		///	<Type>read</Type>
		///	<Interprete>
		///		<RawType>other</RawType>
		///		<LengthType>next param</LengthType>
		///		<Type>string</Type>
		///		<DefaultValue>A</DefaultValue>
		///	</Interprete>
		///	<Display>
		///		<RTDisplay>false</RTDisplay>
		///	</Display>
		///	<Measurement>
		///		<Type>string</Type>
		///	</Measurement>
		///</Param>
		///]]>
		///	</code>
		///	<para>Suppose the ElementData.xml file contains the following in the ItemData tag:</para>
		///	<code language = "xml" >
		///<![CDATA[
		///<ItemData>
		///	<Param id = "1">Data</Param>
		///</ItemData>
		///]]>
		///	</code>
		///	<para>In this example the result will be the string “A”.</para>
		///	<code>
		///		object result = protocol.GetParameterByData("Data");
		///	</code>
		///	</example>
		object GetParameterByData(string data);

		/// <summary>
		/// Sets the parameter that has the specified data in the ElementData.xml file to the specified value.
		/// </summary>
		/// <param name="data">The data value in the ElementData.xml file of the parameter to set.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		///	<remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 86 NT_SET_PARAMETER_BY_DATA call.</description>
		///			</item>
		///			<item>
		///				<description>In case multiple parameters need to be set by data, use the <see cref="SLProtocol.SetParametersByData"/> method instead.</description>
		///			</item>
		///		</list>
		///	</remarks>
		/// <example>
		///		<para>Consider the following parameter with default value “A”:</para>
		///		<code language = "xml" >
		///			<![CDATA[
		///	<Param id="1" trending="false">
		///		<Name>ExampleParameter</Name>
		///		<Description>AnExampleParameter</Description>
		///		<Type>read</Type>
		///		<Interprete>
		///			<RawType>other</RawType>
		///			<LengthType>next param</LengthType>
		///			<Type>string</Type>
		///			<DefaultValue>A</DefaultValue>
		///		</Interprete>
		///		<Display>
		///			<RTDisplay>false</RTDisplay>
		///		</Display>
		///		<Measurement>
		///			<Type>string</Type>
		///		</Measurement>
		///		</Param>
		///		]]>
		///		</code>
		///		<para>Suppose the ElementData.xml file contains the following in the ItemData tag:</para>
		///		<code language="xml">
		///		<![CDATA[
		///		<ItemData>
		///			 <Param id="1">Data</Param>
		///		</ItemData>
		///		]]>
		///		</code>
		///		<para>Then parameter 1 will have the value “B” after performing the following method call:</para>
		///		<code>
		///		 int result = protocol.SetParameterByData("Data", "B");
		///		 </code>
		///	</example>
		int SetParameterByData(string data, object value);

		/// <summary>
		/// Sets the parameters that have the specified data values in the ElementData.xml file to the specified values.
		/// </summary>
		/// <param name="datas">The data values for the parameters that need to be set.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error or an array of HRESULT values (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 86 NT_SET_PARAMETER_BY_DATA call.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersByData(string[] datas, object[] values);

		/// <summary>
		/// Gets the value stored for the specified parameter in the ElementData.xml file.
		/// </summary>
		/// <param name="data">The name of the parameter.</param>
		/// <returns>The value stored in the ElementData.xml file (as string). In case the ElementData.xml file did not contain a value for the specified parameter and the parameter is defined in the protocol, an empty string is returned. In case there is no parameter defined with the specified name, a null reference is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 88 <see href="xref:NT_GET_ITEM_DATA">NT_GET_ITEM_DATA</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object GetParameterItemData(string data);

		/// <summary>
		/// Sets the value stored for the specified parameter in the ElementData.xml file.
		/// </summary>
		/// <param name="data">The name of the parameter.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> This is a wrapper method for the NotifyProtocol type 89 <see href="xref:NT_SET_ITEM_DATA">NT_SET_ITEM_DATA</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The ElementData.xml file is located in the folder “C:\Skyline DataMiner\Elements\[ElementName]\”.</description>
		///			</item>
		///			<item>
		///				<description>When multiple parameters need to be set at once, use the <see cref="SLProtocol.SetParametersItemData"/> method instead.</description>
		///			</item>
		///		</list>
		///	</remarks>
		int SetParameterItemData(string data, object value);

		/// <summary>
		/// Sets the values stored for the specified parameters in the ElementData.xml file.
		/// </summary>
		/// <param name="datas">The names of the parameters.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>Either a single HRESULT (uint) value specifying an error or an array of HRESULT values (uint[]) (where the array has the same size as the number of parameters that have been set) where each HRESULT value indicates the result of the corresponding item that has been set.</returns>
		///<remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 89 <see href="xref:NT_SET_ITEM_DATA">NT_SET_ITEM_DATA</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The ElementData.xml file is located in the folder “C:\Skyline DataMiner\Elements\[ElementName]\”.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersItemData(string[] datas, object[] values);

		/// <summary>
		/// Retrieves the description of the specified parameter.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <returns>The parameter description as string. If no parameter with the specified ID exists in the protocol, a null reference is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 77 <see href="xref:NT_GET_DESCRIPTION">NT_GET_DESCRIPTION</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string description = Convert.ToString(protocol.GetParameterDescription(100));
		/// </code>
		/// </example>
		object GetParameterDescription(int iID);

		/// <summary>
		/// Sets the description of the specified parameter.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <param name="value">The description to set.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 131 <see href="xref:NT_SET_DESCRIPTION">NT_SET_DESCRIPTION</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	int result = protocol.SetParameterDescription(100, "My Description");
		/// </code>
		/// </example>
		int SetParameterDescription(int iID, object value);

		/// <summary>
		/// Retrieves the value of a cell in the table specified by the 1-based row and column position.
		/// </summary>
		/// <param name="iID">The ID of the table parameter.</param>
		/// <param name="iX">The 1-based position of the row.</param>
		/// <param name="iY">The 1-based position of the column.</param>
		/// <returns>The value of the cell.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> This is a wrapper method for the NotifyProtocol type 122 <see href="xref:NT_GET_PARAMETER_INDEX">NT_GET_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameterIndex call fails because the retrieved cell falls outside the bounds of the table, a null reference is returned and the following message is logged: “NT_GET_PARAMETER_INDEX for [tableID]/[rowPosition]/[columnPosition] failed. 0x80040244”.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameterIndex call fails because the protocol does not contain a table parameter with the provided table ID, a null reference is returned and the following message is logged: “NT_GET_PARAMETER_INDEX for [tableID]/[rowPosition]/[columnPosition] failed. 0x80040221”.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string myValue = Convert.ToString(protocol.GetParameterIndex(100, 5, 6));
		/// </code>
		/// </example>
		object GetParameterIndex(int iID, int iX, int iY);

		/// <summary>
		/// Sets the value of a cell in a table, identified by its 1-based row and column position, with the specified value.
		/// </summary>
		/// <param name="iID">The ID of the table parameter.</param>
		/// <param name="iX">The 1-based row position.</param>
		/// <param name="iY">The 1-based column position.</param>
		/// <param name="value">The value to set.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns>Whether the cell value has changed. <c>true</c> indicates change; otherwise, <c>false</c>.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>The primary key can never be updated.</description>
		///			</item>
		///			<item>
		///				<description>In case multiple cells need to be set, it is preferred to use a single SetParametersIndex method call in order to reduce the inter-process communication between the SLScripting and SLProtocol processes.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 call ("NT_PUT_PARAMETER_INDEX"). See [NT_PUT_PARAMETER_INDEX (121)](xref:NT_PUT_PARAMETER_INDEX).</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	bool hasSucceeded = protocol.SetParameterIndex(1000, 5, 6, "MyValue", DateTime.Now);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool SetParameterIndex(int iID, int iX, int iY, object value, ValueType timeInfo);

		/// <summary>
		/// Sets the value of a cell in a table, identified by its 1-based row and column position, with the specified value.
		/// </summary>
		/// <param name="iID">The ID of the table parameter.</param>
		/// <param name="iX">The 1-based row position.</param>
		/// <param name="iY">The 1-based column position.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>Whether the cell value has changed. <c>true</c> indicates change; otherwise, <c>false</c>.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>The primary key can never be updated.</description>
		///			</item>
		///			<item>
		///				<description>In case multiple cells need to be set, it is preferred to use a single SetParametersIndex method call in order to reduce the inter-process communication between the SLScripting and SLProtocol processes.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 <see href="xref:NT_PUT_PARAMETER_INDEX">NT_PUT_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	bool hasSucceeded = protocol.SetParameterIndex(1000, 5, 6, "MyValue");
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool SetParameterIndex(int iID, int iX, int iY, object value);

		/// <summary>
		/// Sets the value of cells in tables, identified by their 1-based row and column position, with the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the table parameters.</param>
		/// <param name="iXs">The 1-based positions of the rows.</param>
		/// <param name="iYs">The 1-based positions of the columns.</param>
		/// <param name="values">The values to set.</param>
		/// <param name="timeInfos">Time stamps.</param>
		/// <returns>This method call can return an unsigned integer error code, e.g. when the size of the <paramref name="ids"/> array does not match the size of the values array. Otherwise a uint[] is returned that has the same size as the <paramref name="ids"/> array containing the HRESULT value.At each position, this array contains the result value as would be returned when performing a SetParameterIndex call on the individual cell.In case the value in the array is 262730 (0x0004024AL), this indicates the cell value changed.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.2.7 (RN 33198), the SetParametersIndex method cannot be used to update a single cell. In case a single cell must be updated, use the SetParameterIndex method instead. In cases where you dynamically set a number of cells, make sure to check the number of cells that will need to be updated. In case multiple cells need to be updated, use the SetParametersIndex method. If a single cell needs to be updated, use the SetParameterIndex method.</description>
		///			</item>
		///			<item>
		///				<description>This method should only be used in case multiple distinct cells need to be set(e.g., cells in different tables). When appropriate, use the SetRow, FillArray, FillArrayNoDelete, NotifyProtocol type 220 call, etc.to set multiple cells belonging to the same row, column or table, respectively.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 <see href="xref:NT_PUT_PARAMETER_INDEX">NT_PUT_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of an entry of <paramref name="timeInfos"/> is unspecified, the timestamp of that entry will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersIndex(int[] ids, int[] iXs, int[] iYs, object[] values, DateTime[] timeInfos);

		/// <summary>
		/// Sets the value of cells in tables, identified by their 1-based row and column position, with the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the table parameters.</param>
		/// <param name="iXs">The 1-based positions of the rows.</param>
		/// <param name="iYs">The 1-based positions of the columns.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>This method call can return an unsigned integer error code, e.g. when the size of the <paramref name="ids"/> array does not match the size of the values array.Otherwise a uint[] is returned that has the same size as the <paramref name="ids"/> array containing the HRESULT value.At each position, this array contains the result value as would be returned when performing a SetParameterIndex call on the individual cell.In case the value in the array is 262730 (0x0004024AL), this indicates the cell value changed.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.2.7 (RN 33198), the SetParametersIndex method cannot be used to update a single cell. In case a single cell must be updated, use the SetParameterIndex method instead. In cases where you dynamically set a number of cells, make sure to check the number of cells that will need to be updated. In case multiple cells need to be updated, use the SetParametersIndex method. If a single cell needs to be updated, use the SetParameterIndex method.</description>
		///			</item>
		///			<item>
		///				<description>This method should only be used in case multiple distinct cells need to be set(e.g., cells in different tables). When appropriate, use the SetRow, FillArray, FillArrayNoDelete, NotifyProtocol type 220 call, etc.to set multiple cells belonging to the same row, column or table, respectively.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 <see href="xref:NT_PUT_PARAMETER_INDEX">NT_PUT_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersIndex(int[] ids, int[] iXs, int[] iYs, object[] values);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="iType">The type of message to send.</param>
		/// <param name="value1">Depends on the type of message to send.</param>
		/// <param name="value2">Depends on the type of message to send.</param>
		/// <returns>Depends on the type of message that has been sent.</returns>
		object NotifyClient(int iType, object value1, object value2);

		/// <summary>
		/// Sends a message to the SLDataMiner process via the SLProtocol process.
		/// </summary>
		/// <param name="iType">The type of message to send.</param>
		/// <param name="value1">Depends on the type of message to send.</param>
		/// <param name="value2">Depends on the type of message to send.</param>
		/// <returns>Depends on the type of message that has been sent.</returns>
		/// <remarks>Refer to [Notify Types overview](xref:NTNotifyTypesOverview) for an overview of the available Notify types.</remarks>
		object NotifyDataMiner(int iType, object value1, object value2);

		/// <summary>
		/// Sends a message to the SLProtocol process.
		/// </summary>
		/// <param name="iType">The type of message to send.</param>
		/// <param name="value1">Depends on the type of message to send.</param>
		/// <param name="value2">Depends on the type of message to send.</param>
		/// <returns>Depends on the type of message that has been sent.</returns>
		/// <remarks>Refer to [Notify Types overview](xref:NTNotifyTypesOverview) for an overview of the available Notify types.</remarks>
		object NotifyProtocol(int iType, object value1, object value2);

		/// <summary>
		/// Sends a queued message to the SLDataMiner process via the SLProtocol process.
		/// </summary>
		/// <param name="iType">The type of message to send.</param>
		/// <param name="value1">Depends on the type of message to send.</param>
		/// <param name="value2">Depends on the type of message to send.</param>
		/// <returns>(int): HRESULT value.</returns>
		/// <remarks>Refer to [Notify Types overview](xref:NTNotifyTypesOverview) for an overview of the available Notify types.</remarks>
		int NotifyDataMinerQueued(int iType, object value1, object value2);

		/// <summary>
		/// Retrieves the value of a cell in the table specified by the primary key and 1-based column position.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="iY">The 1-based position of the column.</param>
		/// <returns>The value of the cell.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 122 <see href="xref:NT_GET_PARAMETER_INDEX">NT_GET_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameterIndex call fails because the retrieved cell falls outside the bounds of the table, a null reference is returned and the following message is logged: “NT_GET_PARAMETER_INDEX for [tableID]/[primaryKey]/[columnPosition] failed. 0x80040244”.</description>
		///			</item>
		///			<item>
		///				<description>When a GetParameterIndex call fails because the protocol does not contain a table parameter with the provided table ID or the table does not contain a row with the provided primary key, a null reference is returned and the following message is logged: “NT_GET_PARAMETER_INDEX for [tableID]/[primaryKey]/[columnPosition] failed. 0x80040221”.</description>
		///			</item>
		///			<item>
		///				<description>GetParameterIndexByKey returns a null reference for uninitialized cells.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string myValue = Convert.ToString(protocol.GetParameterIndexByKey(100, "Row 1", 6));
		/// </code>
		/// </example>
		object GetParameterIndexByKey(int iPID, string key, int iY);

		/// <summary>
		/// Sets the value of a cell in a table, identified by the primary key of the row and column position, with the specified value.
		/// </summary>
		/// <param name="iID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="iY">The 1-based column position.</param>
		/// <param name="value">The value to set.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns>Whether the cell value has changed. <c>true</c> indicates change; otherwise, <c>false</c>.</returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>The primary key can never be updated.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 call ("NT_PUT_PARAMETER_INDEX"). See [NT_PUT_PARAMETER_INDEX (121)](xref:NT_PUT_PARAMETER_INDEX).</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	bool hasSucceeded = protocol.SetParameterIndexByKey(1000, "Row 5", 6, "MyValue", DateTime.Now);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool SetParameterIndexByKey(int iID, string key, int iY, object value, ValueType timeInfo);

		/// <summary>
		/// Sets the value of a cell in a table, identified by the primary key of the row and column position, with the specified value.
		/// </summary>
		/// <param name="iID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="iY">The 1-based column position.</param>
		/// <param name="value">The value to set.</param>
		/// <returns>Whether the cell value has changed. <c>true</c> indicates change; otherwise, <c>false</c>.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>The primary key can never be updated.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 call ("NT_PUT_PARAMETER_INDEX"). See [NT_PUT_PARAMETER_INDEX (121)](xref:NT_PUT_PARAMETER_INDEX).</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	bool hasSucceeded = protocol.SetParameterIndexByKey(1000, "Row 5", 6, "MyValue");
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool SetParameterIndexByKey(int iID, string key, int iY, object value);

		/// <summary>
		/// Sets the value of cells in tables, identified by their primary key and 1-based column position, with the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the table parameters.</param>
		/// <param name="keys">The primary keys of the rows.</param>
		/// <param name="iYs">The 1-based positions of the columns.</param>
		/// <param name="values">The values to set.</param>
		/// <param name="timeInfos">Time stamps.</param>
		/// <returns>This method call can return an unsigned integer error code, e.g. when the size of the <paramref name="ids"/> array does not match the size of the values array.Otherwise a uint[] is returned that has the same size as the <paramref name="ids"/> array containing the HRESULT value.At each position, this array contains the result value as would be returned when performing a SetParameterIndexByKey call on the individual cell.In case the value in the array is 262730 (0x0004024AL), this indicates the cell value changed.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///			<description>Prior to DataMiner 10.2.7 (RN 33198), the SetParametersIndexByKey method cannot be used to update a single cell. In case a single cell must be updated, use the SetParameterIndexByKey method instead. In cases where you dynamically set a number of cells, make sure to check the number of cells that will need to be updated. In case multiple cells need to be updated, use the SetParametersIndexByKey method. If a single cell needs to be updated, use the SetParameterIndexByKey method.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>This method should only be used in case multiple distinct cells need to be set(e.g., cells in different tables). When appropriate, use the SetRow, FillArray, FillArrayNoDelete, NotifyProtocol type 220 call, etc.to set multiple cells belonging to the same row, column or table, respectively.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 <see href="xref:NT_PUT_PARAMETER_INDEX">NT_PUT_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of an entry in <paramref name="timeInfos"/> is unspecified, the timestamp of that entry will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersIndexByKey(int[] ids, string[] keys, int[] iYs, object[] values, DateTime[] timeInfos);

		/// <summary>
		/// Sets the value of cells in tables, identified by their primary key and 1-based column position, with the specified values.
		/// </summary>
		/// <param name="ids">The IDs of the table parameters.</param>
		/// <param name="keys">The primary keys of the rows.</param>
		/// <param name="iYs">The 1-based positions of the columns.</param>
		/// <param name="values">The values to set.</param>
		/// <returns>This method call can return an unsigned integer error code, e.g. when the size of the <paramref name="ids"/> array does not match the size of the values array.Otherwise a uint[] is returned that has the same size as the <paramref name="ids"/> array containing the HRESULT value. At each position, this array contains the result value as would be returned when performing a SetParameterIndexByKey call on the individual cell.In case the value in the array is 262730 (0x0004024AL), this indicates the cell value changed.</returns>
		/// <remarks>
		///		<list type="bullet" >
		///			<item>
		///			<description>Prior to DataMiner 10.2.7 (RN 33198), the SLProtocol.SetParametersIndexByKey method cannot be used to update a single cell. In case a single cell must be updated, use the SetParameterIndexByKey method instead. In cases where you dynamically set a number of cells, make sure to check the number of cells that will need to be updated. In case multiple cells need to be updated, use the SetParametersIndexByKey method. If a single cell needs to be updated, use the SetParameterIndexByKey method.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.0.3.</description>
		///			</item>
		///			<item>
		///				<description>This method should only be used in case multiple distinct cells need to be set(e.g., cells in different tables). When appropriate, use the SetRow, FillArray, FillArrayNoDelete, NotifyProtocol type 220 call, etc.to set multiple cells belonging to the same row, column or table, respectively.</description>
		///			</item>
		///			<item>
		///				<description>This method acts as a wrapper for a NotifyProtocol type 121 <see href="xref:NT_PUT_PARAMETER_INDEX">NT_PUT_PARAMETER_INDEX</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetParametersIndexByKey(int[] ids, string[] keys, int[] iYs, object[] values);

		/// <summary>
		/// Gets the row data of the specified row in the specified table.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="iRow">The 0-based index of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 215 <see href="xref:NT_GET_ROW">NT_GET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the table does not contain a row on the specified index or with the specified primary key, an object array containing null references is returned.</description>
		///			</item>
		///			<item>
		///				<description>In case the protocol does not contain a table parameter with specified ID or the table does not contain a row with the provided primary key, the following message is logged: “NT_GET_ROW for [tableID]/[rowIndex or primaryKey] failed. 0x80040239”.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	object[] row = (object[]) protocol.GetRow(34000, 1);
		/// </code>
		/// </example>
		object GetRow(int iPID, int iRow);

		/// <summary>
		/// Gets the row data of the specified row in the specified table.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <returns>The row data.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 215 <see href="xref:NT_GET_ROW">NT_GET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the table does not contain a row on the specified index or with the specified primary key, an object array containing null references is returned.</description>
		///			</item>
		///			<item>
		///				<description>In case the protocol does not contain a table parameter with specified ID or the table does not contain a row with the provided primary key, the following message is logged: “NT_GET_ROW for [tableID]/[rowIndex or primaryKey] failed. 0x80040239”.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	object[] row = (object[]) protocol.GetRow(34000, "Row 1");
		/// </code>
		/// </example>
		object GetRow(int iPID, string key);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="iRow">The 0-based index of the row.</param>
		/// <param name="row">The row data. </param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <param name="bOverrideBehaviour">When set to true, protocol.Clear and protocol.Leave can be used as cell values, which will clear or preserve the cell content, respectively.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 (NT_SET_ROW) call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, int iRow, object row, ValueType timeInfo, [MarshalAs(UnmanagedType.U1)] bool bOverrideBehaviour);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="iRow">The 0-based index of the row.</param>
		/// <param name="row">The row data. </param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 (NT_SET_ROW) call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, int iRow, object row, ValueType timeInfo);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="iRow">The 0-based index of the row.</param>
		/// <param name="row">The row data. </param>
		/// <param name="bOverrideBehaviour">When set to true, protocol.Clear and protocol.Leave can be used as cell values, which will clear or preserve the cell content, respectively.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 (NT_SET_ROW) call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, int iRow, object row, [MarshalAs(UnmanagedType.U1)] bool bOverrideBehaviour);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="iRow">The 0-based index of the row.</param>
		/// <param name="row">The row data as an object array. </param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 <see href="xref:NT_SET_ROW">NT_SET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, int iRow, object row);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="row">The row data.</param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <param name="bOverrideBehaviour">When set to true, protocol.Clear and protocol.Leave can be used as cell values, which will clear or preserve the cell content, respectively.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 <see href="xref:NT_SET_ROW">NT_SET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///			<item>
		///				<description>From DataMiner 10.2.9 onwards (RN 33849), if the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, string key, object row, ValueType timeInfo, [MarshalAs(UnmanagedType.U1)] bool bOverrideBehaviour);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="row">The row data. </param>
		/// <param name="timeInfo">Time stamp.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 <see href="xref:NT_SET_ROW">NT_SET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///			<item>
		///				<description>If the DateTime.Kind property of <paramref name="timeInfo"/> is unspecified, the timestamp will be handled as local time.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, string key, object row, ValueType timeInfo);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="row">The row data. </param>
		/// <param name="bOverrideBehaviour">When set to true, protocol.Clear and protocol.Leave can be used as cell values, which will clear or preserve the cell content, respectively.</param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 <see href="xref:NT_SET_ROW">NT_SET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, string key, object row, [MarshalAs(UnmanagedType.U1)] bool bOverrideBehaviour);

		/// <summary>
		/// Sets the data of the specified row to the specified values.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row.</param>
		/// <param name="row">The row data. </param>
		/// <returns>Array with value 0 (No Change) or 1(Change) to indicate the change state of the cell in the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for a NotifyProtocol type 225 <see href="xref:NT_SET_ROW">NT_SET_ROW</see> call.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array must not be larger than the number of columns defined in the table.</description>
		///			</item>
		///			<item>
		///				<description>The length of the rowData array may, however, be smaller than the number of columns defined in the table. In case there are fewer values than columns, then no update is done for the missing columns.</description>
		///			</item>
		///			<item>
		///				<description>A null reference as cell value will preserve the value of the cell.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object SetRow(int iPID, string key, object row);

		/// <summary>
		/// Gets the value that indicates the cell in the row should be cleared.
		/// </summary>
		/// <value>The value that indicates the cell in the row should be cleared.</value>
		///	<remarks>This corresponds with a value of double.NegativeInfinity.
		///
		/// This is used with the SetRow method where the enableCellActions parameter has been set to true and NotifyDataMiner types 193 ([NT_FILL_ARRAY](xref:NT_FILL_ARRAY)) and 194 ([NT_FILL_ARRAY_NO_DELETE](xref:NT_FILL_ARRAY_NO_DELETE)) with the Clear and Leave flag enabled.
		///	</remarks>
		double Clear { get; }

		/// <summary>
		/// Gets the value indicating the cell in the row should be preserved.
		///	</summary>
		///	<value>The value that indicates the cell in the row should be preserved.</value>
		///	<remarks>This property is used with the SetRow method for example.
		///	
		/// This is used with the SetRow method where the enableCellActions parameter has been set to true and NotifyDataMiner types 193 ([NT_FILL_ARRAY](xref:NT_FILL_ARRAY)) and 194 ([NT_FILL_ARRAY_NO_DELETE](xref:NT_FILL_ARRAY_NO_DELETE)) with the Clear and Leave flag enabled.</remarks>
		double Leave { get; }

		/// <summary>
		/// Gets the ID of the parameter that triggered the execution of QAction.
		/// </summary>
		/// <returns>The ID of the parameter that triggered the execution of the QAction.</returns>
		/// <example>
		/// <code>
		/// int triggerParameterId = protocol.GetTriggerParameter();
		/// </code>
		/// </example>
		int GetTriggerParameter();

		/// <summary>
		/// Retrieves the user connection. Available from DataMiner 10.0.10 onwards.
		/// </summary>
		/// <returns>Returns a connection that impersonates the user who triggered the QAction based on SLProtocol#UserCookie. If no user cookie is present within the QAction context, the returned IConnection will act as the SLManagedScripting connection.</returns>
		/// <example>
		/// <code language="c#">
		/// using(var logHelper = LogHelper.Create(protocol.GetUserConnection()))
		/// {
		///		...
		/// }
		/// </code>
		/// </example>
		IConnection GetUserConnection();

		/// <summary>
		/// Retrieves the type of the local database.
		/// </summary>
		/// <returns>The type of the local database  (MySQL, Microsoft SQL Server or Cassandra).</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> Before using this method call, it is good practice to use “#if DBInfo” in order to check whether the GetLocalDatabaseType method is supported on the DataMiner Agent.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 9.0.0 (RN 10395).</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///		<code>
		///			#if DBInfo
		///				string databaseType = protocol.GetLocalDatabaseType();
		///				protocol.Log("Local DB type is: " + databaseType);
		///			#else
		///				protocol.Log("This DataMiner version does not support requesting the type of the local database.");
		///			#endif
		///		</code>
		///	</example>
		string GetLocalDatabaseType();

		/// <summary>
		/// Retrieves the specified input parameter.
		/// </summary>
		/// <param name="j">The 0-based index denoting where the parameter is specified in the inputParameters attribute.</param>
		/// <returns>The value of the specified input parameter.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> This method requires the inputParameters attribute to be used on the QAction that executes this method call.</description>
		///			</item>
		///			<item>
		///				<description>The value of the parameter obtained via the GetInputParameter method will be the value of the parameter at the time the QAction started.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<para>In the following example the parameter with ID 1000 is a table parameter.</para>
		///	<code language = "xml" >
		///	<![CDATA[
		///	<QAction id = "1000" name = "ProcessTable" encoding = "csharp" triggers = "10" inputParameters = "1000" >
		///	]]>
		///</code>
		///<para>In the QAction, the input parameter can then be retrieved as follows:</para>
		///	<code>
		///	using Skyline.DataMiner.Scripting;
		///	
		/// public class QAction
		/// {
		///		public static void Run(SLProtocolExt protocol)
		///		{
		///			object[] table = (object[])protocol.GetInputParameter(0);
		///			object[] primaryKeyColumn = (object[])table[0];
		///			////…
		///		}
		///	}
		///	</code>	
		///	</example>
		object GetInputParameter(int j);

		/// <summary>
		/// Gets the number of rows present in the specified table.
		/// </summary>
		/// <param name="theArray">The ID of the table parameter or the input parameter table object.</param>
		/// <returns>The number of rows in the table.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This a wrapper method for a NotifyProtocol type 195 (NT_ARRAY_ROW_COUNT) call.</description>
		///			</item>
		///			<item>
		///				<description>In case the protocol does not define a table with the specified ID, -1 is returned.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<para>Retrieve row count of input parameter table 1000:</para>
		///	<para><c>&lt;QAction id = "500" encoding="csharp" triggers="500" inputParameters="1000"&gt;</c></para>
		///	<code>
		/// using Skyline.DataMiner.Scripting;
		/// 
		/// public class QAction
		/// {
		///	    /// &lt;summary&gt;
		///	    /// QAction entry point.
		///	    /// &lt;/summary&gt;
		///	    /// &lt;param name="protocol">Link with SLProtocol process.&lt;/param&gt;
		///	    public static void Run(SLProtocolExt protocol)
		///	    {
		///	        object table = protocol.GetInputParameter(0);
		///	        int rowCount = protocol.RowCount(table);
		///	        ////...
		///	    }
		///	}
		///	</code>
		///	</example>
		int RowCount(object theArray);

		/// <summary>
		/// Gets the number of rows present in the specified table.
		/// </summary>
		/// <param name="tableId">The ID of the table parameter.</param>
		/// <returns>The number of rows the table contains. If the table was not found, a value of -1 is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), this method was defined as an SLProtocol extension method in the NotifyProtocol class.</description>
		///			</item>
		///			<item>
		///				<description>This a wrapper method for a NotifyProtocol type 195 <see href="xref:NT_ARRAY_ROW_COUNT">NT_ARRAY_ROW_COUNT</see> call.</description>
		///			</item>
		///			<item>
		///				<description>In case the protocol does not define a table with the specified ID, -1 is returned.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <para>Retrieve row count of table by specifying the ID of the table parameter:</para>
		/// <code>
		/// using Skyline.DataMiner.Scripting;
		/// 
		/// public class QAction
		/// {
		///     public static void Run(SLProtocolExt protocol)
		///     {
		///         int rowCount = protocol.RowCount(1000);
		///         //// ...
		///     }
		/// }
		/// </code>
		/// </example>
		int RowCount(int tableId);

		/// <summary>
		/// Gets a row from the specified table.
		/// </summary>
		/// <param name="theArray">The table from which a row must be retrieved.</param>
		/// <param name="iRow">The 0-based row index in the table.</param>
		/// <returns>The row data.</returns>
		/// <example>
		///		<para>In the following example parameter 1000 represents a table:</para>
		///		<code language = "xml" >
		///		<![CDATA[
		///		<QAction id = "100" name = "Row Method Example" encoding = "csharp" triggers = "500" inputParameters = "1000">
		///		]]>
		///		</code>
		///	<code language="c#">
		/// using Skyline.DataMiner.Scripting;
		/// 
		/// public class QAction
		/// {
		///     public static void Run(SLProtocol protocol)
		///     {
		///         object table = protocol.GetInputParameter(0);
		///         object[] rowData = (object[])protocol.Row(table, 0);
		///         ////...
		///     }
		/// }
		///	</code>
		///	</example>
		object Row(object theArray, int iRow);

		/// <summary>
		/// Gets the 1-based row position of the row that triggered the execution of the QAction.
		/// </summary>
		/// <returns>The position of the row.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method can only be used in QActions that have the attribute row set to “true”.</description>
		///			</item>
		///		</list>
		///	</remarks>
		int RowIndex();

		/// <summary>
		/// Gets the primary key of the row that triggered the execution of the QAction.
		/// </summary>
		/// <returns>The primary key of the row that triggered the execution of the QAction.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method can only be used in QActions that have the attribute row set to “true”.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DMS v.8.5.0. (RN 7690).</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	string rowKey = protocol.RowKey();
		/// </code>
		/// </example>
		string RowKey();

		/// <summary>
		/// Gets information about the previous cell values before the row was updated.
		/// </summary>
		/// <returns><para>Information about the previous cell values in the row.</para>
		/// <para>The return value is an object array where each element is an array containing information about the previous cell value.This array is organized as follows:</para>
		/// <list type = "bullet" >
		///		<item><description>cellDetails[0]: Cell value</description></item>
		///		<item><description>cellDetails[1]: Timestamp</description></item>
		///		<item><description>cellDetails[2]: User</description></item>
		///		<item><description>cellDetails[3]: Display string</description></item>
		///		<item><description>cellDetails[4]: Display state</description></item>
		///		<item><description>cellDetails[5]: ms</description></item>
		///		<item><description>cellDetails[6]: <c>TBD</c></description></item>
		///	</list>
		/// </returns>
		/// <remarks>
		///		<list type = "bullet">
		///			<item>
		///				<description>This method can only be used in QActions that have the attribute row set to “true” and the “preserve state” option is enabled for this table.</description>
		///			</item>
		///			<item>
		///				<description>If this method is used in a QAction for which the “group” option is specified, the method will instead return the values retrieved by the group that triggered the QAction. See <see href="xref:Protocol.QActions.QAction-options#group">group</see>.</description>
		///			</item>
		///		</list>
		///	</remarks>
		object OldRow();

		/// <summary>
		/// Retrieves information about the updated cells in a row.
		/// </summary>
		/// <returns>
		/// <para>Information about the updated cells in the row.</para>
		/// <para>This will be an object array where each element is either a null reference(in case the cell was not updated) or an array containing information about an updated cell.The array containing information about the updated cell is organized as follows:</para>
		/// <list type = "bullet">
		/// <item><description>cellDetails[0]: Cell value</description></item>
		/// <item><description>cellDetails[1]: Update timestamp</description></item>
		/// <item><description>cellDetails[2]: User</description></item>
		/// <item><description>cellDetails[3]: Display string</description></item>
		/// <item><description>cellDetails[4]: Display state</description></item>
		/// <item><description>cellDetails[5]: ms</description></item>
		/// <item><description>cellDetails[6]: <c>TBD</c></description></item>
		/// </list>
		/// </returns>
		///<remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<para>This method can only be used in QActions that have the attribute row set to “true”.</para>
		///			</item>
		///		</list>
		///	</remarks>
		object NewRow();

		/// <summary>
		/// Gets the round-trip time (RTT).
		/// </summary>
		/// <returns>The round-trip time in ms as double.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method is intended to be used with multi-threaded timers that have the option “ping” defined.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.5.0 (RN 7690).</description>
		///			</item>
		///		</list>
		///	</remarks>
		object RowRTT();

		/// <summary>
		/// Gets the timestamp of the ping execution.
		/// </summary>
		/// <returns>The timestamp as string.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This method is intended to be used with multi-threaded timers that have the ping option defined.</description>
		///			</item>
		///			<item>
		///				<description>Feature introduced in DataMiner version 8.5.0 (RN 7690).</description>
		///			</item>
		///		</list>
		///	</remarks>
		object RowPingTimestamp();

		/// <summary>
		/// Retrieves the 1-based position of the row with the specified primary key in the table with the specified ID.
		/// </summary>
		/// <param name="iPID">The ID of the table parameter.</param>
		/// <param name="key">The primary key of the row for which the position has to be determined.</param>
		/// <returns>The 1-based position of the row in the table. If the table does not contain a row with the specified primary key, 0 is returned.</returns>
		/// <remarks>
		/// <list type = "bullet" >
		///		<item>
		///			<description> This is a wrapper method for the NotifyProtocol type 163 <see href="xref:NT_GET_KEY_POSITION">NT_GET_KEY_POSITION</see> call.</description>
		///		</item>
		///	</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	int position = protocol.GetKeyPosition(1000, "Row 10");
		/// </code>
		/// </example>
		int GetKeyPosition(int iPID, string key);

		/// <summary>
		/// Retrieves the raw data of the specified item.
		/// </summary>
		/// <param name="from">The type of the item. Currently only “parameter” is supported.</param>
		/// <param name="iID">The ID of the item.</param>
		/// <returns>An object array  where each item is a byte. In case the specified item does not exist, a null reference is returned.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description> This is a wrapper method for the NotifyProtocol type 60 <see href="xref:NT_GET_DATA">NT_GET_DATA</see> call.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	public static void Run(SLProtocol protocol)
		///	{
		///		object data = protocol.GetData("parameter", 10);
		///		
		///		if (data != null)
		///		{
		///			object[] dataBytes = (object[])data;
		///			byte[] bytes = new byte[dataBytes.Length];
		///			Array.Copy(dataBytes, bytes, bytes.Length);
		///			////...
		///		}
		///		else
		///		{
		///			////...
		///		}
		///	}
		///	</code>
		///	</example>
		object GetData(string from, int iID);

		/// <summary>
		/// Determines whether the parameter with the specified ID has been initialized.
		/// </summary>
		/// <param name="iID">The ID of the parameter.</param>
		/// <returns><c>true</c> if the value has not been initialized; otherwise, <c>false</c>.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This a wrapper method for a NotifyProtocol type 60 <see href="xref:NT_GET_DATA">NT_GET_DATA</see> call.</description>
		///			</item>
		///			<item>
		///				<description>This call is intended to be used on standalone parameters.</description>
		///			</item>
		///			<item>
		///				<description>In case the protocol does not define a parameter with the specified ID, the following message is logged: NT_GET_DATA for [parameterID] failed. 0x80040239.</description>
		///			</item>
		///			<item>
		///				<description>In case a table ID or a column ID is provided, the following message is logged: NT_GET_DATA for [tableID] failed. 0x80040239.</description>
		///			</item>
		///		</list>
		///	</remarks>
		/// <example>
		/// <code>
		/// int isEmpty = protocol.IsEmpty(100);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool IsEmpty(int iID);



		/// <summary>
		/// Makes the SLElement process update the specified parameter.
		/// </summary>
		/// <param name="iID">The ID of the parameter to update.</param>
		/// <param name="iXs">The 1-based inputs.</param>
		/// <param name="iYs">The 1-based outputs.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 123 NT_NOTIFY_DISPLAY call.</description>
		///			</item>
		///			<item>
		///				<description>When SendToDisplay(int parameterID) is used on a matrix, this will update the entire matrix. This is also the case when input is set to 0 or -1 and output to 0 or -1.</description>
		///			</item>
		///			<item>
		///				<description>It is advised to use one of the overloads providing the input(s) and output(s) when possible(i.e.when it is known which crosspoints have been updated) to reduce the load.</description>
		///			</item>
		///			<item>
		///				<description>The overloads accepting one or multiple input and output indices were introduced in DataMiner version 9.0.0 (RN 12434, RN 12487).</description>
		///			</item>
		///			<item>
		///				<para>In case of a 2x10 matrix, for example, the coordinates of the top-left crosspoint are iX=1/iY=1, and the coordinates of the bottom-right crosspoint are iX = 2 / iY = 10.</para>
		///			</item>
		///		</list>
		///	</remarks>
		int SendToDisplay(int iID, int[] iXs, int[] iYs);

		/// <summary>
		/// Makes the SLElement process update the specified parameter.
		/// </summary>
		/// <param name="iID">The ID of the parameter to update.</param>
		/// <param name="iX">The 1-based input.</param>
		/// <param name="iY">The 1-based output.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 123 NT_NOTIFY_DISPLAY call.</description>
		///			</item>
		///			<item>
		///				<description>When SendToDisplay(int parameterID) is used on a matrix, this will update the entire matrix. This is also the case when input is set to 0 or -1 and output to 0 or -1.</description>
		///			</item>
		///			<item>
		///				<description>It is advised to use one of the overloads providing the input(s) and output(s) when possible(i.e.when it is known which crosspoints have been updated) to reduce the load.</description>
		///			</item>
		///			<item>
		///				<description>The overloads accepting one or multiple input and output indices were introduced in DataMiner version 9.0.0 (RN 12434, RN 12487).</description>
		///			</item>
		///			<item>
		///				<para>In case of a 2x10 matrix, for example, the coordinates of the top-left crosspoint are iX=1/iY=1, and the coordinates of the bottom-right crosspoint are iX = 2 / iY = 10.</para>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	protocol.SendToDisplay(1000, 1, 1);
		/// </code>
		/// </example>
		int SendToDisplay(int iID, int iX, int iY);

		/// <summary>
		/// Makes the SLElement process update the specified parameter.
		/// </summary>
		/// <param name="iID">The ID of the parameter to update.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 123 NT_NOTIFY_DISPLAY call.</description>
		///			</item>
		///			<item>
		///				<description>When SendToDisplay(int parameterID) is used on a matrix, this will update the entire matrix. This is also the case when input is set to 0 or -1 and output to 0 or -1.</description>
		///			</item>
		///			<item>
		///				<description>It is advised to use one of the overloads providing the input(s) and output(s) when possible(i.e.when it is known which crosspoints have been updated) to reduce the load.</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	protocol.SendToDisplay(1000);
		/// </code>
		/// </example>
		int SendToDisplay(int iID);

		/// <summary>
		/// Triggers the trigger with the specified ID.
		/// </summary>
		/// <param name="iID">The ID of the trigger to be executed.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>This is a wrapper method for the NotifyProtocol type 134 (NT_CHECK_TRIGGER) call.</description>
		///			</item>
		///			<item>
		///				<description>If a trigger defines when a trigger should trigger (using the On and Time tags) and the CheckTrigger method is called on this trigger, then the trigger will be invoked regardless of the values specified for the On and Time tags, except when On is set to "parameter" and Time is set to either "timeout" or "timeout after retries".</description>
		///			</item>
		///		</list>
		///	</remarks>
		///	<example>
		///	<code>
		///	int result = protocol.CheckTrigger(100);
		/// </code>
		/// </example>
		int CheckTrigger(int iID);

		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="iType">The logging type. Supported values: 1=Information, 2=Error, 4=DebugInfo, 8=Always.</param>
		/// <param name="iLevel">The logging level. Supported values: -1=Development Logging, 0=No Logging, 1=Level 1 Logging, 2=Level 2 Logging, 3=Level 3 logging, 4=Level 4 Logging, 5=Log everything.</param>
		/// <param name="message">The message to be logged.</param>
		/// <returns>HRESULT value. A value of 0 (S_OK) indicates the set succeeded.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>The usage of this method is deprecated, use one of the other overloads instead.</description>
		///			</item>
		///			<item>
		///				<description>The message will be logged in the log file of the element(located in the folder C:\Skyline DataMiner\logging\).</description>
		///			</item>
		///		</list>
		///	</remarks>
		int Log(int iType, int iLevel, string message);

		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="logType">The logging type.</param>
		/// <param name="logLevel">The logging level.</param>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), the overloads with a LogType and/or LogLevel arguments were defined as an SLProtocol extension method (with optional LogType and LogLevel arguments) in the ProtocolExtenders class.</description>
		///			</item>
		///			<item>
		///				<description>The message will be logged in the log file of the element(located in the folder C:\Skyline DataMiner\logging\).</description>
		///			</item>
		///		</list>
		///	</remarks>
		void Log(string message, LogType logType, LogLevel logLevel);

		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="logLevel">The logging level.</param>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), the overloads with a LogType and/or LogLevel arguments were defined as an SLProtocol extension method (with optional LogType and LogLevel arguments) in the ProtocolExtenders class.</description>
		///			</item>
		///			<item>
		///				<description>This overload uses LogType.Allways.</description>
		///			</item>
		///			<item>
		///				<description>The message will be logged in the log file of the element(located in the folder C:\Skyline DataMiner\logging\).</description>
		///			</item>
		///		</list>
		///	</remarks>
		void Log(string message, LogLevel logLevel);

		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="logType">The logging type.</param>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), the overloads with a LogType and/or LogLevel arguments were defined as an SLProtocol extension method (with optional LogType and LogLevel arguments) in the ProtocolExtenders class.</description>
		///			</item>
		///			<item>
		///				<description>This overload uses LogLevel.DevelopmentLogging.</description>
		///			</item>
		///			<item>
		///				<description>The message will be logged in the log file of the element(located in the folder C:\Skyline DataMiner\logging\).</description>
		///			</item>
		///		</list>
		///	</remarks>
		void Log(string message, LogType logType);

		/// <summary>
		/// Logs a message to the element log file.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Prior to DataMiner 10.1.1 (RN 27995), the overloads with a LogType and/or LogLevel arguments were defined as an SLProtocol extension method (with optional LogType and LogLevel arguments) in the ProtocolExtenders class.</description>
		///			</item>
		///			<item>
		///				<description>This overload uses LogType.Allways. and LogLevel.DevelopmentLogging.</description>
		///			</item>
		///			<item>
		///				<description>The message will be logged in the log file of the element(located in the folder C:\Skyline DataMiner\logging\).</description>
		///			</item>
		///		</list>
		///	</remarks>
		void Log(string message);

		//void DisposeResources();

		/// <summary>
		/// Retrieves the specified DCF interface.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="name">The name of the interface.</param>
		/// <param name="customName"><c>true</c> if the name specified in <paramref name="name"/> is the custom interface name; otherwise, <c>false</c>.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The specified interface or <see langword="null"/> in case the interface was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner 8.5.8 (RN 10066).</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityInterface method (Int32, Int32, string, Boolean, Boolean) retrieves all connectivity interfaces for the specified element (including interfaces of DVE children if exported is true) and then returns the connectivity interface with the specified name (if present). Therefore, if you need to request multiple interfaces, it can be more performant to request all interfaces using a GetConnectivityInterfaces call and extract the desired interfaces from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var myInterface = protocol.GetConnectivityInterface(400, 2000, "MyInterface", true, true);
		/// </code>
		/// </example>
		ConnectivityInterface GetConnectivityInterface(int DMAId, int EId, string name, [MarshalAs(UnmanagedType.U1)] bool customName, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the specified DCF interface.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="name">The name of the interface.</param>
		/// <param name="customName"><c>true</c> if the name specified in <paramref name="name"/> is the custom interface name; otherwise, <c>false</c>.</param>
		/// <returns>The specified DCF interface or <see langword="null"/> in case the interface was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In the background, this call performs a GetConnectivityInterface(int DMAId, int Eid, string name, bool customName, bool exported) call with exported set to false.</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityInterface method (Int32, Int32, string, Boolean, Boolean) retrieves all connectivity interfaces for the specified element (including interfaces of DVE children if exported is true) and then returns the connectivity interface with the specified name (if present). Therefore, if you need to request multiple interfaces, it can be more performant to request all interfaces using a GetConnectivityInterfaces call and extract the desired interfaces from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var myInterface = protocol.GetConnectivityInterface(400, 2000, "MyInterface", true);
		/// </code>
		/// </example>
		ConnectivityInterface GetConnectivityInterface(int DMAId, int EId, string name, [MarshalAs(UnmanagedType.U1)] bool customName);

		/// <summary>
		/// Retrieves the specified DCF interface.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element the interface is part of.</param>
		/// <param name="EId">The element ID of the element the interface is part of.</param>
		/// <param name="ItfId">The ID of the interface.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The specified interface or <see langword="null"/> in case the specified interface was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner 8.5.8 (RN 10066).</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityInterface method (Int32, Int32, Int32, Boolean) retrieves all connectivity interfaces for the specified element (including interfaces of DVE children if exported is true) and then returns the connectivity interface with the specified ID (if present). Therefore, if you need to request multiple interfaces, it can be more performant to request all interfaces using a single GetConnectivityInterfaces call and then extract the desired interfaces from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var myInterface = protocol.GetConnectivityInterface(400, 2000, 1, true);
		/// </code>
		/// </example>
		ConnectivityInterface GetConnectivityInterface(int DMAId, int EId, int ItfId, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the specified DCF interface.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="ItfId">The ID of the interface.</param>
		/// <returns>The specified DCF interface or <see langword="null"/> in case the interface was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In the background, this call performs a GetConnectivityInterface(int DMAId, int Eid, int ItfId, bool exported) call, with exported set to false.</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityInterface method (Int32, Int32, Int32, Boolean) retrieves all connectivity interfaces for the specified element (including interfaces of DVE children if exported is true) and then returns the connectivity interface with the specified ID (if present). Therefore, if you need to request multiple interfaces, it can be more performant to request all interfaces using a single GetConnectivityInterfaces call and then extract the desired interfaces from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var myInterface = protocol.GetConnectivityInterface(400, 2000, 1);
		/// </code>
		/// </example>
		ConnectivityInterface GetConnectivityInterface(int DMAId, int EId, int ItfId);

		/// <summary>
		/// Retrieves the DCF interfaces of the specified element that match the specified name filter.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="nameFilter">The name filter.</param>
		/// <param name="customName"><c>true</c> if <paramref name="nameFilter"/> refers to the custom name; otherwise, <c>false</c>.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The matching DCF interfaces.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.8 (RN 10066).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityInterface&gt; interfaces = protocol.GetConnectivityInterfaces(400, 2000, "Input*", true, false);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityInterface> GetConnectivityInterfaces(int DMAId, int EId, string nameFilter, [MarshalAs(UnmanagedType.U1)] bool customName, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the DCF interfaces of the specified element that match the specified name filter.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="nameFilter">The name filter.</param>
		/// <param name="customName"><c>true</c> if <paramref name="nameFilter"/> refers to the custom name; otherwise, <c>false</c>.</param>
		/// <returns>The matching DCF interfaces.</returns>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityInterface&gt; interfaces = protocol.GetConnectivityInterfaces(400, 2000, "Input*", true);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityInterface> GetConnectivityInterfaces(int DMAId, int EId, string nameFilter, [MarshalAs(UnmanagedType.U1)] bool customName);

		/// <summary>
		/// Retrieves the DCF interfaces of the specified element.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The matching DCF interfaces.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.8 (RN 10066).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityInterface&gt; interfaces = protocol.GetConnectivityInterfaces(400, 2000, false);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityInterface> GetConnectivityInterfaces(int DMAId, int EId, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the DCF interfaces of the specified element.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <returns>The DCF interfaces.</returns>
		/// <remarks>This will not include the interfaces of the DVE children.</remarks>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityInterface&gt; interfaces = protocol.GetConnectivityInterfaces(400, 2000);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityInterface> GetConnectivityInterfaces(int DMAId, int EId);

		/// <summary>
		/// Gets the DCF interfaces known by the element that executes this QAction.
		/// </summary>
		/// <value>The DCF interfaces known by the element that executes this QAction.</value>
		/// <remarks>
		/// <para>This property does not return the exported interfaces.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// var interfaces = protocol.ConnectivityInterfaces;
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityInterface> ConnectivityInterfaces { get; }

		/// <summary>
		/// Retrieves the specified DCF connection.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="EId">The element ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="name">The name of the connection.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The DCF connection or <see langword="null"/> in case the connection was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner 8.5.8 (RN 10066).</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityConnection method (Int32, Int32, string, Boolean) retrieves all connectivity connections for the specified element and then returns the connectivity connection with the specified name (if present). Therefore, if you need to request multiple connections, it can be more performant to request all connections using a single GetConnectivityConnections call and then extract the desired connections from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var connection = protocol.GetConnectivityConnection(400, 2000, "MyConnection", false);
		/// </code>
		/// </example>
		ConnectivityConnection GetConnectivityConnection(int DMAId, int EId, string name, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the specified DCF connection.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="EId">The element ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="name">The name of the connection.</param>
		/// <returns>The DCF connection or <see langword="null"/> in case the connection was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In the background, this call performs a GetConnectivityConnection(int DMAId, int Eid, string name, bool exported) call, with exported set to false.</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityConnection method (Int32, Int32, string, Boolean) retrieves all connectivity connections for the specified element and then returns the connectivity connection with the specified name (if present). Therefore, if you need to request multiple connections, it can be more performant to request all connections using a single GetConnectivityConnections call and then extract the desired connections from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var connection = protocol.GetConnectivityConnection(400, 2000, "MyConnection");
		/// </code>
		/// </example>
		ConnectivityConnection GetConnectivityConnection(int DMAId, int EId, string name);

		/// <summary>
		/// Retrieves the specified DCF connection.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="EId">The element ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="exported"><c>true</c> to include interfaces of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The DCF connection or <see langword="null"/> in case the connection was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>Feature introduced in DataMiner 8.5.8 (RN 10066).</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityConnection method (Int32, Int32, Int32, Boolean) retrieves all connectivity connections for the specified element and then returns the connectivity connection with the specified ID (if present). Therefore, if you need to request multiple connections, it can be more performant to request all connections using a single GetConnectivityConnections call and then extract the desired connections from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var connection = protocol.GetConnectivityConnection(400, 2000, 1, false);
		/// </code>
		/// </example>
		ConnectivityConnection GetConnectivityConnection(int DMAId, int EId, int ConnectionId, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the specified DCF connection.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="EId">The element ID of the element that holds the corresponding connection entry in the connections table.</param>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <returns>The DCF connection or <see langword="null"/> in case the connection was not found.</returns>
		/// <remarks>
		///		<list type = "bullet" >
		///			<item>
		///				<description>In the background, this call performs a GetConnectivityConnection(int DMAId, int Eid, int connectionId, bool exported) call, with exported set to false.</description>
		///			</item>
		///			<item>
		///				<description>The SLProtocol.GetConnectivityConnection method (Int32, Int32, Int32, Boolean) retrieves all connectivity connections for the specified element and then returns the connectivity connection with the specified ID (if present). Therefore, if you need to request multiple connections, it can be more performant to request all connections using a single GetConnectivityConnections call and then extract the desired connections from the returned dictionary.</description>
		///			</item>
		///		</list>
		/// </remarks>
		/// <example>
		/// <code>
		/// var connection = protocol.GetConnectivityConnection(400, 2000, 1);
		/// </code>
		/// </example>
		ConnectivityConnection GetConnectivityConnection(int DMAId, int EId, int ConnectionId);

		/// <summary>
		/// Retrieves the DCF connections that are known by the specified element and that match the specified name filter.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="nameFilter">The name filter.</param>
		/// <param name="exported"><c>true</c> to include connections of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The DCF connections that are known by the specified element and that match the specified name filter.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.8 (RN 10066).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityConnection&gt; connections = protocol.GetConnectivityConnections(400, 2000, "Input*", false);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityConnection> GetConnectivityConnections(int DMAId, int EId, string nameFilter, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the DCF connections that are known by the specified element and that match the specified name filter.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="nameFilter">The name filter.</param>
		/// <returns>The DCF connections that are known by the specified element and that match the specified name filter.</returns>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityConnection&gt; connections = protocol.GetConnectivityConnections(400, 2000, "Input*");
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityConnection> GetConnectivityConnections(int DMAId, int EId, string nameFilter);

		/// <summary>
		/// Retrieves the DCF connections that are known by the specified element.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <param name="exported"><c>true</c> to include connections of DVE children; otherwise, <c>false</c>.</param>
		/// <returns>The DCF connections that are known by the specified element.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.8 (RN 10066).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityConnection&gt; connections = protocol.GetConnectivityConnections(400, 2000, true);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityConnection> GetConnectivityConnections(int DMAId, int EId, [MarshalAs(UnmanagedType.U1)] bool exported);

		/// <summary>
		/// Retrieves the DCF connections that are known by the specified element.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element.</param>
		/// <param name="EId">The element ID of the element.</param>
		/// <returns>The DCF connections that are known by the specified element.</returns>
		/// <example>
		/// <code>
		/// Dictionary&lt;int, ConnectivityConnection&gt; connections = protocol.GetConnectivityConnections(400, 2000);
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityConnection> GetConnectivityConnections(int DMAId, int EId);

		/// <summary>
		/// Gets the DCF connections known by the element that executes this QAction.
		/// </summary>
		/// <value>The DCF connections known by the element that executes this QAction.</value>
		/// <remarks>
		/// <para>This property does not return the exported connections.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// var connections = protocol.ConnectivityConnections;
		/// </code>
		/// </example>
		Dictionary<int, ConnectivityConnection> ConnectivityConnections { get; }

		/// <summary>
		/// Deletes the specified DCF interface property.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 9296).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityInterfaceProperty(1, 400, 2000);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityInterfaceProperty(int id, int dmaID, int eleID);

		/// <summary>
		/// Deletes the specified DCF interface property.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <param name="itfId">The ID of the interface.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case <paramref name="itfId"/> is not correct, the property will not be deleted.</para>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 9296).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityInterfaceProperty(1, 1, 400, 2000);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityInterfaceProperty(int id, int itfId, int dmaID, int eleID);

		/// <summary>
		/// Deletes the specified DCF connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <param name="both"><c>true</c> to delete the property  at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 9.5.1 (RN 14594).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityConnectionProperty(1, 400, 2000, false);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityConnectionProperty(int id, int dmaID, int eleID, [MarshalAs(UnmanagedType.U1)] bool both);

		/// <summary>
		/// Deletes the specified DCF connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 9296).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityConnectionProperty(1, 400, 2000);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityConnectionProperty(int id, int dmaID, int eleID);

		/// <summary>
		/// Deletes the specified DCF connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="connId">The ID of the connection to which this property belongs.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <param name="both"><c>true</c> to delete the property  at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case <paramref name="connId"/> is not correct, the property will not be deleted.</para>
		/// <para>Feature introduced in DataMiner 9.5.1 (RN 14594).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityConnectionProperty(1, 1, 400, 2000, false);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityConnectionProperty(int id, int connId, int dmaID, int eleID, [MarshalAs(UnmanagedType.U1)] bool both);

		/// <summary>
		/// Deletes the specified DCF connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="connId">The ID of the connection.</param>
		/// <param name="dmaID">The DataMiner Agent ID of the element.</param>
		/// <param name="eleID">The element ID of the element.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 9296).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityConnectionProperty(1, 1, 400, 2000);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityConnectionProperty(int id, int connId, int dmaID, int eleID);

		/// <summary>
		/// Deletes the specified DCF connection.
		/// </summary>
		/// <param name="id">The connection ID.</param>
		/// <param name="dmaID">The DataMiner Agent ID.</param>
		/// <param name="eleID">The element ID.</param>
		/// <param name="deleteBothConnections"><c>true</c> to delete both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 9296).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// bool hasSucceeded = protocol.DeleteConnectivityConnection(1, 400, 2000, false);
		/// </code>
		/// </example>
		[return: MarshalAs(UnmanagedType.U1)]
		bool DeleteConnectivityConnection(int id, int dmaID, int eleID, [MarshalAs(UnmanagedType.U1)] bool deleteBothConnections);

		/// <summary>
		/// Shows a message to the user in a pop-up window.
		/// </summary>
		/// <param name="message">The message to be displayed.</param>
		/// <param name="caption">The caption that will be displayed in the title bar of the pop-up window.</param>
		/// <remarks>
		/// <para>This only works in QActions that are directly triggered from a client with user interaction.</para>
		/// <para>Example scenarios that are supported:</para>
		/// <list type="bullet">
		/// <item><description>Write parameter that triggers a QAction</description></item>
		/// <item><description>Context menu</description></item>
		/// </list>
		/// <para>Example scenarios that are not supported:</para>
		/// <list type="bullet">
		/// <item><description>Protocol.SetParameter or Protocol.CheckTrigger that starts a new QAction</description></item>
		/// <item><description>After Startup QAction</description></item>
		/// <item><description>A read parameter that was set using setter=true</description></item>
		/// </list>
		/// <para>The message will only be shown to the client triggering the QAction (even when there are multiple Cube sessions open on the same client and all are using the same credentials, the message will only be shown on the intended client).</para>
		/// <para>Feature introduced in DataMiner version 8.5.2 (RN 8348).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// protocol.ShowInformationMessage("My message", "Caption");
		/// </code>
		/// </example>
		void ShowInformationMessage(string message, string caption);

		/// <summary>
		/// Shows a message to the user in a pop-up window.
		/// </summary>
		/// <param name="message">The message to be displayed.</param>
		/// <remarks>
		/// <para>This only works in QActions that are directly triggered from a client with user interaction.</para>
		/// <para>Example scenarios that are supported:</para>
		/// <list type="bullet">
		/// <item><description>Write parameter that triggers a QAction</description></item>
		/// <item><description>Context menu</description></item>
		/// </list>
		/// <para>Example scenarios that are not supported:</para>
		/// <list type="bullet">
		/// <item><description>Protocol.SetParameter or Protocol.CheckTrigger that starts a new QAction</description></item>
		/// <item><description>After Startup QAction</description></item>
		/// <item><description>A read parameter that was set using setter=true</description></item>
		/// </list>
		/// <para>The message will only be shown to the client triggering the QAction (even when there are multiple Cube sessions open on the same client and all are using the same credentials, the message will only be shown on the intended client).</para>
		/// <para>Feature introduced in DataMiner version 8.5.2 (RN 8348).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// protocol.ShowInformationMessage("My message");
		/// </code>
		/// </example>
		void ShowInformationMessage(string message);
	}
}
