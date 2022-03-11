namespace Skyline.DataMiner.Library.Common
{
    /// <summary>
    /// Specifies the state of the element.
    /// </summary>
    public enum ElementState
    {
        /// <summary>
        /// Specifies the undefined element state.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Specifies the active element state.
        /// </summary>
        Active = 1,

        /// <summary>
        /// Specifies the hidden element state.
        /// </summary>
        Hidden = 2,

        /// <summary>
        /// Specifies the paused element state.
        /// </summary>
        Paused = 3,

        /// <summary>
        /// Specifies the stopped element state.
        /// </summary>
        Stopped = 4,

        /// <summary>
        /// Specifies the deleted element state.
        /// </summary>
        Deleted = 6,

        /// <summary>
        /// Specifies the error element state.
        /// </summary>
        Error = 10,

        /// <summary>
        /// Specifies the restart element state.
        /// </summary>
        Restart = 11,

        /// <summary>
        /// Specifies the masked element state.
        /// </summary>
        Masked = 12
    }
}