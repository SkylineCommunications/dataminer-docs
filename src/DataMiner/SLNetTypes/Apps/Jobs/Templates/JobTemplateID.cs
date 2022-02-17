using Skyline.DataMiner.Net.Ownership;
using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a job template ID.
	/// </summary>
	/// <remarks>
	/// <para>Feature introduced in DataMiner 9.6.6 (RN 21380).</para>
	/// </remarks>
	[Serializable]
    //[DataContract]
    public class JobTemplateID : GuidDMAObjectRef<JobTemplateID>, IGuidDMAObjectRef
    {
		/// <summary>
		/// Gets the job template ID.
		/// </summary>
		/// <value>The job template ID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="JobTemplateID"/> class.
		/// </summary>
		public JobTemplateID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobTemplateID"/> class using the specified Job template ID.
		/// </summary>
		/// <param name="id">The Job template ID.</param>
		public JobTemplateID(Guid id)
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
		/// Builds a <see cref="JobTemplateID"/> instance out of the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The reader to build the instance from.</param>
		/// <returns>The created <see cref="JobTemplateID"/> instance.</returns>
		public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
			return null;
		}

		/// <summary>
		/// Returns a file-friendly string that represents the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		public override string ToFileFriendlyString()
        {
			return null;
		}
    }
}