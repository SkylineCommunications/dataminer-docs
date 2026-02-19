using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests diagnostic information from a specific NodeRecovery instance
    /// </summary>
    [Serializable]
    public class DiagnosticInfoRequest : ClientRequestMessage
    {
        /// <summary>
        /// The ID of the DataMiner agent where an instance of NodeRecovery is running. If not specified, the local agent is used.
        /// </summary>
        public int TargetDataMinerId { get; set; }
    }
}
