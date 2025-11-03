using System;
using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Analytics.DataTypes;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Request message to get relational anomaly detections for a specific parameter instance and time range.
    /// Results will be returned in a <see cref="GetRelationalAnomaliesResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class GetRelationalAnomaliesMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the <see cref="ParameterKey"/> representing the target parameter for fetching relational anomaly detections.
        /// </summary>
        public ParameterKey ParameterKey { get; set; }
     
        /// <summary>
        /// Gets or sets the start time of the time range for which relational anomalies are requested.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the time range for which relational anomalies are requested.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRelationalAnomaliesMessage"/> class.
        /// </summary>
        public GetRelationalAnomaliesMessage(ParameterKey parameterKey, DateTime start, DateTime end) { }
    }
}
