using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Automation;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// Input argument for the <see cref="AutomationEntryPoint.Types.OnNodeRecoveryLocalStateChange"/> automation entry point
    /// </summary>
    [Serializable]
    public class LocalStateChangeInput
    {
        /// <summary>
        /// The local node id, the one that is executing this script
        /// In case of DataMiner, this is the DataMiner id
        /// </summary>
        public int LocalNodeId { get; set; }

        /// <summary>
        /// Overview of every node in the cluster as observed from the local node's perspective
        /// </summary>
        public Dictionary<int, NodeStateInfo> ClusterState { get; set; }

        /// <summary>
        /// Overview of the node changes that were detected from the local node's perspective
        /// </summary>
        public Dictionary<int, NodeStateChange> ClusterStateChanges { get; set; }
    }
}
