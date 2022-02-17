using Skyline.DataMiner.Net.Ownership;
using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a <see cref="Job"/> ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class JobID : GuidDMAObjectRef<JobID>, IGuidDMAObjectRef
    {

		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		///Initializes a new instance of the <see cref="JobID"/> class.
		/// </summary>
		public JobID()
        {
        }

		/// <summary>
		///Initializes a new instance of the <see cref="JobID"/> class using the specified GUID.
		/// </summary>
		/// <param name="id">The job ID.</param>
		public JobID(Guid id)
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

		/// <summary>
		/// Creates a new <see cref="JobID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="JobID"/> instance.</returns>
		public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
			return null;
		}

		/// <summary>
		/// Returns a file-friendly string that represents the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		/// <remarks>The resulting string is formatted as follows: "JobID_[GUID]", where [GUID] represents the value of the <see cref="Id"/> property.</remarks>
		public override string ToFileFriendlyString()
        {
			return null;
		}

		/// <summary>
		/// Returns the attachment string.
		/// </summary>
		/// <returns>The attachment string..</returns>
		/// <remarks>The resulting string is formatted as follows: "[Id]", where [Id] represents the value of the <see cref="Id"/> property.</remarks>
		public override string ToAttachmentString()
        {
			return null;
		}
    }
}