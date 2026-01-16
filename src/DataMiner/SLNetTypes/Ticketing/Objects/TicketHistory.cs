using System;
using System.Collections;
using System.Collections.Generic;

using Newtonsoft.Json;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;

namespace Skyline.DataMiner.Net.Ticketing.Objects
{
	/// <summary>
	/// Represents the history of a specific ticket. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    //[ProtoBufIgnoreListHandling]
    public class TicketHistory : IManagerIdentifiableObject<TicketID>, IManagerIdentifiableObject<Guid>, IEnumerable<KeyValuePair<TicketHistory.HistoryKey, HashSet<TicketHistory.ChangedProperty>>>, CustomDataType, ITrackLastModified
    {
		Guid IManagerIdentifiableObject<Guid>.ID => default(Guid);

		/// <summary>
		/// The group separator.
		/// </summary>
		public const char GroupSeparator = ((char)29);

		/// <summary>
		/// Represents a key to uniquely identify a ticket history entry. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
		/// </summary>
		[Serializable]
        [JsonObject(MemberSerialization.OptIn)]
        public class HistoryKey : IComparable, IComparable<HistoryKey>
        {
			#region Properties & Fields
			/// <summary>
			/// Gets or sets the version number.
			/// </summary>
			/// <value>The version number.</value>
			[JsonProperty]
            public int Version { get; set; }

			/// <summary>
			/// Gets or sets the time stamp.
			/// </summary>
			/// <value>The time stamp.</value>
			public DateTime Time
            {
				get; set;
            }

			/// <summary>
			/// The username.
			/// </summary>
			[JsonProperty]
            public string User;
			#endregion

			/// <summary>
			/// Initializes a new instance of the <see cref="HistoryKey"/> class.
			/// </summary>
			public HistoryKey()
            {
            }

			/// <summary>
			/// Creates a <see cref="HistoryKey"/> instance from the specified string.
			/// </summary>
			/// <param name="encodedKey">The encoded history key.</param>
			/// <returns>The <see cref="HistoryKey"/> instance.</returns>
			public static HistoryKey CreateFromString(string encodedKey)
            {
				return null;
			}

			/// <summary>
			/// Determines whether the specified object is equal to the current object.
			/// </summary>
			/// <param name="obj">The object to compare with the current object.</param>
			/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
			/// <remarks>The history is considered equal if the <see cref="Version"/> of the specified history key equals the <see cref="Version"/> of this object.</remarks>
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
			/// <returns>A string that represents the current object.</returns>
			public override string ToString()
            {
 	             return "";
            }

			/// <summary>
			/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
			/// </summary>
			/// <param name="other">An <see cref="HistoryKey"/> instance to compare with this instance.</param>
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
			public int CompareTo(HistoryKey other)
            {
				return 1;
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
			/// <term>Meaning</term>
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
				return 1;
			}
        }

		/// <summary>
		/// Contains the data of a property change in the ticket history. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
		/// </summary>
		[Serializable]
        [JsonObject(MemberSerialization.OptIn)]
        public class ChangedProperty
        {
			/// <summary>
			/// Gets or sets the name.
			/// </summary>
			/// <value>The name.</value>
			[JsonProperty]
            public string Name { get; set; }

			/// <summary>
			/// Gets a value indicating whether the change relates to a custom field.
			/// </summary>
			/// <value><c>true</c> if the change relates to a custom field; otherwise, <c>false</c>.</value>
			public bool IsCustomField
            {
				get;
            }

			/// <summary>
			/// Gets or sets the value.
			/// </summary>
			/// <value>The value.</value>
			[JsonProperty]
            public object Value { get; set; }

			/// <summary>
			/// Gets or sets the type of change.
			/// </summary>
			/// <value>The type of change.</value>
			[JsonProperty]
			public PropertyChangedEnum PropertyChanged { get; set; }

			/// <summary>
			/// Initializes a new instance of the <see cref="ChangedProperty"/> class.
			/// </summary>
			public ChangedProperty()
            {
            }

			/// <summary>
			/// Initializes a new instance of the <see cref="ChangedProperty"/> class using the specified name, value and optionally the type of change.
			/// </summary>
			/// <param name="name">The name.</param>
			/// <param name="value">The value.</param>
			/// <param name="propertyChanged">The type of change.</param>
			public ChangedProperty(string name, object value, PropertyChangedEnum propertyChanged = PropertyChangedEnum.Changed)
            {
            }

			/// <summary>
			/// Determines whether the specified object is equal to the current object.
			/// </summary>
			/// <param name="obj">The object to compare with the current object.</param>
			/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
			/// <remarks>
			/// <para>Tickets are considered equal if their name is the same.</para>
			/// </remarks>
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
        }

		/// <summary>
		/// Gets or sets the ID of the ticket to which this history relates.
		/// </summary>
		/// <value>The ID of the ticket to which this history relates.</value>
		[JsonProperty]
        public TicketID ID { get; set; }

        /// <summary>
        /// UID of the ticket for which this History applies
        /// </summary>
        [JsonProperty]
        public Guid UID { get; set; }

