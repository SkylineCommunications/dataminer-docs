using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Response for <see cref="GlobalClusterStateRequest"/>
    /// </summary>
    [Serializable]
    public class GlobalClusterStateResponse : ResponseMessage
    {
        /// <summary>
        /// The ID of the leader node within the NodeRecovery cluster.
        /// </summary>
        public int LeaderNodeId { get; set; }

        /// <summary>
        /// Overview of every node in the cluster as observed by the NodeRecovery DxMs
        /// </summary>
        public Dictionary<int, NodeStateInfo> ClusterState { get; set; } = new Dictionary<int, NodeStateInfo>();

        public override string ToString()
        {
            return "Global Cluster State: " + string.Join(", ", ClusterState
                .Values
                .GroupBy(n => n.State)
                .OrderBy(g => g.Key)
                .Select(g => $"{g.Key}: {g.Count()}"));
        }
    }
}
