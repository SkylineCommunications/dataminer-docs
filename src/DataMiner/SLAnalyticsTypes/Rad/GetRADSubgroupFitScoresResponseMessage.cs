using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{

    [Serializable]
    public class RADSubgroupFitScore
    {
        /// <summary>
        /// Gets or sets the unique identifier of the subgroup.
        /// </summary>
        public Guid SubgroupID { get; set; }

        /// <summary>
        /// Gets or sets the model data fit value for the subgroup.
        /// A high ModelFit value (i.e. a value close to 1) indicates that the subgroup's behavior closely aligns with the overall model.
        /// A low ModelFit value (i.e. a value closer to 0) indicates that the subgroup's behavior deviates significantly from the behavior learned by the overall model.
        /// </summary>
        public double ModelFit { get; set; }

        /// <summary>
        /// Gets or sets whether the subgroup behaves as an outlier compared to other subgroups that use the same shared model.
        /// This value is automatically determined by comparing the subgroup's ModelFit against the ModelFit values of the other subgroups.
        /// Available from DataMiner 10.6.0/10.6.1 onwards.
        /// </summary>
        public bool IsOutlier { get; set; }
    }

    /// <summary>
    /// Response message for <see cref="GetRADSubgroupFitScoresMessage"/>.
    /// </summary>
    [Serializable]
    public class GetRADSubgroupFitScoresResponseMessage : ResponseMessage
    {

        /// <summary>
        /// Gets or sets the list of subgroup fit scores.
        /// </summary>
        public List<RADSubgroupFitScore> SubgroupFitScores { get; set; }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(GetRADSubgroupFitScoresResponseMessage)}";
        }

    }
}