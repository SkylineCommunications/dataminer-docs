using System;
using Skyline.DataMiner.Analytics.Communication;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Request message to get all relational anomaly detections within a specific time range, across all relational anomaly groups.
    /// Results will be returned in a <see cref="GetRelationalAnomaliesResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class GetAllRelationalAnomaliesMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the start time of the time range for which relational anomalies are requested.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the time range for which relational anomalies are requested.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRelationalAnomaliesMessage"/> class.
        /// </summary>
        public GetAllRelationalAnomaliesMessage(DateTime start, DateTime end) { }
    }
}
