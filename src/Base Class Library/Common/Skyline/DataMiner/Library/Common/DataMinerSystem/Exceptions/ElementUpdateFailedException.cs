namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when an element failed to update.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ElementUpdateFailedException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class.
        /// </summary>
        public ElementUpdateFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class.
        /// </summary>
        /// <param name="dmaId">DataMiner Agent ID of the element that failed to update.</param>
        /// <param name="elementId">Element ID of the element that failed to update.</param>
        public ElementUpdateFailedException(int dmaId, int elementId)
        : base(String.Format(CultureInfo.InvariantCulture, "Failed to update element with DataMiner agent ID '{0}' and element ID '{1}'.", dmaId, elementId))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class using <see cref="DmsElementId"/>.
        /// </summary>
        /// <param name="dmsElementId">The system-wide element ID.</param>
        public ElementUpdateFailedException(DmsElementId dmsElementId)
            : base(String.Format(CultureInfo.InvariantCulture, "Failed to update element with DataMiner agent ID '{0}' and element ID '{1}'.", dmsElementId.AgentId, dmsElementId.ElementId))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ElementUpdateFailedException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ElementUpdateFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementUpdateFailedException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ElementUpdateFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}