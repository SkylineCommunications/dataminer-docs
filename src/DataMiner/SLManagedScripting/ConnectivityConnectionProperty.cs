namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) connection property.
	/// </summary>
	public class ConnectivityConnectionProperty
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityConnectionProperty"/> class.
		/// </summary>
		public ConnectivityConnectionProperty() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityConnectionProperty"/> class.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="value">The value of the connection property.</param>
		/// <param name="type">The type of the connection property.</param>
		/// <param name="name">The name of the connection property.</param>
		public ConnectivityConnectionProperty(int id, string value, string type, string name) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityConnectionProperty"/> class.
		/// </summary>
		/// <param name="id">The ID of the connection property.</param>
		/// <param name="value">The value of the connection property.</param>
		/// <param name="type">The type of the connection property.</param>
		/// <param name="name">The name of the connection property.</param>
		/// <param name="itf">The connection to which this connection property belongs.</param>
		public ConnectivityConnectionProperty(int id, string value, string type, string name, ConnectivityConnection itf) { }

		/// <summary>
		/// Gets or sets the connection to which this connection property belongs.
		/// </summary>
		/// <value>The connection to which this connection property belongs.</value>
		public ConnectivityConnection Connection { get; set; }

		/// <summary>
		/// Gets or sets the ID of this connection property.
		/// </summary>
		/// <value>The ID of this connection property.</value>
		public int ConnectionPropertyId { get; set; }

		/// <summary>
		/// Gets or sets the name of this connection property.
		/// </summary>
		/// <value>The name of this connection property.</value>
		public string ConnectionPropertyName { get; set; }

		/// <summary>
		/// Gets or sets the type of this connection property.
		/// </summary>
		/// <value>The type of this connection property.</value>
		public string ConnectionPropertyType { get; set; }

		/// <summary>
		/// Gets or sets the value of this connection property.
		/// </summary>
		/// <value>The value of this connection property.</value>
		public string ConnectionPropertyValue { get; set; }

		/// <summary>
		/// Deletes this connection property.
		/// </summary>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool Delete() { return true; }

		/// <summary>
		/// Deletes this connection property.
		/// </summary>
		/// <param name="both"><c>true</c> if the property should be deleted at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool Delete(bool both) { return true; }

		/// <summary>
		/// Updates this connection property.
		/// </summary>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool Update() { return true; }

		/// <summary>
		/// Updates this connection property.
		/// </summary>
		/// <param name="both"><c>true</c> if the property should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool Update(bool both) { return true; }
	}
}
