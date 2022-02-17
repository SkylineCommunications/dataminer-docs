namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Attributes;
    using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// The exception that is thrown when an exception occurs in a DataMiner System.
	/// </summary>
	[Serializable]
    [DllImport("System.Runtime.Serialization.dll")]
    public class DmsException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DmsException"/> class.
		/// </summary>
		public DmsException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DmsException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public DmsException(string message)
        : base(message)
        {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DmsException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public DmsException(string message, Exception innerException)
            : base(message, innerException)
        {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DmsException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is <see langword="null" />.</exception>
		/// <exception cref="SerializationException">The class name is <see langword="null" /> or HResult is zero (0).</exception>
		/// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
		protected DmsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
		}
	}
}