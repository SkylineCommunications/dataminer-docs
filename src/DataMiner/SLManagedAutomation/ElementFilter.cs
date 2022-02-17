namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a filter for filtering elements.
	/// </summary>
	public class ElementFilter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ElementFilter" /> class.
		/// </summary>
		public ElementFilter()
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Critical" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Critical" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool CriticalOnly { get; set; }

		/// <summary>
		/// Gets or sets a value limiting the search to the specified DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int DataMinerID { get; set; }

		/// <summary>
		/// Gets or sets a value limiting the search to the specified element ID.
		/// </summary>
		/// <value>The element ID.</value>
		/// <remarks>
		/// <note type="note">
		/// <para>If you specify ElementID, also specify DataMinerID.</para>
		/// </note>
		/// </remarks>
		public int ElementID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether subviews should be searched.
		/// </summary>
		/// <value><c>true</c> if subviews should be excluded; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <note type="note">If you specify <see cref="ExcludeSubViews"/>, also specify <see cref="View"/> or <see cref="ViewID"/>. Default: false.</note>
		/// </remarks>
		public bool ExcludeSubViews { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether hidden elements should be included.
		/// </summary>
		/// <value><c>true</c> if hidden elements should be included; otherwise, <c>false</c>. Default: true.</value>
		public bool IncludeHidden { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether paused elements should be included.
		/// </summary>
		/// <value><c>true</c> if paused elements should be included; otherwise, <c>false</c>. Default: true.</value>
		public bool IncludePaused { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether service elements should be included.
		/// </summary>
		/// <value><c>true</c> if service elements should be included; otherwise, <c>false</c>. Default: false.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.11 (RN 22631).</remarks>
		public bool IncludeServiceElements { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether stopped elements should be included.
		/// </summary>
		/// <value><c>true</c> if stopped elements should be included; otherwise, <c>false</c>. Default: true.</value>
		public bool IncludeStopped { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Major" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Major" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool MajorOnly { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only masked elements should be included.
		/// </summary>
		/// <value><c>true</c> if only masked elements should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool MaskedOnly { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Minor" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Minor" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool MinorOnly { get; set; }

		/// <summary>
		/// Gets or sets a filter for the element name, which can contain * and ? wildcards.
		/// </summary>
		/// <value>The element name filter (can contain * and ? wildcards).</value>
		public string NameFilter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Normal" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Normal" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool NormalOnly { get; set; }

		/// <summary>
		/// Gets or sets a filter for the protocol name. No wildcards are allowed.
		/// </summary>
		/// <value>The protocol name filter.</value>
		public string ProtocolName { get; set; }

		/// <summary>
		/// Gets or sets a filter for the protocol version. No wildcards are allowed.
		/// </summary>
		/// <value>The protocol version filter.</value>
		public string ProtocolVersion { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Timeout" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Timeout" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool TimeoutOnly { get; set; }

		/// <summary>
		/// Gets or sets the name of the view to be searched.
		/// </summary>
		/// <value>The name of the view to be searched</value>
		public string View { get; set; }

		/// <summary>
		/// Gets or sets the ID of the view to be searched.
		/// </summary>
		/// <value>The ID of the view to be searched</value>
		public int ViewID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether only elements with severity state "Warning" should be included.
		/// </summary>
		/// <value><c>true</c> if only elements with severity state "Warning" should be included; otherwise, <c>false</c>. Default: false.</value>
		public bool WarningOnly { get; set; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="DataMinerID"/> and <see cref="ElementID"/> set to the specified DataMiner Agent ID and element ID, respectively.
		/// </summary>
		/// <param name="dataMinerID">The DataMiner Agent ID.</param>
		/// <param name="elementID">The element ID.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="DataMinerID"/> and <see cref="ElementID"/> set to the specified DataMiner Agent ID and element ID, respectively.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByID(200, 4000);
		/// </code>
		/// </example>
		public static ElementFilter ByID(int dataMinerID, int elementID) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="NameFilter"/> set to the specified element name filter.
		/// </summary>
		/// <param name="name">The element name filter.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="NameFilter"/> set to the specified element name filter.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByName("Test*");
		/// </code>
		/// </example>
		public static ElementFilter ByName(string name) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="ProtocolName"/> set to the specified protocol name filter.
		/// </summary>
		/// <param name="name">The protocol name.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="ProtocolName"/> set to the specified protocol name.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByProtocol("Microsoft Platform");
		/// </code>
		/// </example>
		public static ElementFilter ByProtocol(string name) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified protocol name and version filter, respectively.
		/// </summary>
		/// <param name="name">The protocol name.</param>
		/// <param name="version">The protocol version.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified protocol name and version, respectively.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByProtocol("Microsoft Platform", "1.0.0.1");
		/// </code>
		/// </example>
		public static ElementFilter ByProtocol(string name, string version) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="View"/> set to the specified view name.
		/// </summary>
		/// <param name="name">The name of the view.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="View"/> set to the specified view name.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByView("MyView");
		/// </code>
		/// </example>
		public static ElementFilter ByView(string name) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="ViewID"/> set to the specified view ID.
		/// </summary>
		/// <param name="id">The ID of the view.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="ViewID"/> set to the specified view name.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByView(202);
		/// </code>
		/// </example>
		public static ElementFilter ByView(int id) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="View"/>, <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified view name, protocol name and protocol version, respectively.
		/// </summary>
		/// <param name="name">The name of the view.</param>
		/// <param name="protocolName">The protocol name.</param>
		/// <param name="protocolVersion">The protocol version.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="View"/>, <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified view name, protocol name and protocol version, respectively.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByView("MyView", "Microsoft Platform", "1.0.0.1");
		/// </code>
		/// </example>
		public static ElementFilter ByView(string name, string protocolName, string protocolVersion) { return null; }

		/// <summary>
		/// Retrieves a new <see cref="ElementFilter"/> object that has <see cref="ViewID"/>, <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified view ID, protocol name and protocol version, respectively.
		/// </summary>
		/// <param name="id">The ID of the view.</param>
		/// <param name="protocolName">The protocol name.</param>
		/// <param name="protocolVersion">The protocol version.</param>
		/// <returns>An <see cref="ElementFilter"/> object with <see cref="ViewID"/>, <see cref="ProtocolName"/> and <see cref="ProtocolVersion"/> set to the specified view ID, protocol name and protocol version, respectively.</returns>
		/// <example>
		/// <code>
		/// var filter = ElementFilter.ByView(202, "Microsoft Platform", "1.0.0.1");
		/// </code>
		/// </example>
		public static ElementFilter ByView(int id, string protocolName, string protocolVersion) { return null; }
	}
}