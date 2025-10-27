using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to stop monitoring a parameter group with Relational Anomaly Detection.
    /// Results in a <see cref="RemoveRADParameterGroupResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class RemoveRADParameterGroupMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveRADParameterGroupMessage"/> class.
        /// </summary>
        public RemoveRADParameterGroupMessage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveRADParameterGroupMessage"/> class.
        /// </summary>
        /// <param name="groupName">The name of the parameter group.</param>
        public RemoveRADParameterGroupMessage(string groupName) { }

    }
}
