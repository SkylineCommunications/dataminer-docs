using System;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Represents a profile definition ID.
	/// </summary>
	[Serializable]
    //[DataContract(IsReference = false, Name = "ProfileDefinitionID", Namespace = "Skyline.DataMiner.Net")]
    public class ProfileDefinitionID : GuidDMAObjectRef<ProfileDefinitionID>, IGuidDMAObjectRef
    {
		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public override Guid Id => default(Guid);

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileDefinitionID"/> class.
		/// </summary>
		public ProfileDefinitionID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileDefinitionID"/> class using the specified GUID.
		/// </summary>
		/// <param name="id">The GUID.</param>
		public ProfileDefinitionID(Guid id)
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
		/// Returns a file-friendly string representation of the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		public override string ToFileFriendlyString()
        {
            return "";
        }

    }
}