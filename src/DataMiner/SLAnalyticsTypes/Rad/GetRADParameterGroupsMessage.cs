using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to retrieve the relational anomaly detection parameter group names 
    /// Results in a <see cref="GetRADParameterGroupsResponseMessage"/>
    /// </summary>
    [Serializable]
    public class GetRADParameterGroupsMessage : GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRADParameterGroupsMessage"/> class.
        /// </summary>
        public GetRADParameterGroupsMessage() : base() { }

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
