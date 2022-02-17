using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Exceptions
{
	/// <summary>Base class for all DataMiner-related exceptions</summary>
	[Serializable]
	public class DataMinerException : Exception
	{
		public DataMinerException()
		{
		}

		public DataMinerException(string message)
		  : base(message)
		{
		}

		public DataMinerException(string message, int errorCode)
		  : this(message, errorCode, 0, string.Empty)
		{
		}

		public DataMinerException(string message, int errorCode, string extraSerializationInfo)
		  : this(message, errorCode, 0, extraSerializationInfo)
		{
		}

		public DataMinerException(string message, int errorCode, int subErrorCode)
		  : this(message, errorCode, subErrorCode, string.Empty)
		{
		}

		public DataMinerException(string message, int errorCode, int subErrorCode, string extraSerializationInfo)
		  : base(message)
		{
			this.ExtraSerializationInfo = extraSerializationInfo;
			this.HResult = errorCode;
			this.SubErrorCode = subErrorCode;
		}

		public DataMinerException(string message, Exception innerException)
		  : base(message, innerException)
		{
		}

		public DataMinerException(string message, int errorCode, Exception innerException)
		  : this(message, errorCode, 0, innerException)
		{
		}

		public DataMinerException(string message, int errorCode, int subErrorCode, Exception innerException)
		  : base(message, innerException)
		{
			this.HResult = errorCode;
			this.SubErrorCode = subErrorCode;
		}

		protected DataMinerException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		  : base(serializationInfo, streamingContext)
		{
			try
			{
				this.SubErrorCode = serializationInfo.GetInt32("subErrorCode");
			}
			catch (SerializationException ex)
			{
			}
		}

		/// <summary>Gets the error code (HRESULT).</summary>
		/// <remarks>By default, this is COR_E_EXCEPTION (0x80131500)</remarks>
		/// <value></value>
		public int ErrorCode
		{
			get
			{
				return this.HResult;
			}
		}

		/// <summary>
		/// Extra error code (DataMinerErrorCode.NoError by default), e.g. more detail on authentication errors.
		/// </summary>
		public int SubErrorCode { get; set; }

		public override string ToString()
		{
			return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "(Code: 0x{0,8:X}) {1}", new object[2]
			{
		(object) this.ErrorCode,
		(object) base.ToString()
			});
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("subErrorCode", this.SubErrorCode);
		}

		/// <summary>
		/// Extra information that needs to be serialized when wrapping
		/// a DataMinerException in a SoapException
		/// </summary>
		public virtual string ExtraSerializationInfo
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}
	}
}
