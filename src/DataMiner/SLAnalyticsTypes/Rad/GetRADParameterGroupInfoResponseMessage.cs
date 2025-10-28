using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Response message for GetRADParameterGroupInfoMessage.
    /// </summary>
    [Serializable]
    public class GetRADParameterGroupInfoResponseMessage : ResponseMessage
    {
        /// <summary>
        /// The requested group information.
        /// </summary>
        public RADGroupInfo ParameterGroupInfo { get; set; }

        /// <summary>
        /// The DataMiner ID of the Agent hosting the parameter group. Available from DataMiner 10.5.11/10.6.0 onwards.
        /// </summary>
        public int DataMinerID { get; set; }

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
