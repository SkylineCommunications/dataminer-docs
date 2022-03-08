namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) interface property.
	/// </summary>
	public class ConnectivityInterfaceProperty
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterfaceProperty"/> class.
		/// </summary>
		public ConnectivityInterfaceProperty() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterfaceProperty"/> class.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <param name="value">The value of the interface property.</param>
		/// <param name="type">The type of the interface property.</param>
		/// <param name="name">The name of the interface property.</param>
		public ConnectivityInterfaceProperty(int id, string value, string type, string name) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterfaceProperty"/> class.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <param name="value">The value of the interface property.</param>
		/// <param name="type">The type of the interface property.</param>
		/// <param name="name">The name of the interface property.</param>
		/// <param name="itf">The interface this property belongs to.</param>
		public ConnectivityInterfaceProperty(int id, string value, string type, string name, ConnectivityInterface itf) { }

		/// <summary>
		/// Gets or sets the interface this interface property belongs to.
		/// </summary>
		/// <value>The interface this interface property belongs to.</value>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 8854).</para>
		/// </remarks>
		public ConnectivityInterface Interface { get; set; }

		/// <summary>
		/// Gets or sets the ID of the interface property.
		/// </summary>
		/// <value>The ID of the interface property.</value>
		/// <remarks>
		/// <para>Can be set from DataMiner 8.5.3 (RN 8854) onwards.</para>
		/// </remarks>
		public int InterfacePropertyId { get; set; }

		/// <summary>
		/// Gets or sets the name of the interface property.
		/// </summary>
		/// <value>The name of the interface property.</value>
		/// <remarks>
		/// <para>Can be set from DataMiner 8.5.3 (RN 8854) onwards.</para>
		/// </remarks>
		public string InterfacePropertyName { get; set; }

		/// <summary>
		/// Gets or sets the type of the interface property.
		/// </summary>
		/// <value>The type of the interface property.</value>
		/// <remarks>
		/// <para>Can be set from DataMiner 8.5.3 (RN 8854) onwards.</para>
		/// </remarks>
		public string InterfacePropertyType { get; set; }

		/// <summary>
		/// Gets or sets the value of the interface property.
		/// </summary>
		/// <value>The value of the interface property.</value>
		/// <remarks>
		/// <para>Can be set from DataMiner 8.5.3 (RN 8854) onwards.</para>
		/// </remarks>
		public string InterfacePropertyValue { get; set; }

		/// <summary>
		/// Deletes this property from the interface.
		/// </summary>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 8854).</para>
		/// </remarks>
		public bool Delete() { return true; }

		/// <summary>
		/// Updates this property.
		/// </summary>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 8.5.3 (RN 8854).</para>
		/// </remarks>
		public bool Update() { return true; }
	}
}
