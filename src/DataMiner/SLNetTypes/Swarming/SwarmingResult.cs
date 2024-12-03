using System;
using System.Text;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Result of a swarming operation. 
    /// </summary>
    [Serializable]
    public class SwarmingResult
    {
        /// <summary>
        /// whether the swarming was successful or stopped somewhere for a reason
        /// see <see cref="Message"/> for more the reason.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A message in case the swarming action failed.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// A reference to a dataminer object, eg Element, booking, service etc
        /// </summary>
        public DMAObjectRef DmaObjectRef { get; set; }
    }
}