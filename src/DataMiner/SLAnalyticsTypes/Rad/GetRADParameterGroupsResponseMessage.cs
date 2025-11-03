using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Response message for GetRADParameterGroupsMessage.
    /// </summary>
    [Serializable]
    public class GetRADParameterGroupsResponseMessage : ResponseMessage
    {
        /// <summary>
        /// Names of the relational anomaly detection parameter groups available on the targeted Agent.
        /// </summary>
        public List<string> GroupNames { get; set; }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
