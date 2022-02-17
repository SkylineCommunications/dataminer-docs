namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner service advanced settings interface.
	/// </summary>
	public interface IServiceParamsSettings
	{
		/// <summary>
		/// Gets the included parameters.
		/// </summary>
		ServiceParamSettings[] IncludedParameters { get; }
	}
}