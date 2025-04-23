using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to start monitoring a parameter group with Relational Anomaly Detection. If a group with the same name already exists on the same Agent, it will be overwritten.
    /// </summary>
    [Serializable]
    public class AddRADParameterGroupMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The group information.
        /// </summary>
        public RADGroupInfo ParameterGroupInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRADParameterGroupMessage"/> class.
        /// </summary>
        public AddRADParameterGroupMessage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRADParameterGroupMessage"/> class.
        /// </summary>
        /// <param name="groupInfo">The group information.</param>
        public AddRADParameterGroupMessage(RADGroupInfo groupInfo) { }

    }
}
