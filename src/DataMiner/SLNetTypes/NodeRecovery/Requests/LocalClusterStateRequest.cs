using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests the local cluster state from the viewpoint of Node Recovery on a specific DataMiner Agent.
    /// </summary>
    [Serializable]
    public class LocalClusterStateRequest : ClientRequestMessage
    {
        /// <summary>
        /// The ID of the DataMiner Agent where an instance of the NodeRecovery DxM is running. If not specified, the local Agent is used.
        /// </summary>
        public int TargetDataMinerId { get; set; }
    }
}
