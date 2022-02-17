using System;

namespace Skyline.DataMiner.Net.Ticketing.Interfaces
{
	/// <summary>
	/// Ticketing gateway request message interface.
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
