using Skyline.DataMiner.Net.Ownership;
using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a section ID.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class SectionID : GuidDMAObjectRef<SectionID>, IGuidDMAObjectRef
    {
		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		///Initializes a new instance of the <see cref="SectionID"/> class.
		/// </summary>
		public SectionID()
        {
        }

		/// <summary>
		///Initializes a new instance of the <see cref="SectionID"/> class using the specified GUID.
		/// </summary>
		/// <param name="id">The section ID.</param>
		public SectionID(Guid id)
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
		/// Creates a new <see cref="SectionID"/> instance from the specified <see cref="SimpleByteReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="SimpleByteReader"/> instance.</param>
		/// <returns>The created <see cref="SectionID"/> instance.</returns>
		public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
            return null;
        }

		/// <summary>
		/// Returns a file-friendly string that represents the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		/// <remarks>The resulting string is formatted as follows: "SectionID_[GUID]", where [GUID] represents the value of the <see cref="Id"/> property.</remarks>
		public override string ToFileFriendlyString()
        {
            return "";
        }
    }
}