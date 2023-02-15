using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;

using Skyline.DataMiner.Net.Correlation;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;
using Skyline.DataMiner.Net.Ticketing.Helpers;
using Skyline.DataMiner.Net.Ticketing.Objects;
using Skyline.DataMiner.Net.ToolsSpace.Collections;
#if NETFRAMEWORK
using System.Drawing.Design;
#endif

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// Represents a ticket used by the Ticketing Gateway.
	/// </summary>
	/// <example>
	/// <code>
	/// private Ticket CreateTicket(TicketFieldResolver resolver)
	/// {
	///		Ticket ticket = new Ticket();
	///		ticket.CustomFieldResolverID = resolver.ID;
	///		ticket.CustomTicketFields["State"] = new GenericEnumEntry&lt;int&gt;() { Name = "Created", Value = 0 };
	///		ticket.CustomTicketFields["Status"] = "Created";
	///		ticket.CustomTicketFields["User"] = "Geoffrey";
	///		ticket.CustomTicketFields["Accnr"] = (long)789456123;
	///		ticket.CustomTicketFields["Mail"] = "Geoffry@KingsLanding.gov";
	///		ticket.CustomTicketFields["Addr"] = "789456123@internal.gov";
	///		ticket.CustomTicketFields["Quality"] = 0.9;
	///		ticket.CustomTicketFields["Score"] = 0x54;
	///		ticket.Links.Add("Links", new TicketLink[]{ new TicketLink(new Skyline.DataMiner.Net.ElementID(123, 456)) });
	/// 
	///		string error;
	///		if(!Helper.SetTicket(out error, ref ticket))
	///		{
	///			throw new DataMinerException("Something went wrong while creating the ticket: " + error);
	///		}
	///		
	///		return ticket;
	/// }
	/// </code>
	/// <para>The code snippet shown in the example uses hard-coded values for the ticket fields. In real implementations, these values will be known either by user input or by polling the third-party ticketing system.</para>
	/// </example>
	[Serializable]
