namespace Skyline.DataMiner.Library.Common
{
    /// <summary>
    /// The alarm level of an element, parameter or alarm.
    /// </summary>
    public enum AlarmLevel
    {
        /// <summary>
        /// No alarm
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Normal
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Warning
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Minor
        /// </summary>
        Minor = 3,

        /// <summary>
        /// Major
        /// </summary>
        Major = 4,

        /// <summary>
        /// Critical
        /// </summary>
        Critical = 5,

        /// <summary>
        /// Information
        /// </summary>
        Information = 6,

        /// <summary>
        /// Timeout
        /// </summary>
        Timeout = 7,

        /// <summary>
        /// Initial
        /// </summary>
        Initial = 8,

        /// <summary>
        /// Masked
        /// </summary>
        Masked = 9,

        /// <summary>
        /// Error
        /// </summary>
        Error = 10,

        /// <summary>
        /// Notice
        /// </summary>
        Notice = 11,

        /// <summary>
        /// Suggestion
        /// </summary>
        Suggestion = 12
    }
}