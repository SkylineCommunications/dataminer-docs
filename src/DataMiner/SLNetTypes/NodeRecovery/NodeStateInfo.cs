using System;
using Skyline.DataMiner.Net.NodeRecovery.Requests;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// General info about the state of a node in the cluster
    /// </summary>
    [Serializable]
    public class NodeStateInfo
    {
        /// <summary>
        /// The state of the node, e.g. healthy
        /// </summary>
        public NodeState State { get; set; }

        /// <summary>
        /// Whether or not the node is in maintenance mode.
        /// Changes in this maintenance state get triggered through user actions only. (<see cref="SetMaintenanceRequest"/>)
        /// </summary>
        public bool InMaintenance { get; set; }

        public override string ToString()
        {
            if (InMaintenance)
                return $"{State} (maintenance)";
            else
                return State.ToString();

        }
    }
}
