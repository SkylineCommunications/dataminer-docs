using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Rad
{

    /// <summary>
    /// Response message for RenameRADParameterGroupMessage.
    /// </summary>
    [Serializable]
    public class RenameRADParameterGroupResponseMessage : ResponseMessage
    {
        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        /// <returns>A string that represents the current message.</returns>
        public override string ToString()
        {
            return $"{nameof(RenameRADParameterGroupResponseMessage)}";
        }

    }
}
