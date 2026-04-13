using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests diagnostic information from a specific NodeRecovery DxM instance.
    /// </summary>
    [Serializable]
    public class DiagnosticInfoRequest : ClientRequestMessage
    {
        /// <summary>
        /// The ID of the DataMiner Agent where an instance of the NodeRecovery DxM is running. If no ID is specified, the local Agent is used.
        /// </summary>
        public int TargetDataMinerId { get; set; }
    }
}
