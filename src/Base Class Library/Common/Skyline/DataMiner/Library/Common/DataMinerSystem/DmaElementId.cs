namespace Skyline.DataMiner.Library.Common
{
    using System;
    using System.Globalization;
	using Newtonsoft.Json;
	using Skyline.DataMiner.Library.Common.Attributes;

	/// <summary>
	/// Represents a system-wide element ID.
	/// </summary>
	/// <remarks>This is a combination of a DataMiner Agent ID (the ID of the Agent on which the element was created) and an element ID.</remarks>
	[Serializable]
	[DllImport("Newtonsoft.Json.dll")]
	public struct DmsElementId : IEquatable<DmsElementId>, IComparable, IComparable<DmsElementId>
    {
        /// <summary>
        /// The DataMiner Agent ID.
        /// </summary>
        private int agentId;

        /// <summary>
        /// The element ID.
        /// </summary>
        private int elementId;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DmsElementId"/> structure using the specified string.
		/// </summary>
		/// <param name="id">String representing the system-wide element ID.</param>
		/// <remarks>The provided string must be formatted as follows: "DataMiner Agent ID/element ID (e.g. 400/201)".</remarks>
		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/> .</exception>
		/// <exception cref="ArgumentException"><paramref name="id"/> is the empty string ("") or white space.</exception>
		/// <exception cref="ArgumentException">The ID does not match the mandatory format.</exception>
		/// <exception cref="ArgumentException">The DataMiner Agent ID is not an integer.</exception>
		/// <exception cref="ArgumentException">The element ID is not an integer.</exception>
		/// <exception cref="ArgumentException">Invalid DataMiner Agent ID.</exception>
		/// <exception cref="ArgumentException">Invalid element ID.</exception>
		public DmsElementId(string id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (String.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException("The provided ID must not be empty.", "id");
			}

			string[] idParts = id.Split('/');

			if (idParts.Length != 2)
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid ID. Value: {0}. The string must be formatted as follows: \"agent ID/element ID\".", id);

				throw new ArgumentException(message, "id");
			}

			if (!Int32.TryParse(idParts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out agentId))
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid DataMiner agent ID. \"{0}\" is not an integer value", id);

				throw new ArgumentException(message, "id");
			}

			if (!Int32.TryParse(idParts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out elementId))
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid Element ID. \"{0}\" is not an integer value", id);

				throw new ArgumentException(message, "id");
			}

			if (!IsValidAgentId())
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);

				throw new ArgumentException(message, "id");
			}

			if (!IsValidElementId())
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", elementId);

				throw new ArgumentException(message, "id");
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="DmsElementId" /> structure using the specified element ID and DataMiner Agent ID.
        /// </summary>
        /// <param name="agentId">The DataMiner Agent ID.</param>
        /// <param name="elementId">The element ID.</param>
        /// <remarks>The hosting DataMiner Agent ID value will be set to the same value as the specified DataMiner Agent ID.</remarks>
        /// <exception cref="ArgumentException"><paramref name="agentId"/> is invalid.</exception>
        /// <exception cref="ArgumentException"><paramref name="elementId"/> is invalid.</exception>
        public DmsElementId(int agentId, int elementId)
        {
            if ((elementId == -1 && agentId != -1) || agentId < -1)
            {
                string message = String.Format(CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);

                throw new ArgumentException(message, "agentId");
            }

            if ((agentId == -1 && elementId != -1) || elementId < -1)
            {
                string message = String.Format(CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", elementId);

                throw new ArgumentException(message, "elementId");
            }

            this.elementId = elementId;
            this.agentId = agentId;
        }

        /// <summary>
        /// Gets the DataMiner Agent ID.
        /// </summary>
        /// <remarks>The DataMiner Agent ID is the ID of the DataMiner Agent this element has been created on.</remarks>
        public int AgentId
        {
            get
            {
                return agentId;
            }
			private set
			{
				// setter for serialization.
				agentId = value;
			}
        }

        /// <summary>
        /// Gets the element ID.
        /// </summary>
        public int ElementId
        {
            get
            {
                return elementId;
			}
			private set
			{
				// setter for serialization.
				elementId = value;
			}
		}

		/// <summary>
		/// Gets the DataMiner Agent ID/element ID string representation.
		/// </summary>
		[JsonIgnore]
		public string Value
        {
            get
            {
                return agentId + "/" + elementId;
            }
        }

        /// <summary>
        /// Determines whether the two specified objects are not equal.
        /// </summary>
        /// <param name="id1">The first object to compare.</param>
        /// <param name="id2">The second object to compare.</param>
        /// <returns><c>false</c> if the operands are equal; otherwise, <c>true</c>.</returns>
        public static bool operator !=(DmsElementId id1, DmsElementId id2)
        {
            return !id1.Equals(id2);
        }

        /// <summary>
        /// Determines whether the two specified objects are equal.
        /// </summary>
        /// <param name="id1">The first value to compare.</param>
        /// <param name="id2">The second value to compare.</param>
        /// <returns><c>true</c> if the operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DmsElementId id1, DmsElementId id2)
        {
            return id1.Equals(id2);
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsElementId"/> value is less than another specified <see cref="DmsElementId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is less than <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <(DmsElementId id1, DmsElementId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId < id2.agentId : id1.elementId < id2.elementId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsElementId"/> value is less than or equal to another specified <see cref="DmsElementId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is less than or equal to <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <=(DmsElementId id1, DmsElementId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId <= id2.agentId : id1.elementId <= id2.elementId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsElementId"/> value is greater than another specified <see cref="DmsElementId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is greater than <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >(DmsElementId id1, DmsElementId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId > id2.agentId : id1.elementId > id2.elementId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsElementId"/> value is greater than or equal to another specified <see cref="DmsElementId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is greater than or equal to <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >=(DmsElementId id1, DmsElementId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId >= id2.agentId : id1.elementId >= id2.elementId;
        }

		/// <summary>
		/// Compares two specified <see cref="DmsElementId"/> instances and returns an integer that indicates their relative position in the sort order.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns>A 32-bit signed integer that indicates the relationship between the two comparands.</returns>
		public static int Compare(DmsElementId id1, DmsElementId id2)
        {
            int result = id1.AgentId.CompareTo(id2.AgentId);

            if (result == 0)
            {
                result = id1.ElementId.CompareTo(id2.ElementId);
            }

            return result;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the
        /// current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        /// The return value has these meanings: Less than zero means this instance precedes <paramref name="other"/> in the sort order.
        /// Zero means this instance occurs in the same position in the sort order as <paramref name="other"/>.
        /// Greater than zero means this instance follows <paramref name="other"/> in the sort order.</returns>
        /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, element ID.</remarks>
        public int CompareTo(DmsElementId other)
        {
            int result = agentId.CompareTo(other.AgentId);

            if (result == 0)
            {
                result = elementId.CompareTo(other.ElementId);
            }

            return result;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Less than zero means this instance precedes <paramref name="obj"/> in the sort order. Zero means this instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero means this instance follows <paramref name="obj"/> in the sort order.</returns>
        /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, element ID.</remarks>
        /// <exception cref="ArgumentException">The obj is not of type <see cref="DmsElementId"/></exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is DmsElementId))
            {
                throw new ArgumentException("The provided object must be of type DmsElementId.", "obj");
            }

            return CompareTo((DmsElementId)obj);
        }

        /// <summary>
        /// Compares the object to another object.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DmsElementId))
            {
                return false;
            }

            return Equals((DmsElementId)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(DmsElementId other)
        {
            if (elementId == other.elementId && agentId == other.agentId)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return elementId ^ agentId;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "agent ID: {0}, element ID: {1}", agentId, elementId);
        }

		/// <summary>
		/// Returns a value determining whether the agent ID is valid.
		/// </summary>
		/// <returns><c>true</c> if the agent ID is valid; otherwise, <c>false</c>.</returns>
		private bool IsValidAgentId()
		{
			bool isValid = true;

			if ((elementId == -1 && agentId != -1) || agentId < -1)
			{
				isValid = false;
			}

			return isValid;
		}

		/// <summary>
		/// Returns a value determining whether the element ID is valid.
		/// </summary>
		/// <returns><c>true</c> if the element ID is valid; otherwise, <c>false</c>.</returns>
		private bool IsValidElementId()
		{
			bool isValid = true;

			if ((agentId == -1 && elementId != -1) || elementId < -1)
			{
				isValid = false;
			}

			return isValid;
		}
	}
}