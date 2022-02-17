namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Represents the spectrum analyzer monitors.
	/// </summary>
	public interface IDmsSpectrumAnalyzerMonitors
	{
		/// <summary>
		/// Deletes the monitor with the specified ID.
		/// Replaces sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_MONITOR (8), monitorMetaInfo, monitorDetails, out result);
		/// </summary>
		/// <param name="monitorId">The ID of the monitor to be deleted.</param>
		/// <returns></returns>
		int DeleteMonitor(int monitorId);

		/// <summary>
		/// Retrieves all monitors.
		/// Replaces sa.NotifyElement(userID, elementID, SPA_NE_GETINFO (4), SPAI_MONITORS_ALL (7), null, null, out result);
		/// </summary>
		/// <returns>An object representing all monitors.</returns>
		object GetMonitors();

		/// <summary>
		/// Retrieves a single monitor.
		/// Replaces sa.NotifyElementEx(userId,elementInfo.DmaId,elementInfo.ElementId,SPA_NE_GETINFO (4),SPAI_MONITOR (8),monitorId,null,out result);
		/// </summary>
		/// <param name="monitorId">The ID of the monitor to be retrieved.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Monitor not found.</exception>
		object GetMonitor(int monitorId);

		/// <summary>
		/// Updates the monitor with the specified ID.
		/// Replaces sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_MONITOR (8), monitorMetaInfo, monitorDetails, out result);
		/// </summary>
		/// <param name="monitorId">The ID of the monitor.</param>
		/// <param name="monitorDetails">Details describing the monitor.</param>
		/// <returns>ID of the updated monitor.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="monitorDetails"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="monitorDetails"/> must be an array of at least size 6.</exception>
		int UpdateMonitor(int monitorId, string[] monitorDetails);

		/// <summary>
		/// Adds a monitor with the specified settings.
		/// Replaces:sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_MONITOR (8), monitorMetaInfo, monitorDetails, out result);
		/// Where monitorId is set to 2100000000 for creation
		/// </summary>
		/// <param name="monitorDetails">Details of the monitor.</param>
		/// <returns>ID of the added monitor.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="monitorDetails"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="monitorDetails"/> must be an array of at least size 6.</exception>
		int AddMonitor(string[] monitorDetails);
	}
}