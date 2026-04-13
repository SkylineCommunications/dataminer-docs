using System;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// Possible states of a node in the cluster.
    /// </summary>
    [Serializable]
    public enum NodeState
    {
        /// <summary>
        /// <para>For local view: Initial state for nodes before an initial heartbeat has been received from that node. This occurs during startup of the NodeRecovery DxM or after remote nodes have notified that they expect to have downtime (e.g., on restarts).</para>
        /// <para>For global view: A node gets marked as Unknown globally in scenarios where it is not possible to determine whether its state should be marked as Healthy or in Outage. Refer to <see href="xref:NodeRecovery_About">Node Recovery</see> for detailed information.</para>
        /// </summary>
        Unknown,

        /// <summary>
        /// <para>For local view: The node is considered to be alive from the observing node's perspective. Heartbeats have been received from this node recently.</para>
        /// <para>For global view: In general, a node is marked as Healthy as soon as one voting node sees it as Healthy. Refer to <see href="xref:NodeRecovery_About">Node Recovery</see> for detailed information.</para>
        /// </summary>
        Healthy,

        /// <summary>
        /// <para>For local view: When no heartbeats have been received for a period of time from the observing node's perspective, the node is considered to be in outage.</para>
        /// <para>For global view: In general, a node gets marked as Outage when no voting node sees it as Healthy, and a cluster majority of nodes agrees that the node is in outage. Refer to <see href="xref:NodeRecovery_About">Node Recovery</see> for detailed information.</para>
        /// </summary>
        Outage,
    }
}
