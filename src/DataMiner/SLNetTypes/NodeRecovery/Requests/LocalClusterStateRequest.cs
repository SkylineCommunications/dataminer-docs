using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests the local cluster state from the viewpoint of NodeRecovery on a specific DataMiner agent
    /// </summary>
    [Serializable]
    public class LocalClusterStateRequest : ClientRequestMessage
    {
        /// <summary>
        /// The ID of the DataMiner agent where an instance of NodeRecovery is running. If not specified, the local agent is used.
        /// </summary>
        public int TargetDataMinerId { get; set; }
    }
}
