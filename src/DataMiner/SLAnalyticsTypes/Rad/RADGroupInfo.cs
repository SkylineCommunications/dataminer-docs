using System;
using System.Collections.Generic;
using Skyline.DataMiner.Analytics.DataTypes;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Represents information about a parameter group of Relational Anomaly Detection.
    /// </summary>
    [Serializable]
    public class RADGroupInfo 
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of parameters in the group.
        /// </summary>
        [Obsolete("Property is deprecated since DataMiner 10.5.9. Check the Parameters in the Subgroups property instead.")] 
        public List<ParameterKey> Parameters { get; set; }

         /// <summary>
         /// The list of subgroups of parameters. All subgroups will share a RAD model. Available since DataMiner 10.5.9.
         /// </summary>
         public List<RADSubgroupInfo> Subgroups { get; set; }

        /// <summary>
        /// Whether the model is updated automatically on new data.
        /// </summary>
        public bool UpdateModel { get; set; }

        /// <summary>
        /// The threshold for anomaly detection, or null to use the default setting.
        /// </summary>
        public double? AnomalyThreshold { get; set; }

        /// <summary>
        /// The minimum duration in number of minutes for deviating behavior to be considered relevant anomalous behavior, or null to use the default system-wide setting.
        /// </summary>
        public int? MinimumAnomalyDuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RADGroupInfo"/> class.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="parameters">The list of parameters in the group.</param>
        /// <param name="updateModel">Whether the model is updated automatically on new data.</param>
        /// <param name="anomalyThreshold">The threshold for anomaly detection, or null to use the default setting.</param>
        /// <param name="minimumAnomalyDuration">The minimum duration in number of minutes for deviating behavior to be considered relevant anomalous behavior, or null to use the default system-wide setting.</param>
        public RADGroupInfo(string name, List<ParameterKey> parameters, bool updateModel, double? anomalyThreshold = null, int? minimumAnomalyDuration = null)
        {
        }

        /// <summary>  
        /// Initializes a new instance of the <see cref="RADGroupInfo"/> class. Available since DataMiner 10.5.9.
        /// </summary>  
        /// <param name="name">The name of the shared model group.</param>  
        /// <param name="subgroups">The list of subgroups of parameters sharing a model.</param>  
        /// <param name="updateModel">Whether the model is updated automatically on new data.</param>  
        /// <param name="anomalyThreshold">The threshold for anomaly detection, or null to use the default threshold. This threshold is set on the global shared model level. Subgroups can have a specific threshold overriding the shared-model level threshold.</param>  
        /// <param name="minimumAnomalyDuration">The minimum duration in number of minutes for deviating behavior to be considered relevant anomalous behavior, 
        /// or null to use the default system-wide value. Subgroups can have a specific minimum anomaly duration setting overriding this shared model level value.</param>  
        public RADGroupInfo(string name, List<RADSubgroupInfo> subgroups, bool updateModel, double? anomalyThreshold = null, int? minimumAnomalyDuration = null) :
            base(name, subgroups, updateModel, anomalyThreshold, minimumAnomalyDuration)
        {
        }
    }
}
