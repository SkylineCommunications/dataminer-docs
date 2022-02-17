namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when a key is not found in a table.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class KeyNotFoundInTableException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyNotFoundInTableException"/> class.
        /// </summary>
        public KeyNotFoundInTableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyNotFoundInTableException"/> class with a specified DataMiner element parameter ID.
        /// </summary>
        /// <param name="key">The requested key.</param>
        /// <param name="tableId">The ID of the table.</param>
        /// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element the table belongs to.</param>
        public KeyNotFoundInTableException(string key, int tableId, DmsElementId dmsElementId)
        : base(String.Format(CultureInfo.InvariantCulture, "The key \"{0}\" was not found in table with ID '{1}' on the element with agent ID '{2}' and element ID '{3}'.", key, tableId, dmsElementId.AgentId, dmsElementId.ElementId))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyNotFoundInTableException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public KeyNotFoundInTableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyNotFoundInTableException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public KeyNotFoundInTableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyNotFoundInTableException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected KeyNotFoundInTableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}