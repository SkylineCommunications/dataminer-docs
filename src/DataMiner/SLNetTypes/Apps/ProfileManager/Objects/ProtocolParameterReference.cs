using System;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a reference to a protocol parameter.
	/// </summary>
	[Serializable]
    //[DataContract(Name = "ProtocolParameterReference")]
    public class ProtocolParameterReference : IEquatable<ProtocolParameterReference>
    {
		/// <summary>
		/// Gets or sets the name of the protocol.
		/// </summary>
		/// <value>The name of the protocol.</value>
		//[DataMember(Name = "ProtocolName")]
        public string ProtocolName { get; set; }

		/// <summary>
		/// Gets or sets the version of the protocol.
		/// </summary>
		/// <value>The version of the protocol.</value>
		//[DataMember(Name = "ProtocolVersion")]
        public string ProtocolVersion { get; set; }

		/// <summary>
		/// Gets or sets the ID of the protocol parameter.
		/// </summary>
		/// <value>The protocol parameter ID.</value>
		//[DataMember(Name = "ParameterId")]
        public int ParameterId { get; set; }

		/// <summary>
		/// Gets or sets the table index.
		/// </summary>
		/// <value>The table index.</value>
		//[DataMember(Name = "TableIndex")]
        public string TableIndex { get; set; }

		/// <summary>
		/// Gets or sets the media snippet ID.
		/// </summary>
		/// <value>The media snippet ID.</value>
		//[DataMember(Name = "MediationSnippetID")]
        public Guid MediationSnippetID { get; set; }

		/// <summary>
		/// Gets or set the protocol name and version.
		/// </summary>
		/// <value>The protocol ID.</value>
		public ProtocolID ProtocolID
        {
			get; set;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolParameterReference"/> class.
		/// </summary>
		public ProtocolParameterReference()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolParameterReference"/> class using the specified <see cref="ProtocolParameterReference"/> instance.
		/// </summary>
		/// <param name="ppr">The protocol parameter reference to copy the values from.</param>
		public ProtocolParameterReference(ProtocolParameterReference ppr)
        {
        }

		/// <summary>
		/// Retrieves a value indicating whether this protocol parameter reference matches the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns><c>true</c> if this protocol parameter reference matches the specified filter; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(ProtocolParameterReference filter)
        {
            return true;
        }

		/// <summary>
		///  Determines whether the specified <see cref="ProtocolParameterReference"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public bool Equals(ProtocolParameterReference other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 0;
        }
    }
}
