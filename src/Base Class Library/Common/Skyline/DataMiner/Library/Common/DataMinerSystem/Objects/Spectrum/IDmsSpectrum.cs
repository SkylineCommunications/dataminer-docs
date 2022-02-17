namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents the spectrum analyzer component of an element.
	/// </summary>
	public interface IDmsSpectrumAnalyzer
	{
		/// <summary>
		/// Gets the spectrum analyzer monitors.
		/// </summary>
		/// <value>The spectrum analyzer monitors.</value>
		IDmsSpectrumAnalyzerMonitors Monitors { get; }

		/// <summary>
		/// Gets the spectrum analyzer presets.
		/// </summary>
		/// <value>The spectrum analyzer presets.</value>
		IDmsSpectrumAnalyzerPresets Presets { get; }

		/// <summary>
		/// Gets the spectrum analyzer scripts.
		/// </summary>
		/// <value>The spectrum analyzer scripts.</value>
		IDmsSpectrumAnalyzerScripts Scripts { get; }

		/// <summary>
		/// Retrieves the measurement points.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_GETINFO (4), SPAI_MEASUREMENT_POINTS (29), null, null, out result);
		/// </summary>
		/// <returns>The measurement points.</returns>
		object GetMeasurementPoints();

		/// <summary>
		/// Sets the specified measurement points.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_MEASUREMENT_POINTS (29), createServices, measptdata, out result);
		/// </summary>
		/// <param name="createServices">When <c>true</c>, services will be created for the measurement points.</param>
		/// <param name="measurementPointData">An image of all measurement points.</param>
		/// <returns>All measurement point IDs.</returns>
		int[] SetMeasurementPoints(bool createServices, object[] measurementPointData);
	}
}