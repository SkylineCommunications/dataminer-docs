namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when an operation is performed on a stopped element.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ElementStoppedException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementStoppedException"/> class.
        /// </summary>
        public ElementStoppedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementStoppedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ElementStoppedException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementStoppedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="dmsElementId">The ID of the element.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ElementStoppedException(DmsElementId dmsElementId, Exception innerException)
            : base(String.Format(CultureInfo.InvariantCulture, "The element with ID '{0}' is stopped.", dmsElementId.Value), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementStoppedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ElementStoppedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementStoppedException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ElementStoppedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}