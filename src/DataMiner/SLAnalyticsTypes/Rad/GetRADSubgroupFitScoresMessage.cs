using System;

namespace Skyline.DataMiner.Analytics.Rad
{
     /// <summary>
    /// Message to retrieve the model fit quality numbers for the subgroups in a shared model relational anomaly group.
    /// The model fit quality number can be used for identifying potential behavioral outliers among subgroups.   
    /// Results in a <see cref="GetRADSubgroupFitScoresResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class GetRADSubgroupFitScoresMessage : Communication.GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the name of the relational (shared model) anomaly group.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADSubgroupFitScoresMessage"/> class.
        /// </summary>
        /// <param name="groupName">The name of the relational (shared model) anomaly group.</param>
        public GetRADSubgroupFitScoresMessage(string groupName) { }
    }
}