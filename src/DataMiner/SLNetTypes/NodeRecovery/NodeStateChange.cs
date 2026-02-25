using System;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// The state change of a node in the cluster where it went from one state to another
    /// </summary>
    [Serializable]
    public class NodeStateChange
    {
        /// <summary>
        /// Previous known state for the node
        /// </summary>
        public NodeState PreviousState { get; set; }

        /// <summary>
        /// New known state for the node
        /// </summary>
        public NodeState CurrentState { get; set; }
    }
}
