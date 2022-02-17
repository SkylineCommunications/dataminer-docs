using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a service.
	/// </summary>
	public class Service
	{
		/// <summary>
		/// Gets the DataMiner Agent ID of this service.
		/// </summary>
		/// <value>The DataMiner Agent ID of this service.</value>
		public int DmaId { get; }

		/// <summary>
		/// Gets the name of this service.
		/// </summary>
		/// <value>The name of this service.</value>
		public string Name { get; }

		///// <summary>
		///// Gets the raw info of this service.
		///// </summary>
		///// <value>The raw info of this service.</value>
		//public LiteServiceInfoEvent RawInfo { get; }

		/// <summary>
		/// Gets the ID of this service.
		/// </summary>
		/// <value>The ID of this service.</value>
		public int ServiceId { get; }

		///// <summary>
		///// Gets the service info.
		///// </summary>
		///// <value>The service info.</value>
		//public virtual ServiceInfoEventMessage ServiceInfo { get; }

		/// <summary>
		/// Gets the value of the specified service property.
		/// </summary>
		/// <param name="propertyName">The name of the service property.</param>
		/// <returns>The property value or <see langword="null"/> if the property was not found.</returns>
		/// <example>
		/// <code>
		/// var myService = engine.FindService(179, 15629);
		/// if(myService.HasProperty("myProperty"))
		/// {
		///		string myPropertyValue = myService.GetPropertyValue("myProperty");
		/// }
		/// </code>
		/// </example>
		public virtual string GetPropertyValue(string propertyName) { return null; }

		/// <summary>
		/// Determines whether this service has a property with the specified property name.
		/// </summary>
		/// <param name="propertyName">The name of the service property.</param>
		/// <returns><c>true</c> if the service has a property with the given name.; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// var myService = engine.FindService(179, 15629);
		/// if(myService.HasProperty("myProperty"))
		/// {
		///		string myPropertyValue = myService.GetPropertyValue("myProperty");
		/// }
		/// </code>
		/// </example>
		public virtual bool HasProperty(string propertyName) { return false; }

		/// <summary>
		/// Sets the value of the specified service property.
		/// </summary>
		/// <param name="propertyName">The name of the service property.</param>
		/// <param name="propertyValue">The value to set.</param>
		/// <example>
		/// <code>
		/// var myService = engine.FindService(179, 15629);
		/// if(myService.HasProperty("myProperty"))
		/// {
		///		myService.SetPropertyValue("myProperty", "myPropertyValue");
		/// }
		/// </code>
		/// </example>
		public virtual void SetPropertyValue(string propertyName, string propertyValue) { }
	}
}