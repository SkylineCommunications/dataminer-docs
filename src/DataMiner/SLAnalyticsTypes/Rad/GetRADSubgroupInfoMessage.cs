using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to get information about a subgroup (identified by <see cref="SubgroupID"/>) within a RAD parameter group.
    /// </summary>
    [Serializable]
    public class GetRADSubgroupInfoMessage : Communication.GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the subgroup.
        /// </summary>
        public Guid SubgroupID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADSubgroupInfoMessage"/> class.
        /// </summary>
        /// <param name="subgroupID">The subgroup identifier.</param>
        public GetRADSubgroupInfoMessage(Guid subgroupID) { }
    }
}
