namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when a requested protocol was not found.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ProtocolNotFoundException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class.
        /// </summary>
        public ProtocolNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class.
        /// </summary>
        /// <param name="protocolName">The name of the protocol.</param>
        /// <param name="protocolVersion">The version of the protocol.</param>
        public ProtocolNotFoundException(string protocolName, string protocolVersion)
        : base(String.Format(CultureInfo.InvariantCulture, "Protocol with name '{0}' and version '{1}' was not found.", protocolName, protocolVersion))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ProtocolNotFoundException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class.
        /// </summary>
        /// <param name="protocolName">The name of the protocol.</param>
        /// <param name="protocolVersion">The version of the protocol.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProtocolNotFoundException(string protocolName, string protocolVersion, Exception innerException)
        : base(String.Format(CultureInfo.InvariantCulture, "Protocol with name '{0}' and version '{1}' was not found.", protocolName, protocolVersion), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProtocolNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolNotFoundException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ProtocolNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}