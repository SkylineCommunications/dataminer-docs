using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.NodeRecovery.Requests
{
    /// <summary>
    /// Response for <see cref="SetMaintenanceRequest"/>
    /// </summary>
    [Serializable]
    public class SetMaintenanceResponse : ResponseMessage
    {
        public override string ToString()
        {
            return "Set Maintenance Response";
        }
    }
}
