namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;

	using Skyline.DataMiner.Library.Common.Properties;
	using Skyline.DataMiner.Library.Common.Templates;

	/// <summary>
	///     DataMiner System interface.
	/// </summary>
	public interface IDms
	{
		/// <summary>
		///     Gets the communication interface.
		/// </summary>
		/// <value>The communication interface.</value>
		ICommunication Communication { get; }

		/// <summary>
		///     Gets the element property definitions available in the DataMiner System.
		/// </summary>
		/// <value>The element property definitions available in the DataMiner System.</value>
		IPropertyDefinitionCollection<IDmsElementPropertyDefinition> ElementPropertyDefinitions { get; }

		/// <summary>
		///     Gets the service property definitions available in the DataMiner System.
		/// </summary>
		/// <value>The service property definitions available in the DataMiner System.</value>
		IPropertyDefinitionCollection<IDmsServicePropertyDefinition> ServicePropertyDefinitions { get; }

		/// <summary>
		///     Gets the view property definitions available in the DataMiner System.
		/// </summary>
		/// <value>The view property definitions available in the DataMiner System.</value>
		IPropertyDefinitionCollection<IDmsViewPropertyDefinition> ViewPropertyDefinitions { get; }

		/// <summary>
		///     Determines whether a DataMiner Agent with the specified ID is present in the DataMiner System.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <exception cref="ArgumentException">The DataMiner Agent ID is negative.</exception>
		/// <returns><c>true</c> if the DataMiner Agent ID is valid; otherwise, <c>false</c>.</returns>
		bool AgentExists(int agentId);

		/// <summary>
		/// Creates a property with the specified configuration.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">Specifies the property type.</param>
		/// <param name="isFilterEnabled">Specifies if the filter is enabled.</param>
		/// <param name="isReadOnly">Specifies if the property is read-only.</param>
		/// <param name="isVisibleInSurveyor">Specifies if the property is visible in the surveyor.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> is the empty string ("") or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="type" /> is invalid.</exception>
		/// <returns>The ID of the created property. If it fails to create property -1 is returned.</returns>
		int CreateProperty(string name, PropertyType type, bool isFilterEnabled, bool isReadOnly, bool isVisibleInSurveyor);

		/// <summary>
		///     Creates a view with the specified configuration.
		/// </summary>
		/// <param name="configuration">The view to be created.</param>
		/// <exception cref="ArgumentNullException"><paramref name="configuration" /> is <see langword="null" />.</exception>
		/// <exception cref="IncorrectDataException"><paramref name="configuration" /> is invalid.</exception>
		/// <returns>The ID of the created view.</returns>
		int CreateView(ViewConfiguration configuration);

		/// <summary>
		/// Deletes the property with the specified ID.
		/// </summary>
		/// <param name="propertyId">The ID of the property.</param>
		/// <exception cref="ArgumentException"><paramref name="propertyId"/> is invalid.</exception>
		void DeleteProperty(int propertyId);

		/// <summary>
		///     Determines whether an element with the specified DataMiner Agent ID/element ID exists in the DataMiner System.
		/// </summary>
		/// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element.</param>
		/// <returns><c>true</c> if the element exists; otherwise, <c>false</c>.</returns>
		bool ElementExists(DmsElementId dmsElementId);

		/// <summary>
		///     Determines whether an element with the specified name exists in the DataMiner System.
		/// </summary>
		/// <param name="elementName">The name of the element.</param>
		/// <exception cref="ArgumentNullException"><paramref name="elementName" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName" /> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if the element exists; otherwise, <c>false</c>.</returns>
		bool ElementExists(string elementName);

		/// <summary>
		/// Determines whether a service with the specified DataMiner Agent ID/service ID exists in the DataMiner System.
		/// </summary>
		/// <param name="dmsServiceId">The DataMiner Agent ID/service ID of the service.</param>
		/// <returns><c>true</c> if the service exists; otherwise, <c>false</c>.</returns>
		bool ServiceExists(DmsServiceId dmsServiceId);

		/// <summary>
		/// Determines whether a service with the specified name exists in the DataMiner System.
		/// </summary>
		/// <param name="serviceName">The name of the service.</param>
		/// <exception cref="ArgumentNullException"><paramref name="serviceName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if the service exists; otherwise, <c>false</c>.</returns>
		bool ServiceExists(string serviceName);

		/// <summary>
		///     Gets the DataMiner Agent with the specified DataMiner Agent ID.
		/// </summary>
		/// <param name="agentId">The ID of the DataMiner Agent.</param>
		/// <returns>The DataMiner Agent that corresponds with the specified DataMiner Agent ID.</returns>
		/// <exception cref="ArgumentException">The DataMiner Agent ID is negative.</exception>
		/// <exception cref="AgentNotFoundException">
		///     There is no DataMiner Agent in the DataMiner System with the specified
		///     DataMiner Agent ID.
		/// </exception>
		IDma GetAgent(int agentId);

		/// <summary>
		///     Gets the DataMiner Agents found in the DataMiner System.
		/// </summary>
		/// <returns>The DataMiner Agents in the DataMiner System.</returns>
		ICollection<IDma> GetAgents();

		/// <summary>
		///     Retrieves all alarm template groups from the DataMiner System.
		/// </summary>
		/// <returns>The alarm template groups.</returns>
		ICollection<IDmsAlarmTemplateGroup> GetAlarmTemplateGroups();

		/// <summary>
		///     Retrieves all alarm template (standalone or groups) from the DataMiner System.
		/// </summary>
		/// <returns>The list of alarm templates.</returns>
		ICollection<IDmsAlarmTemplate> GetAlarmTemplates();

		/// <summary>
		///     Retrieves the element with the specified element ID.
		/// </summary>
		/// <param name="dmsElementId">The DataMiner Agent ID/element ID of the element.</param>
		/// <exception cref="ArgumentException"><paramref name="dmsElementId" /> is empty.</exception>
		/// <exception cref="ElementNotFoundException">No element with the specified ID exists in the DataMiner System.</exception>
		/// <returns>The element with the specified ID.</returns>
		IDmsElement GetElement(DmsElementId dmsElementId);

		/// <summary>
		///     Retrieves the element with the specified element name.
		/// </summary>
		/// <param name="elementName">The name of the element.</param>
		/// <exception cref="ArgumentNullException"><paramref name="elementName" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName" /> is the empty string ("") or white space.</exception>
		/// <exception cref="ElementNotFoundException">No element with the specified name exists in the DataMiner system.</exception>
		/// <returns>The element with the specified name.</returns>
		IDmsElement GetElement(string elementName);

		/// <summary>
		///     Retrieves all elements from the DataMiner System.
		/// </summary>
		/// <returns>The elements present on the DataMiner System.</returns>
		ICollection<IDmsElement> GetElements();

		/// <summary>
		/// Retrieves the service with the specified service ID.
		/// </summary>
		/// <param name="dmsServiceId">The DataMiner Agent ID/service ID of the service.</param>
		/// <exception cref="ArgumentException"><paramref name="dmsServiceId"/> is empty.</exception>
		/// <exception cref="ServiceNotFoundException">No service with the specified ID exists in the DataMiner System.</exception>
		/// <returns>The service with the specified ID.</returns>
		IDmsService GetService(DmsServiceId dmsServiceId);

		/// <summary>
		/// Retrieves the service with the specified service name.
		/// </summary>
		/// <param name="serviceName">The name of the service.</param>
		/// <exception cref="ArgumentNullException"><paramref name="serviceName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> is the empty string ("") or white space.</exception>
		/// <exception cref="ServiceNotFoundException">No service with the specified name exists in the DataMiner system.</exception>
		/// <returns>The service with the specified name.</returns>
		IDmsService GetService(string serviceName);

		/// <summary>
		/// Retrieves all services from the DataMiner System.
		/// </summary>
		/// <returns>The services present on the DataMiner System.</returns>
		ICollection<IDmsService> GetServices();

		/// <summary>
		///     Retrieves the protocol with the given protocol name and version.
		/// </summary>
		/// <param name="name">The name of the protocol.</param>
		/// <param name="version">The version of the protocol.</param>
		/// <returns>An instance of the protocol.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="version" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="name" /> is the empty string ("") or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="version" /> is the empty string ("") or white space.</exception>
		/// <exception cref="ProtocolNotFoundException">
		///     No protocol with the specified name and version exists in the DataMiner
		///     System.
		/// </exception>
		IDmsProtocol GetProtocol(string name, string version);

		/// <summary>
		///     Retrieves all protocols from the DataMiner System.
		/// </summary>
		/// <returns>The protocols available in the DataMiner System.</returns>
		ICollection<IDmsProtocol> GetProtocols();

		/// <summary>
		///     Retrieves all alarm templates from the DataMiner System.
		/// </summary>
		/// <returns>The alarm templates.</returns>
		ICollection<IDmsStandaloneAlarmTemplate> GetStandaloneAlarmTemplates();

		/// <summary>
		///     Retrieves all trend templates from the DataMiner System.
		/// </summary>
		/// <returns>The trend templates.</returns>
		ICollection<IDmsTrendTemplate> GetTrendTemplates();

		/// <summary>
		///     Gets the view with the specified ID.
		/// </summary>
		/// <param name="viewId">The view ID.</param>
		/// <exception cref="ArgumentException"><paramref name="viewId" /> is invalid.</exception>
		/// <exception cref="ViewNotFoundException">No view with the specified ID exists in the DataMiner System.</exception>
		/// <returns>The view with the specified ID.</returns>
		IDmsView GetView(int viewId);

		/// <summary>
		///     Retrieves the view with the specified name.
		/// </summary>
		/// <param name="viewName">The view name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="viewName" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="viewName" /> is the empty string ("") or white space.</exception>
		/// <exception cref="ViewNotFoundException">No view with the specified name exists in the DataMiner System.</exception>
		/// <returns>The view with the specified name.</returns>
		IDmsView GetView(string viewName);

		/// <summary>
		///     Retrieves the views available on the DataMiner System.
		/// </summary>
		/// <returns>The views.</returns>
		ICollection<IDmsView> GetViews();

		/// <summary>
		///     Determines whether the specified property exists in the DataMiner System.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <param name="type">Specifies the property type.</param>
		/// <returns>Value indicating whether the specified property exists in the DataMiner System.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="name" /> is the empty string ("") or white space.</exception>
		bool PropertyExists(string name, PropertyType type);

		/// <summary>
		///     Determines whether the specified version of the specified protocol exists.
		/// </summary>
		/// <param name="protocolName">The protocol name.</param>
		/// <param name="protocolVersion">The protocol version.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocolName" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="protocolVersion" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="protocolName" /> is the empty string ("") or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="protocolVersion" /> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if the protocol is valid; otherwise, <c>false</c>.</returns>
		bool ProtocolExists(string protocolName, string protocolVersion);

		/// <summary>
		///     Updates the communication interface.
		/// </summary>
		/// <param name="communication">The communication interface.</param>
		/// <exception cref="ArgumentNullException"><paramref name="communication" /> is <see langword="null" />.</exception>
		void Refresh(ICommunication communication);

		/// <summary>
		///     Determines whether the view with the specified ID exists.
		/// </summary>
		/// <param name="viewId">The view ID.</param>
		/// <exception cref="ArgumentException"><paramref name="viewId" /> is invalid.</exception>
		/// <returns><c>true</c> if the view exists; otherwise, <c>false</c>.</returns>
		bool ViewExists(int viewId);

		/// <summary>
		///     Determines whether the view with the specified name exists.
		/// </summary>
		/// <param name="viewName">The view name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="viewName" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="viewName" /> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if the view exists; otherwise, <c>false</c>.</returns>
		bool ViewExists(string viewName);
	}
}