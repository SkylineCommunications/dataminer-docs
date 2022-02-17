using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the parameter does not exist in the given AlarmTemplate.
    /// </summary>
    public class ParameterDoesNotExistException : Exception
    {
		/// <summary>
		/// Gets or sets the target AlarmTemplate where the parameter should have been found in.
		/// </summary>
		/// <value>The target AlarmTemplate where the parameter should have been found in.</value>
		public string TargetAlarmTemplate { get; set; }

		/// <summary>
		/// Gets or sets the name of the condition that is linked to the parameter.
		/// </summary>
		/// <value>The name of the condition that is linked to the parameter.</value>
		public string ConditionName { get; set; }

		/// <summary>
		/// Gets or sets the ID of the parameter that caused the exception.
		/// </summary>
		/// <value>The ID of the parameter that caused the exception.</value>
		public int ParameterID { get; set; }

		/// <summary>
		/// Gets or sets the filter value of the parameter that caused the exception.
		/// </summary>
		/// <value>The filter value of the parameter that caused the exception.</value>
		public string Filter { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterDoesNotExistException"/> class.
		/// </summary>
		public ParameterDoesNotExistException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterDoesNotExistException"/> class using the specified condition name, target alarm template, parameter ID and filter.
		/// </summary>
		/// <param name="conditionName">The condition name.</param>
		/// <param name="targetAlarmTemplate">The target alarm template.</param>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="filter">The filter.</param>
		public ParameterDoesNotExistException(string conditionName, string targetAlarmTemplate, int parameterID, string filter)
        {
        }
    }

}
