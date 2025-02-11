using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper
{
	/// <summary>
	/// Allows manipulation of alarm templates: This helper can be used to extract parameter rows from an AlarmTemplate
	/// and add them to or update them on other AlarmTemplates.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><description>A row will be returned as an AlarmTemplateRow object containing the AlarmTemplateRowID, all parameter values (in a GetAlarmTemplateResponseMessage) and the full condition.</description></item>
	/// <item><description>When a row is deleted, the condition will only be deleted if it is not used by any other parameter.</description></item>
	/// <item><description>When an existing row is merged, the parameter values will be updated, and the parameter will have the same index in the list.</description></item>
	/// <item><description>When a new row is merged, it will be added at the bottom of the list.</description></item>
	/// <item><description>Only parameter rows that are set to "Included" can be extracted and merged.</description></item>
	/// </list>
	/// </remarks>
	/// <example>
	/// <code>
	/// AlarmTemplateHelper helper = new AlarmTemplateHelper(engine.SendSLNetMessages);
	/// 
	/// var id = new AlarmTemplateID("AlarmTemplate", "Protocol", "1.0.0.0");
	/// var rowId = new AlarmTemplateRowID(1, "condition", "filter");
	/// var rowList = new List&lt;AlarmTemplateRowID&gt; { rowId };
	/// var row = helper.GetAlarmTemplateRowsFromServer(id, rowList);
	/// 
	/// helper.DeleteAlarmTemplateRowsOnServer(_id, row);
	/// </code>
	/// </example>
	public class AlarmTemplateHelper
    {
		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateHelper"/> class.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		public AlarmTemplateHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
        {
		}
		#endregion

		#region Get Methods
		/// <summary>
		/// Retrieves the specified alarm template rows from the server.
		/// </summary>
		/// <param name="alarmTemplateID">The alarm template ID.</param>
		/// <param name="alarmTemplateRowIDs">The alarm template row IDs.</param>
		/// <returns>The requested alarm template rows.</returns>
		/// <exception cref="RetrievingAlarmTemplateFromServerException">Failed to retrieve the alarm template with the specified ID.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplateID"/> or <paramref name="alarmTemplateRowIDs"/> is <see langword="null"/>.</exception>
		/// <exception cref="ConditionDoesNotExistException">When the condition is not in the condition list</exception>
		/// <exception cref="ParameterDoesNotExistException">When the parameter is not in the parameter list</exception>
		public List<AlarmTemplateRow> GetAlarmTemplateRowsFromServer(AlarmTemplateID alarmTemplateID, List<AlarmTemplateRowID> alarmTemplateRowIDs)
        {
			return null;
		}

		/// <summary>
		/// Returns a list of <see cref="AlarmTemplateRow"/> objects that were requested by the list of <see cref="AlarmTemplateRowID"/>s.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRowIDs">The alarm template row IDs.</param>
		/// <exception cref="ArgumentNullException">When passing null values to the method</exception>
		/// <exception cref="ConditionDoesNotExistException">When the condition is not in the condition list</exception>
		/// <exception cref="ParameterDoesNotExistException">When the parameter is not in the parameter list</exception>
		public List<AlarmTemplateRow> GetAlarmTemplateRows(AlarmTemplateEventMessage alarmTemplate, List<AlarmTemplateRowID> alarmTemplateRowIDs)
        {
			return null;
		}

		/// <summary>
		/// Returns the alarm template row with the specified alarm template row ID.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRowID">The alarm template row ID.</param>
		/// <returns>The requested alarm template row.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/> or <paramref name="alarmTemplateRowID"/> is <see langword="null"/>.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition is not in the condition list</exception>
		/// <exception cref="ParameterDoesNotExistException">The parameter is not in the parameter list</exception>
		public AlarmTemplateRow GetAlarmTemplateRow(AlarmTemplateEventMessage alarmTemplate, AlarmTemplateRowID alarmTemplateRowID)
        {
			return null;
		}
		#endregion

		#region Delete Methods
		/// <summary>
		/// Deletes the specified alarm template rows from the specified alarm template.
		/// </summary>
		/// <param name="alarmTemplateID">The alarm template ID.</param>
		/// <param name="alarmTemplateRows">The alarm tempalte rows.</param>
		/// <exception cref="RetrievingAlarmTemplateFromServerException">The AlarmTemplate could not be retrieved from the server.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition is not in the condition list.</exception>
		/// <exception cref="ParameterDoesNotExistException">The parameter is not in the parameter list.</exception>
		/// <exception cref="DataMinerException">The GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplateID"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// <para>The AlarmTemplate will be retrieved using the AlarmTemplateID. The deletes are executed and if this was successful the template will be updated on the server.</para>
		/// </remarks>
		public void DeleteAlarmTemplateRowsOnServer(AlarmTemplateID alarmTemplateID, List<AlarmTemplateRow> alarmTemplateRows)
        {
        }

        /// <summary>
        /// Returns an <see cref="AlarmTemplateEventMessage"/> where the parameters defined by the <see cref="AlarmTemplateRow"/>s are removed.
        /// The conditions will also be removed if there are no links anymore.
        /// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRows">The alarm template rows.</param>
        /// <exception cref="ConditionDoesNotExistException">The condition is not in the condition list.</exception>
        /// <exception cref="ParameterDoesNotExistException">The parameter is not in the parameter list.</exception>
        /// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
        /// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
        public AlarmTemplateEventMessage DeleteAlarmTemplateRows(AlarmTemplateEventMessage alarmTemplate, List<AlarmTemplateRow> alarmTemplateRows)
        {
			return null;
		}

		/// <summary>
		/// Deletes the specified alarm template rows from the specified alarm template.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRow">The alarm template row.</param>
		/// <returns>An <see cref="AlarmTemplateEventMessage"/> where the parameter defined by the <see cref="AlarmTemplateRow"/> is removed.</returns>
		/// <exception cref="ConditionDoesNotExistException">The condition is not in the condition list.</exception>
		/// <exception cref="ParameterDoesNotExistException">The parameter is not in the parameter list.</exception>
		/// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/> or <paramref name="alarmTemplateRow"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// <para>The condition will also be removed if there are no links anymore.</para>
		/// </remarks>
		public AlarmTemplateEventMessage DeleteAlarmTemplateRow(AlarmTemplateEventMessage alarmTemplate, AlarmTemplateRow alarmTemplateRow)
        {
			return null;
		}
		#endregion

		#region Merge Methods
		/// <summary>
		/// Merges the specified rows with the specified template.
		/// </summary>
		/// <param name="alarmTemplateID">The ID of the alarm template.</param>
		/// <param name="alarmTemplateRows">The rows to merge.</param>
		/// <exception cref="RetrievingAlarmTemplateFromServerException">The AlarmTemplate could not be retrieved from the server.</exception>
		/// <exception cref="ConditionMergeException">A condition used in a merge call has the same name as an existing condition with a different content.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition specified in the AlarmTemplateRow could not be found in the alarm template.</exception>
		/// <exception cref="DataMinerException">A row could not be found when merging.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplateID"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
		public void MergeAlarmTemplateRowsOnServer(AlarmTemplateID alarmTemplateID, List<AlarmTemplateRow> alarmTemplateRows)
        {
        }

		/// <summary>
		/// Merges the specified rows with the specified template.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRows">The alarm tempalte rows.</param>
		/// <returns>An <see cref="AlarmTemplateEventMessage"/> where the parameters defined by the <see cref="AlarmTemplateRow"/> are merged.</returns>
		/// <exception cref="ConditionMergeException">A condition used in a merge call has the same name as an existing condition with a different content.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition specified in the AlarmTemplateRow could not be found in the alarm template.</exception>
		/// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
		public AlarmTemplateEventMessage MergeAlarmTemplateRows(AlarmTemplateEventMessage alarmTemplate, List<AlarmTemplateRow> alarmTemplateRows)
        {
			return null;
		}

		/// <summary>
		/// Returns an <see cref="AlarmTemplateEventMessage"/> where the parameter defined by the <see cref="AlarmTemplateRow"/> is merged.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRow">The alarm template row.</param>
		/// <param name="onlyAllowUpdate">Value indicating whether only updates are allowed.</param>
		/// <exception cref="ConditionMergeException">A condition with an equal name is found, but the contents are different.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition that is linked to the parameter is not found in the target AlarmTemplate.</exception>
		/// <exception cref="NoAlarmTemplateRowToUpdateException"><paramref name="onlyAllowUpdate"/> is <c>true</c> and no data to update is found.</exception>
		/// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/>, <paramref name="alarmTemplateRow"/> or <paramref name="onlyAllowUpdate"/> is <see langword="null"/>.</exception>
		public AlarmTemplateEventMessage MergeAlarmTemplateRow(AlarmTemplateEventMessage alarmTemplate, AlarmTemplateRow alarmTemplateRow, bool onlyAllowUpdate = false)
        {
			return null;
		}
		#endregion

		#region Update Methods
		/// <summary>
		/// Updates the specified alarm template with the specified rows.
		/// </summary>
		/// <param name="alarmTemplateID">The ID of the alarm template.</param>
		/// <param name="alarmTemplateRows">The alarm template rows to update.</param>
		/// <exception cref="RetrievingAlarmTemplateFromServerException">The AlarmTemplate could not be retrieved from the server.</exception>
		/// <exception cref="NoAlarmTemplateRowToUpdateException">No data to update is found in the AlarmTemplate.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition that is linked to the parameter is not found in the target AlarmTemplate.</exception>
		/// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplateID"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// <para>The AlarmTemplate will be retrieved using the AlarmTemplateID. The updates are executed and the AlarmTemplate will be updated on the server. If this method fails, the AlarmTemplate will not be updated on the server.</para>
		/// </remarks>
		public void UpdateAlarmTemplateRowsOnServer(AlarmTemplateID alarmTemplateID, List<AlarmTemplateRow> alarmTemplateRows)
        {
        }

		/// <summary>
		/// Updates the specified alarm template with the specified rows.
		/// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRows">The alarm template rows to update.</param>
		/// <returns>The updated alarm template.</returns>
		/// <exception cref="NoAlarmTemplateRowToUpdateException">No data to update is found in the AlarmTemplate.</exception>
		/// <exception cref="ConditionDoesNotExistException">The condition that is linked to the parameter is not found in the target alarmTemplate.</exception>
		/// <exception cref="DataMinerException">GetAlarmTemplateRow returns a parameter that cannot be found in the list.</exception>
		/// <exception cref="InvalidAlarmTemplateRowException">The provided AlarmTemplateRow contains data that does not match with the ID in it.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="alarmTemplate"/> or <paramref name="alarmTemplateRows"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// <para>Updates parameter data in the target AlarmTemplate, when no data to update is found, an exception is thrown.</para>
		/// </remarks>
		public AlarmTemplateEventMessage UpdateAlarmTemplateRows(AlarmTemplateEventMessage alarmTemplate, List<AlarmTemplateRow> alarmTemplateRows)
        {
			return null;
        }

        /// <summary>
        /// Updates parameter data in the target AlarmTemplate, when no data to update is found, an exception is thrown.
        /// </summary>
		/// <param name="alarmTemplate">The alarm template.</param>
		/// <param name="alarmTemplateRow">The alarm template row.</param>
		/// <returns>The updated alarm template.</returns>
        /// <exception cref="NoAlarmTemplateRowToUpdateException">When no data to update is found in the AlarmTemplate</exception>
        /// <exception cref="ConditionDoesNotExistException">If the condition that is linked to the parameter is not found in the target alarmTemplate</exception>
        /// <exception cref="DataMinerException">When GetAlarmTemplateRow returns a parameter that cannot be found in the list</exception>
        /// <exception cref="InvalidAlarmTemplateRowException">When the provided AlarmTemplateRow contains data that does not match with the ID in it</exception>
        /// <exception cref="ArgumentNullException">When passing null values to the method</exception>
        public AlarmTemplateEventMessage UpdateAlarmTemplateRow(AlarmTemplateEventMessage alarmTemplate, AlarmTemplateRow alarmTemplateRow)
        {
			return null;
		}
        #endregion
    }
}
