using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System.Collections.Generic;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Specifies configuration options for training the RAD model.
    /// </summary>
    [Serializable]
    public class TrainingConfiguration
    {
        /// <summary>
        /// Gets or sets a list of time ranges that will be used to train the RAD model, or null to use the default range.
        /// </summary>
        public List<TimeRange> TimeRanges { get; set; }

        /// <summary>
        /// Gets or sets the names of the subgroups whose data will be excluded from the training of the (shared) model. A subgroup will be excluded if either
        /// its name is in this list, or its index is in <see cref="ExcludedSubgroupIndices"/>. If both lists are empty, no subgroups will be excluded.
        /// </summary>
        public List<string> ExcludedSubgroupNames { get; set; }

        /// <summary>
        /// Gets or sets the index of the subgroups whose data will be excluded from the training of the (shared) model. The index
        /// corresponds to the position of the subgroup in the list of subgroups defined in <see cref="AddRADParameterGroupMessage.ParameterGroupInfo.Subgroups"/>.
        /// A subgroup will be excluded if either 
        /// its index is in this list, or its name is in <see cref="ExcludedSubgroupNames"/>. If both lists are empty, no subgroups will be excluded.
        /// </summary>
        public List<int> ExcludedSubgroupIndices { get; set; }

        /// <summary>
        /// Initializes a new <see cref="TrainingConfiguration"/> using the specified training time ranges.
        /// </summary>
        public TrainingConfiguration(List<TimeRange> timeRanges) { }

        /// <summary>
        /// Initializes a new <see cref="TrainingConfiguration"/> using the specified training time ranges and excluded subgroup names.
        /// </summary>
        public TrainingConfiguration(List<TimeRange> timeRanges, List<string> excludedSubgroupNames) { }

        /// <summary>
        /// Initializes a new <see cref="TrainingConfiguration"/> using the specified training time ranges and excluded subgroup indices.
        /// </summary>
        public TrainingConfiguration(List<TimeRange> timeRanges, List<int> excludedSubgroupIndices) { }
    }

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
        /// Configuration for training the RAD model. Set to null to retain the existing model,
        /// or to use the default training configuration, which uses at most the last 60 days
        /// of available 5-minute average data if no model exists.
        /// Available from DataMiner 10.6.1/10.6.0 onwards.
        /// </summary>
        public TrainingConfiguration TrainingConfiguration { get; set; } = null;

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
