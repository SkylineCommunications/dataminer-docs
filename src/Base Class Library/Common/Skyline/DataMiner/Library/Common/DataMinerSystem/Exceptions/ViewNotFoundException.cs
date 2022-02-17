namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when performing actions on a view that was not found.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ViewNotFoundException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class.
        /// </summary>
        public ViewNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class.
        /// </summary>
        /// <param name="viewId">The ID of the view that was not found.</param>
        public ViewNotFoundException(int viewId)
        : base(String.Format(CultureInfo.InvariantCulture, "View with ID '{0}' was not found.", viewId))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class.
        /// </summary>
        /// <param name="viewId">The ID of the view that was not found.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ViewNotFoundException(int viewId, Exception innerException)
        : base(String.Format(CultureInfo.InvariantCulture, "View with ID '{0}' was not found.", viewId), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ViewNotFoundException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ViewNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewNotFoundException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
        /// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
        /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
        protected ViewNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}