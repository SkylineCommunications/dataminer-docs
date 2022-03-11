using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
    /// <summary>
    /// This exception that is thrown when the merging of conditions failed due to an equal name but different contents.
    /// </summary>
    public class ConditionMergeException : Exception
    {
		/// <summary>
		/// Gets or sets the target AlarmTemplate where the condition should have been merged to.
		/// </summary>
		/// <value>The target AlarmTemplate where the condition should have been merged to</value>
		public string TargetAlarmTemplate { get; set; }

		/// <summary>
		/// Gets or sets the name of the condition that caused the merge exception.
		/// </summary>
		/// <value>The name of the condition that caused the merge exception.</value>
		public string ConditionName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionMergeException"/> class.
		/// </summary>
		public ConditionMergeException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionMergeException"/> class using the specified condition name and target alarm template.
		/// </summary>
		/// <param name="conditionName">The condition name.</param>
		/// <param name="targetAlarmTemplate">The target alarm template.</param>
		public ConditionMergeException(string conditionName, string targetAlarmTemplate)
        {
        }
    }
}
