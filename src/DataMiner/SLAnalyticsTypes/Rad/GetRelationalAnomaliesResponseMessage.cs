using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Analytics.DataTypes;

namespace Skyline.DataMiner.Analytics.Rad
{
    [Serializable]
    public class RelationalAnomalyRecord 
    {
        /// <summary>
        /// Identifier of the anomaly. Each parameter involved in the anomaly gets its own record, but they all share the same AnomalyID.
        /// </summary>
        public Guid AnomalyID { get; set; }

        /// <summary>
        /// Parameter instance on which the relational anomaly was detected.
        /// </summary>
        public ParameterKey ParameterKey { get; set; }

        /// <summary>
        /// The time point where the first anomalous values were detected.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The last registered time point where the anomalous values were still confirmed
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Name of the Relational Anomaly Detection group that detected the anomaly.
        ///</summary>
        public string GroupName { get; set; }

        /// <summary>
        /// If specified (i.e. not null or empty), the name of the subgroup that detected the anomaly. 
        /// </summary>
        public string SubgroupName { get; set; }

        /// <summary>
        /// Score indicating the severity of the anomaly. The higher the score, the more severe the anomaly.
        /// </summary>
        public double AnomalyScore { get; set; }

        /// <summary>
        /// The unique identifier of the subgroup that detected the anomaly.
        /// </summary>
        public Guid SubgroupID { get; set; }
    }

    /// <summary>
    /// Response for <see cref="GetRelationalAnomaliesMessage "/> and <see cref="GetAllRelationalAnomaliesMessage"/>.
    /// </summary>
    [Serializable]
    public class GetRelationalAnomaliesResponseMessage : ResponseMessage
    {
        public List<RelationalAnomalyRecord> Anomalies { get; set; }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(GetRelationalAnomaliesResponseMessage)}: {Anomalies?.Count ?? 0} anomalies.";
        }
    }
}
