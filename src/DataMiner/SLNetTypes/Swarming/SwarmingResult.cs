using System;
using System.Text;

namespace Skyline.DataMiner.Net.Swarming
{
    /// <summary>
    /// Result of a swarming operation. See <see cref="Helper.SwarmingHelper"/>.
    /// </summary>
    [Serializable]
    public class SwarmingResult
    {
        /// <summary>
        /// Whether the swarming was successful or stopped somewhere for some reason.
        /// See <see cref="Message"/> for the reason.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A message in case the swarming action failed.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// A reference to a DataMiner object, e.g. element, booking, service, etc.
        /// </summary>
        public DMAObjectRef DmaObjectRef { get; set; }
    }
}