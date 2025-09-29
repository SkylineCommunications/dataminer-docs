using Skyline.DataMiner.Analytics.Communication;
using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to retrieve the relational anomaly detection parameter group names.
    /// Results in a <see cref="GetRADParameterGroupsResponseMessage"/>.
    /// </summary>
    /// <remarks>
    ///     <list type = "bullet" >
    ///         <item>
    ///             <description>From DataMiner 10.5.11/10.6.0 onwards (RN 43440), GetRADParameterGroupsMessage retrieves a list of all RAD parameter groups that have been configured across all Agents in the cluster. In earlier DataMiner versions, it only retrieves the RAD parameter groups hosted on the local Agent.</description>
    ///         </item>
    ///     </list>
    /// </remarks>
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