#if NETFRAMEWORK
    [Editor(typeof(TicketTypeEditor), typeof(UITypeEditor))]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    //[ProtoBufSurrogate(typeof(ProtoBufSurrogateTicket))]
    public class Ticket : IEquatable<Ticket>, INotifyPropertyChanged, IManagerIdentifiableObject<TicketID>, IManagerIdentifiableObject<Guid>, IManagerFilterableObject<Ticket>, DataType, ICloneable, CustomDataType, ITrackLastModified
    {
#region Properties, Fields & Events
        /// <summary>
        /// The event that is triggered when a property of the Ticket object changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Gets or sets the module to which a ticket belongs.
		/// </summary>
		/// <value>The module to which a ticket belongs.</value>
		/// <remarks>Depending on this module type, different licenses will be checked.</remarks>
		[JsonProperty]
        public TicketModule Module { get; set; }

		/// <summary>
		/// Gets the creation time of this ticket.
		/// </summary>
		/// <valeu>The creation time of this ticket.</valeu>
		[Description("DateTime at which the ticket was created.")]
        public DateTime CreationDate;

		/// <summary>
		/// Gets a string representation of the ticket ID of this ticket.
		/// </summary>
		/// <value>The string representation of this ticket.</value>
		/// <remarks>
		/// <para>The string is formatted as follows: Ticket-[ID.DataMinerID]-[ID.TID].</para>
		/// </remarks>
		public string DataTypeID => $"Ticket-{UID}";

		/// <summary>
		/// Gets or sets the unique identifier of this ticket.
		/// </summary>
		/// <value>The unique identifier of this ticket.</value>
		[Description("Legacy Identifier of the Ticket")]
        [JsonProperty]
        public TicketID ID
        {
			get; set;
        }

        /// <summary>
        /// This is the unique identifier of the ticket.
        /// </summary>
        [Description("Unique Identifier of the Ticket")]
        [JsonProperty]
        public Guid UID { get; set; }

		/// <summary>
		/// Gets or sets the ID of the <see cref="TicketFieldResolver"/> associated with this ticket.
		/// </summary>
		/// <value>The ID of the <see cref="TicketFieldResolver"/> associated with this ticket.</value>
		[Description("ID of the TicketFieldResolver associated with this ticket.")]
        [JsonProperty]
        public Guid CustomFieldResolverID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the custom ticket fields of this ticket.
		/// </summary>
		/// <value>The custom ticket fields of this ticket.</value>
		[Description("Contains the TicketFields of this ticket.")]
        [JsonProperty]
        public IDictionary<string, object> CustomTicketFields
        {
			get; set;
        }

		/// <summary>
		/// Gets a value indicating whether this object was stitched.
		/// </summary>
		/// <value><c>true</c> if stitched; otherwise, <c>false</c>.</value>
        public bool WasStitched;
#endregion

#region Construction
        static Ticket()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Ticket"/> class.
		/// </summary>
		/// <remarks>Constructs a ticket with default values.</remarks>
		public Ticket()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Ticket"/> class using the specified ticket ID.
		/// </summary>
		/// <param name="id">The ticket ID.</param>
		public Ticket(TicketID id) : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Ticket"/> class using the specified ticket GUID.
		/// </summary>
		/// <param name="uid">The ticket GUID.</param>
		public Ticket(Guid uid) : this()
        {
        }
		#endregion

		#region Methods
		/// <summary>
		/// Compares this ticket to another ticket and returns a set of all the properties that are different.
		/// </summary>
		/// <param name="other">The ticket to compare with.</param>
		/// <returns>All the properties that differ between this ticket and the specified ticket.</returns>
		/// <remarks>
		/// <para>We consider the "other" ticket to be more up to date than this ticket.</para>
		/// </remarks>
		public HashSet<TicketHistory.ChangedProperty> GetChangedProperties(Ticket other)
        {
			return null;
		}

		/// <summary>
		/// Gets the <see cref="TicketField"/> with specified name.
		/// </summary>
		/// <param name="FieldName">The name of the field.</param>
		/// <returns>The <see cref="TicketField" /> with the specified name or <see langword="null" /> if no field with the specified name was found.</returns>
		public object GetTicketField(string FieldName)
        {
			return null;
		}

		/// <summary>
		/// Gets the fields of this ticket.
		/// </summary>
		/// <returns>The fields of this ticket.</returns>
		public IDictionary<string, object> GetTicketFields()
        {
			return null;
		}

		/// <summary>
		/// Gets the links of this ticket.
		/// </summary>
		/// <returns>The links of this ticket.</returns>
		public IDictionary<string, List<TicketLink>> GetTicketLinks()
        {
			return null;
        }

		/// <summary>
		/// Adds the specified ticket link to the links set with the specified key.
		/// </summary>
		/// <param name="Key">The key of the links set.</param>
		/// <param name="link">The link to add.</param>
		/// <returns><c>true</c> if the specified link was added; otherwise, <c>false</c>.</returns>
		/// <remarks>In case the link for the specified key was already present, <c>false</c> is returned.</remarks>
		public bool AddTicketLink(string Key, TicketLink link)
        {
            return true;
        }

		/// <summary>
		/// Removes the specified ticket link.
		/// </summary>
		/// <param name="Key">The key of the links set.</param>
		/// <param name="link">The link to remove.</param>
		public void RemoveTicketLink(string Key, TicketLink link)
        {
        }

        /// <summary>
        /// If you are a client. Don't use this!
        /// </summary>
        /// <param name="CreationDate"></param>
        /// <remarks>Don't use this.</remarks>
        public void SetCreationDate(DateTime CreationDate)
        {
        }

		/// <summary>
		/// Gets the links of this ticket in JSON format.
		/// </summary>
		/// <returns>The links of this ticket in JSON format.</returns>
		public List<string> GetTicketLinksJson()
        {
			return null;
		}

		/// <summary>
		/// Gets the file-friendly links of this ticket in JSON format.
		/// </summary>
		/// <returns>The file-friendly links of this ticket in JSON format.</returns>
		public List<string> GetFileFriendlyTicketLinks()
        {
			return null;
		}
#endregion

#region Event Handling
        protected void RaiseEvent<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
        }

        protected void RaiseEventAsync<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
        }

        protected void RaiseEvent(PropertyChangedEventHandler handler, PropertyChangedEventArgs args)
        {
        }

        protected void RaiseEventAsync(PropertyChangedEventHandler handler, PropertyChangedEventArgs args)
        {
        }
		#endregion

		#region Interface implementations
		/// <summary>
		///  Determines whether the specified <see cref="Ticket"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Tickets are considered equal if their ID is the same.</para>
		/// </remarks>
		public bool Equals(Ticket other)
        {
			return true;
        }

		/// <summary>
		/// Checks if this object qualifies for the specified filter.
		/// </summary>
		/// <param name="obj">Object used as filter.</param>
		/// <returns><c>true</c> if this ticket matches the specified filter; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Currently, <see cref="CustomTicketFields" /> is not filtered on.</para>
		/// <para>This ticket matches the specified filter in case the filter is <see langword="null"/> or the filter ticket ID either equals the ID of this ticket or is <see langword="null"/>.</para>
		/// </remarks>
		public bool FiltersTo(Ticket obj)
        {
			return true;
        }
		#endregion

		#region Serialization magic
		/// <summary>
		/// Converts this ticket to a JSON string.
		/// </summary>
		/// <returns>The JSON representation of this ticket.</returns>
		public string ToJson()
        {
			return "";
        }

		/// <summary>
		/// Parses the specified JSON string and creates a <see cref="Ticket"/> object.
		/// </summary>
		/// <param name="json">The JSON string from which to create a <see cref="Ticket"/>.</param>
		/// <exception cref="DataMinerJsonDeserializationException">Invalid JSON string.</exception>
		/// <returns>The <see cref="Ticket"/> object.</returns>
		public static Ticket FromJson(string json)
        {
			return null;
		}
