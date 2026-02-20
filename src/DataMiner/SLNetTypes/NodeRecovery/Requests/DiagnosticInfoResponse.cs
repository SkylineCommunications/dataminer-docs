using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Response for <see cref="DiagnosticInfoRequest"/>
    /// </summary>
    [Serializable]
    public class DiagnosticInfoResponse : ResponseMessage
    {
        /// <summary>
        /// Local node identifier
        /// </summary>
        public int LocalNodeId { get; set; }

        /// <summary>
        /// Current leader node identifier. If no leader is elected, this value is -1.
        /// </summary>
        public int LeaderNodeId { get; set; }

        /// <summary>
        /// Startup time of the NodeRecovery DxM
        /// </summary>
        public DateTimeOffset StartupTime { get; set; }

        /// <summary>
        /// Version of the DxM
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Detailed diagnostic information for each node in the cluster
        /// </summary>
        public Dictionary<int, NodeDiagnosticInfo> NodeDiagnostics { get; set; } = new Dictionary<int, NodeDiagnosticInfo>();

        public override string ToString()
        {
            return $"Diagnostics from Node {LocalNodeId} (Leader: {LeaderNodeId}): {NodeDiagnostics.Count} nodes";
        }
    }
}
