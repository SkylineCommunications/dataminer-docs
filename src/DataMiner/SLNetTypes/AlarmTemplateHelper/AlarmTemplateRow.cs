using System;
using Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper
{
	/// <summary>
	/// Represents a row in an alarm template.
	/// </summary>
	[Serializable]
    public class AlarmTemplateRow : ICloneable
    {
		/// <summary>
		/// Gets or sets the alarm template row ID.
		/// </summary>
		/// <value>The alarm template row ID.</value>
		public AlarmTemplateRowID ID { get; set; }

		/// <summary>
		/// Gets or sets the parameter values.
		/// </summary>
		/// <value>The parameter values.</value>
		public GetAlarmTemplateResponseMessage ParameterValues { get; set; }

		/// <summary>
		/// Gets or sets the condition.
		/// </summary>
		/// <value>The condition.</value>
		public AlarmTemplateCondition Condition { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateRow"/> class.
		/// </summary>
		public AlarmTemplateRow()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateRow"/> class using the specified alarm template row ID, parameter values and optional condition.
		/// </summary>
		/// <param name="id">The alarm template row ID.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <param name="condition">The condition.</param>
		public AlarmTemplateRow(AlarmTemplateRowID id, GetAlarmTemplateResponseMessage parameterValues, AlarmTemplateCondition condition = null)
        {
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Verifies whether this row is valid (i.e. ID of the AlarmTemplateRow match the values within the AlarmTemplateRow).
		/// </summary>
		/// <exception cref="InvalidAlarmTemplateRowException">The row is invalid.</exception>
		/// <remarks>
		/// <para>Note: If the ID.filter or ID.ConditionName is null or empty, the linked value does not matter</para>
		/// </remarks>
		public void Verify()
        {
		}
    }
}