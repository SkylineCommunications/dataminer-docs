using System;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Enables Swarming on a system.
    /// See <see href="https://aka.dataminer.services/enable-swarming">Enabling the Swarming feature</see>.
    /// </summary>
    [Serializable]
    //[DataMinerSecurity(PermissionFlags.AdminTools)]
    public class EnableSwarmingRequest // : TargetedClientRequestMessage
    {
    }
}
