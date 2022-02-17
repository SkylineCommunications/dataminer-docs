using Skyline.DataMiner.Net.Ownership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record cell definition ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class RecordCellDefinitionID : GuidDMAObjectRef<RecordCellDefinitionID>, IGuidDMAObjectRef
    {

		/// <summary>
		/// Gets the record cell definition ID.
		/// </summary>
		/// <value>The record cell definition ID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordCellDefinitionID"/> class.
		/// </summary>
		public RecordCellDefinitionID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordCellDefinitionID"/> class with the specified ID.
		/// </summary>
		/// <param name="id">The GUID to use as ID.</param>
		public RecordCellDefinitionID(Guid id)
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
		/// Creates a new <see cref="RecordCellDefinitionID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="RecordCellDefinitionID"/> instance.</returns>
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
