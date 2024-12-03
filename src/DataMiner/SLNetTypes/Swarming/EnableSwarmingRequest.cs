using System;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Enables Swarming on a system.
    /// See <see href="https://docs.dataminer.services/user-guide/Advanced_Functionality/Swarming/EnableSwarming.html">Enabling the Swarming feature</see>
    /// </summary>
    [Serializable]
    //[DataMinerSecurity(PermissionFlags.AdminTools)]
    public class EnableSwarmingRequest // : TargetedClientRequestMessage
    {
    }
}
