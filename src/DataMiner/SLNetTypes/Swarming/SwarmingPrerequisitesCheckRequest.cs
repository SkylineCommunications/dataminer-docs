﻿using System;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Verifies Swarming prerequisites on a system.
    /// See <see href="https://docs.dataminer.services/user-guide/Advanced_Functionality/Swarming/EnableSwarming.html">Enabling the Swarming feature</see>
    /// </summary>
    [Serializable]
    // [DataMinerSecurity(PermissionFlags.AdminTools)]
    public class SwarmingPrerequisitesCheckRequest // : TargetedClientRequestMessage
    {
        /// <summary>
        /// Whether this check includes analyzing Automation scripts for incompatible AlarmID usage.
        /// </summary>
        public bool AnalyzeAlarmIDUsage { get; set; } = true;
    }
}
