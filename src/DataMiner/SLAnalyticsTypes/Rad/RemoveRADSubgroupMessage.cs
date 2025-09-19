using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to remove a subgroup from an already existing Relational Anomaly Detection (RAD) shared model group. Available since DataMiner 10.5.9.
    /// This message can be used to remove a subgroup from the shared model group without having to delete or retrain the entire shared model group.
    /// Results in a <see cref="RemoveRADParameterGroupResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class RemoveRADSubgroupMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The name of the shared model group from which the subgroup will be removed.
        /// </summary>
        public string SharedModelGroupName { get; set; }

        /// <summary>
        /// The name of the subgroup to be removed.
        /// This field does not need to be specified when SubgroupID has been specified.
        /// </summary>
        public string SubgroupName { get; set; }

        /// <summary>
        /// The unique identifier of the subgroup to be removed.
        /// This field does not need to be specified when SubgroupName has been specified.
        /// The unique identifier of the subgroup can be retrieved using the <see cref="GetRADParameterGroupInfoMessage"/> message.
        /// </summary>
        public Guid SubgroupID { get; set; } = Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveRADSubgroupMessage"/> class.
        /// </summary>
        public RemoveRADSubgroupMessage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveRADSubgroupMessage"/> class.
        /// </summary>
        /// <param name="sharedModelGroupName">The name of the shared model group.</param>
        /// <param name="subGroupName">The name of the subgroup to be removed.</param>
        public RemoveRADSubgroupMessage(string sharedModelGroupName, string subGroupName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveRADSubgroupMessage"/> class.
        /// </summary>
        /// <param name="sharedModelGroupName">The name of the shared model group.</param>
        /// <param name="subgroupID">The identifier of the subgroup.</param>
        public RemoveRADSubgroupMessage(string sharedModelGroupName, Guid subgroupID) { }
    }
}
