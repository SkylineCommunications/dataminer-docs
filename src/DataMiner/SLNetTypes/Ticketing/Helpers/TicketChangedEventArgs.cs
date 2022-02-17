using Skyline.DataMiner.Net.Ticketing.Objects;
using System;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Event arguments for the <see cref="TicketingGatewayHelper.TicketChangedEvent"/> event.
	/// </summary>
	public class TicketChangedEventArgs : EventArgs
    {
		/// <summary>
		/// Indicates whether this is a delete.
		/// </summary>
		public bool isDelete;

		/// <summary>
		/// The changed ticket.
		/// </summary>
		public Ticket ChangedTicket;

		/// <summary>
		/// The change history.
		/// </summary>
		public TicketHistory ChangedHistory;

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketChangedEventArgs"/> class.
		/// </summary>
		public TicketChangedEventArgs()
            : base()
        {

        }
    }
}
