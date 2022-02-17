namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) interface parameter.
	/// </summary>
	public class ConnectivityInterfaceParameter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterfaceParameter"/> class.
		/// </summary>
		public ConnectivityInterfaceParameter() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterfaceParameter"/> class using the parameter ID and index.
		/// </summary>
		/// <param name="id">The ID of the parameter.</param>
		/// <param name="index">The index.</param>
		public ConnectivityInterfaceParameter(int id, string index) { }

		/// <summary>
		/// Gets the ID of the interface parameter.
		/// </summary>
		/// <value>The ID of the interface parameter.</value>
		public int InterfaceParameterId { get; }

		/// <summary>
		/// Gets the index of the interface parameter.
		/// </summary>
		/// <value>The index of the interface parameter.</value>
		public string InterfaceParameterIndex { get; }
	}
}
