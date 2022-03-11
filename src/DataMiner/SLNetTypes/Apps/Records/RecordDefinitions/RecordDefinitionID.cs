using System;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record definition ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class RecordDefinitionID : GuidDMAObjectRef<RecordDefinitionID>, IGuidDMAObjectRef
    {

		/// <summary>
		/// Gets the record definition ID.
		/// </summary>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinitionID"/> class.
		/// </summary>
		public RecordDefinitionID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinitionID"/> class with the specified ID.
		/// </summary>
		/// <param name="id">The GUID to use as ID.</param>
		public RecordDefinitionID(Guid id)
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
		/// Creates a new <see cref="RecordDefinitionID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="RecordDefinitionID"/> instance.</returns>
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
            return "";
        }
    }
}
