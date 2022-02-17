using Skyline.DataMiner.Net.Ownership;
using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a section definition ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class SectionDefinitionID : GuidWithModuleIdDMAObjectRef<SectionDefinitionID>, IGuidDMAObjectRef
    {

		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Gets or sets the module ID.
		/// </summary>
		/// <value>The module ID.</value>
        public override string ModuleId
        {
			get; set;
        }

		/// <summary>
		///Initializes a new instance of the <see cref="SectionDefinitionID"/> class.
		/// </summary>
		public SectionDefinitionID()
        {
        }

		/// <summary>
		///Initializes a new instance of the <see cref="SectionDefinitionID"/> class using the specified GUID.
		/// </summary>
		/// <param name="id">The section definition ID.</param>
		public SectionDefinitionID(Guid id)
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
		/// Creates a new <see cref="FieldDescriptorID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="FieldDescriptorID"/> instance.</returns>
		public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
			return null;
		}

		/// <summary>
		/// Returns a file-friendly string that represents the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		/// <remarks>The resulting string is formatted as follows: "SectionDefinitionID_[GUID]", where [GUID] represents the value of the <see cref="Id"/> property.</remarks>
		public override string ToFileFriendlyString()
        {
			return null;
		}
    }
}