namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner service configuration interface for included elements or services.
	/// </summary>
	public interface IServiceParamConfiguration
	{
		/// <summary>
		/// Gets or sets the Alias of the service.
		/// </summary>
		string Alias { get; set; }
		
		/// <summary>
		/// Gets or sets the included capped alarm level of the element or service.
		/// </summary>
		AlarmLevel IncludedCapped { get; set; }

		/// <summary>
		/// Gets the index of the element or service.
		/// </summary>
		int Index { get; }

		/// <summary>
		/// Gets or sets a value indicating whether the element is excluded.
		/// </summary>
		bool IsExcluded { get; set; }

		/// <summary>
		/// Gets a value indicating whether the element is a service.
		/// </summary>
		bool IsService { get; }

		/// <summary>
		/// Gets or sets the not used capped alarm level of the element.
		/// </summary>
		AlarmLevel NotUsedCapped { get; set; }
	}
}