using System;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// Possible states of a node in the cluster
    /// </summary>
    [Serializable]
    public enum NodeState
    {
        /// <summary>
        /// Initial state, no info yet
        /// </summary>
        Unknown,

        /// <summary>
        /// A recent heartbeat has been received from this node and thus the node is considered alive
        /// </summary>
        Healthy,

        /// <summary>
        /// No heartbeat from this node has been received in a while and thus the node is now considered in outage
        /// </summary>
        Outage,
    }
}
