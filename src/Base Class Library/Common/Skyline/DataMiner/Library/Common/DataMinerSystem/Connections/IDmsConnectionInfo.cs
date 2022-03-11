namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner element connection information interface.
	/// </summary>
    public interface IDmsConnectionInfo
    {
		/// <summary>
		/// Gets the connection name.
		/// </summary>
		/// <value>The connection name.</value>
		string Name { get; }

		/// <summary>
		/// Gets the connection type.
		/// </summary>
		/// <value>The connection type.</value>
		ConnectionType Type { get; }
    }
}