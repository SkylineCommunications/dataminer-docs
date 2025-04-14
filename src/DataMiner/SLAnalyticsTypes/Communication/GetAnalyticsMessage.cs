using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Analytics.Communication
{
    /// <summary>
    /// Base class for messages that retrieve analytics data. Results in a <see cref="GetAnalyticsResponseMessage"/>.
    /// </summary>
    [Serializable]
    public abstract class GetAnalyticsMessage : TargetedClientRequestMessage, IGetAnalyticsMessage
    {
        /// <summary>
        /// Gets the time span to wait for a response before timing out.
        /// </summary>
        public TimeSpan Timeout { get; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Convert the message to a string.
        /// </summary>
        /// <returns>A string representing the message.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
