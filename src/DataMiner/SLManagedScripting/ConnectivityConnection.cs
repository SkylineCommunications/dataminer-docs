using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) connection.
	/// </summary>
	public class ConnectivityConnection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityConnection"/> class.
		/// Gets a value indicating whether 
		/// </summary>
		public ConnectivityConnection() { }

		// NOTE: Not documented.
		//public ConnectivityConnection(int DMAId, int EId, InterfaceConnectionInfoEventMessage.InterfaceConnectionInfo info) { }

		// NOTE: Not documented.
		//public ConnectivityConnection(int DMAId, int EId, InterfaceConnectionInfoEventMessage.InterfaceConnectionInfo info, SLProtocol engine) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityConnection"/> class.
		/// </summary>
		/// <param name="DMAId">The DataMiner Agent ID of the element that owns the connection.</param>
		/// <param name="EId">The element ID of the element that owns the connection.</param>
		/// <param name="connId">The ID of the connection.</param>
		/// <param name="connName">The name of the connection.</param>
		/// <param name="sourceItf">The ID of the source interface.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="destDma">The DataMiner Agent ID of the element that owns the destination interface.</param>
		/// <param name="destEid">The element ID of the element that owns the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="engine">Link with SLProtocol process.</param>
		public ConnectivityConnection(int DMAId, int EId, int connId, string connName, int sourceItf, int destItf, int destDma, int destEid, string filter, SLProtocol engine) { }

		/// <summary>
		/// Gets the connection filter.
		/// </summary>
		/// <value>The connection filter.</value>
		public string ConnectionFilter { get; }

		/// <summary>
		/// Gets the ID of the connection.
		/// </summary>
		/// <value>The ID of the connection.</value>
		public int ConnectionId { get; }

		/// <summary>
		/// Gets the name of the connection.
		/// </summary>
		/// <value>The name of the connection.</value>
		public string ConnectionName { get; }

		/// <summary>
		/// Gets the properties of the connection.
		/// </summary>
		/// <value>The properties of the connection.</value>
		public Dictionary<int, ConnectivityConnectionProperty> ConnectionProperties { get; }

		/// <summary>
		/// Gets the DataMiner Agent ID of the element that owns the destination interface.
		/// </summary>
		/// <value>The DataMiner Agent ID of the element that owns the destination interface.</value>
		public int DestinationDMAId { get; }

		/// <summary>
		/// Gets the element ID of the element that owns the destination interface.
		/// </summary>
		/// <value>The element ID of the element that owns the destination interface.</value>
		public int DestinationEId { get; }

		/// <summary>
		/// Gets the ID of the destination interface.
		/// </summary>
		/// <value>The ID of the destination interface.</value>
		public int DestinationInterfaceId { get; }

		/// <summary>
		/// Gets a value indicating whether this interface is internal.
		/// </summary>
		/// <value><c>true</c> if this is an internal interface; otherwise, <c>false</c>.</value>
		public bool IsInternal { get; }

		/// <summary>
		/// Gets the DataMiner Agent ID of the element that owns the source interface.
		/// </summary>
		/// <value>The DataMiner Agent ID of the element that owns the source interface.</value>
		public int SourceDataMinerId { get; }

		/// <summary>
		/// Gets the element ID of the element that owns the source interface.
		/// </summary>
		/// <value>The element ID of the element that owns the source interface.</value>
		public int SourceElementId { get; }

		/// <summary>
		/// Gets the ID of the source interface.
		/// </summary>
		/// <value>The ID of the source interface.</value>
		public int SourceInterfaceId { get; }

		/// <summary>
		/// Adds the specified property to this connection.
		/// </summary>
		/// <param name="prop">The property to add.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		public bool AddProperty(ConnectivityConnectionProperty prop) { return true; }

		/// <summary>
		/// Adds the specified connection property to this connection.
		/// </summary>
		/// <param name="prop">The connection property to add.</param>
		/// <param name="both"><c>true</c> if the property should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>When <paramref name="both"/> is set to true, the connection must be known by both the source and destination element.</para>
		/// </remarks>
		public bool AddProperty(ConnectivityConnectionProperty prop, bool both) { return true; }

		/// <summary>
		/// Adds the specified connection property to this connection.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">The type of the property.</param>
		/// <param name="value">The value of the property.</param>
		/// <param name="id">The ID of the property.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		public bool AddProperty(string name, string type, string value, out int id) { id = 0; return true; }

		/// <summary>
		/// Adds the specified connection property to this connection.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">The property type.</param>
		/// <param name="value">The property value.</param>
		/// <param name="id">The ID of the property.</param>
		/// <param name="both"><c>true</c> if the property should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>When <paramref name="both"/> is set to true, the connection must be known by both the source and destination element.</para>
		/// </remarks>
		public bool AddProperty(string name, string type, string value, out int id, bool both) { id = 0;  return true; }

		/// <summary>
		/// Adds the specified connection property to this connection.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">The property type.</param>
		/// <param name="value">The property value.</param>
		/// <param name="prop">The created property.</param>
		/// <param name="timeoutMs">The property addition timeout.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the property was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddProperty(string name, string type, string value, out ConnectivityConnectionProperty prop, int timeoutMs) { prop = null;  return true; }

		/// <summary>
		/// Adds the specified connection property to this connection.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">The property type.</param>
		/// <param name="value">The property value.</param>
		/// <param name="prop">The created property.</param>
		/// <param name="timeoutMs">The property addition timeout.</param>
		/// <param name="both"><c>true</c> if the property should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if adding the property succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the property was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddProperty(string name, string type, string value, out ConnectivityConnectionProperty prop, int timeoutMs, bool both) { prop = null;  return true; }

		/// <summary>
		/// Deletes the specified connection.
		/// </summary>
		/// <param name="deleteBothConnections"><c>true</c> if the connection should be deleted from both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>This will also delete the corresponding connection properties.</para>
		/// </remarks>
		public bool Delete(bool deleteBothConnections) { return true; }

		/// <summary>
		/// Deletes the specified connection property.
		/// </summary>
		/// <param name="prop">The connection property to delete.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteProperty(ConnectivityConnectionProperty prop) { return true; }

		/// <summary>
		/// Deletes the specified connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property to delete.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteProperty(int id) { return true; }

		/// <summary>
		/// Deletes the specified connection property.
		/// </summary>
		/// <param name="prop">The connection property to delete.</param>
		/// <param name="both"><c>true</c> if the connection property should be deleted from both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteProperty(ConnectivityConnectionProperty prop, bool both) { return true; }

		/// <summary>
		/// Deletes the specified connection property.
		/// </summary>
		/// <param name="id">The ID of the connection property to delete.</param>
		/// <param name="both"><c>true</c> if the connection property should be deleted from both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteProperty(int id, bool both) { return true; }

		/// <summary>
		/// Retrieves the destination connectivity interface.
		/// </summary>
		/// <returns>The destination connectivity interface.</returns>
		public ConnectivityInterface GetDestinationInterface() { return null; }

		/// <summary>
		/// Retrieves the connection property with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the connection property to retrieve.</param>
		/// <returns>The connection property or <see langword="null"/> if the property with the specified ID was not found.</returns>
		public ConnectivityConnectionProperty GetPropertyById(int id) { return null; }

		/// <summary>
		/// Retrieves the connection property with the specified name.
		/// </summary>
		/// <param name="name">The name of the connection property to retrieve.</param>
		/// <returns>The connection property or <see langword="null"/> if the property with the specified name was not found.</returns>
		public ConnectivityConnectionProperty GetPropertyByName(string name) { return null; }

		/// <summary>
		/// Retrieves the source connectivity interface.
		/// </summary>
		/// <returns>The source connectivity interface.</returns>
		public ConnectivityInterface GetSourceInterface() { return null; }

		/// <summary>
		/// Updates this connection.
		/// </summary>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool Update(string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates this connection.
		/// </summary>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool Update(string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates this connection.
		/// </summary>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destPK">The ID (primary key) of the destination interface.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool Update(string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections, out int destPK) { destPK = 0;  return true; }

		/// <summary>
		/// Updates this connection.
		/// </summary>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destConn">The connection on the destination.</param>
		/// <param name="timeoutMs">The update timeout.</param>
		/// <returns><c>true</c> if the update succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not updated within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool Update(string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections, out ConnectivityConnection destConn, int timeoutMs) { destConn = null; return true; }

		/// <summary>
		/// Updates the destination interface of this connection.
		/// </summary>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateDestination(ConnectivityInterface newDestination, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the destination interface of this connection.
		/// </summary>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destPK">The ID (primary key) of the destination interface.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateDestination(ConnectivityInterface newDestination, bool updateBothConnections, out int destPK) { destPK = 0;  return true; }

		/// <summary>
		/// Updates the destination interface of this connection.
		/// </summary>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destConn">The connection on the destination.</param>
		/// <param name="timeoutMs">The update timeout.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not updated within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool UpdateDestination(ConnectivityInterface newDestination, bool updateBothConnections, out ConnectivityConnection destConn, int timeoutMs) { destConn = null;  return true; }

		/// <summary>
		/// Updates the connection filter.
		/// </summary>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateFilter(string newFilter, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the interfaces of this connection.
		/// </summary>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection filter should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateInterfaces(int newSourceInterfaceId, int newDestinationInterfaceId, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the name of this connection.
		/// </summary>
		/// <param name="newSourceName">The new connection name for the source end of the connection.</param>
		/// <param name="newDestinationName">The new connection name for the destination end of the connection.</param>
		/// <param name="updateBothConnections"><c>true</c> if the name should be updated on both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateName(string newSourceName, string newDestinationName, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the specified connection property.
		/// </summary>
		/// <param name="prop">The property to update.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(ConnectivityConnectionProperty prop) { return true; }

		/// <summary>
		/// Updates the specified connection property.
		/// </summary>
		/// <param name="prop">The property to update.</param>
		/// <param name="both"><c>true</c> if the connection property should be updated on both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(ConnectivityConnectionProperty prop, bool both) { return true; }

		/// <summary>
		/// Updates the property with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the property.</param>
		/// <param name="name">The new name of the property.</param>
		/// <param name="type">The new type of the property.</param>
		/// <param name="value">The new value of the property.</param>
		/// <param name="link">The new ID of the connection to which this property belongs.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(int id, string name, string type, string value, int link) { return true; }

		/// <summary>
		/// Updates the property with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the property.</param>
		/// <param name="name">The new name of the property.</param>
		/// <param name="type">The new type of the property.</param>
		/// <param name="value">The new value of the property.</param>
		/// <param name="link">The new ID of the connection to which this property belongs.</param>
		/// <param name="both"><c>true</c> if the connection property should be updated on both the source and destination element; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(int id, string name, string type, string value, int link, bool both) { return true; }
	}
}