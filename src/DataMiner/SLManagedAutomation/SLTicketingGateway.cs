using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Skyline.DataMiner.Net.Ticketing;
using Skyline.DataMiner.Net.Ticketing.Helpers;
using Skyline.DataMiner.Net.Ticketing.Objects;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents the DataMiner ticketing gateway. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	public class SLTicketingGateway : IDisposable
	{
		//~SLTicketingGateway() { }

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		//public sealed override void Dispose() { }
		public virtual void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the non-masked ticket field resolvers corresponding to one or more filters.
		/// </summary>
		/// <param name="filters">A collection of filters. Each filter will be processed separately, and the results will be added to the final response.</param>
		/// <returns> The requested <see cref="TicketFieldResolver"/> objects.</returns>
		public virtual IEnumerable<TicketFieldResolver> GetTicketFieldResolvers(params TicketFieldResolver[] filters) { return null; }

		/// <summary>
		/// Retrieves the history for one or more tickets.
		/// </summary>
		/// <param name="TicketIDs">The ticket IDs of the tickets for which the history should be retrieved.</param>
		/// <returns>The requested <see cref="TicketHistory"/> objects.</returns>
		public virtual IEnumerable<TicketHistory> GetTicketHistory(params TicketID[] TicketIDs) { return null; }

		/// <summary>
		/// Removes one or more ticket field resolvers.
		/// </summary>
		/// <param name="error">String with notifications and/or errors that occurred.</param>
		/// <param name="filters">The ticket field resolvers that should be removed.</param>
		/// <returns><c>true</c> when removing the ticket field resolver(s) was successful; otherwise, <c>false</c>.</returns>
		public virtual bool RemoveTicketFieldResolvers(out string error, params TicketFieldResolver[] filters) { error = ""; return false; }

		/// <summary>
		/// Removes one or more tickets.
		/// </summary>
		/// <param name="error">String with notifications and/or errors that occurred.</param>
		/// <param name="filters">The tickets that should be removed.</param>
		/// <returns><c>true</c> when removing the ticket(s) was successful; otherwise, <c>false</c>.</returns>
		public virtual bool RemoveTickets(out string error, params Ticket[] filters) { error = ""; return false; }

		/// <summary>
		/// Adds or edits multiple ticket field resolvers.
		/// </summary>
		/// <param name="error">String with notifications and/or errors that occurred.</param>
		/// <param name="resolvers">The ticket field resolvers you wish to add or edit.</param>
		/// <returns><c>true</c> when adding/editing the ticket field resolver(s) was successful; otherwise, <c>false</c>.</returns>
		public virtual bool SetTicketFieldResolvers(out string error, ref TicketFieldResolver[] resolvers) { error = ""; return false; }

		/// <summary>
		/// Adds or edits multiple tickets.
		/// </summary>
		/// <param name="error">String with notifications and/or errors that occurred.</param>
		/// <param name="tickets">The tickets you wish to add or edit.</param>
		/// <returns><c>true</c> when adding/editing the ticket(s) was successful; otherwise, <c>false</c>.</returns>
		public virtual bool SetTickets(out string error, ref Ticket[] tickets) { error = ""; return false; }

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="SLTicketingGateway"/> and optionally releases the managed resources
		/// </summary>
		/// <param name="A_0"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources</param>
		//[HandleProcessCorruptedStateExceptions]
		protected virtual void Dispose(bool A_0) { }
	}
}