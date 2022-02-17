namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner property entry interface.
	/// </summary>
	public interface IDmsPropertyEntry
	{
		/// <summary>
		/// Gets the internal value.
		/// </summary>
		int Metric { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		string Value { get; }
	}
}