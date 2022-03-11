using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// The exception that is thrown when a section definition is not attached.
	/// </summary>
	[Serializable]
    public class SectionDefinitionNotAttachedException : Exception
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionNotAttachedException"/> class.
		/// </summary>
		public SectionDefinitionNotAttachedException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionNotAttachedException"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public SectionDefinitionNotAttachedException(string message) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionNotAttachedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not <see langword="null"/>, the current exception is raised in a catch block that handles the inner exception.</param>
		public SectionDefinitionNotAttachedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SectionDefinitionNotAttachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}