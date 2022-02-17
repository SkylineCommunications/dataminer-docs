using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// This class can be used to store data for an element that will remain accessible as long as the SLScripting process remains active.
	/// </summary>
	/// <remarks>
	///		<list type="bullet">
	///			<item><description>The <see cref="ElementStorage"/> class has a field of type Dictionary&lt;int, object&gt;, where the element ID is used as the key in this dictionary. The methods in the ElementStorage class that define a parameter of type SLProtocol use this protocol instance to retrieve the element ID.</description></item>
	///		</list>
	///	<note type="note">
	/// <list type="bullet">
	/// <item>
	/// <description>The data remains stored as long as SLScripting is running.</description>
	/// </item>
	/// <item>
	/// <description>From DataMiner version 7.5.6.2 onwards, instance QAction entry point methods are supported, allowing you to use instance fields. This makes using the ElementStorage class obsolete. This class should therefore no longer be used: use instance entry points accessing QAction instance field instead of the ElementStorage class.</description>
	/// </item>
	/// </list>
	///	</note>
	/// </remarks>
	public class ElementStorage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ElementStorage"/> class.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance used to interact with the SLProtocol process.</param>
		/// <param name="buffer">If set to <c>true</c>, indicates that pointers to values stored/retrieved should be buffered in order to minimize locking.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.</exception>
		public ElementStorage(SLProtocol protocol, bool buffer = true) { }

		/// <summary>
		/// Gets or sets the object at the specified key.
		/// </summary>
		/// <param name="Key">The key corresponding with the object.</param>
		/// <returns>The object.</returns>
		public object this[string Key] { get { return ""; } set { } }

		/// <summary>
		/// Indicates whether data is buffered.
		/// </summary>
		/// <value><c>true</c> means buffered; otherwise, <c>false</c>.</value>
		/// <remarks>This means that the Data (and possibly the Map) property of the ElementStorage class are not null.</remarks>
		public bool Buffered { get { return false; } set { } }

		/// <summary>
		/// Gets or sets the raw saved data.
		/// </summary>
		/// <value>The raw saved data.</value>
		public object Data { get { return null; } set { } }

		/// <summary>
		/// Gets or sets the saved data as a dictionary.
		/// </summary>
		/// <value>The data map.</value>
		public Dictionary<string, object> Map { get { return null; } set { } }

		/// <summary>
		/// Indicates whether the map has been loaded.
		/// </summary>
		/// <value><c>false</c> when Map is a null reference; otherwise, <c>true</c>.</value>
		public bool MapLoaded { get { return false; } }

		/// <summary>
		/// Gets the SLProtocol instance use to interact with the SLProtocol process.
		/// </summary>
		/// <value>The SLProtocol instance.</value>
		public SLProtocol Protocol { get { return null; } }

		/// <summary>
		/// Clears the stored data for the element.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance to interact with the SLProtocol process.</param>
		public static void ClearData(SLProtocol protocol) { }

		/// <summary>
		/// Creates a map for an element.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance to interact with the SLProtocol process.</param>
		/// <param name="Reset">Whether a new maps needs to be created if data is already stored for the current element.</param>
		/// <returns>The map for the element.</returns>
		public static Dictionary<string, object> CreateMap(SLProtocol protocol, bool Reset = false) { return null; }

		/// <summary>
		/// Gets the raw stored data for the element.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance to interact with the SLProtocol process.</param>
		/// <returns>The saved data for this element.</returns>
		public static object GetData(SLProtocol protocol) { return null; }

		/// <summary>
		/// Gets the stored data as an object of type Dictionary&lt;string, object&gt;.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance to interact with the SLProtocol process.</param>
		/// <returns>The saved data for this element.</returns>
		public static Dictionary<string, object> GetMap(SLProtocol protocol) { return null; }

		/// <summary>
		/// Stores raw data for the element.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance to interact with the SLProtocol process.</param>
		/// <param name="data">The object to store.</param>
		public static void SetData(SLProtocol protocol, object data) { }

		/// <summary>
		/// Gets the data object for this element and buffers it.
		/// </summary>
		/// <returns>The raw saved data stored for this element.</returns>
		/// <remarks>
		///		<list type="bullet">
		///			<item><description>When the data for this element is not null, the property Buffered will be set to <c>true</c>, otherwise it will be set to <c>false</c>.</description></item>
		///			<item><description>If the data saved for this element is of type Dictionary&lt;string, object&gt;, the mapping will also be loaded.</description></item>
		///		</list>
		/// </remarks>
		public object Load() { return null; }
	}
}
