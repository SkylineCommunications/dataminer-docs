using System;

namespace Skyline.DataMiner.Net.Ticketing.Interfaces
{
	/// <summary>
	/// Ticketing gateway request message interface. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	public interface ITicketingGatewayRequestMessage : ICloneable
    {
		/// <summary>
		/// Gets or sets the ID of the hosting DataMiner Agent.
		/// </summary>
		int HostingDataMinerID { get; set; }
    }

    public interface ITicketLicenseCheckable
    {
        bool IsFullyLicensed(bool ticketingLicensed, out string notLicensedReason);
    }
}
