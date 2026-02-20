using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Automation;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// Input argument for the <see cref="AutomationEntryPoint.Types.OnNodeRecoveryGlobalStateChange"/> automation entry point
    /// </summary>
    [Serializable]
    public class GlobalStateChangeInput
    {
        /// <summary>
        /// The node id of the leader node within the NodeRecovery cluster. This is the node that triggered the script.
        /// In case of DataMiner, this is the DataMiner ID.
        /// </summary>
        public int LeaderNodeId { get; set; }

        /// <summary>
        /// Overview of the state of every node in the cluster, as calculated based on the local views of the different nodes
        /// </summary>
        public Dictionary<int, NodeStateInfo> ClusterState { get; set; }

        /// <summary>
        /// Overview of the node changes compared to the previous known global state
        /// </summary>
        public Dictionary<int, NodeStateChange> ClusterStateChanges { get; set; }
    }
}
