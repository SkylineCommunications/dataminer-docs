using System;
using System.Runtime.Serialization;
using Skyline.DataMiner.Net.Tickets;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Contains all settings used by the ticket field resolver. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[Serializable]
    //[DataContract]
    public class TicketFieldResolverSettings
    {
		/// <summary>
		/// Gets or sets the script settings containing the name of the scripts that should be executed for the corresponding CRUD operation on a ticket.
		/// </summary>
		/// <value>The script settings.</value>
		//[DataMember(Name = "ScriptSettings")]
        public ExecuteScriptOnTicketActionSettings ScriptSettings { get; set; }
    }
}
