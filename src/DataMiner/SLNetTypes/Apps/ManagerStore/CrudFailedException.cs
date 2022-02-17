using System;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace Skyline.DataMiner.Net.ManagerStore
{

	/// <summary>
	/// The exception that is thrown when a CRUD operation failed.
	/// </summary>
	[Serializable]
    public class CrudFailedException : Exception
    {
		/// <summary>
		/// Gets or sets the trace data.
		/// </summary>
		/// <value>The trace data.</value>
		public TraceData TraceData { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CrudFailedException"/> class.
		/// </summary>
		/// <param name="data">The error data.</param>
		public CrudFailedException(ErrorData data)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="CrudFailedException"/> class using the specified trace data.
		/// </summary>
		/// <param name="data">The trace data.</param>
		public CrudFailedException(TraceData data)
        {
        }

        // Needed for deserialization
        protected CrudFailedException(SerializationInfo info, StreamingContext context)
        {
        }

		/// <summary>
		/// Populates a <see cref="SerializationInfo"/>  with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		/// <exception cref="SecurityException">The caller does not have the required permission.</exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return null;
		}
    }
}