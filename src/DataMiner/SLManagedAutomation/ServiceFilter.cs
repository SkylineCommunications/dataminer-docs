namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a filter that can be used when searching for services.
	/// </summary>
	public class ServiceFilter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceFilter"/> class.
		/// </summary>
		public ServiceFilter() { }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Critical”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Critical" are included; otherwise, <c>false</c>.</value>
		public bool CriticalOnly { get; set; }

		/// <summary>
		/// Gets or set a value limiting the search to the specified DataMiner Agent.
		/// </summary>
		/// <value>The ID of the DataMiner Agent to which the search should be limited.</value>
		public int DataMinerID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only exclude subviews from the search.
		/// </summary>
		/// <value><c>true</c> if subviews are excluded; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <note type="note">
		/// If you specify <see cref="ExcludeSubViews"/>, also specify <see cref="View"/> or <see cref="ViewID"/>.
		/// </note>
		/// </remarks>
		public bool ExcludeSubViews { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Major”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Major" are included; otherwise, <c>false</c>.</value>
		public bool MajorOnly { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Minor”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Minor" are included; otherwise, <c>false</c>.</value>
		public bool MinorOnly { get; set; }

		/// <summary>
		/// Gets or sets a filter for the service name, which can contain * and ? as wildcards.
		/// </summary>
		/// <value>A filter for the service name, which can contain * and ? as wildcards.</value>
		public string NameFilter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Normal”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Normal" are included; otherwise, <c>false</c>.</value>
		public bool NormalOnly { get; set; }

		/// <summary>
		/// Gets or sets a value limiting the search to the service with the specified service ID.
		/// </summary>
		/// <remarks>
		/// <note type="note">
		/// If you specify ServiceID, also specify <see cref="DataMinerID"/>.
		/// </note>
		/// </remarks>
		public int ServiceID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Timeout”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Timeout" are included; otherwise, <c>false</c>.</value>
		public bool TimeoutOnly { get; set; }

		/// <summary>
		/// Gets or sets the name of the view to search for.
		/// </summary>
		/// <value>The view name.</value>
		public string View { get; set; }

		/// <summary>
		/// Gets or sets the ID of the view to search for.
		/// </summary>
		/// <value>The view ID.</value>
		public int ViewID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to only include services with severity state “Warning”.
		/// </summary>
		/// <value><c>true</c> if only services with severity state "Warning" are included; otherwise, <c>false</c>.</value>
		public bool WarningOnly { get; set; }

		/// <summary>
		/// Creates a new <see cref="ServiceFilter"/> object with <see cref="DataMinerID"/> and <see cref="ServiceID"/> set to the specified DataMiner Agent ID and service ID, respectively.
		/// </summary>
		/// <param name="dataMinerID">The DataMiner Agent ID.</param>
		/// <param name="serviceID">The service ID.</param>
		/// <returns>A new <see cref="ServiceFilter"/> object with <see cref="DataMinerID"/> and <see cref="ServiceID"/> set to the specified DataMiner Agent ID and service ID, respectively.</returns>
		/// <example>
		/// <code>
		/// var filter = ServiceFilter.ByID(200, 4000);
		/// </code>
		/// </example>
		public static ServiceFilter ByID(int dataMinerID, int serviceID) { return null; }

		/// <summary>
		/// Creates a new <see cref="ServiceFilter"/> object with <see cref="NameFilter"/> set to the specified name filter.
		/// </summary>
		/// <param name="name">The service name filter (can contain * and ? wildcards).</param>
		/// <returns>A new <see cref="ServiceFilter"/> object with <see cref="NameFilter"/> set to the specified name filter.</returns>
		/// <example>
		/// <code>
		/// var filter = ServiceFilter.ByName("Test*");
		/// </code>
		/// </example>
		public static ServiceFilter ByName(string name) { return null; }

		/// <summary>
		/// Creates a new <see cref="ServiceFilter"/> object with <see cref="View"/> set to the specified view name.
		/// </summary>
		/// <param name="name">The name of the view.</param>
		/// <returns>A new <see cref="ServiceFilter"/> object with <see cref="View"/> set to the specified view name.</returns>
		/// <example>
		/// <code>
		/// var filter = ServiceFilter.ByView("MyView");
		/// </code>
		/// </example>
		public static ServiceFilter ByView(string name) { return null; }

		/// <summary>
		/// Creates a new <see cref="ServiceFilter"/> object with <see cref="ViewID"/> set to the specified view ID.
		/// </summary>
		/// <param name="id">The ID of the view.</param>
		/// <returns>A new <see cref="ServiceFilter"/> object with <see cref="ViewID"/> set to the specified view ID.</returns>
		/// <example>
		/// <code>
		/// var filter = ServiceFilter.ByView(202);
		/// </code>
		/// </example>
		public static ServiceFilter ByView(int id) { return null; }
	}
}