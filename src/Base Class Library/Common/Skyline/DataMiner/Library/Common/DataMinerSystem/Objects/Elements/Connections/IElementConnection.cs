namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Represents a connection of a DataMiner element.
	/// </summary>
	public interface IElementConnection
	{
		/// <summary>
		/// Gets the value indicating the connection number or sets which connection id should be used during creation.
		/// </summary>
		/// <value>The identifier of the connection.</value>
		int Id { get; }
	}
}