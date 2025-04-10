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
        public List<ParameterKey> Parameters { get; set; }

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
    }
}
