using System;

using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class RecordID : GuidDMAObjectRef<RecordID>, IGuidDMAObjectRef
    {
		/// <summary>
		/// Gets the record ID.
		/// </summary>
		/// <value>The record ID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordID"/> class.
		/// </summary>
		public RecordID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordID"/> class with the specified ID.
		/// </summary>
		/// <param name="id">The GUID to use as ID.</param>
		public RecordID(Guid id)
        {
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Creates a new <see cref="RecordID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="RecordID"/> instance.</returns>
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
