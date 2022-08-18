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
	public struct DmsServiceId : IEquatable<DmsServiceId>, IComparable, IComparable<DmsServiceId>
    {
        /// <summary>
        /// The DataMiner Agent ID.
        /// </summary>
        private int agentId;

        /// <summary>
        /// The service ID.
        /// </summary>
        private int serviceId;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DmsServiceId"/> structure using the specified string.
		/// </summary>
		/// <param name="id">String representing the system-wide service ID.</param>
		/// <remarks>The provided string must be formatted as follows: "DataMiner Agent ID/service ID (e.g. 400/201)".</remarks>
		/// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/> .</exception>
		/// <exception cref="ArgumentException"><paramref name="id"/> is the empty string ("") or white space.</exception>
		/// <exception cref="ArgumentException">The ID does not match the mandatory format.</exception>
		/// <exception cref="ArgumentException">The DataMiner Agent ID is not an integer.</exception>
		/// <exception cref="ArgumentException">The service ID is not an integer.</exception>
		/// <exception cref="ArgumentException">Invalid DataMiner Agent ID.</exception>
		/// <exception cref="ArgumentException">Invalid service ID.</exception>
		public DmsServiceId(string id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (String.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException("The provided ID must not be empty.", "id");
			}

			string[] identifierParts = id.Split('/');

			if (identifierParts.Length != 2)
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid ID. Value: {0}. The string must be formatted as follows: \"agent ID/service ID\".", id);

				throw new ArgumentException(message, "id");
			}

			if (!Int32.TryParse(identifierParts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out agentId))
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid DataMiner agent ID. \"{0}\" is not an integer value", id);

				throw new ArgumentException(message, "id");
			}

			if (!Int32.TryParse(identifierParts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out serviceId))
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid Service ID. \"{0}\" is not an integer value", id);

				throw new ArgumentException(message, "id");
			}

			if (!IsValidAgentId())
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);

				throw new ArgumentException(message, "id");
			}

			if (!IsValidServiceId())
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", serviceId);

				throw new ArgumentException(message, "id");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DmsServiceId" /> structure using the specified service ID and DataMiner Agent ID.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="serviceId">The service ID.</param>
		/// <remarks>The hosting DataMiner Agent ID value will be set to the same value as the specified DataMiner Agent ID.</remarks>
		/// <exception cref="ArgumentException"><paramref name="agentId"/> is invalid.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceId"/> is invalid.</exception>
		public DmsServiceId(int agentId, int serviceId)
        {
			this.serviceId = serviceId;
			this.agentId = agentId;

			if (!IsValidAgentId())
            {
                string message = String.Format(CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);

                throw new ArgumentException(message, "agentId");
            }

            if (!IsValidServiceId())
            {
                string message = String.Format(CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", serviceId);

                throw new ArgumentException(message, "serviceId");
            }
        }

        /// <summary>
        /// Gets the DataMiner Agent ID.
        /// </summary>
        /// <remarks>The DataMiner Agent ID is the ID of the DataMiner Agent this service has been created on.</remarks>
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
        /// Gets the service ID.
        /// </summary>
        public int ServiceId
        {
            get
            {
                return serviceId;
			}

			private set
			{
				// setter for serialization.
				serviceId = value;
			}
		}

		/// <summary>
		/// Gets the DataMiner Agent ID/service ID string representation.
		/// </summary>
		[JsonIgnore]
		public string Value
        {
            get
            {
                return agentId + "/" + serviceId;
            }
        }

        /// <summary>
        /// Determines whether the two specified objects are not equal.
        /// </summary>
        /// <param name="id1">The first object to compare.</param>
        /// <param name="id2">The second object to compare.</param>
        /// <returns><c>false</c> if the operands are equal; otherwise, <c>true</c>.</returns>
        public static bool operator !=(DmsServiceId id1, DmsServiceId id2)
        {
            return !id1.Equals(id2);
        }

        /// <summary>
        /// Determines whether the two specified objects are equal.
        /// </summary>
        /// <param name="id1">The first value to compare.</param>
        /// <param name="id2">The second value to compare.</param>
        /// <returns><c>true</c> if the operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DmsServiceId id1, DmsServiceId id2)
        {
            return id1.Equals(id2);
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsServiceId"/> value is less than another specified <see cref="DmsServiceId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is less than <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <(DmsServiceId id1, DmsServiceId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId < id2.agentId : id1.serviceId < id2.serviceId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsServiceId"/> value is less than or equal to another specified <see cref="DmsServiceId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is less than or equal to <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator <=(DmsServiceId id1, DmsServiceId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId <= id2.agentId : id1.serviceId <= id2.serviceId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsServiceId"/> value is greater than another specified <see cref="DmsServiceId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is greater than <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >(DmsServiceId id1, DmsServiceId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId > id2.agentId : id1.serviceId > id2.serviceId;
        }

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="DmsServiceId"/> value is greater than or equal to another specified <see cref="DmsServiceId"/> value.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns><c>true</c> if <paramref name="id1"/> is greater than or equal to <paramref name="id2"/>; otherwise, <c>false</c>.</returns>
		public static bool operator >=(DmsServiceId id1, DmsServiceId id2)
        {
            return (id1.agentId != id2.agentId) ? id1.agentId >= id2.agentId : id1.serviceId >= id2.serviceId;
        }

		/// <summary>
		/// Compares two specified <see cref="DmsServiceId"/> instances and returns an integer that indicates their relative position in the sort order.
		/// </summary>
		/// <param name="id1">The first value to compare.</param>
		/// <param name="id2">The second value to compare.</param>
		/// <returns>A 32-bit signed integer that indicates the relationship between the two comparands.</returns>
		public static int Compare(DmsServiceId id1, DmsServiceId id2)
        {
            int result = id1.AgentId.CompareTo(id2.AgentId);

            if (result == 0)
            {
                result = id1.ServiceId.CompareTo(id2.ServiceId);
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
        /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, service ID.</remarks>
        public int CompareTo(DmsServiceId other)
        {
            int result = agentId.CompareTo(other.AgentId);

            if (result == 0)
            {
                result = serviceId.CompareTo(other.ServiceId);
            }

            return result;
        }

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Less than zero means this instance precedes <paramref name="obj"/> in the sort order. Zero means this instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero means this instance follows <paramref name="obj"/> in the sort order.</returns>
		/// <remarks>The order of the comparison is as follows: DataMiner Agent ID, service ID.</remarks>
		/// <exception cref="ArgumentException">The obj is not of type <see cref="DmsServiceId"/></exception>
		public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is DmsServiceId))
            {
                throw new ArgumentException("The provided object must be of type DmsServiceId.", "obj");
            }

            return CompareTo((DmsServiceId)obj);
        }

        /// <summary>
        /// Compares the object to another object.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DmsServiceId))
            {
                return false;
            }

            return Equals((DmsServiceId)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the services are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(DmsServiceId other)
        {
            if (serviceId == other.serviceId && agentId == other.agentId)
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
            return serviceId ^ agentId;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "agent ID: {0}, service ID: {1}", agentId, serviceId);
        }

		/// <summary>
		/// Returns a value determining whether the agent ID is valid.
		/// </summary>
		/// <returns><c>true</c> if the agent ID is valid; otherwise, <c>false</c>.</returns>
		private bool IsValidAgentId()
		{
			bool isValid = true;

			if ((serviceId == -1 && agentId != -1) || agentId < -1)
			{
				isValid = false;
			}

			return isValid;
		}

		/// <summary>
		/// Returns a value determining whether the element ID is valid.
		/// </summary>
		/// <returns><c>true</c> if the element ID is valid; otherwise, <c>false</c>.</returns>
		private bool IsValidServiceId()
		{
			bool isValid = true;

			if ((agentId == -1 && serviceId != -1) || serviceId < -1)
			{
				isValid = false;
			}

			return isValid;
		}
	}
}