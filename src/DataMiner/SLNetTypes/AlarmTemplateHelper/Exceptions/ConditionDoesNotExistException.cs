using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
	/// <summary>
	/// The exception that is thrown when the condition that needs to be linked to a parameter does not exist.
	/// </summary>
	public class ConditionDoesNotExistException : Exception
	{
		/// <summary>
		/// The target AlarmTemplate where the condition should have been found in.
		/// </summary>
		public string TargetAlarmTemplate { get; set; }

		/// <summary>
		/// The name of the condition that caused the exception.
		/// </summary>
		public string ConditionName { get; set; }

		/// <summary>
		/// The ID of the linked parameter.
		/// </summary>
		public int ParameterID { get; set; }

		/// <summary>
		/// The filter value of the linked parameter.
		/// </summary>
		public string Filter { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionDoesNotExistException"/> class.
		/// </summary>
		public ConditionDoesNotExistException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionDoesNotExistException"/> class with the specified condition name, target alarm template, parameter ID and filter.
		/// </summary>
		/// <param name="conditionName">The condition name.</param>
		/// <param name="targetAlarmTemplate">The target alarm template.</param>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="filter">The filter.</param>
		public ConditionDoesNotExistException(string conditionName, string targetAlarmTemplate, int parameterID, string filter)
		{
			ConditionName = conditionName;
			TargetAlarmTemplate = targetAlarmTemplate;
			ParameterID = parameterID;
			Filter = filter;
		}
	}

}
