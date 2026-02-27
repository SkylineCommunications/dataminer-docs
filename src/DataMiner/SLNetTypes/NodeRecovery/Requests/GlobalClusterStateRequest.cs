using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Requests the global cluster state as observed by the NodeRecovery DxMs
    /// </summary>
    [Serializable]
    public class GlobalClusterStateRequest : ClientRequestMessage
    {
    }
}
