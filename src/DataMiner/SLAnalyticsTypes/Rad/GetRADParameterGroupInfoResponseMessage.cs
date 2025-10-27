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
        /// Returns a string that represents the current message.
        /// </summary>
        /// <returns>A string that represents the current message.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
