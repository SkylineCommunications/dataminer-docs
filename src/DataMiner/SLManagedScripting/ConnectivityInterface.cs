using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) interface.
	/// </summary>
	public class ConnectivityInterface
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectivityInterface"/> class.
		/// </summary>
		public ConnectivityInterface() { }

		// NOTE: Not documented.
		//public ConnectivityInterface(int DataMinerId, int ElementId, InterfaceInfoEventMessage.InterfaceInfo info) { }

		// NOTE: Not documented.
		//public ConnectivityInterface(int DataMinerId, int ElementId, InterfaceInfoEventMessage.InterfaceInfo info, SLProtocol managed) { }

		/// <summary>
		/// Gets the DataMiner Agent ID of the element this interface is part of.
		/// </summary>
		/// <value>The DataMiner Agent ID of the element this interface is part of.</value>
		public int DataMinerId { get; }

		/// <summary>
		/// Gets the ID of the table exposing this dynamic interface.
		/// </summary>
		/// <value>The ID of the table exposing this dynamic interface.</value>
		public int DynamicLink { get; }

		/// <summary>
		/// Gets the key of this dynamic interface.
		/// </summary>
		/// <value>The key of this dynamic interface.</value>
		public string DynamicPK { get; }

		/// <summary>
		/// Gets the element ID of the element this interface is part of.
		/// </summary>
		/// <value>The element ID of the element this interface is part of.</value>
		public int ElementId { get; }

		/// <summary>
		/// Gets the element key ("DataMiner Agent ID/element ID") of the element this interface is part of.
		/// </summary>
		/// <value>The element key ("DataMiner Agent ID/element ID") of the element this interface is part of.</value>
		public string ElementKey { get; }

		/// <summary>
		/// Gets the custom name of this interface.
		/// </summary>
		/// <value>The custom name of this interface.</value>
		public string InterfaceCustomName { get; }

		/// <summary>
		/// Gets the interface ID.
		/// </summary>
		/// <value>The interface ID.</value>
		public int InterfaceId { get; }

		/// <summary>
		/// Gets the interface name.
		/// </summary>
		/// <value>The interface name.</value>
		public string InterfaceName { get; }

		/// <summary>
		/// Gets the parameters of this interface.
		/// </summary>
		/// <value>The interface parameters.</value>
		public Dictionary<int, ConnectivityInterfaceParameter> InterfaceParameters { get; }

		/// <summary>
		/// Gets the properties of this interface.
		/// </summary>
		/// <value>The interface properties.</value>
		public Dictionary<int, ConnectivityInterfaceProperty> InterfaceProperties { get; }

		/// <summary>
		/// Gets the interface type.
		/// </summary>
		/// <value>The interface type.</value>
		public InterfaceType InterfaceTypeInfo { get; }

		/// <summary>
		/// Gets a value indicating whether this interface is internal.
		/// </summary>
		/// <value><c>true</c> if this is an internal interface; otherwise, <c>false</c>.</value>
		public bool IsInternal{ get; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should also be added to the destination connections table; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if addition succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(ConnectivityInterface destItf, bool addBothCOnnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the element that owns the destination interface.</param>
		/// <param name="destItf">The destination interface ID.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should also be added to the destination connections table; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string destElementKey, int destItf, bool addBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(ConnectivityInterface destItf, string filter, bool addBothCOnnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, bool addBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connections table entry at the source.</param>
		/// <param name="destPK">The ID (primary key) of the connections table entry at the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(ConnectivityInterface destItf, bool addBothCOnnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string destElementKey, int destItf, string filter, bool addBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, string filter, bool addBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(ConnectivityInterface destItf, bool addBothCOnnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(ConnectivityInterface destItf, string filter, bool addBothCOnnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string destElementKey, int destItf, bool addBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, bool addBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothCOnnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(ConnectivityInterface destItf, string filter, bool addBothCOnnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="AddBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, string filter, bool AddBothConnections) { return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, bool addBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string destElementKey, int destItf, bool addBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string destElementKey, int destItf, string filter, bool addBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string destElementKey, int destItf, string filter, bool addBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connections table entry at the source.</param>
		/// <param name="destPK">The ID (primary key) of the connections table entry at the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, string filter, bool addBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="AddBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, bool AddBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, bool addBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, bool addBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destItf">The destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="addBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string sourceName, string destName, ConnectivityInterface destItf, string filter, bool addBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null; destConn = null; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="AddBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourcePK">The ID (primary key) of the connection added to the source.</param>
		/// <param name="destPK">The ID (primary key) of the connection added to the destination.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, string filter, bool AddBothConnections, out int sourcePK, out int destPK) { sourcePK = 0; destPK = 0; return true; }

		/// <summary>
		/// Adds a connection between this interface and the specified destination interface.
		/// </summary>
		/// <param name="sourceName">The name to apply to this connection on the source.</param>
		/// <param name="destName">The name to apply to this connection on the destination.</param>
		/// <param name="destElementKey">The element key ("DataMiner Agent ID/element ID") of the destination element.</param>
		/// <param name="destItf">The ID of the destination interface.</param>
		/// <param name="filter">The connection filter.</param>
		/// <param name="AddBothConnections"><c>true</c> if the connection entry should be added to both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="sourceConn">The connection added to the source.</param>
		/// <param name="destConn">The connection added to the destination.</param>
		/// <param name="timeoutMs">The connection addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded within the specified timeout; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddConnection(string sourceName, string destName, string destElementKey, int destItf, string filter, bool AddBothConnections, out ConnectivityConnection sourceConn, out ConnectivityConnection destConn, int timeoutMs) { sourceConn = null;  destConn = null; return true; }

		/// <summary>
		/// Adds the specified interface property to this interface.
		/// </summary>
		/// <param name="prop">The interface property to add.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddProperty(ConnectivityInterfaceProperty prop) { return true; }

		/// <summary>
		/// Adds a property with the specified name, value and type.
		/// </summary>
		/// <param name="name">The name of the interface property.</param>
		/// <param name="type">The type of the interface property.</param>
		/// <param name="value">The value of the interface property.</param>
		/// <param name="id">The ID of the interface property.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool AddProperty(string name, string type, string value, out int id) { id = 0;  return true; }

		/// <summary>
		/// Adds a property with the specified name, value and type.
		/// </summary>
		/// <param name="name">The name of the interface property.</param>
		/// <param name="type">The type of the interface property.</param>
		/// <param name="value">The value of the interface property.</param>
		/// <param name="prop">The added property.</param>
		/// <param name="timeoutMs">The property addition timeout.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the property was not created within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool AddProperty(string name, string type, string value, out ConnectivityInterfaceProperty prop, int timeoutMs) { prop = null;  return true; }

		/// <summary>
		/// Deletes the connection with the specified name.
		/// </summary>
		/// <param name="connectionName">The name of the connection to delete.</param>
		/// <param name="deleteBothConnections"><c>true</c> if the connection entry should be removed from both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteConnection(string connectionName, bool deleteBothConnections) { return true; }

		/// <summary>
		/// Deletes the connection with the specified ID.
		/// </summary>
		/// <param name="connectionId">The ID of the connection to delete.</param>
		/// <param name="deleteBothConnections"><c>true</c> if the connection entry should be removed from both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the deletion succeeded; otherwise, <c>false</c>.</returns>
		public bool DeleteConnection(int connectionId, bool deleteBothConnections) { return true; }

		/// <summary>
		/// Deletes the specified interface property.
		/// </summary>
		/// <param name="prop">The interface property to delete.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the property does not exist, this method will also return true.</para>
		/// </remarks>
		public bool DeleteProperty(ConnectivityInterfaceProperty prop) { return true; }

		/// <summary>
		/// Deletes the interface property with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case there was no property with the specified ID, this method will also return true.</para>
		/// </remarks>
		public bool DeleteProperty(int id) { return true; }

		/// <summary>
		/// Retrieves the connection with the specified ID.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <returns>The connection with the specified ID, or <see langword="null"/> if no connection was found with the specified ID.</returns>
		public ConnectivityConnection GetConnectionById(int ConnectionId) { return null; }

		/// <summary>
		/// Retrieves the connection with the specified ID from the specified element.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID of the element.</param>
		/// <param name="eid">The element ID of the element.</param>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <returns>The connection with the specified ID, or <see langword="null"/> if no connection was found with the specified ID.</returns>
		public ConnectivityConnection GetConnectionById(int dmaid, int eid, int ConnectionId) { return null; }

		/// <summary>
		/// Retrieves the connection with the specified name.
		/// </summary>
		/// <param name="name">The name of the connection.</param>
		/// <returns>The connection with the specified name, or <see langword="null"/> if no connection was found with the specified name.</returns>
		public ConnectivityConnection GetConnectionByName(string name) { return null; }

		/// <summary>
		/// Retrieves the connection with the specified ID from the specified element.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID of the element.</param>
		/// <param name="eid">The element ID of the element.</param>
		/// <param name="name">The name of the connection.</param>
		/// <returns>The connection with the specified name, or <see langword="null"/> if no connection was found with the specified name.</returns>
		public ConnectivityConnection GetConnectionByName(int dmaid, int eid, string name) { return null; }

		/// <summary>
		/// Gets the connections from the element this interface is part of.
		/// </summary>
		/// <returns>The connections from the element this interface is part of.</returns>
		public Dictionary<int, ConnectivityConnection> GetConnections() { return null; }

		/// <summary>
		/// Gets the connections from the element this interface is part of using the specified connection filter.
		/// </summary>
		/// <param name="filter">The connection filter.</param>
		/// <returns>The connections from the element this interface is part of and that match the specified filter.</returns>
		public Dictionary<int, ConnectivityConnection> GetConnections(string filter) { return null; }

		/// <summary>
		/// Gets the connections from the specified element using the specified connection filter.
		/// </summary>
		/// <param name="filter">The connection filter.</param>
		/// <param name="dmaid">The DataMiner Agent ID of the element.</param>
		/// <param name="eid">The element ID of the element.</param>
		/// <param name="sItf">The ID of the interface.</param>
		/// <returns>The connections from the element that match the specified filter.</returns>
		public Dictionary<int, ConnectivityConnection> GetConnections(string filter, int dmaid, int eid, int sItf) { return null; }

		/// <summary>
		/// Gets the property with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the interface property.</param>
		/// <returns>The interface property or <see langword="null"/> if no property with the specified ID was found.</returns>
		public ConnectivityInterfaceProperty GetPropertyById(int id) { return null; }

		/// <summary>
		/// Gets the property with the specified name.
		/// </summary>
		/// <param name="name">The name of the interface property.</param>
		/// <returns>The interface property or <see langword="null"/> if no property with the specified name was found.</returns>
		public ConnectivityInterfaceProperty GetPropertyByName(string name) { return null; }

		/// <summary>
		/// Updates the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The new ID of the source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the new destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the new destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnection(int ConnectionId, string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The new ID of the source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the new destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the new destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnection(int ConnectionId, string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The new ID of the source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the new destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the new destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destPK">The ID (primary key) of the destination interface.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnection(int ConnectionId, string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections, out int destPK) { destPK = 0; return true; }

		/// <summary>
		/// Updates the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newSourceInterfaceId">The new ID of the source interface.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="newDestinationDMAId">The DataMiner Agent ID of the new destination element.</param>
		/// <param name="newDestinationElementId">The element ID of the new destination element.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destConn">The destination connection.</param>
		/// <param name="timeoutMs">The update timeout.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not updated within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool UpdateConnection(int ConnectionId, string newSourceName, int newSourceInterfaceId, string newDestinationName, int newDestinationDMAId, int newDestinationElementId, int newDestinationInterfaceId, string newFilter, bool updateBothConnections, out ConnectivityConnection destConn, int timeoutMs) { destConn = null;  return true; }

		/// <summary>
		/// Updates the destination of the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnectionDestination(int ConnectionId, ConnectivityInterface newDestination, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the destination of the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destPK">The ID (primary key) of the destination interface.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnectionDestination(int ConnectionId, ConnectivityInterface newDestination, bool updateBothConnections, out int destPK) { destPK = 0; return true; }

		/// <summary>
		/// Updates the destination of the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newDestination">The new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <param name="destConn">The destination connection.</param>
		/// <param name="timeoutMs">The update timeout.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>In case the connection was not updated within the specified timeout, <c>false</c> will be returned. However, the message will still be handled by DataMiner.</para>
		/// </remarks>
		public bool UpdateConnectionDestination(int ConnectionId, ConnectivityInterface newDestination, bool updateBothConnections, out ConnectivityConnection destConn, int timeoutMs) { destConn = null;  return true; }

		/// <summary>
		/// Updates the connection filter of the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newFilter">The new connection filter.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnectionFilter(int ConnectionId, string newFilter, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the connected interfaces of the specified connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceInterfaceId">The ID of the new source interface.</param>
		/// <param name="newDestinationInterfaceId">The ID of the new destination interface.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnectionInterfaces(int ConnectionId, int newSourceInterfaceId, int newDestinationInterfaceId, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the name of the connection.
		/// </summary>
		/// <param name="ConnectionId">The ID of the connection.</param>
		/// <param name="newSourceName">The new name to apply to this connection on the source.</param>
		/// <param name="newDestinationName">The new name to apply to this connection on the destination.</param>
		/// <param name="updateBothConnections"><c>true</c> if the connection entry should be updated at both ends of the connection; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the update succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateConnectionName(int ConnectionId, string newSourceName, string newDestinationName, bool updateBothConnections) { return true; }

		/// <summary>
		/// Updates the specified property.
		/// </summary>
		/// <param name="prop">The property to update.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(ConnectivityInterfaceProperty prop) { return true; }

		/// <summary>
		/// Updates the specified property with the new property information.
		/// </summary>
		/// <param name="id">The ID of the property to update.</param>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">The type of the property.</param>
		/// <param name="value">The value of the property.</param>
		/// <param name="link">The ID of the interface to which this property belongs.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool UpdateProperty(int id, string name, string type, string value, int link) { return true; }

		/// <summary>
		/// Specifies the DCF interface type.
		/// </summary>
		public enum InterfaceType
		{
			/// <summary>
			/// In.
			/// </summary>
			In = 0,
			/// <summary>
			/// Out.
			/// </summary>
			Out = 1,
			/// <summary>
			/// In-Out.
			/// </summary>
			InOut = 2,
			/// <summary>
			/// Undefined.
			/// </summary>
			Undefined = 3
		}
	}
}