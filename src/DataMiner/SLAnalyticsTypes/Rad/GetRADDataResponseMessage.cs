using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// A data point containing the 5-min. average trend data values, the time stamp of the data point and the anomaly score of the data point according to the RAD model.
    /// </summary>
    [Serializable]
    public class RADDataPoint
    {
        /// <summary>
        /// 5-min. average trend data values.
        /// </summary>
        public List<double> Values { get; set; }

        /// <summary>
        /// Time stamp of the data point.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Anomaly score of the data point according to the RAD model.
        /// </summary>
        public double AnomalyScore { get; set; }

        /// <summary>
        /// Creates a new <see cref="RADDataPoint"/> instance.
        /// </summary>
        public RADDataPoint() { }

        /// <summary>
        /// Creates a new <see cref="RADDataPoint"/> instance with the given values, timestamp, and anomaly score.
        /// </summary>
        /// <param name="values">The 5-min. average trend data values of the parameters in the RAD group.</param>
        /// <param name="timestamp">The time of the data point.</param>
        /// <param name="anomalyScore">The anomaly score according to the RAD model.</param>
        public RADDataPoint(List<double> values, DateTime timestamp, double anomalyScore)
        {
        }
    }

    /// <summary>
    /// Response message for GetRADDataMessage.
    /// </summary>
    [Serializable]
    public class GetRADDataResponseMessage : ResponseMessage
    {

        /// <summary>
        /// The parameters in the RAD group for which the data was requested.
        /// </summary>
        public List<Skyline.DataMiner.Net.Messages.SLDataGateway.ParameterID> Parameters { get; set; }

        /// <summary>
        /// The data points for the parameters in the RAD group.
        /// </summary>
        public List<RADDataPoint> DataPoints { get; set; }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        /// <returns>A string that represents the current message.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
