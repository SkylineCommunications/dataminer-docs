﻿using System;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Verifies Swarming prerequisites on a system.
    /// See <see href="https://aka.dataminer.services/enable-swarming">Enabling the Swarming feature</see>.
    /// </summary>
    [Serializable]
    // [DataMinerSecurity(PermissionFlags.AdminTools)]
    public class SwarmingPrerequisitesCheckRequest // : TargetedClientRequestMessage
    {
        /// <summary>
        /// Whether this check includes analyzing automation scripts for incompatible AlarmID usage.
        /// </summary>
        public bool AnalyzeAlarmIDUsage { get; set; } = true;
    }
}
