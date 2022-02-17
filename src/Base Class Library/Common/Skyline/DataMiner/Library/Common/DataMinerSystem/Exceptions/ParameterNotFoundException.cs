namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when an action is performed on a DataMiner element parameter that was not found.
    /// </summary>
    [Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ParameterNotFoundException : DmsException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class.
        /// </summary>
        public ParameterNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class with a specified DataMiner element parameter ID.
        /// </summary>
        /// <param name="id">The ID of the DataMiner Agent that was not found.</param>
        /// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element the parameter belongs to.</param>
        public ParameterNotFoundException(int id, DmsElementId dmsElementId)
        : base(String.Format(CultureInfo.InvariantCulture, "The parameter with ID '{0}' was not found on the element with agent ID '{1}' and element ID '{2}'.", id, dmsElementId.AgentId, dmsElementId.ElementId))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ParameterNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ParameterNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class with a specified DataMiner element parameter ID.
		/// </summary>
		/// <param name="id">The ID of the DataMiner agent that was not found.</param>
		/// <param name="dmsElementId">The DataMiner agent ID/element ID of the element the parameter belongs to.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public ParameterNotFoundException(int id, DmsElementId dmsElementId, Exception innerException)
        : base(String.Format(CultureInfo.InvariantCulture, "The parameter with ID '{0}' was not found on the element with agent ID '{1}' and element ID '{2}'.", id, dmsElementId.AgentId, dmsElementId.ElementId), innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterNotFoundException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ParameterNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}