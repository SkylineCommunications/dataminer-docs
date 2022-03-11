using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an AlarmTemplateRow is given to a method where the ID object does not correspond with the condition, filter or parameter ID.
    /// </summary>
    public class InvalidAlarmTemplateRowException : Exception
    {
		/// <summary>
		/// Gets or sets the AlarmTemplateRow that is invalid.
		/// </summary>
		/// <value>The AlarmTemplateRow that is invalid.</value>
		public AlarmTemplateRow TemplateRow { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidAlarmTemplateRowException"/> class.
		/// </summary>
		public InvalidAlarmTemplateRowException() 
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidAlarmTemplateRowException"/> class using the specified alarm template row.
		/// </summary>
		/// <param name="templateRow">The template row.</param>
		public InvalidAlarmTemplateRowException(AlarmTemplateRow templateRow)
        {
        }
    }
}
