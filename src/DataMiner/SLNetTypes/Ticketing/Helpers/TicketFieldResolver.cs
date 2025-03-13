using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;
using Skyline.DataMiner.Net.Ticketing.Helpers.Visualization;
using Skyline.DataMiner.Net.Ticketing.Objects;
using Skyline.DataMiner.Net.Ticketing.Validators;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Resolves fields of a ticket from a DataMiner FieldName to a third-party FieldName and vice versa.
	/// </summary>
	/// <remarks>
	/// <para>The TicketFieldResolver contains a dictionary with all the names of the fields. Therefore, it is not allowed to have multiple <see cref="TicketFieldDescriptor"/> objects in the same <see cref="TicketFieldResolver"/> instance that share the same <see cref="TicketFieldDescriptor.FieldName"/>.</para>
	/// </remarks>
	/// <example>
	/// <para>Creating a default ticket field resolver:</para>
	/// <code>
	/// private TicketFieldResolver CreateDefaultResolver()
	/// {
	///		var resolver = TicketFieldResolver.Factory.CreateDefaultResolver();
	///		
	///		string error;
	///		
	///		var success = Helper.SetTicketFieldResolver(out error, ref resolver);
	///		if(!success)
	///		{
	///			throw new DataMinerException("Something went wrong during setting the TicketFieldResolver: " + error);	
	///		}
	///		
	///		return resolver;
	/// }
	/// </code>
	/// <para>Creating a custom resolver:</para>
	/// <code>
	///	private TicketFieldResolver CreateCustomResolver()
	///	{
	///		TicketFieldResolver resolver = TicketFieldResolver.Factory.CreateEmptyResolver("CustomResolver");
	///		
	///		// Specify the element that will use this ticket field resolver. Leave empty in case the resolver is not used by any element.
	///		resolver.ElementUsingResolver = new Skyline.DataMiner.Net.ElementID(123, 456);
	///		
	///		// The generated empty resolver already contains a "State" field. Remove this in case this is undesired.
	///		var fields = resolver.GetDataMinerFields2ThirdPartyFields();
	///		
	///		foreach(var fields in fields)
	///		{
	///			resolver.RemoveDataMinerField(field.Key);
	///			resolver.RemoveThirdPartyField(field.Value);
	///		}
	///		
	///		// Clear the custom states.
	///		resolver.StateResolver.Clear();
	///		
	///		// Clear the link fields.
	///		resolver.TicketLinkFields.Clear();
	///		
	///		// Add a "Links" field.
	///		resolver.TicketLinkFields.Add("Links");
	///		
	///		// Create a state field.
	///		// First, we create a StateEnum which contains the names and integer values of the states.
	///		StateEnum dmaState = new StateEnum();
	///		dmaState.EnumName = "MyStates";
	///		dmaState.DynamicAdd("Created", 0);
	///		dmaState.DynamicAdd("Started", 1);
	///		dmaState.DynamicAdd("Paused", 2);
	///		dmaState.DynamicAdd("Stopped", 3);
	///		dmaState.DynamicAdd( "Closed", 4);
	///		
	///		// We now link our custom ticket states to a DataMiner <see cref="TicketState"/>.
	///		// I.e. "Created" has value 0 and gets linked to <see cref="TicketState.Open"/>.
	///		resolver.StateResolver.Add(0, TicketState.Open); // Created
	///		resolver.StateResolver.Add(1, TicketState.Open); // Started
	///		resolver.StateResolver.Add(2, TicketState.Open); // Paused
	///		resolver.StateResolver.Add(3, TicketState.Closed); // Stopped
	///		resolver.StateResolver.Add(4, TicketState.Closed); // Closed
	///		
	///		// Now we add a "State" field.
	///		resolver.AddOrUpdateNames(
	///			// Here, we add the descriptor for our "State" field.
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "State",
	///				FieldName = "State",
	///				FieldType = typeof(GenericEnumEntry&lt;int&gt;),
	///				IsThirdParty = false,	// This is a DataMiner ticket field.
	///				IsDataMinerMaster = true,	// When a clash of this field occurs, the value set by DataMiner is used.
	///				Validator = new EnumValidator&lt;int&gt;(DmaState)
	///			},
	///			// And we link the "State" field to a third-party "Status" field.
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Status",
	///				FieldName = "Status",
	///				FieldType = typeof(string),
	///				IsThirdParty = true,	// This is a third-party ticket field.
	///				Validator = new TypeValidator&lt;string&gt;
	///			}
	///		);
	///		
	///		// Add a "User Name" field.
	///		resolver.AddOrUpdateNames(
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "User Name",
	///				FieldName = "User",
	///				FieldType = typeof(string),
	///				IsThirdParty = false,	// This is a DataMiner ticket field.
	///				Validator = new UserValidator() // We know this is a user.
	///			},
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Account Number",
	///				FieldName = "Accnr",
	///				FieldType = typeof(long),
	///				IsThirdParty = true,	// This is a third-party ticket field.
	///				Validator = new TypeValidator&lt;long&gt;	// The third-party system uses an account number instead of a user.
	///			}
	///		);
	///		
	///		// Create an email field.
	///		resolver.AddOrUpdateNames(
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Email Address",
	///				FieldName = "Mail",
	///				FieldType = typeof(string),
	///				IsThirdParty = false,	// This is a DataMiner ticket field.
	///				Validator = new EmailAddressValidator() // We know this has to be an email address.
	///			},
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Internal Address",
	///				FieldName = "Addr",
	///				FieldType = typeof(string),
	///				IsThirdParty = true,	// This is a third-party ticket field.
	///				Validator = new RegexValidator()	// The third-party system uses a string, but we can validate it with a regular expression.
	///				{
	///					RegexOptions = RegexOptions.IgnoreCase | RegexOptions.SingleLine,
	///					RegexPattern = @"\A(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9]!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
	///				}
	///			}
	///		);
	///		
	///		// Add a "Quality" field.
	///		resolver.AddOrUpdateNames(
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Quality",
	///				FieldName = "Quality",
	///				FieldType = typeof(double),
	///				IsThirdParty = false,	// This is a DataMiner ticket field.
	///				Validator = new TypeValidator&lt;double&gt;() // A quality score.
	///			},
	///			new TicketFieldDescriptor()
	///			{
	///				FieldDisplayName = "Score",
	///				FieldName = "Score",
	///				FieldType = typeof(byte),
	///				IsThirdParty = true,	// This is a third-party ticket field.
	///				Validator = new TypeValidator&lt;byte&gt;	// The third-party system uses a byte to store this.
	///			}
	///		);
	///		
	///		// Save our custom ticket field resolver.
	///		string error;
	///		
	///		if(!Helper.SetTicketFieldResolver(out error, ref resolver))
	///		{
	///			throw new DataMinerException("Something went wrong during setting the TicketFieldResolver: " + error")	
	///		}
	///		
	///		return resolver;
	/// }
	/// </code>
	/// </example>
	[Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class TicketFieldResolver : IManagerIdentifiableObject<Guid>, DataType, CustomDataType, ITrackLastModified
    {
		#region Properties & Fields
		/// <summary>
		/// The ticket field resolver factory.
		/// </summary>
		public static readonly TicketFieldResolverFactory Factory;

		/// <summary>
		/// Gets or sets the ticket module.
		/// </summary>
		/// <value>The ticket module.</value>
		[JsonProperty(Required = Required.Default)]
        public TicketModule Module { get; set; }

		/// <summary>
		/// Gets or sets the ID of this resolver.
		/// </summary>
		/// <value>The ID of this resolver.</value>
		//[global::Newtonsoft.Json.JsonPropertyAttribute]
		[JsonProperty]
        public Guid ID { get; set; }

		/// <summary>
		/// Gets or sets the name of this resolver.
		/// </summary>
		/// <value>The name of this resolver.</value>
		[JsonProperty]
        public string Name { get; set; }

        private List<string> _ticketLinkFields;

		/// <summary>
		/// Gets or sets the ticket link fields.
		/// </summary>
		/// <value>The ticket link fields.</value>
		[JsonProperty]
		public List<string> TicketLinkFields
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the ID of the element that uses the resolver.
		/// </summary>
		/// <value>The ID of the element that uses this resolver.</value>
		/// <remarks>
		/// <para>A <see cref="TicketFieldResolver"/> can only be used by one element, but one element can use multiple <see cref="TicketFieldResolver"/> instances.</para>
		/// <para>Without an element attached, the tickets will only be stored on the DataMiner System and will not be synchronized with a third-party system.</para>
		/// </remarks>
		[JsonProperty]
		public ElementID ElementUsingResolver { get; set; }

		/// <summary>
		/// Gets or sets the state resolver.
		/// </summary>
		[JsonProperty]
		public Dictionary<int, TicketState> StateResolver { get; set; }

		/// <summary>
		/// Gets or sets the visualization hints.
		/// </summary>
		/// <value>The visualization hints.</value>
		[JsonProperty]
        public TicketingVisualizationHints VisualizationHints { get; set; }

        [JsonProperty]
        public TicketFieldResolverSettings Settings { get; set; }

		/// <summary>
		/// Gets a value indicating whether this resolver is valid.
		/// </summary>
		/// <value><c>true</c> if this resolver is valid; otherwise, <c>false</c>.</value>
		public bool IsValid
        {
			get;
        }
        #endregion

        #region Construction & Initialization
        /// <summary>
        /// Constructs the Default TicketFieldResolver.
        /// </summary>
        static TicketFieldResolver()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldResolver"/> class.
		/// </summary>
		public TicketFieldResolver()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldResolver"/> class using the specified GUID.
		/// </summary>
		/// <param name="g">The GUID.</param>
		public TicketFieldResolver(Guid g)
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldResolver"/> class using the specified GUID and name.
		/// </summary>
		/// <param name="g">The GUID of the resolver.</param>
		/// <param name="Name">The name of the resolver.</param>
		public TicketFieldResolver(Guid g, string Name)
            : this(g)
        {
        }
		#endregion

		#region Methods
		#region Ticket Field Descriptors
		/// <summary>
		/// Retrieves a dictionary with the DataMiner fields serving as the keys and the third-party fields serving as the values.
		/// </summary>
		/// <returns>A dictionary with the DataMiner fields serving as the keys and the third-party fields serving as the values.</returns>
		public Dictionary<TicketFieldDescriptor, TicketFieldDescriptor> GetDataMinerFields2ThirdPartyFields()
        {
			return null;
		}

		/// <summary>
		/// Retrieves a dictionary with the third-party fields serving as the keys and the DataMiner fields serve as the values.
		/// </summary>
		/// <returns>A dictionary with the third-party fields serving as the keys and the DataMiner fields serve as the values.</returns>
		public Dictionary<TicketFieldDescriptor, TicketFieldDescriptor> GetThirdPartyFields2DataMinerFields()
        {
			return null;
		}

		/// <summary>
		/// Adds or updates this resolver with the specified fields.
		/// </summary>
		/// <param name="DataMinerField">The DataMiner field.</param>
		/// <param name="ThirdPartyField">The third-party ticketing system field.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="DataMinerField"/> is <see langword="null"/>.<br />
		/// -or-<br />
		/// <paramref name="ThirdPartyField"/> is <see langword="null"/>.<br />
		/// </exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="DataMinerField"/> and <paramref name="ThirdPartyField"/> have the same FieldName.
		/// -or-<br/>
		/// The specified <paramref name="DataMinerField"/> object has a FieldName that is already used by an existing ThirdPartyField.<br />
		/// -or-<br/>
		/// The specified <paramref name="ThirdPartyField"/> object has a FieldName that is already used by an existing DataMinerField.<br />
		/// </exception>
		public void AddOrUpdateNames(TicketFieldDescriptor DataMinerField, TicketFieldDescriptor ThirdPartyField)
        {
        }

		/// <summary>
		/// Removes the specified <see cref="TicketFieldDescriptor"/> DataMiner field from the resolver.
		/// </summary>
		/// <param name="field">The DataMiner field.</param>
		public void RemoveDataMinerField(TicketFieldDescriptor field)
        {
        }

		/// <summary>
		/// Removes the specified <see cref="TicketFieldDescriptor"/> third-party field from the resolver.
		/// </summary>
		/// <param name="field">The third-party field.</param>
		public void RemoveThirdPartyField(TicketFieldDescriptor field)
        {
        }

		/// <summary>
		/// Gets the third-party <see cref="TicketFieldDescriptor"/> that corresponds with the specified DataMiner <see cref="TicketFieldDescriptor"/>.
		/// </summary>
		/// <param name="dataMinerField">The DataMiner <see cref="TicketFieldDescriptor"/>.</param>
		/// <returns>The third-party <see cref="TicketFieldDescriptor"/> that corresponds with the specified third-party <see cref="TicketFieldDescriptor"/> or <see langword="null" /> if the corresponding field was not found.</returns>
		public TicketFieldDescriptor GetThirdPartyField(TicketFieldDescriptor dataMinerField)
        {
			return null;
		}

		/// <summary>
		/// Gets the DataMiner <see cref="TicketFieldDescriptor"/> that corresponds with the specified third-party <see cref="TicketFieldDescriptor"/>.
		/// </summary>
		/// <param name="thirdPartyField">The third-party <see cref="TicketFieldDescriptor"/>.</param>
		/// <returns>The DataMiner <see cref="TicketFieldDescriptor"/> that corresponds with the specified third-party <see cref="TicketFieldDescriptor"/> or <see langword="null" /> if the corresponding field was not found.</returns>
		public TicketFieldDescriptor GetDataMinerField(TicketFieldDescriptor thirdPartyField)
        {
			return null;
		}

		/// <summary>
		/// Gets the <see cref="TicketFieldDescriptor"/> with the specified name.
		/// </summary>
		/// <param name="name">The name of the <see cref="TicketFieldDescriptor"/> to retrieve.</param>
		/// <returns>The <see cref="TicketFieldDescriptor"/> with the specified name or <see langword="null"/> if no field with the specified name was found.</returns>
		public TicketFieldDescriptor GetFieldWithName(string name)
        {
            return null;
        }
		#endregion

		/// <summary>
		/// Gets the internal state of the specified ticket.
		/// </summary>
		/// <param name="ticket">The ticket for which the internal state should be retrieved.</param>
		/// <returns>The internal state.</returns>
		public TicketState GetInternalState(Ticket ticket)
		{
            return TicketState.Open;
		}

		/// <summary>
		/// Gets or sets the ticket state field descriptor.
		/// </summary>
		/// <value>The ticket state field descriptor.</value>
		public TicketFieldDescriptor TicketStateFieldDescriptor
		{
			get; set;
		}

        [JsonIgnore]
        public bool FromMigration { get; set; }

		/// <summary>
		/// Gets the data type ID.
		/// </summary>
		/// <value>The data type ID.</value>
		public string DataTypeID => ID.ToString();

		/// <summary>
		/// Gets or sets the last modification time.
		/// </summary>
		/// <value>The last modification time.</value>
		[JsonProperty("SyncLastModified")]
        public DateTime LastModified { get; set; }

		/// <summary>
		/// Returns a value indicating whether the specified <see cref="TicketFieldResolver"/> has the same ID or name as this <see cref="TicketFieldResolver"/> object.
		/// </summary>
		/// <param name="filter">The <see cref="TicketFieldResolver"/> instance.</param>
		/// <returns><c>true</c> if the ID or name of the specified <see cref="TicketFieldResolver"/> matches the ID or name of this <see cref="TicketFieldResolver"/> instance.</returns>
		/// <remarks>
		/// <para>When <see langword="null"/> is specified for <paramref name="filter"/>, <c>true</c> is returned</para>
		/// <para>When <see cref="TicketFieldResolver.ID"/> of <paramref name="filter"/> is set to <see cref="Guid.Empty"/>, <c>true</c> is returned.</para>
		/// </remarks>
		public bool FiltersTo(TicketFieldResolver filter)
        {
            return false;
        }

		#region Json Serialization
		/// <summary>
		/// Retrieves the JSON representation of this <see cref="TicketFieldResolver"/> object.
		/// </summary>
		/// <returns>The JSON representation of this <see cref="TicketFieldResolver"/> object.</returns>
		public string ToJson()
        {
			return "";
		}

		/// <summary>
		/// Creates a <see cref="TicketFieldResolver"/> instance of the specified JSON string.
		/// </summary>
		/// <param name="json">The JSON string representing a JSON serialized <see cref="TicketFieldResolver"/> object.</param>
		/// <returns>The <see cref="TicketFieldResolver"/> instance.</returns>
		public static TicketFieldResolver FromJson(string json)
        {
			return null;
		}
		#endregion
		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return 1;
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
        /// Returns all GenericEnumEntries that represent a state for ticket
        /// that is linked to this TicketFieldResolver. These can be used
        /// to filter on the state field of a Ticket.
        /// </summary>
        /// <returns>An empty list when the <see cref="TicketStateFieldDescriptor"/> is invalid</returns>
        public List<GenericEnumEntry<int>> GetAllTicketStateGenericEnumEntries()
        {
			return null;
		}

        /// <summary>
        /// Returns a list of all GenericEnumEntries that represent the given state.
        /// These can be used to filter on the state field of a Ticket.
        /// </summary>
        /// <returns>An empty list when <see cref="TicketStateFieldDescriptor"/> or <see cref="StateResolver"/> are invalid</returns>
        public List<GenericEnumEntry<int>> GetAllTicketStateGenericEnumEntriesForState(TicketState ticketState)
        {
			return null;
		}

        /// <summary>
        /// Returns a Ticket filter that can be used to retrieve all Tickets linked
        /// to this TicketFieldResolver with the given state. 
        /// </summary>
        /// <returns>
        /// Null when no filter could be build because there are no state
        /// GenericEnumEntries available on this TicketFieldResolver.
        /// </returns>
        public FilterElement<Ticket> GetTicketStateFilter(TicketState ticketState)
        {
			return null;
		}
        #endregion
    }

	public class TicketFieldResolverContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
			return null;
		}
    }

    public class ResolverDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
			return true;
		}

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			return null;
		}

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }

	/// <summary>
	/// Ticket states that are used internally.
	/// </summary>
	/// <remarks>
	/// <para>Depending on whether the linked cause is open or cleared, a <see cref="Ticket"/> can only be:</para>
	/// <list type="bullet">
	///  <item>Open and alarm active</item>
	///  <item>Open and alarm not active (Cause is cleared)</item>
	///  <item>Closed and alarm active</item>
	///  <item>Closed and alarm not active (Cause is cleared)</item>
	/// </list>
	/// </remarks>
	[Serializable]
	public enum TicketState
	{
		/// <summary>
		/// Open.
		/// </summary>
		Open,
		/// <summary>
		/// Closed.
		/// </summary>
		Closed
	}

    public class TicketFieldResolverExposers
    {
        public static string TableName = "";

        public static FullTableDefinition<TicketFieldResolver> CreateFullTableDefinition()
        {
			return null;
		}

        private static void Throw()
        {
        }

        public static readonly Exposer<TicketFieldResolver, Guid> ID;

        public static readonly Exposer<TicketFieldResolver, string> Name;

        public static readonly Exposer<TicketFieldResolver, string> ElementUsingResolver;

        public static readonly Exposer<TicketFieldResolver, List<string>> TicketLinkFields;

        /// <summary>
        /// Guarantee that all static fields are initialized.
        /// Since C# makes use of the laziest initialization.
        /// </summary>
        public static void Initialize()
        {
        }
    }
}