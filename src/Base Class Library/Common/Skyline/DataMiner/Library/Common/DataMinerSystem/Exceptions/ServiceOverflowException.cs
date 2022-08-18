namespace Skyline.DataMiner.Library.Common
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
	using Skyline.DataMiner.Library.Common.Attributes;

	/// <summary>
	/// The exception that is thrown when performing actions on an service that has too many elements or services included.
	/// </summary>
	[Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ServiceOverflowException : DmsException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class.
		/// </summary>
		public ServiceOverflowException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class.
		/// </summary>
		/// <param name="dmsServiceId">The DataMiner Agent ID/service ID of the service that has too many elements or services included.</param>
		public ServiceOverflowException(DmsServiceId dmsServiceId)
            : base(String.Format(CultureInfo.InvariantCulture, "Service with DMA ID '{0}' and service ID '{1}' has too many elements or services included.", dmsServiceId.AgentId, dmsServiceId.ServiceId))
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class.
		/// </summary>
		/// <param name="dmaId">The ID of the DataMiner Agent that has too many elements or services included.</param>
		/// <param name="serviceId">The ID of the service that has too many elements or services included.</param>
		public ServiceOverflowException(int dmaId, int serviceId)
        : base(String.Format(CultureInfo.InvariantCulture, "Service with DMA ID '{0}' and service ID '{1}' has too many elements or services included.", dmaId, serviceId))
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public ServiceOverflowException(string message)
        : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public ServiceOverflowException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="dmsServiceId">The DataMiner Agent ID/service ID of the service that has too many elements or services included.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public ServiceOverflowException(DmsServiceId dmsServiceId, Exception innerException)
            : base(String.Format(CultureInfo.InvariantCulture, "Service with DMA ID '{0}' and service ID '{1}' has too many elements or services included.", dmsServiceId.AgentId, dmsServiceId.ServiceId), innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceOverflowException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ServiceOverflowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}