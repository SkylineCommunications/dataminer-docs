using System;
using System.Collections.Generic;
using Skyline.DataMiner.Analytics.DataTypes;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Represents information about a parameter instance used in a RAD subgroup. Available from DataMiner 10.5.9/10.6.0 onwards.
    /// </summary>
    [Serializable]
    public class RADParameter
    {
        /// <summary>
        /// The parameter key of the parameter.
        /// </summary>
        public ParameterKey Key { get; set; }

        /// <summary>
        /// The label of the parameter. 
        /// When a shared model group contains multiple subgroups, parameter labels are used to identify
        /// and differentiate the parameters within those subgroups.  
        ///
        /// Example:
        /// - Group A has two parameters: { param1: label = "Temperature", param2: label = "Fan Speed" }  
        /// - Group B has two parameters: { param3: label = "Fan Speed", param4: label = "Temperature" }  
        ///
        /// Note that parameters with the same label (e.g., "Temperature" or "Fan Speed") do not
        /// necessarily come from the same connector.  
        ///
        /// If a parameter label is not specified (null or empty), you must ensure that all
        /// `RADSubgroupInfo` subgroups define their parameters in a consistent order.
        /// </summary>
        public string Label { get; set; }

        public RADParameter() { }

        public RADParameter(ParameterKey key, string label) { }

        public RADParameter(ParameterKey key) {}
    }


    /// <summary>
    /// Represents information about a subgroup of a Relational Anomaly Detection shared model group. Available from DataMiner 10.5.9/10.6.0 onwards.
    /// </summary>
    [Serializable]
    public class RADSubgroupInfo
    {
        /// <summary>
        /// If specified (i.e. not null or empty), the name of the subgroup. 
        /// If not specified, the subgroup will receive the name of the shared model group it is part of.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters in the subgroup.
        /// In case multiple RADSubGroupInfo objects are defined for the same shared model group, the parameters in the subgroups need to be consistent with each other.
        /// This means that either the parameters in the subgroups have the same label, or have consistent order of the parameters in them.
        /// </summary>
        public List<RADParameter> Parameters { get; set; }

        /// <summary>
        /// If specified, this determines the threshold for anomaly detection overriding the anomaly threshold set on the shared model group it is part of.
        /// If not specified (null), the anomaly threshold set on the shared model group will be used, or the default setting if the anomaly threshold is not set on shared model group level.
        /// </summary>
        public double? AnomalyThreshold { get; set; }

        /// <summary>
        /// The minimum duration in number of minutes for deviating behavior to be considered relevant anomalous behavior:
        /// If specified, this overrides the minimum anomaly duration set on the shared model group it is part of.
        /// If not specified (null), the minimum anomaly duration set on the shared model group is used (or the default setting if it is not set).
        /// </summary>
        public int? MinimumAnomalyDuration { get; set; }

        /// <summary>
        /// The unique identifier for the subgroup. Set by the server.
        /// </summary>
        public Guid ID { get; set; } = Guid.Empty;

        /// <summary>
        /// Indicates whether the subgroup is currently being monitored, or whether there was an error such that the subgroup can no longer be monitored (check the SLAnalytics logging for more details on the error).
        /// </summary>
        public bool IsMonitored { get; set; } = true;
        
         /// <summary>
        /// Initializes a new instance of the <see cref="RADSubgroupInfo"/> class.
        /// </summary>
        public RADSubgroupInfo() {} 

         /// <summary>
        /// Initializes a new instance of the <see cref="RADSubgroupInfo"/> class.
        /// </summary>
        /// <param name="parameters">The parameters in the subgroup.</param>
        public RADSubgroupInfo(List<RADParameter> parameters) {}
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RADSubgroupInfo"/> class.
        /// </summary>
        /// <param name="name">The name of the subgroup.</param>
        /// <param name="parameters">The parameters in the subgroup.</param>
        /// <param name="anomalyThreshold">The threshold for anomaly detection overriding the anomaly threshold set on the shared model group it is part of. If not specified (null), the anomaly threshold set on the shared model group is used (or the default setting if it is not set on shared model group level).</param>
        /// <param name="minimumAnomalyDuration">The minimum duration in number of minutes for deviating behavior to be considered relevant anomalous behavior: If specified, this overrides the minimum anomaly duration set on the shared model group it is part of. If not specified (null), the minimum anomaly duration set on the shared model group is used (or the default setting if it is not set).</param>
        public RADSubgroupInfo(string name, List<RADParameter> parameters, double? anomalyThreshold = null, int? minimumAnomalyDuration = null) {}
        
    }
}

