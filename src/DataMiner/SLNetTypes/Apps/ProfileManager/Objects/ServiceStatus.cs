using System;

namespace Skyline.DataMiner.Net.Profiles
{
    [Serializable]
    public enum ServiceStatus
    {
		/// <summary>
		/// Stopped.
		/// </summary>
		Stopped,
		/// <summary>
		/// Standby.
		/// </summary>
		Standby,
		/// <summary>
		/// Paused.
		/// </summary>
		Paused,
		/// <summary>
		/// Running.
		/// </summary>
		Running,
		/// <summary>
		/// Retired.
		/// </summary>
		Retired,
	}
}
