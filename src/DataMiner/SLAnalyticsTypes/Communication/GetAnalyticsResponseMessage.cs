using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Communication
{
    /// <summary>
    /// Base class for all response messages that are sent in response to a <see cref="GetAnalyticsMessage"/>.
    /// </summary>
    [Serializable]
    public abstract class GetAnalyticsResponseMessage : ResponseMessage, IGetAnalyticsResponseMessage
    {
        /// <summary>
        /// Convert the response to a string.
        /// </summary>
        /// <returns>A string representing the response.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
