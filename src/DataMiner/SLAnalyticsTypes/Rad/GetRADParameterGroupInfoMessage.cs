using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
   /// <summary>
   /// Message to get information about a parameter group with Relational Anomaly Detection.
   /// </summary>
   [Serializable]
   public class GetRADParameterGroupInfoMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADParameterGroupInfoMessage"/> class.
        /// </summary>
        public GetRADParameterGroupInfoMessage() : base(){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADParameterGroupInfoMessage"/> class.
        /// </summary>
        /// <param name="groupName">The name of the parameter group.</param>
        public GetRADParameterGroupInfoMessage(string groupName) { }
    }
}
