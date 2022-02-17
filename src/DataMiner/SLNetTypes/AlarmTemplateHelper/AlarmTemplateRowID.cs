using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper
{
	/// <summary>
	/// Identifies a row of an alarm template.
	/// </summary>
	[Serializable]
    public class AlarmTemplateRowID : ICloneable
    {
		/// <summary>
		/// Gets or sets the parameter ID.
		/// </summary>
		/// <value>The parameter ID.</value>
		public int ParameterID { get; set; }

		/// <summary>
		/// Gets or sets the condition name.
		/// </summary>
		/// <value>The condition name.</value>
		public string ConditionName { get; set; }

		/// <summary>
		/// Gets or sets the filter.
		/// </summary>
		/// <value>The filter.</value>
		/// <remarks>
		/// <para>Keep in mind that setting the filter value to "" or a null reference will prevent the alarms from being triggered. A “*” character needs to be filled in. Keep this in mind when retrieving rows from alarm templates. When a template is made via Cube, the filter value of this type of parameters will always be a “*” by default. So when creating a AlarmTemplateRowID object, you have to fill that in in the filter field.</para>
		/// </remarks>
		public string Filter { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateRowID"/> class.
		/// </summary>
		public AlarmTemplateRowID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateRowID"/> class using the specified parameter ID, condition name and filter.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="conditionName">The condition name.</param>
		/// <param name="filter">The filter.</param>
		public AlarmTemplateRowID(int parameterID, string conditionName, string filter)
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
    }
}