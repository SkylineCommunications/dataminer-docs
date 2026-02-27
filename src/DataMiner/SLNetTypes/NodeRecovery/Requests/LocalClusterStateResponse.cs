using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Response for <see cref="LocalClusterStateRequest"/>
    /// </summary>
    [Serializable]
    public class LocalClusterStateResponse : ResponseMessage
    {
        /// <summary>
        /// Overview of every node in the cluster as observed from the local node's perspective
        /// </summary>
        public Dictionary<int, NodeStateInfo> ClusterState { get; set; } = new Dictionary<int, NodeStateInfo>();

        public override string ToString()
        {
            return "Local Cluster State: " + string.Join(", ", ClusterState
                .Values
                .GroupBy(n => n.State)
                .OrderBy(g => g.Key)
                .Select(g => $"{g.Key}: {g.Count()}"));
        }
    }
}
