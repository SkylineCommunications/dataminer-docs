using System;
using System.Collections.Generic;
using Skyline.DataMiner.Analytics.Communication;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Represents a time range with a start and end time.
    /// </summary>
    [Serializable]
    public class TimeRange
    {
        /// <summary>
        /// Gets or sets the start time of the time range.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time of the time range.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeRange"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        public TimeRange(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    /// <summary>
    /// Message class for triggering a retraining of the Relational Anomaly Detection (RAD) model.
    /// Results in a <see cref="RetrainRADModelResponseMessage"/>
    /// </summary>
    [Serializable]
    public class RetrainRADModelMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the name of the group for which RAD retraining is triggered.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the start time of the range of normal behavior used for retraining.
        /// When set, the corresponding time range is added or updated in <see cref="RetrainTimeRanges" />.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the range of normal behavior used for retraining.
        /// When set, the corresponding time range is added or updated in <see cref="RetrainTimeRanges" />.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets a list of time ranges that will be used to retrain the RAD model.
        /// </summary>
        public List<TimeRange> RetrainTimeRanges { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrainRADModelMessage"/> class.
        /// </summary>
        public RetrainRADModelMessage() { }

        /// <summary>
        /// Initializes a new instance with the specified parameters.
        /// </summary>
        /// <param name="groupName">The name of the group whose RAD model needs to be retrained.</param>
        /// <param name="correctBehaviorTimeRanges">A list of time ranges representing correct behavior, i.e. the training data.</param>        
        public RetrainRADModelMessage(string groupName, List<TimeRange> correctBehaviorTimeRanges) { }

        /// <summary>
        /// Initializes a new instance with the specified parameters.
        /// </summary>
        /// <param name="groupName">The name of the group whose RAD model needs to be retrained.</param>
        /// <param name="startTime">start time of the time range with correct behavior.</param>
        /// <param name="endTime">end time of the time range with correct behavior.</param>
        public RetrainRADModelMessage(string groupName, DateTime startTime, DateTime endTime) {}
    }
}
