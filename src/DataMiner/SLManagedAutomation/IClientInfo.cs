using System;

namespace Skyline.DataMiner.Automation
{
    /// <summary>
    /// Provides the info the client has provided when executing the script.
    /// Can be requested using the <see cref="IEngine.ClientInfo"/> property.
    /// </summary>
    /// <remarks>
    /// <note type="note">Available from DataMiner 10.6.4/10.7.0 onwards.</note> <!-- RN 44742 -->
    /// </remarks>
    public interface IClientInfo
    {
        /// <summary>
        /// Gets the time zone of the client.
        /// If the client did not provide this information, <see langword="null"/> will be returned.
        /// </summary>
        /// <remarks>
        /// <note type="note">Available from DataMiner 10.6.4/10.7.0 onwards, for scripts executed in web apps.</note> <!-- RN 44742 / RN 44788 -->
        /// </remarks>
        TimeZoneInfo TimeZone { get; }
    }
}
