namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a DataMiner Connectivity Framework (DCF) interface.
	/// </summary>
	public class Interface
	{
		/// <summary>
		/// Gets the custom name of this interface.
		/// </summary>
		/// <value>The custom name of this interface.</value>
		/// <example>
		/// <code>
		/// string customName = interface.CustomName;
		/// </code>
		/// </example>
		public string CustomName { get; }

		/// <summary>
		/// Gets the ID of the DataMiner Agent on which the element resides.
		/// </summary>
		/// <value>The ID of the DataMiner Agent on which the element resides.</value>
		/// <example>
		/// <code>
		/// int agentId = interface.DmaId;
		/// </code>
		/// </example>
		public int DmaId { get; }

		/// <summary>
		/// Gets the ID of the element this interface belongs to.
		/// </summary>
		/// <value>The ID of the element this interface belongs to.</value>
		/// <example>
		/// <code>
		/// int elementId = interface.EId;
		/// </code>
		/// </example>
		public int EId { get; }

		/// <summary>
		/// Gets the ID of this interface.
		/// </summary>
		/// <value>The ID of this interface.</value>
		/// <example>
		/// <code>
		/// int interfaceId = interface.InterfaceId;
		/// </code>
		/// </example>
		public int InterfaceId { get; }

		/// <summary>
		/// Gets a value indicating whether this interface is internal.
		/// </summary>
		/// <value><c>true</c> if this interface is internal; otherwise, <c>false</c>.</value>
		/// <remarks>Feature introduced in DataMiner 10.1.5 (RN 29314).</remarks>
		public bool IsInternal { get; }

		/// <summary>
		/// Gets the name of this interface.
		/// </summary>
		/// <value>The name of this interface.</value>
		/// <example>
		/// <code>
		/// string name = interface.Name;
		/// </code>
		/// </example>
		public string Name { get; }

		/// <summary>
		/// Gets the type of this interface: in, out or inout.
		/// </summary>
		/// <value>The type of this interface (in, out or inout).</value>
		/// <example>
		/// <code>
		/// string type = interface.Type;
		/// </code>
		/// </example>
		public string Type { get; }

		/// <summary>
		/// Returns the DCF interface to which this interface is connected.
		/// </summary>
		/// <param name="connectionNameFilter">The connection name filter.</param>
		/// <returns>The DCF interface or <see langword="null"/> if there is no connected interface.</returns>
		/// <remarks>
		/// <para>Use the <see cref="GetNext(string, Interface)"/> overload to make sure that you do not get the same interface twice, especially when performing a sequence of multiple GetNext calls.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Interface nextInterface = interface.GetNext("Connection A");
		/// </code>
		/// </example>
		public Interface GetNext(string connectionNameFilter) { return null; }

		/// <summary>
		/// Returns the DCF interface to which the specified interface is connected, making sure that the same interface is not retrieved twice, especially when performing a sequence of multiple GetNext calls.
		/// </summary>
		/// <param name="connectionNameFilter">The connection name filter.</param>
		/// <param name="previousInterface">The previous interface.</param>
		/// <returns>The interface or <see langword="null"/> if there is no connected interface..</returns>
		/// <example>
		/// <code>
		/// Interface nextInterface = interface.GetNext("*",lastInterface);
		/// </code>
		/// </example>
		public Interface GetNext(string connectionNameFilter, Interface previousInterface) { return null; }

		/// <summary>
		/// Returns all DCF interfaces connected to the current interface. This is especially useful in cases where a connection splits up into multiple internal connections.
		/// </summary>
		/// <param name="connectionNameFilter">The connection name filter.</param>
		/// <returns>The DCF interfaces.</returns>
		/// <remarks>
		/// <para>You can filter by connection name in order to limit the number of connections that will be returned.</para>
		/// <para>Like for the GetNext method, you can use the <see cref="GetNexts(string, Interface)"/> overload to pass along the previous interface. This can be useful in case of star topology setups where all interfaces are connected to one interface defined from source to destination, or vice versa.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Interface[] nextInterfaces = interface.GetNexts("MyConnection",previousInterface);
		/// </code>
		/// </example>
		public Interface[] GetNexts(string connectionNameFilter) { return null; }

		/// <summary>
		/// Returns all DCF interfaces connected to the current interface, passing along the previous interface. This can be useful in case of star topology setups where all interfaces are connected to one interface defined from source to destination, or vice versa.
		/// </summary>
		/// <param name="connectionNameFilter">The connection name filter.</param>
		/// <param name="previousInterface">The previous interface.</param>
		/// <returns>The DCF interfaces.</returns>
		/// 
		public Interface[] GetNexts(string connectionNameFilter, Interface previousInterface) { return null; }

		/// <summary>
		/// Gets the value of a property by providing the property name.
		/// </summary>
		/// <param name="propertyName">The name of the property.</param>
		/// <returns>The property value or <see langword="null"/> if there is no property with the specified name.</returns>
		/// <remarks>
		/// <para>To test if the interface has a specific property, use the <see cref="HasProperty(string)"/> method.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Element element = engine.FindElement("MyElement");
		/// 
		/// if(element != null)
		/// {
		///		Interface myInterface = element.GetInterface("MyInterface");
		///
		///		if(myInterface != null)
		///		{
		///			if(myInterface.HasProperty("MyProperty"))
		///			{
		///				string propertyValue = myInterface.GetPropertyValue("MyProperty");
		///				...			
		///			}
		///		}
		/// }
		/// </code>
		/// </example>
		public virtual string GetPropertyValue(string propertyName) { return null; }

		/// <summary>
		/// Determines whether a property with the specified name exists.
		/// </summary>
		/// <param name="propertyName">The name of the property.</param>
		/// <returns><c>true</c> if a property with the specified name exists; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// Element element = engine.FindElement("MyElement");
		/// 
		/// if(element != null)
		/// {
		///		Interface myInterface = element.GetInterface("MyInterface");
		///
		///		if(myInterface != null)
		///		{
		///			if(myInterface.HasProperty("MyProperty"))
		///			{
		///				string propertyValue = myInterface.GetPropertyValue("MyProperty");
		///				...			
		///			}
		///		}
		/// }
		/// </code>
		/// </example>
		public virtual bool HasProperty(string propertyName) { return false; }

		/// <summary>
		/// Sets the value of a property.
		/// </summary>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <remarks>
		/// <para>If there is no property with the specified name for this interface, the set will not be performed.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// Element element = engine.FindElement("MyElement");
		/// 
		/// if(element != null)
		/// {
		///		Interface myInterface = element.GetInterface("MyInterface");
		///
		///		if(myInterface != null)
		///		{
		///			if(myInterface.HasProperty("MyProperty"))
		///			{
		///				myInterface.SetPropertyValue("MyProperty", "MyPropertyValue");		
		///			}
		///		}
		/// }
		/// </code>
		/// </example>
		public virtual void SetPropertyValue(string propertyName, string propertyValue) { }
	}
}
