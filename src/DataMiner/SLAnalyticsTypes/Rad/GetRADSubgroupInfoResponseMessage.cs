using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Response message for GetRADSubgroupInfoMessage.
    /// </summary>
    [Serializable]
    public class GetRADSubgroupInfoResponseMessage : ResponseMessage
    {
        /// <summary>
        /// The requested subgroup information.
        /// </summary>
        public RADSubgroupInfo Info { get; set; }

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
