using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Contains information about this DataMiner Agent. This information is available
    /// from the <see cref="Connection"/> object after authentication is complete.
    /// </summary>
    [Serializable]
    public class ServerDetails
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="ServerDetails"/> class.
		/// </summary>
		public ServerDetails() 
        {
            
        }

		/// <summary>
		/// Gets or sets the name of the DMS cluster.
		/// </summary>
		/// <value>The name of the DMS cluster.</value>
		public string ClusterName { get; set; }

		/// <summary>
		/// Gets or sets the name of the DataMiner Agent.
		/// </summary>
		/// <value>The name of the DataMiner Agent.</value>
		public string AgentName { get; set; }

		/// <summary>
		/// Gets or sets the DataMiner Agent IP address.
		/// </summary>
		/// <value>The DataMiner Agent IP address.</value>
		public string AgentIP { get; set; }

		/// <summary>
		/// Gets or sets the DataMiner Agent ID.
		/// </summary>
        /// <value>The DataMiner Agent ID.</value>
		public int AgentID { get; set; }

		/// <summary>
		/// Gets or sets the SLNetTypes version.
		/// </summary>
		/// <value>The SLNetTypes version.</value>
		public string SLNetTypesVersion { get; set; }

		/// <summary>
		/// Gets or sets the name of the domain to which the DataMiner Agent belongs.
		/// </summary>
		/// <value>The name of the domain to which the DataMiner Agent belongs.</value>
		public string AgentDomainName { get; set; }

		///// <summary>
		///// Allowed caching modes (objects, events, ...)
		///// (when "Undefined", the server does not specify any rules).
		///// </summary>
		//public CachingMode AllowedCacheModes { get; set; }

		/// <summary>
		/// Gets or sets the global client setting flags, e.g. "SkipViewUpdates".
		/// </summary>
		/// <value>The global client setting flags, e.g. "SkipViewUpdates".</value>
		public GlobalClientFlags GlobalClientFlags { get; set; }

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
        {
            return "Server Details";
        }
    }

    /// <summary>
    /// Global client setting flags.
    /// </summary>
    [Serializable]
    [Flags]
    public enum GlobalClientFlags
    {
		/// <summary>
		/// None.
		/// </summary>
		None = 0x00000000,

        /// <summary>
        /// Client should not listen in
        /// on view updates. Corresponds to the
        /// "ClientSkipViewUpdates" SLNet option
        /// in MaintenanceSettings.xml
        /// </summary>
        SkipViewUpdates = 0x00000001,
    }
    
}
