using System;

namespace Skyline.DataMiner.Net.NodeRecovery
{
    /// <summary>
    /// The state change of a node in the cluster where it went from one state to another
    /// </summary>
    [Serializable]
    public class NodeStateChange
    {
        public NodeState PreviousState { get; set; }
        public NodeState CurrentState { get; set; }
    }
}
