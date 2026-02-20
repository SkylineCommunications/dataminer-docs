using System;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// Detailed diagnostic information about a node in the NodeRecovery cluster
    /// </summary>
    [Serializable]
    public class NodeDiagnosticInfo
    {
        /// <summary>
        /// Local observed state of this node
        /// </summary>
        public NodeState LocalObservedState { get; set; }

        /// <summary>
        /// Last time the local observed state changed
        /// </summary>
        public DateTimeOffset LocalObservedStateChanged { get; set; }

        /// <summary>
        /// Global observed state of this node (only populated when diagnostics are requested from the leader node)
        /// </summary>
        public NodeState? GlobalObservedState { get; set; }

        /// <summary>
        /// Last time the global observed state changed (only populated when diagnostics are requested from the leader node)
        /// </summary>
        public DateTimeOffset? GlobalObservedStateChanged { get; set; }

        /// <summary>
        /// Timestamp of the most recent heartbeat received from this node
        /// </summary>
        public DateTimeOffset LastHeartbeatReceived { get; set; }

        /// <summary>
        /// Whether the node is in maintenance mode
        /// </summary>
        public bool InMaintenance { get; set; }

        public override string ToString()
        {
            var globalState = GlobalObservedState.HasValue ? $" - Global: {GlobalObservedState.Value}" : string.Empty;
            var maintenance = InMaintenance ? " (maintenance)" : string.Empty;
            return $"Local: {LocalObservedState} - Last HB: {LastHeartbeatReceived.ToUniversalTime():yyyy-MM-dd HH:mm:ss.fff} (UTC){globalState}{maintenance}";
        }
    }
}
