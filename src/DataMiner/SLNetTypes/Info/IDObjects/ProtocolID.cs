using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Skyline.DataMiner.Net.APIDeployment.Url.Blocks;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Represents a protocol ID.
	/// </summary>
	[Serializable]
    //[DataContract(Name = "ProtocolID")]
    [JsonObject(MemberSerialization.OptIn)]
	sealed public class ProtocolID : DMAObjectRef, ICloneable, IEquatable<ProtocolID>, IComparable<ProtocolID>, IComparable, ISerializable
    {
        public static ProtocolID Empty() => new ProtocolID("", "");

		/// <summary>
		/// Gets or sets the parent object.
		/// </summary>
		/// <value>The parent object.</value>
		public DMAObjectRef ParentObjectRef { get; set; }

		/// <summary>
		/// Gets or sets the name of the protocol.
		/// </summary>
		/// <value>The name of the protocol.</value>
		//[DataMember(Name = "ProtocolName")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the version of the protocol.
		/// </summary>
		/// <value>The version of the protocol.</value>
		//[DataMember(Name = "ProtocolVersion")]
        public string Version { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolID"/> class.
		/// </summary>
		public ProtocolID() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolID"/> class using the specified name and version.
		/// </summary>
		/// <param name="name">The name of the protocol.</param>
		/// <param name="version">The version of the protocol.</param>
		public ProtocolID(string name, string version)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProtocolID"/> class using the specified name, version and parent object reference.
		/// </summary>
		/// <param name="name">The name of the protocol.</param>
		/// <param name="version">The version of the protocol.</param>
		/// <param name="parentObjectRef">The parent object.</param>
		public ProtocolID(string name, string version, DMAObjectRef parentObjectRef) : this(name, version)
        {
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

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object, formatted as follows: [Name]/[Version].</returns>
		public override string ToString()
        {
            return "";
        }

		#region IEquatable        
		/// <summary>
		/// Determines whether the specified <see cref="ProtocolID"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>Two <see cref="ProtocolID"/> objects are considered equal by this method if the <see cref="Name"/>, <see cref="Version"/> and <see cref="ParentObjectRef"/> property values are equal.</remarks>
		public bool Equals(ProtocolID other)
        {
            return false;
        }
		#endregion

		#region ICloneable
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}
		#endregion

		#region IComparable
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// <para>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="other"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(ProtocolID other)
        {
			return 0;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// <para>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="obj"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(object obj)
        {
            return 0;
        }
		#endregion

		#region ISerializable
		/// <summary>
		/// Populates a <see cref="SerializationInfo"/>  with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }


        /// <summary>
        /// Constructor used for deserialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ProtocolID(SerializationInfo info, StreamingContext context)
        {
        }
        #endregion

        public override void Write(SimpleByteWriter writer)
        {
        }

        public new static IDMAObjectRef Build(SimpleByteReader reader)
        {
			return null;
		}

        public override string ToFileFriendlyString()
        {
            return "";
        }

        public override SelectorBlock ToSelectorBlock()
        {
            return null;
        }
    }
}
