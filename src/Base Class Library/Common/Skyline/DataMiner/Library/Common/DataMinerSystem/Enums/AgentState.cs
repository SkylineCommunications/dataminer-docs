namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Specifies the state of the Agent.
	/// </summary>
	public enum AgentState
	{
		/// <summary>
		/// Specifies the not running state.
		/// </summary>
		NotRunning = 0,

        /// <summary>
        /// Specifies the running state.
        /// </summary>
        Running = 1,

        /// <summary>
        /// Specifies the starting state.
        /// </summary>
        Starting = 2,

        /// <summary>
        /// Specifies the unknown state.
        /// </summary>
        Unknown = 3,

        /// <summary>
        /// Specifies the switching state.
        /// </summary>
        Switching = 4
	}
}