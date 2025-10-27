using System;

namespace Skyline.DataMiner.Analytics.Communication
{
    /// <summary>
    /// Base class for messages that retrieve analytics data. Results in a <see cref="GetAnalyticsResponseMessage"/>.
    /// </summary>
    [Serializable]
    public abstract class GetSessionedAnalyticsMessage : GetAnalyticsMessage
    {
    }
}
