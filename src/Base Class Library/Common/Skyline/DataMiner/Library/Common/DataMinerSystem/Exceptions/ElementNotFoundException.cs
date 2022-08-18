namespace Skyline.DataMiner.Library.Common
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
	using Skyline.DataMiner.Library.Common.Attributes;

	/// <summary>
	/// The exception that is thrown when performing actions on an element that was not found.
	/// </summary>
	[Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class ElementNotFoundException : DmsException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class.
		/// </summary>
		public ElementNotFoundException()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class.
		/// </summary>
		/// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element that was not found.</param>
		public ElementNotFoundException(DmsElementId dmsElementId)
            : base(String.Format(CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmsElementId.AgentId, dmsElementId.ElementId))
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class.
		/// </summary>
		/// <param name="dmaId">The ID of the DataMiner Agent that was not found.</param>
		/// <param name="elementId">The ID of the element that was not found.</param>
		public ElementNotFoundException(int dmaId, int elementId)
        : base(String.Format(CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmaId, elementId))
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public ElementNotFoundException(string message)
        : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public ElementNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element that was not found.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public ElementNotFoundException(DmsElementId dmsElementId, Exception innerException)
            : base(String.Format(CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmsElementId.AgentId, dmsElementId.ElementId), innerException)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementNotFoundException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected ElementNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}