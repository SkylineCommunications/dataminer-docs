using System;

namespace Skyline.DataMiner.Net.ManagerStore
{
	/// <summary>
	/// Interface for tracking the last modification time.
	/// </summary>
	public interface ITrackLastModified
    {
		/// <summary>
		/// Gets or sets the last modification time.
		/// </summary>
		/// <value>The last modification time.</value>
		DateTime LastModified { get; set; }
    }
}
