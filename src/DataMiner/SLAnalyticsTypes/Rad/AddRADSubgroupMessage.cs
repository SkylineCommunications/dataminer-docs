using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to add a subgroup to an already existing relational anomaly group. Available since DataMiner 10.5.9.
    /// </summary>
    [Serializable]
    public class AddRADSubgroupMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The name of the shared model group to which the subgroup will be added.
        /// </summary>
        public string SharedModelGroupName { get; set; }

        /// <summary>
        /// The subgroup information.
        /// </summary>
        public RADSubgroupInfo SubgroupInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRADSubgroupMessage"/> class.
        /// </summary>
        public AddRADSubgroupMessage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRADSubgroupMessage"/> class.
        /// </summary>
        /// <param name="sharedModelGroupName">The name of the shared model group to which the subgroup will be added.</param>
        /// <param name="subgroupInfo">The subgroup information.</param>
        public AddRADSubgroupMessage(string sharedModelGroupName, RADSubgroupInfo subgroupInfo) { }

    }
}
    