		/// <summary>
		/// Gets or sets the ticket history.
		/// </summary>
		/// <value>The ticket history.</value>
		[JsonProperty]
        //[JsonConverter(typeof(HistoryDictionaryCreationConverter))]
        protected SortedDictionary<HistoryKey, HashSet<ChangedProperty>> History { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketHistory"/> class.
		/// </summary>
		public TicketHistory()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketHistory"/> class using the specified <see cref="TicketID"/>.
		/// </summary>
		/// <param name="id">The ticket ID.</param>
		public TicketHistory(TicketID id) : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketHistory"/> class using the specified <see cref="TicketID"/> and GUID.
		/// </summary>
		/// <param name="id">The ticket ID to which this <see cref="TicketHistory"/> object relates to.</param>
		/// <param name="uid">The GUID.</param>
		public TicketHistory(TicketID id, Guid uid) : this(id)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketHistory"/> class using the specified <see cref="Ticket"/> and username.
		/// </summary>
		/// <param name="ticket">The ticket to which this <see cref="TicketHistory"/> object relates to.</param>
		/// <param name="userName">The username.</param>
		public TicketHistory(Ticket ticket, string userName) : this(ticket.ID, ticket.UID)
		{
		}

		/// <summary>
		/// Adds a new entry to the ticket history.
		/// </summary>
		/// <param name="user">The username.</param>
		/// <param name="value">The changed properties.</param>
		/// <returns><c>true</c> if the entry was added; otherwise, <c>false</c>.</returns>
		public bool AddHistoryEntry(string user, HashSet<ChangedProperty> value)
		{
			return false;
		}

		/// <summary>
		/// Adds a new entry to the ticket history.
		/// </summary>
		/// <param name="time">The time stamp.</param>
		/// <param name="user">The username.</param>
		/// <param name="value">The changed properties.</param>
		/// <returns><c>true</c> if the entry was added; otherwise, <c>false</c>.</returns>
		public bool AddHistoryEntry(DateTime time, string user, HashSet<ChangedProperty> value)
        {
			return false;
        }

		/// <summary>
		/// Retrieves a value indicating whether the specified ticket history relates to the same ticket.
		/// </summary>
		/// <param name="oneFilter">The ticket history to filter to.</param>
		/// <returns><c>true</c> if the <see cref="ID"/> of <paramref name="oneFilter"/> is equal to the <see cref="ID"/> of this ticket history; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(TicketHistory oneFilter)
        {
            return true;
        }

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<KeyValuePair<HistoryKey, HashSet<ChangedProperty>>> GetEnumerator()
        {
            return null;
        }

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return null;
        }

		/// <summary>
		/// Creates a JSON string representation of this <see cref="TicketHistory"/> object.
		/// </summary>
		/// <returns>The JSON string representation of this <see cref="TicketHistory"/> object.</returns>
		public string ToJson()
        {
			return null;
        }

		/// <summary>
		/// Parses the specified JSON string and creates a <see cref="TicketHistory"/> object.
		/// </summary>
		/// <param name="json">The JSON string from which to create a <see cref="TicketHistory"/>.</param>
		/// <exception cref="DataMinerJsonDeserializationException">Invalid JSON string.</exception>
		/// <returns>The <see cref="TicketHistory"/> object.</returns>
		public static TicketHistory FromJson(string json)
        {
			return null;
		}

        public FilterElement<T> ToFilter<T>()
        {
			return null;
		}

        string[] DataType.ToStringArray()
        {
            throw new NotSupportedException();
        }

        object[] DataType.ToInterOp()
        {
            throw new NotSupportedException();
        }

        DataType DataType.toType(string[] data)
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Specifies the type of change. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
		/// </summary>
		public enum PropertyChangedEnum
		{
			/// <summary>
			/// Added.
			/// </summary>
			Added,
			/// <summary>
			/// Changed.
			/// </summary>
			Changed,
			/// <summary>
			/// Deleted.
			/// </summary>
			Deleted
		}

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count;

        [JsonIgnore]
        public bool FromMigration { get; set; }

		/// <summary>
		/// Gets the data type ID.
		/// </summary>
		/// <value>The data type ID.</value>
        [JsonIgnore]
		public string DataTypeID { get; }

		/// <summary>
		/// Gets or sets the last modification date.
		/// </summary>
		/// <value>The last modification date.</value>
		[JsonProperty("SyncLastModified")]
        public DateTime LastModified { get; set; }
    }

	/// <summary>
	/// Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
    public class TicketHistoryExposers
    {

        public static string TableName = "ctickethistory";

        public static FullTableDefinition<TicketHistory> CreateFullTableDefinition()
        {
			return null;
		}

        public static readonly Exposer<TicketHistory, Guid> UniqueID;

        public static readonly Exposer<TicketHistory, int> DataMinerID;

        public static readonly Exposer<TicketHistory, int> TicketID;

        /// <summary>
        /// Guarantee that all static fields are initialized.
        /// Since C# makes use of the laziest initialization.
        /// </summary>
        public static void Initialize()
        {
        }
    }
}
