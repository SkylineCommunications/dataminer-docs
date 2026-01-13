using Skyline.DataMiner.Net.Apps.Utils;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Ticketing;
using Skyline.DataMiner.Net.Ticketing.Helpers;
using Skyline.DataMiner.Net.Ticketing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyline.DataMiner.Net.Tickets
{
	/// <summary>
	/// Ticketing helper class. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	/// <remarks>
	/// <para>Feature introduced in DataMiner 9.6.4 (RN 20344).</para>
	/// </remarks>
	public class TicketingHelper : BaseManagerHelper
    {
		/// <summary>
		/// Ticket attachments folder name.
		/// </summary>
        public static readonly string TicketAttachmentFolderName;

		/// <summary>
		/// Ticket attachments file path.
		/// </summary>
        public static readonly string TicketAttachmentFilePath;

		/// <summary>
		/// Gets the tickets.
		/// </summary>
		/// <value>The tickets.</value>
		public TicketCrudHelperComponent Tickets { get; }

		/// <summary>
		/// Gets the ticket field resolver CRUD helper component.
		/// </summary>
		/// <value>The ticket field resolver CRUD helper component.</value>
		public TicketFieldResolverCrudHelperComponent TicketFieldResolvers { get; }

		/// <summary>
		/// Gets the ticket histories.
		/// </summary>
		/// <value>The ticket histories.</value>
		public CrudHelperComponent<TicketHistory> TicketHistories { get; }

		/// <summary>
		/// Gets the attachments.
		/// </summary>
		/// <value>The attachments.</value>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 10.0.8 (RN 25612).</para>
		/// </remarks>
		public AttachmentsHelper Attachments { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingHelper"/> class.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		public TicketingHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
            : base(messageHandler)
        {
        }

		/// <summary>
		/// Synchronizes tickets to an external system.
		/// </summary>
		/// <param name="id">The element ID of the element running the Ticketing protocol.</param>
		/// <param name="timeStamp">The time stamp of the last polling cycle to the external ticketing system.</param>
		/// <param name="managerObjects">The tickets to save or merge on the DataMiner Agent.</param>
		/// <returns>The merged tickets.</returns>
		/// <remarks>
		/// <para>Method used when syncing tickets to an external system. The DriverSyncer will check and return all latest changes related to a resolver linked to the given ElementID. When a list of tickets is given, these tickets will be saved or merged on the DMA. The merged tickets will also be returned.</para>
		/// </remarks>
		public List<TicketingGatewayEventMessage> SendDriverSync(ElementID id, DateTime timeStamp, List<Tuple<DateTime, Ticket>> managerObjects)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified masked ticket field resolvers and all tickets linked to that resolver.
		/// </summary>
		/// <param name="ticketFieldResolverGuid">The GUID of the masked ticket domain.</param>
		/// <returns>Output string with notifications and/or errors that occurred.</returns>
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
		/// </remarks>
		public TraceData DeleteMaskedTicketFieldResolver(Guid ticketFieldResolverGuid)
        {
			return null;
		}
    }
}