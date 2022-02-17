namespace Skyline.DataMiner.Library.Common
{
    /// <summary>
    /// DataMiner object interface.
    /// </summary>
    public interface IDmsObject
    {
		/// <summary>
		/// Returns a value indicating whether the object exists in the DataMiner System.
		/// </summary>
		/// <returns><c>true</c> if the object exists in the DataMiner System; otherwise, <c>false</c>.</returns>
		bool Exists();
    }
}