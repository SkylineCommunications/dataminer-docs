using System;

namespace Skyline.DataMiner.Automation
{
    /// <summary>
    /// Event arguments for script events.
    /// </summary>
    public class ScriptEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the script succeeded.
        /// </summary>
        public bool ScriptSucceed { get; }
    }
}
