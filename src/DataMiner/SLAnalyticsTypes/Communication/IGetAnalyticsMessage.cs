using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Analytics.Communication
{
    /// <summary>
    /// Interface for messages that are used to retrieve analytics data.
    /// </summary>
    public interface IGetAnalyticsMessage
    {
        /// <summary>
        /// Gets the time span to wait for a response before timing out.
        /// </summary>
        TimeSpan Timeout { get; }
    }
}
