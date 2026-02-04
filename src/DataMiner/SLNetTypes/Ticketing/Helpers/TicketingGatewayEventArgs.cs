using System;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Ticketing.Interfaces;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Provides data for the <see cref="TicketingGatewayHelper.SendEvent"/> event. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	public class TicketingGatewayEventArgs : EventArgs
    {
		/// <summary>
		/// Gets the request message.
		/// </summary>
		public ITicketingGatewayRequestMessage requestMessage { get; }

		/// <summary>
		/// Gets or sets the response message.
		/// </summary>
		public TicketingResponseMessage responseMessage { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingGatewayEventArgs"/> class.
		/// </summary>
		public TicketingGatewayEventArgs() : base()
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingGatewayEventArgs"/> class using the specified request message.
		/// </summary>
		/// <param name="m">The request message.</param>
		public TicketingGatewayEventArgs(ITicketingGatewayRequestMessage m) : this()
        {
        }
    }
}