#endregion

#region Indexed Serialization magic
        /// <summary>
        /// Converts this Ticket to a JSON string
        /// </summary>
        /// <returns>The JSON string</returns>
        public string ToIndexedJson()
        {
			return "";
        }

		/// <summary>
		/// Converts a JSON string to a Ticket object.
		/// </summary>
		/// <param name="json">The JSON string to parse to <see cref="Ticket"/> instance.</param>
		/// <returns>Ticket object parsed from the JSON string.</returns>
		public static Ticket FromIndexedJson(string json)
        {
			return null;
		}
#endregion

#region DataType
        [JsonIgnore]
        public bool FromMigration { get; set; }

        [JsonProperty("SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

		Guid IManagerIdentifiableObject<Guid>.ID => UID;

		public DataType toType(string[] data)
		{
			return null;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Tickets are considered equal if their ID is the same.</para>
		/// </remarks>
		public override bool Equals(object obj)
		{
            // If parameter is null or cannot be cast to Data return false
            return true;
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
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
            return 0;
		}

		/// <summary>
		/// Converts this ticket to a string array.
		/// </summary>
		/// <returns>The string array.</returns>
		/// <remarks>
		/// <para>The string array has tree items and is structured as follows:</para>
		/// <list type="bullet">
		/// <item><description>[0]: DataMiner Agent ID.</description></item>
		/// <item><description>[1]: Ticket ID</description></item>
		/// <item><description>[2]: JSON representation of the ticket.</description></item>
		/// </list>
		/// </remarks>
		public string[] ToStringArray()
		{
			return null;
		}

		public object[] ToInterOp()
		{
			return null;
		}

		/// <summary>
		/// Returns a new <see cref="FilterElement{T}"/> instance based on this ticket.
		/// </summary>
		/// <typeparam name="T">The type to which the resulting filter element should be cast.</typeparam>
		/// <returns>The filter element base on this ticket.</returns>
		/// <remarks>
		/// <para>This method creates a new <see cref="FilterElement{T}"/> instance based on the DataMiner Agent ID and ticket ID of this ticket and casts it to the specified type.</para>
		/// </remarks>
		public FilterElement<T> ToFilter<T>()
        {
			return null;
		}

		#endregion

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Returns a <see cref="JSONSerializableDictionary"/> instance with the custom ticket fields.
		/// </summary>
		/// <returns>A <see cref="JSONSerializableDictionary"/> instance with the custom ticket fields.</returns>
		public JSONSerializableDictionary TicketFieldAsCustomSerializableJson()
        {
			return null;
		}

		/// <summary>
		/// Merges the alarm properties from the AlarmEventMessage in the ticket fields when the TicketFieldResolver defines an AlarmFilterField.
		/// </summary>
		/// <param name="baseTicket">To be merged ticket.</param>
		/// <param name="resolver">Resolver that defines the ticket fields.</param>
		/// <param name="alarm">AlarmEventMessage that contains all alarm data.</param>
		/// <returns>Merged ticket.</returns>
		/// <exception cref="FailedParseAlarmPropertyException">Failed parsing alarm property.</exception>
		/// <exception cref="AlarmPropertyNameDoesNotExistException">An exposer with the specified name does not exist.</exception>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (21202).</remarks>
		/// <example>
		/// <code>
		/// Ticket newTicket = Ticket.MergeWithAlarmProperties(new Ticket(), ticketFieldResolver, alarm);
		/// </code>
		/// </example>
		public static Ticket MergeWithAlarmProperties(Ticket baseTicket, TicketFieldResolver resolver, AlarmEventMessage alarm)
        {
			return null;
		}

		/// <summary>
		/// Merges the alarm properties and default values in the ticket fields as defined in the override fields.
		/// </summary>
		/// <param name="baseTicket">To be merged Ticket.</param>
		/// <param name="overrideFields">Override fields that define the ticket fields.</param>
		/// <param name="resolver">Resolver that is linked to the ticket.</param>
		/// <param name="alarm">AlarmEventMessage that contains all alarm data.</param>
		/// <returns>Merged Ticket.</returns>
		/// <exception cref="FailedParseAlarmPropertyException">Failed parsing alarm property.</exception>
		/// <exception cref="AlarmPropertyNameDoesNotExistException">An exposer with the specified name does not exist.</exception>
		/// <exception cref="TicketFieldDoesNotExistException">One of the override fields define a ticket field that is not  in the resolver.</exception>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (21202).</remarks>
		public static Ticket MergeWithOverrideProperties(Ticket baseTicket, List<TicketFieldOverrideConfig> overrideFields, TicketFieldResolver resolver, AlarmEventMessage alarm )
        {
			return null;
		}

		/// <summary>
		/// Stitches this ticket with the specified ticket provider.
		/// </summary>
		/// <param name="ticketProvider">The ticket provider.</param>
        public void Stitch(Func<Guid, TicketFieldResolver> ticketProvider)
        {
        }

        /// <summary>
        /// Returns the TicketFieldResolver when the Ticket has been stitched
        /// </summary>
        public TicketFieldResolver GetTicketFieldResolver()
        {
			return null;
		}
    }

#if NETFRAMEWORK
    public class TicketTypeEditor : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return 0;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return null;
        }
    }
