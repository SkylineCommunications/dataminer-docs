using System;

namespace Skyline.DataMiner.Automation
{
    /// <summary>
    /// Event arguments for script events.
    /// </summary>
    public class DestroyEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the script succeeded.
        /// </summary>
        /// <value><c>true</c> if the script succeeded; otherwise, <c>false</c>.</value>
        public bool ScriptSucceeded { get; }
    }
}
