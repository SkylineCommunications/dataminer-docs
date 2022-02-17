using System;
using System.Runtime.Serialization;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Represents a profile parameter ID.
	/// </summary>
	[Serializable]
    //[DataContract(IsReference = false, Name = "ProfileParameterID", Namespace = "Skyline.DataMiner.Net")]
    public class ProfileParameterID : GuidDMAObjectRef<ProfileParameterID>, IGuidDMAObjectRef
    {
		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterID"/> class.
		/// </summary>
		public ProfileParameterID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterID"/> class using the specified GUID.
		/// </summary>
		/// <param name="id">The GUID.</param>
		public ProfileParameterID(Guid id)
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

        public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
			return null;
		}

		/// <summary>
		/// Returns a file-friendly string representation of the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		public override string ToFileFriendlyString()
        {
            return "";
        }
    }
}