#endif
	/// <summary>
	/// Defines ticketing exposers.
	/// </summary>
	/// <example>
	/// <para>Retrieving tickets by ticket field resolver:</para>
	/// <code>
	/// public Ticket[] RetrieveTicketByResolverID(TicketFieldResolver resolver)
	/// {
	/// 	var outputTickets = helper.GetTickets(filter: TicketingExposers.ResolverID.Equal(resolver.ID));
	///
	/// 	return outputTickets.ToArray();
	///	}
	/// </code>
	/// </example>
	public class TicketingExposers
    {
		/// <summary>
		/// The table name.
		/// </summary>
        public static string TableName = "";

		/// <summary>
		/// Creates the full table definition.
		/// </summary>
		/// <returns>The full table definition.</returns>
        public static FullTableDefinition<Ticket> CreateFullTableDefinition()
        {
			return null;
		}

		/// <summary>
		/// Exposes the <see cref="TicketID.DataMinerID"/> property of the <see cref="Ticket.ID"/> of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, int> DataMinerID;

		/// <summary>
		/// Exposes the <see cref="TicketID.TID"/> property of the <see cref="Ticket.ID"/> of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, int> TicketID;

		/// <summary>
		/// Exposes the full ID of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, string> FullID;

		/// <summary>
		/// Exposes the unique ID of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, Guid> UniqueID;

		/// <summary>
		/// Exposes the <see cref="Ticket.ToJson"/> method of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, string> Ticket;

		/// <summary>
		/// Exposes the <see cref="Ticket.CustomFieldResolverID"/> property of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, Guid> ResolverID;

		/// <summary>
		/// Exposes the <see cref="Ticket.CreationDate"/> property of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, DateTime> CreationDate;

		/// <summary>
		/// Exposes the <see cref="Ticket.Module"/> property of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, int> Module;

		/// <summary>
		/// Exposes the <see cref="Ticket.CustomTicketFields"/> property of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, IDictionary<string, dynamic>> CustomTicketFields;

		/// <summary>
		/// Exposes the file friendly ticket links of a <see cref="Ticket"/> instance.
		/// </summary>
		public static readonly Exposer<Ticket, List<string>> TicketLinks;

        /// <summary>
        /// Guarantee that all static fields are initialized.
        /// Since C# makes use of the laziest initialization.
        /// </summary>
        public static void Initialize()
        {
        }
    }

    public enum TicketsByTimeEnum
	{
		DMAID,
		TID,
		TimeStamp,
		Ticket
	}

	public enum TicketLinkerEnum
	{
		DMAID,
		TID,
		Type,
		Key
	}
}