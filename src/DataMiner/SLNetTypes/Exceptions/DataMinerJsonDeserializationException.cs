using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Exceptions
{
	/// <summary>
	/// The exception that is thrown when JSON deserialization fails.
	/// </summary>
	[Serializable]
	public class DataMinerJsonDeserializationException : DataMinerException
	{
		/// <summary>
		/// Gets or sets the JSON string.
		/// </summary>
		/// <value>The JSON string.</value>
		private string Json { get; set; }

		/// <summary>
		/// Gets or sets the first exception stack.
		/// </summary>
		/// <value>The first exception stack.</value>
		private string ExceptionStack1 { get; set; }

		/// <summary>
		/// Gets or sets the second exception stack.
		/// </summary>
		/// <value>The second exception stack.</value>
		private string ExceptionStack2 { get; set; }

		protected DataMinerJsonDeserializationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		  : base(serializationInfo, streamingContext)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/>.
		/// </summary>
		public DataMinerJsonDeserializationException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message.
		/// </summary>
		/// <param name="message">The error message.</param>
		public DataMinerJsonDeserializationException(string message)
		  : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message and error code.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="errorCode">The error code.</param>
		public DataMinerJsonDeserializationException(string message, int errorCode)
		  : base(message, errorCode)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message, error code and serialization info.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="errorCode">The error code.</param>
		/// <param name="extraSerializationInfo">The serialization info.</param>
		public DataMinerJsonDeserializationException(string message, int errorCode, string extraSerializationInfo)
		  : base(message, errorCode, extraSerializationInfo)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message and inner exception.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="innerException">The inner exception.</param>
		public DataMinerJsonDeserializationException(string message, Exception innerException)
		  : base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message, inner exception and JSON string.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="innerException">The inner exception.</param>
		/// <param name="json">The JSON string.</param>
		public DataMinerJsonDeserializationException(string message, Exception innerException, string json)
		  : base(message, innerException)
		{
			this.Json = json;
			this.ExceptionStack1 = (innerException != null ? innerException.ToString() : (string)null) ?? "";
			this.ExceptionStack2 = "";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataMinerJsonDeserializationException"/> with the specified message, inner exception and JSON string.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="innerException">The inner exception.</param>
		/// <param name="json">The JSON string.</param>
		/// <param name="exception2">The second exception stack.</param>
		public DataMinerJsonDeserializationException(string message, Exception innerException, string json, string exception2)
		  : base(message, innerException)
		{
			this.Json = json;
			this.ExceptionStack1 = (innerException != null ? innerException.ToString() : (string)null) ?? "";
			this.ExceptionStack2 = exception2;
		}

		/// <summary>
		/// Gets the error message.
		/// </summary>
		/// <value>The error message.</value>
		public override string Message
		{
			get
			{
				return base.Message + "\r\nThe Faulty JSON: " + this.Json + ".\r\nFirst attempt: " + this.ExceptionStack1 + "\r\nSecond attempt: " + this.ExceptionStack2;
			}
		}
	}
}
