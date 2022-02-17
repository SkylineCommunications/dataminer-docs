namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a redundancy group filter.
	/// </summary>
	public class RedundancyGroupFilter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RedundancyGroupFilter"/> class.
		/// </summary>
		public RedundancyGroupFilter() { }

		/// <summary>
		/// Gets or sets a value limiting the search to the specified DataMiner Agent ID.
		/// </summary>
		/// <value>The value limiting the search to the specified DataMiner Agent ID.</value>
		public int DataMinerID { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether subviews should be searched.
		/// </summary>
		/// <value><c>true</c> to exclude subviews; otherwise, false.</value>
		/// <remarks>
		/// <note type="note">
		/// <para>If you specify <see cref="ExcludeSubViews"/>, also specify <see cref="View"/> or <see cref="ViewID"/>.</para>
		/// </note>
		/// </remarks>
		public bool ExcludeSubViews { get; set; }

		/// <summary>
		/// Gets or sets a value limiting the search to the specified redundancy group ID.
		/// </summary>
		/// <value>The value limiting the search to the specified redundancy group ID.</value>
		/// <remarks>
		/// <note type="note">
		/// <para>If you specify <see cref="GroupID"/>, also specify <see cref="DataMinerID"/>.</para>
		/// </note>
		/// </remarks>
		public int GroupID { get; set; }

		/// <summary>
		/// Gets or sets a filter for the redundancy group name, which can contain * and ? wildcards.
		/// </summary>
		/// <value>The filter for the redundancy group name, which can contain * and ? wildcards.</value>
		public string NameFilter { get; set; }

		/// <summary>
		/// Gets or sets the name of the view to be searched.
		/// </summary>
		/// <value>The name of the view to be searched.</value>
		public string View { get; set; }

		/// <summary>
		/// Gets or sets the ID of the view to be searched.
		/// </summary>
		/// <value>The ID of the view to be searched.</value>
		public int ViewID { get; set; }

		/// <summary>
		/// Creates a new <see cref="RedundancyGroupFilter"/> object with <see cref="DataMinerID"/> and <see cref="GroupID"/> set to the specified DataMiner Agent ID and redundancy group ID, respectively.
		/// </summary>
		/// <param name="dataMinerID">The DataMiner Agent ID.</param>
		/// <param name="groupID">The redundancy group ID.</param>
		/// <returns>The <see cref="RedundancyGroupFilter"/> instance.</returns>
		/// <example>
		/// <code>
		/// var filter = RedundancyGroupFilter.ByID(200, 4000);
		/// </code>
		/// </example>
		public static RedundancyGroupFilter ByID(int dataMinerID, int groupID) { return null; }

		/// <summary>
		/// Creates a new <see cref="RedundancyGroupFilter"/> object with <see cref="NameFilter"/> set to the specified name filter.
		/// </summary>
		/// <param name="name">The service name filter (can contain * and ? wildcards).</param>
		/// <returns>A new <see cref="RedundancyGroupFilter"/> object with <see cref="NameFilter"/> set to the specified name filter.</returns>
		/// <example>
		/// <code>
		/// var filter = RedundancyGroupFilter.ByName("Test*");
		/// </code>
		/// </example>
		public static RedundancyGroupFilter ByName(string name) { return null; }

		/// <summary>
		/// Creates a new <see cref="RedundancyGroupFilter"/> object with <see cref="ViewID"/> set to the specified view ID.
		/// </summary>
		/// <param name="id">The ID of the view.</param>
		/// <returns>A new <see cref="RedundancyGroupFilter"/> object with <see cref="ViewID"/> set to the specified view ID.</returns>
		/// <example>
		/// <code>
		/// var filter = RedundancyGroupFilter.ByView(202);
		/// </code>
		/// </example>
		public static RedundancyGroupFilter ByView(int id) { return null; }

		/// <summary>
		/// Creates a new <see cref="RedundancyGroupFilter"/> object with <see cref="View"/> set to the specified view name.
		/// </summary>
		/// <param name="name">The name of the view.</param>
		/// <returns>A new <see cref="RedundancyGroupFilter"/> object with <see cref="View"/> set to the specified view name.</returns>
		/// <example>
		/// <code>
		/// var filter = RedundancyGroupFilter.ByView("MyView");
		/// </code>
		/// </example>
		public static RedundancyGroupFilter ByView(string name) { return null; }
	}
}