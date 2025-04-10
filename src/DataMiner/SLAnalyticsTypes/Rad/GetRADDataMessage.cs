using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to retrieve the relational anomaly scores for a given time range of historical trend data values
    /// Results in a <see cref="GetRADDataResponseMessage"/>
    /// </summary>
    [Serializable]
    public class GetRADDataMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the name of the RAD parameter group.
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Gets or sets the start time of the historical time range over which anomaly scores need to be retrieved.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time of the historical time range over which anomaly scores need to be retrieved.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADDataMessage"/> class.
        /// </summary>
        public GetRADDataMessage() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADDataMessage"/> class.
        /// </summary>
        /// <param name="groupName">Name of the RAD parameter group</param>
        /// <param name="startTime">Start time of the historical time range over which anomaly scores need to be retrieved</param>
        /// <param name="endTime">End time of the historical time range over which anomaly scores need to be retrieved</param>
        public GetRADDataMessage(string groupName, DateTime startTime, DateTime endTime) { }

        /// <summary>
        /// Converts the message to a string.
        /// </summary>
        /// <returns>A string representing the message.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
