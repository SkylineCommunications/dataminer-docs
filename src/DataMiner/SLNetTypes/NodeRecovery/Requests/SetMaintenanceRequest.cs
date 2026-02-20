using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests to set the maintenance mode for a specific node in the cluster
    /// </summary>
    [Serializable]
    public class SetMaintenanceRequest : ClientRequestMessage
    {
        /// <summary>
        /// The id of the node to set maintenance mode for
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// True to set the node in maintenance mode, false otherwise
        /// </summary>
        public bool InMaintenance { get; set; }
    }
}
