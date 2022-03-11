using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a redundancy group.
	/// </summary>
	public class RedundancyGroup
	{
		/// <summary>
		/// Gets the DataMiner Agent ID of this redundancy group.
		/// </summary>
		/// <value>The DataMiner Agent ID of this redundancy group.</value>
		public int DmaId { get; }

		/// <summary>
		/// Gets the ID of this redundancy group.
		/// </summary>
		/// <value>The ID of this redundancy group.</value>
		public int GroupId { get; }

		/// <summary>
		/// Gets or sets the current operating mode of the redundancy group.
		/// </summary>
		/// <value>The current operating mode of the redundancy group.</value>
		/// <exception cref="ArgumentException">
		/// The redundancy group was not found.<br />
		/// -or-<br />
		/// The value for a set operation is invalid.
		/// </exception>
		public RedundancyMode Mode { get; set; }

		/// <summary>
		/// Gets the name of the redundancy group.
		/// </summary>
		/// <value>The name of the redundancy group.</value>
		public string Name { get; }

		/// <summary>
		/// Gets the raw info of the redundancy group.
		/// </summary>
		/// <value>The raw info of the redundancy group.</value>
		public LiteRedundancyGroupInfoEvent RawInfo { get; }

		/// <summary>
		/// Gets a value indicating whether the specified element in the redundancy group is in maintenance mode.
		/// </summary>
		/// <param name="element">The element in the redundancy group.</param>
		/// <exception cref="ArgumentException">The redundancy group was not found.</exception>
		/// <exception cref="ArgumentException">The element was not found in this redundancy group.</exception> 
		/// <returns><c>true</c> if the specified element is in maintenance mode; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// var mainElement = engine.FindElement("MyMainElement");
		/// 
		/// bool isInMaintenance = redundancyGroup.IsInMaintenance(mainElement);
		/// </code>
		/// </example>
		public bool IsInMaintenance(IActionableElement element) { return false; }

		/// <summary>
		/// Gets a value indicating whether the specified element in the redundancy group is in maintenance mode.
		/// </summary>
		/// <param name="name">The name of the element in the redundancy group.</param>
		/// <exception cref="ArgumentException">The redundancy group was not found.</exception>
		/// <exception cref="ArgumentException">The element was not found in this redundancy group.</exception> 
		/// <returns><c>true</c> if the specified element is in maintenance mode; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// 
		/// bool isInMaintenance = redundancyGroup.IsInMaintenance("MyMainElement");
		/// </code>
		/// </example>
		public bool IsInMaintenance(string name) { return false; }

		/// <summary>
		/// Gets a value indicating whether the specified element in the redundancy group is in maintenance mode.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID of the element in the redundancy group.</param>
		/// <param name="eid">The element ID of the element in the redundancy group.</param>
		/// <exception cref="ArgumentException">The redundancy group was not found.</exception>
		/// <exception cref="ArgumentException">The element was not found in this redundancy group.</exception> 
		/// <returns><c>true</c> if the specified element is in maintenance mode; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// 
		/// bool isInMaintenance = redundancyGroup.IsInMaintenance(200, 4000);
		/// </code>
		/// </example>
		public bool IsInMaintenance(int dmaid, int eid) { return false; }

		/// <summary>
		/// Sets the maintenance mode of the specified element in the redundancy group.
		/// </summary>
		/// <param name="element">The element in the redundancy group.</param>
		/// <param name="inMaintenance"><c>true</c> to  set in maintenance mode; otherwise, <c>false</c> (normal mode).</param>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// var mainElement = engine.FindElement("MyMainElement");
		/// 
		/// redundancyGroup.SetMaintenanceMode(mainElement, true);
		/// </code>
		/// </example>
		public void SetMaintenanceMode(IActionableElement element, bool inMaintenance) { }

		/// <summary>
		/// Sets the maintenance mode of the specified element in the redundancy group.
		/// </summary>
		/// <param name="name">The name of the element in the redundancy group.</param>
		/// <param name="inMaintenance"><c>true</c> to  set in maintenance mode; otherwise, <c>false</c> (normal mode).</param>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// 
		/// redundancyGroup.SetMaintenanceMode("MyMainElement", true);
		/// </code>
		/// </example>
		public void SetMaintenanceMode(string name, bool inMaintenance) { }

		/// <summary>
		/// Sets the maintenance mode of the specified element in the redundancy group.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID of the element in the redundancy group.</param>
		/// <param name="eid">The ID of the element in the redundancy group.</param>
		/// <param name="inMaintenance"><c>true</c> to  set in maintenance mode; otherwise, <c>false</c> (normal mode).</param>
		/// <example>
		/// <code>
		/// var redundancyGroup = engine.FindRedundancyGroup("MyRedundancyGroup");
		/// 
		/// redundancyGroup.SetMaintenanceMode(200, 4000, true);
		/// </code>
		/// </example>
		public void SetMaintenanceMode(int dmaid, int eid, bool inMaintenance) { }
	}
}