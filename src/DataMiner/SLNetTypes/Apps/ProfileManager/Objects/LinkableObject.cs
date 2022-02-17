
using Newtonsoft.Json;
using Skyline.DataMiner.Net.IManager.Objects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents an object that has an ID. This class serves as a base class for other classes to inherit from.
	/// </summary>
    [Serializable]
    //[DataContract(Name = "LinkableObject")]
    [JsonObject(MemberSerialization.OptIn)]
    public class LinkableObject : IManagerIdentifiableObject<Guid>
    {
        //[DataMember(Name = "ID")]
        protected Guid _ID;

		/// <summary>
		/// Gets or set the ID of this object.
		/// </summary>
		/// <value>The ID of this object.</value>
		public virtual Guid ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="LinkableObject"/> class.
		/// </summary>
		/// <remarks>
		/// <para>Constructs an empty <see cref="LinkableObject"/> object with its <see cref="ID"/> set to <see cref="Guid.Empty"/>.</para>
		/// </remarks>
		public LinkableObject()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="LinkableObject"/> class using the specified <see cref="Guid"/>.
		/// </summary>
		/// <param name="g">GUID to use as ID.</param>
		public LinkableObject(Guid g)
        {
        }

		/// <summary>
		/// Retrieves a value indicating whether this object matches the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns><c>true</c> if this object matches the specified filter; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(LinkableObject filter)
        {
            return true;
        }

		/// <summary>
		///  Determines whether the specified <see cref="LinkableObject"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		private bool Equals(LinkableObject other)
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
            return 1;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }
    }

	/// <summary>
	/// Comparer for <see cref="LinkableObject"/> instances which performs the comparison based on the <see cref="LinkableObject.ID"/>.
	/// </summary>
	public class LinkableObjectCompareOnID : IEqualityComparer<LinkableObject>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinkableObjectCompareOnID"/> class.
		/// </summary>
		public LinkableObjectCompareOnID() { }

		/// <summary>
		/// Determines whether the specified objects are equal.
		/// </summary>
		/// <param name="x">The first object of type <see cref="LinkableObject"/>  to compare.</param>
		/// <param name="y">The second object of type <see cref="LinkableObject"/> to compare.</param>
		/// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// Two <see cref="LinkableObject"/> instances are considered equal by this method if their <see cref="LinkableObject.ID"/> is the same.
		/// </remarks>
		public bool Equals(LinkableObject x, LinkableObject y)
        {
            return false;
        }

		/// <summary>
		/// Returns a hash code for the specified object.
		/// </summary>
		/// <param name="obj">The object for which a hash code is to be returned.</param>
		/// <returns>A hash code for the specified object.</returns>
		public int GetHashCode(LinkableObject obj)
        {
            return 0;
        }
    }
}
