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
        /// The id of the DataMiner agent where an instance of Node Recovery is running
        /// </summary>
        /// <remarks>
        /// Not using the DataMinerId from <see cref="TargetedClientRequestMessage"/> so the routing goes over nats and not via SLNet.
        /// This also has the benefit that we can reach the remote Node Recovery instance even when the DataMiner agent is down.
        /// </remarks>
        public int TargetDataMinerId { get; set; }
    }
}
