using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using Skyline.DataMiner.Net.Apps.Utils;
using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.IManager.Messages;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Ticketing.Helpers;
using Skyline.DataMiner.Net.Ticketing.Objects;
using Skyline.DataMiner.Net.Tickets;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// Helper class for the Ticketing Gateway.
	/// </summary>
	/// <remarks>
	/// <para>This is the access point to the Ticketing Gateway. It provides an easy interface to communicate with the Ticketing Gateway.</para>
	/// <para>TicketingGatewayHelper does not keep a cache of tickets or resolvers. If client-side caching is required, it must be implemented by the client.The TicketingGateway running on the server does keep a cache, however. Its cache consists of all the open tickets.</para>
	/// </remarks>
	/// <example>
	/// <code>
	/// class Script
	/// {
	///		private TicketingGatewayHelper helper;
	///		private Connection connection;
	///		
	///		Script()
	///		{
	///			// Connect to SLNet. Protocols and automation scripts do not need this.
	///			connection = ConnectionSettings.GetConnection("localhost");
	///			connection.Authenticate();
	///
	///			helper = new TicketingGatewayHelper();
	///			helper.HandleEventsAsync = false; // Most client applications will prefer blocking calls for event handling. If this is the case, set this property to false.
	///			helper.RequestResponseEvent += HelperRequestResponseEvent;
	///
	///			// Attaching the following event handlers is optional.
	///			helper.LoggingEvent += HelperLoggingEvent;
	///			helper.TicketChangedEvent += HelperTicketChangedEvent;
	///			helper.TicketFieldResolverChangedEvent += HelperTicketFieldResolverChangedEvent;
	///		}
	///
	///		private void HelperRequestResponseEvent(object sender, IManagerRequestResponseEventArgs e)
	///		{
	///			e.responseMessage = connection.HandleSingleResponseMessage(e.responseMessage);
	///		}
	///
	///		private void HelperLoggingEvent(object sender, IManagerErrorEventArgs e)
	///		{
	///			// ...
	///		}
	///
	///		private void HelperTicketChangedEvent(object sender, TicketChangedEventArgs e)
	///		{
	///			var changedTicket = e.ChangedTicket;    // The changed ticket.
	///			var changedHistory = e.ChangedHistory;  // The history entry that changed.
	///			bool isDeleted = e.isDelete;    // Delete or add/update?
	///		}
	///
	///		private void HelperTicketFieldResolverChangedEvent(object sender, TicketFieldResolverChangedEventArgs e)
	///		{
	///			var changedResolver = e.ChangedResolver; // The changed resolver.
	///			bool isDeleted = e.isDelete; // Delete or add/update?
	///		}
	///	}
	/// </code>
	/// </example>
	[Serializable]
    public class TicketingGatewayHelper : IManagerHelper<Guid>
    {
		#region Properties, Fields & events

		/// <summary>
		/// Gets a value indicating whether Ticketing is licensed.
		/// </summary>
		/// <value><c>true</c> if Ticketing is licensed; otherwise, <c>false</c>.</value>
		public bool IsLicensed
        {
			get;
        }

		/// <summary>
		/// Occurs when the Helper wants to send a message to the server.
		/// </summary>
		/// <remarks>
		/// <para>Obsolete. Use <see cref="RequestResponseEvent" /> instead.</para>
		/// </remarks>
		[Obsolete("Use RequestResponseEvent instead. Will be removed in the future.", true)]
        [field: NonSerialized]
        public event EventHandler<TicketingGatewayEventArgs> SendEvent;

		/// <summary>
		/// Occurs when the Helper wants to send a message to the server and expects a response.
		/// </summary>
		[field: NonSerialized]
        public event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent;

		/// <summary>
		/// Occurs when an error or notification should get logged.
		/// </summary>
		[field: NonSerialized]
        public event EventHandler<IManagerErrorEventArgs> LoggingEvent;

		/// <summary>
		/// Occurs when a ticket actually changes (add/update/delete).
		/// </summary>
		[field: NonSerialized]
        public event EventHandler<TicketChangedEventArgs> TicketChangedEvent;

		/// <summary>
		/// Occurs when a TicketFieldResolver actually changes (add/update/delete).
		/// </summary>
		[field: NonSerialized]
        public event EventHandler<TicketFieldResolverChangedEventArgs> TicketFieldResolverChangedEvent;

        private bool _handleEventsAsync;
		/// <summary>
		/// Gets or sets a value indicating whether incoming events will be handled asynchronously.
		/// </summary>
		/// <value><c>true</c> if incoming events should be handled asynchronously; otherwise, <c>false</c>.</value>
		/// <remarks>Client applications will typically prefer blocking calls for event handling. If this is the case, set this property to <c>false</c>.</remarks>
		public bool HandleEventsAsync
        {
			get; set;
        }

		/// <summary>
		/// Gets the attachments.
		/// </summary>
		/// <value>The attachments.</value>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 10.0.8 (RN 25612).</para>
		/// </remarks>
		public AttachmentsHelper Attachments { get; private set; }
		#endregion

		#region Construction & Destruction
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingGatewayHelper"/> class.
		/// </summary>
		public TicketingGatewayHelper()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Internal method for received eventmessages
        /// If <see cref="HandleEventsAsync"/> is <c>true</c>, the function will return immediately.
        /// If <see cref="HandleEventsAsync"/> is <c>false</c>, the function will return once the event is handled.
        /// </summary>
        /// <param name="message">TicketingGatewayEventMessage that is received.</param>
        protected virtual void OnEventReceived(TicketingGatewayEventMessage message)
        {
        }

		/// <summary>
		/// Retrieves the trace data of the last call.
		/// </summary>
		/// <returns>Retrieves the trace data of the last call.</returns>
		/// <remarks>
		/// <para>From DataMiner 9.6.10 (RN 22526) onwards, for each call that failed, an entry of type TicketingManagerError. Reason.LegacyError will now be added to the TraceData. The value of the error will be stored in the <see cref="TicketingManagerError.LegacyErrorMessage"/> property.</para>
		/// </remarks>
		public TraceData GetTraceDataLastCall()
        {
			return null;
		}

		/// <summary>
		/// Retrieves the tickets that match the specified  filters.
		/// </summary>
		/// <param name="filters">The filter to use when searching the tickets.</param>
		/// <returns>The tickets that match the specified filters.</returns>
		[Obsolete("Please use the new GetTickets(IEnumerable<TicketLink> links, Messages.SLDataGateway.FilterElement<Ticket> filter, bool CacheOnly)", true)]
		public IEnumerable<Ticket> GetTickets(params Ticket[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the tickets that match the specified  filters.
		/// </summary>
		/// <param name="filters">The filter to use when searching the tickets.</param>
		/// <returns>The tickets that match the specified filters.</returns>
		[Obsolete("Please use the new GetTickets(IEnumerable<TicketLink> links, Messages.SLDataGateway.FilterElement<Ticket> filter, bool CacheOnly)", true)]
		public IEnumerable<Ticket> GetTickets(params FilterElement<Ticket>[] filters)
		{
			return null;
		}

		/// <summary>
		/// Retrieves the tickets that match the specified  filters and links.
		/// </summary>
		/// <param name="links">The links to be used when searching the tickets.</param>
		/// <param name="filter">The filter to use when searching the tickets.</param>
		/// <param name="CacheOnly">Indicates whether to only check the cache (true) or also the DB (false).</param>
		/// <returns>The tickets that match the specified filter and links.</returns>
		/// <example>
		/// <para>Retrieving tickets by ticket field:</para>
		/// <code>
		/// public Ticket RetrieveTicketByField()
		/// {
		///		var outputTickets = helper.GetTickets(filter: ReflectiveExposer.DictField&lt;Ticket, object&gt;("CustomTicketFields", "User").Equal("Jane"));
		///		if (outputTickets.Count() != 1)
		///			return null;
		///			
		///		return outputTickets.First();
		///	}
		/// </code>
		/// <para>Retrieving tickets by state:</para>
		/// <code>
		/// public Ticket RetrieveTicketByState()
		/// {
		///		var outputTickets = helper.GetTickets(filter: ReflectiveExposer.DictField&lt;Ticket, object&gt;("CustomTicketFields", "State").Equal(0));
		///		
		///		//Alternatively: 
		///		var alternative = helper.GetTickets(filter: ReflectiveExposer.DictField&lt;Ticket, object&gt;("CustomTicketFields", "State").Equal(new GenericEnumEntry&lt;int&gt;()
		///		  {
		///			  Name = "Created",
		///			  Value = 0
		///		  }));
		///		  
		///		if (outputTickets.Count() != 1)
		///			return null;
		///			
		///		return outputTickets.First();
		///	}
		/// </code>
		/// <para>Retrieving tickets by link:</para>
		/// <code>
		/// public Ticket RetrieveTicketByLink()
		/// {
		///		var outputTickets = helper.GetTickets(new TicketLink[] { TicketLink.Create(new Skyline.DataMiner.Net.ElementID(123, 456)) });
		///		
		///		if (outputTickets.Count() != 1)
		///			return null;
		///		
		///		return outputTickets.First();
		///	}
		/// </code>
		/// <para>Retrieving tickets by ticket field resolver:</para>
		/// <code>
		/// public Ticket[] RetrieveTicketByResolverID(TicketFieldResolver resolver)
		/// {
		///		var outputTickets = helper.GetTickets(filter: TicketingExposers.ResolverID.Equal(resolver.ID));
		///		
		///		return outputTickets.ToArray();
		///	}
		/// </code>
		/// </example>
		public IEnumerable<Ticket> GetTickets(IEnumerable<TicketLink> links = null, FilterElement<Ticket> filter = null, bool CacheOnly = false)
		{
			return null;
		}

		/// <summary>
		/// Requests tickets in a paged fashion. This method requests a new page.
		/// </summary>
		/// <param name="pagesize">The number of tickets that should be retrieved on one page.</param>
		/// <param name="pagingCookie">The paging cookie to use in the NextPagingRequest method to request the next page. If output is 0, no cookie could be created.</param>
		/// <param name="totalTickets">The total number of tickets this request would result in if done as a regular request (GetTickets). If output is -1, no total number could be calculated.</param>
		/// <param name="pageNumber">The page number you want to retrieve.</param>
		/// <param name="links">The links to be used when searching the tickets.</param>
		/// <param name="filter">The filter to use when searching the tickets.</param>
		/// <param name="CacheOnly">Indicates whether to only check the cache (true) or also the database (false).</param>
		/// <returns>A collection of tickets with the indicated page size, matching the links and filter.</returns>
		/// <remarks>
		/// <para>Instead of using the page number and calling a NewPagingRequest to retrieve the next page, we advise to use the <see cref="NextPagingRequest"/> method instead.</para>
		/// </remarks>
		/// <example>
		/// <para>When you have a system with a lot of tickets, it can be more feasible to retrieve the tickets in a paged fashion, so the client application does not receive a large amount all at once, which it cannot all display anyway.</para>
		/// <para>The following example demonstrates how to use paging.</para>
		/// <code>
		/// private static long PagingCookie = -1;
		/// private static int PageSize = 2;
		/// private static int totalTickets = 10;
		/// 
		/// private IEnumerable&lt;Ticket&gt; RetrieveNextPage()
		/// {
		/// 	List&lt;Ticket&gt; result;
		/// 	
		///		// The maximum number of tickets retrieved by this method is pageSize * number of DataMiner Agents in the DataMiner System.
		///		if (PagingCookie == -1)
		///		{
		///			result = Helper.NewPagingRequest(PageSize, out PagingCookie, out totalTickets, filter: TicketingExposers.DataMinerID.Equal(123)).ToList();
		///		}
		///		
		///		result = Helper.NextPagingRequest(PagingCookie).ToList();
		///		
		///		if (result.Count &lt; PageSize)
		///			PagingCookie = -1;
		///			
		///		return result;
		///	}
		/// </code>
		/// </example>
		public IEnumerable<Ticket> NewPagingRequest(int pagesize, out long pagingCookie, out int totalTickets, int pageNumber = 0, IEnumerable<TicketLink> links = null, Messages.SLDataGateway.FilterElement<Ticket> filter = null, bool CacheOnly = false)
		{
			pagingCookie = 0;
			totalTickets = 0;
			return null;
		}

		/// <summary>
		/// Requests the next page of a previously requested set of pages (retrieved via NewPagingRequest).
		/// </summary>
		/// <param name="pagingCookie">The pagingCookie retrieved from NewPagingRequest</param>
		/// <returns>The next page of the set.</returns>
		public IEnumerable<Ticket> NextPagingRequest(long pagingCookie)
        {
			return null;
		}

		/// <summary>
		/// Synchronizes the ticketing driver with DataMiner.
		/// </summary>
		/// <param name="ElementID">The element ID of the element running the Ticketing protocol.</param>
		/// <param name="TimeStamp">The time stamp of the last polling cycle to the external ticketing system.</param>
		/// <param name="ChangedTickets">The tickets that have changed since the last time this method was used, with DateTime being the timestamp of the last change to the ticket, and Ticket being the changed ticket.</param>
		/// <returns>A collection of event messages containing all the verified and updated or deleted tickets.</returns>
		public IEnumerable<TicketingGatewayEventMessage> DriverSync(ElementID ElementID, DateTime TimeStamp, params Tuple<DateTime, Ticket>[] ChangedTickets)
        {
			return null;
		}

        /// <summary>
        /// Retrieve Tickets, using links as input
        /// </summary>
        /// <param name="links">for every link, all available tickets will be given</param>
        /// <returns>Collection of Tickets which pass at least 1 of the given links.</returns>
        [Obsolete("Please use the new GetTickets(IEnumerable<TicketLink> links, Messages.SLDataGateway.FilterElement<Ticket> filter, bool CacheOnly)", true)]
		public IEnumerable<Ticket> GetTicketsByLink(params TicketLink[] links)
		{
			return null;
		}

		/// <summary>
		/// Adds or edits the specified tickets.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="tickets">The tickets to add/edit.</param>
		/// <returns><c>true</c> if adding/editing the tickets succeeded; otherwise, <c>false</c>.</returns>
		public bool SetTickets(out string error, ref Ticket[] tickets)
        {
			error = "";
			return false;
        }

		/// <summary>
		/// Adds or edits a ticket.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="ticket">The ticket to add or edit.</param>
		/// <returns><c>true</c> if adding/editing the ticket succeeded; otherwise, <c>false</c>.</returns>
		public bool SetTicket(out string error, ref Ticket ticket)
        {
			error = "";
			return false;
		}

		/// <summary>
		/// Removes the specified tickets.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="tickets">The tickets that should be removed.</param>
		/// <returns><c>true</c> if removing the ticket succeeded; otherwise, <c>false</c>.</returns>
		public bool RemoveTickets(out string error, params Ticket[] tickets)
        {
			error = "";
			return false;
        }

		/// <summary>
		/// Retrieves the history of the specified tickets.
		/// </summary>
		/// <param name="ticketIDs">The ticket IDs of the tickets for which the history should be retrieved.</param>
		/// <returns>The requested collection of TicketHistory objects.</returns>
		public IEnumerable<TicketHistory> GetTicketHistory(params TicketID[] ticketIDs)
        {
			return null;
		}

		/// <summary>
		/// Adds or edits the specified ticket field resolvers.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="resolvers">The ticket field resolvers to add/edit.</param>
		/// <returns><c>true</c> if adding/editing the ticket field resolvers succeeded; otherwise, <c>false</c>.</returns>
		public bool SetTicketFieldResolvers(out string error, ref TicketFieldResolver[] resolvers)
        {
			error = "";
			return false;
        }

		/// <summary>
		/// Adds or edits the specified ticket field resolver.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="resolver">The ticket field resolver to add/edit.</param>
		/// <returns><c>true</c> if adding/editing the ticket field resolver succeeded; otherwise, <c>false</c>.</returns>
		public bool SetTicketFieldResolver(out string error, ref TicketFieldResolver resolver)
		{
			error = "";
			return false;
		}

		/// <summary>
		/// Removes the specified ticket field resolvers.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="resolvers">The ticket field resolvers that should be removed.</param>
		/// <returns><c>true</c> if removing the ticket field resolvers succeeded; otherwise, <c>false</c>.</returns>
		public bool RemoveTicketFieldResolvers(out string error, params TicketFieldResolver[] resolvers)
        {
            error = "No response received";
            return false;
        }

		/// <summary>
		/// Removes the specified masked ticket field resolvers and all tickets linked to that resolver.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="maskedResolverGuid">The GUID of the masked resolver to remove.</param>
		/// <returns><c>true</c> if removing the masked ticket field resolver succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>An error will be returned in the following cases:</para>
		/// <list type="bullet">
		///	<item>
		///		<description>If the <see cref="TicketFieldResolver"/> does not exist.</description>
		///	</item>
		///	<item>
		///		<description>If the <see cref="TicketFieldResolver"/> is not masked.</description>
		///	</item>
		///	<item>
		///		<description>If the user has not been granted the “Ticketing Gateway/Configure” permission.</description>
		///	</item>
		///	<item>
		///		<description>If something went wrong while deleting the <see cref="TicketFieldResolver"/> or any of the linked tickets.</description>
		///	</item>
		/// </list>
		/// <para>Feature introduced in DataMiner 9.6.10 (RN 22403).</para>
		/// <para>For Ticketing with Elastic search, use the TicketingHelper.DeleteMaskedTicketDomain(Guid) method.</para>
		/// </remarks>
		public bool RemoveMaskedTicketFieldResolver(out string error, Guid maskedResolverGuid)
        {
            error = "No response received";
            return false;
        }

		/// <summary>
		/// Retrieves the non-masked ticket field resolvers corresponding to one or more filters.
		/// </summary>
		/// <param name="filters">A collection of filters. Each filter will be processed separately and the results will be added to the final response.</param>
		/// <returns>The requested ticket field resolvers.</returns>
		public IEnumerable<TicketFieldResolver> GetTicketFieldResolvers(params TicketFieldResolver[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the masked resolvers corresponding to one or more filters.
		/// </summary>
		/// <param name="filters">A collection of filters. Each filter will be processed separately and the results will be added to the final response.</param>
		/// <returns>The requested ticket field resolvers.</returns>
		/// <example>
		/// <para>If the following is specified within a script, any resolvers that are masked will be retrieved and an information event will be generated with information about them:</para>
		/// <code>
		/// private void ShowMaskedResolvers(Engine engine)
		/// {
		///		var maskedTicketFieldResolvers = helper.GetMaskedTicketFieldResolvers();
		///		foreach (TicketFieldResolver maskedTicketFieldResolver in maskedTicketFieldResolvers)
		///		{
		///			engine.GenerateInformation(string.Format("Resolver \"{0}\", which is configured to be linked to \"{1}\", is masked.", maskedTicketFieldResolver.Name, maskedTicketFieldResolver.ElementUsingResolver.ToString()));
		///		}
		///	}
		/// </code>
		/// </example>
		public IEnumerable<TicketFieldResolver> GetMaskedTicketFieldResolvers(params TicketFieldResolver[] filters)
        {
			return null;
		}

        #endregion

        #region Interface Implementation
		/// <summary>
		/// Retrieves a value indicating whether it is initialized.
		/// </summary>
		/// <returns><c>true</c> if initialized; otherwise, <c>false</c>.</returns>
        public bool IsInitialized()
        {
			return true;
		}

		/// <summary>
		/// Handles an incoming event message. If Skyline.DataMiner.Net.Ticketing.TicketingGatewayHelper.HandleEventsAsync is true, the event message is handled asynchronously and this method will return immediately. If Skyline.DataMiner.Net.Ticketing.TicketingGatewayHelper.HandleEventsAsync is false, the event message is handled in a blocking fashion.
		/// </summary>
		/// <param name="message">TicketingGatewayEventMessage that is received.</param>
		public virtual void OnEventReceived(IManagerEventMessage message)
        {
        }

		/// <summary>
		/// Populates a <see cref="SerializationInfo"/>  with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		/// <exception cref="SecurityException">The caller does not have the required permission.</exception>
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
        }
        #endregion

        #region Event Handling
        protected void RaiseEventAsync<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
        }

        protected void RaiseEvent<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
        }
        #endregion
    }
}
