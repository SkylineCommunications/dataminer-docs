using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
	/// <summary>
	/// The exception that is thrown when trying to do an update on a parameter that does not exist in the AlarmTemplate.
	/// </summary>
	class NoAlarmTemplateRowToUpdateException : Exception
	{
		/// <summary>
		/// Gets or sets the target AlarmTemplate where parameter data should have been available.
		/// </summary>
		/// <value>The target AlarmTemplate where parameter data should have been available.</value>
		public string TargetAlarmTemplate { get; set; }

		/// <summary>
		/// Gets or sets the ID of the parameter where no data exists for.
		/// </summary>
		/// <value>The ID of the parameter where no data exists for.</value>
		public int ParameterID { get; set; }

		/// <summary>
		/// Gets or sets the filter value of the parameter where no data exists for.
		/// </summary>
		/// <value>The filter value of the parameter where no data exists for.</value>
		public string Filter { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="NoAlarmTemplateRowToUpdateException"/> class.
		/// </summary>
		public NoAlarmTemplateRowToUpdateException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NoAlarmTemplateRowToUpdateException"/> class.
		/// </summary>
		/// <param name="targetAlarmTemplate">The target alarm template.</param>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="filter">The filter.</param>
		public NoAlarmTemplateRowToUpdateException(string targetAlarmTemplate, int parameterID, string filter)
		{
			TargetAlarmTemplate = targetAlarmTemplate;
			ParameterID = parameterID;
			Filter = filter;
		}
	}
}
