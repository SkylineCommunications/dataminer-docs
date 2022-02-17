using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
    /// <summary>
    /// The exception that is thrown when retrieving the AlarmTemplate from server failed.
    /// </summary>
    public class RetrievingAlarmTemplateFromServerException : Exception
    {
		/// <summary>
		/// Gets or sets the alarm template ID used to retrieve the AlarmTemplate.
		/// </summary>
		/// <value>The alarm template ID used to retrieve the AlarmTemplate.</value>
		public AlarmTemplateID TemplateID { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RetrievingAlarmTemplateFromServerException"/> class.
		/// </summary>
		public RetrievingAlarmTemplateFromServerException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RetrievingAlarmTemplateFromServerException"/> class using the specified alarm template ID.
		/// </summary>
		/// <param name="templateID">The alarm template ID.</param>
		public RetrievingAlarmTemplateFromServerException(AlarmTemplateID templateID)
        {
        }
    }
}
