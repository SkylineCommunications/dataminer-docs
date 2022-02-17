namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner element redundancy settings interface.
	/// </summary>
    public interface IRedundancySettings
    {
		/// <summary>
		/// Gets a value indicating whether the element is derived from another element.
		/// </summary>
		/// <value><c>true</c> if the element is derived from another element; otherwise, <c>false</c>.</value>
		bool IsDerived { get; }
    }
}