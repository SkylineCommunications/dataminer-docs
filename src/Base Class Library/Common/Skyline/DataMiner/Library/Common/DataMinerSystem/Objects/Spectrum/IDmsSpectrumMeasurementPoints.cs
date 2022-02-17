namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents spectrum analyzer measurement points.
	/// </summary>
	public interface IDmsSpectrumAnalyzerMeasurementPoints
	{
		/// <summary>
		/// Get all spectrum measurement points.
		/// </summary>
		/// <returns>An object representing all measurement points similar to how the interop call returned it.</returns>
		object GetMeasurementPoints();
	}
}