using System;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Event arguments for the <see cref="TicketingGatewayHelper.TicketFieldResolverChangedEvent"/> event. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	public class TicketFieldResolverChangedEventArgs : EventArgs
    {
		/// <summary>
		/// Indicates whether this ticket field resolver is deleted.
		/// </summary>
		public bool isDelete;

		/// <summary>
		/// The changed ticket field resolver.
		/// </summary>
		public TicketFieldResolver ChangedResolver;

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldResolverChangedEventArgs"/> class.
		/// </summary>
		public TicketFieldResolverChangedEventArgs()
            : base()
        {

        }
    }
}