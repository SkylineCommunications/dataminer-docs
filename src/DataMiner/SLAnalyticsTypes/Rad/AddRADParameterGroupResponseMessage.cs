using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Response message for AddRADParameterGroupMessage.
    /// </summary>
    [Serializable]
    public class AddRADParameterGroupResponseMessage : ResponseMessage
    {
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
