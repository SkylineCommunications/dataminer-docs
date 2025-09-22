using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to retrieve the relational anomaly scores for a given time range of historical trend data values.
    /// Results in a <see cref="GetRADDataResponseMessage"/>.
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
        /// Gets or sets the name of the subgroup for which one wants to retrieve anomaly scores in case of a RAD shared model group.
        /// This field does not need to be specified when the group is not a shared model group (i.e. there is only one subgroup of parameter instances).
        /// This field does not need to be specified when SubgroupID has been specified.
        /// Available from DataMiner 10.5.9/10.6.0 onwards.
        /// </summary>
         public string SubgroupName { get; set; }
         /// <summary>
         /// Gets or sets the unique identifier of the subgroup for which one wants to retrieve anomaly scores in case of a RAD shared model group.
         /// This field does not need to be specified when the group is not a shared model group (i.e. there is only one subgroup of parameter instances).
         /// This field does not need to be specified when SubgroupName has been specified.
         /// The unique identifier of the subgroup can be retrieved using the <see cref="GetRADParameterGroupInfoMessage"/> message.
         /// Available from DataMiner 10.5.9/10.6.0 onwards.
         /// </summary>
         public Guid SubgroupID { get; set; } = Guid.Empty;

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
        /// Initializes a new instance of the <see cref="GetRADDataMessage"/> class. Available from DataMiner 10.5.9/10.6.0 onwards.
        /// </summary>
        /// <param name="groupName">Name of the RAD parameter group</param>
        /// <param name="subgroupName">Name of the subgroup for which one wants to retrieve anomaly scores.</param>
        /// <param name="startTime">Start time of the historical time range over which anomaly scores need to be retrieved</param>
        /// <param name="endTime">End time of the historical time range over which anomaly scores need to be retrieved</param>
        public GetRADDataMessage(string groupName, string subgroupName, DateTime startTime, DateTime endTime) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADDataMessage"/> class. Available from DataMiner 10.5.9/10.6.0 onwards.
        /// </summary>
        /// <param name="groupName">Name of the RAD parameter (shared model) group.</param>
        /// <param name="subgroupID">Identifier of the RAD parameter group which is a subgroup of the shared model group.</param>
        /// <param name="startTime">Start time of the historical time range over which anomaly scores need to be retrieved.</param>
        /// <param name="endTime">End time of the historical time range over which anomaly scores need to be retrieved.</param>
        public GetRADDataMessage(string groupName, Guid subgroupID, DateTime startTime, DateTime endTime) {}

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
