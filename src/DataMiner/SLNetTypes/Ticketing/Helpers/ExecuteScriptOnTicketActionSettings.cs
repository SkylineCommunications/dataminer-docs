using System;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Used to define the scripts that should be executed for each CRUD action on a <see cref="Ticket"/>. No script will be executed when the name is null or empty. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class ExecuteScriptOnTicketActionSettings
    {
		/// <summary>
		/// Gets or sets the name of the scripts that should be executed for the create operation on a Ticket.
		/// </summary>
		//[DataMember(Name = "OnCreate")]
        public string OnCreate { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the name of the scripts that should be executed for the update operation on a Ticket.
		/// </summary>
		//[DataMember(Name = "OnUpdate")]
        public string OnUpdate { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the name of the scripts that should be executed for the delete operation on a Ticket.
		/// </summary>
		//[DataMember(Name = "OnDelete")]
        public string OnDelete { get; set; } = string.Empty;
    }
}
