using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Skyline.DataMiner.Net.AutomationUI.Objects
{
	/// <summary>
	/// Represents an item of a tree view control.
	/// </summary>
	/// <example>
	/// <code>
	/// var treeViewItem = new TreeViewItem("displayValue", "keyValue", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None };
	/// </code>
	/// </example>
	[Serializable]
	public class TreeViewItem : IEquatable<TreeViewItem>
	{
		/// <summary>
		/// Gets or sets the items that are child items of this item.
		/// </summary>
		/// <value>The items that are child items of this item, if any.</value>
		public List<TreeViewItem> ChildItems { get; set; }

		/// <summary>
		/// Gees or sets the item type.
		/// </summary>
		/// <value>The item type.</value>
		public TreeViewItem.TreeViewItemType ItemType { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the item is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		/// <remarks>Do not fill in this property for TreeViewItems that have child items.The selection of such a parent item depends on the selected child items. If some of the child items are selected, the parent item is only partially selected and its value will not be included in the destination variable. If all child items are selected, the parent item is automatically also selected.</remarks>
		public bool IsChecked { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the item is collapsed.
		/// </summary>
		/// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
		public bool IsCollapsed { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the previous collapsed state of the node should be restored. Default is <c>false</c>.
		/// If no prior state is available, the value of <see cref="IsCollapsed"/> will be used instead.
		/// </summary>
		/// <value><c>true</c> if the previous collapsed state of the node should be restored; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <note type="note">Available from DataMiner 10.6.3/10.6.0 onwards.</note> <!-- RN 44515 -->
		/// </remarks>
		public bool UsePreviousCollapsedState { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the item supports lazy loading. Default is <c>false</c>.
		/// </summary>
		/// <value><c>true</c> if lazy loading is supported; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <note type="note">
		///   When set to <c>true</c> an arrow will be shown in front of the tree view item, even when it does not have any child items.
		///   Upon clicking the arrow, the script will continue (note that 'WantsOnChange' is not required for this) and the expanded
		///   state of the item can be checked by using the 'GetExpanded' method on 'UIResults'.
		///   The child items for the expanded item can now be added to the tree view.
		/// </note> <!-- RN 28528 -->
		/// </remarks>
		public bool SupportsLazyLoading { get; set; }

		/// <summary>
		/// Gets or sets the string value displayed for this item in the UI.
		/// </summary>
		/// <value>The string value displayed for this item in the UI.</value>
		public string DisplayValue { get; set; }

		/// <summary>
		/// Gets or sets the string value that is used as a key to retrieve the selected state of the item.
		/// </summary>
		/// <value>The string value that is used as a key to retrieve the selected state of the item. This is the value that will be used in the destination variable.</value>
		public string KeyValue { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeViewItem"/> class.
		/// </summary>
		/// <param name="displayValue">The display value.</param>
		/// <param name="keyValue">The key value.</param>
		/// <param name="childItems">The child items.</param>
		public TreeViewItem(string displayValue, string keyValue, List<TreeViewItem> childItems = null)
		{
			this.DisplayValue = displayValue;
			this.KeyValue = keyValue;
			this.ChildItems = childItems ?? new List<TreeViewItem>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeViewItem"/> class.
		/// </summary>
		/// <param name="displayValue">The display value.</param>
		/// <param name="keyValue">The key value.</param>
		/// <param name="isChecked">Indication of whether the item is selected by default.</param>
		/// <param name="childItems">The child items.</param>
		public TreeViewItem(
		  string displayValue,
		  string keyValue,
		  bool isChecked,
		  List<TreeViewItem> childItems = null)
		  : this(displayValue, keyValue, childItems)
		{
			this.IsChecked = isChecked;
		}

		/// <summary>
		/// Returns a string representation of this dialog box item.
		/// </summary>
		/// <returns>A string representation of this dialog box item.</returns>
		public string ToCode()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				new BinaryFormatter().Serialize((Stream)memoryStream, (object)this);
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		/// <summary>
		/// Parses the specified string and returns the corresponding <see cref="TreeViewItem"/> instance.
		/// </summary>
		/// <returns>A new <see cref="TreeViewItem"/> instance that corresponds with the specified string.</returns>
		public static TreeViewItem FromCode(string encodedObject)
		{
			return null;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public bool Equals(TreeViewItem other)
		{
			return true; // other != null && (this == other || Tools.ScrambledEquals<TreeViewItem>((IEnumerable<TreeViewItem>)this.ChildItems, (IEnumerable<TreeViewItem>)other.ChildItems, (IEqualityComparer<TreeViewItem>)null) && object.Equals((object)this.ItemType, (object)other.ItemType) && (object.Equals((object)this.IsChecked, (object)other.IsChecked) && object.Equals((object)this.DisplayValue, (object)other.DisplayValue)) && object.Equals((object)this.KeyValue, (object)other.KeyValue));
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			return true;
		}

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return 0;
		}

		/// <summary>
		/// Specifies the tree view item type.
		/// </summary>
		public enum TreeViewItemType
		{
			/// <summary>
			/// Empty.
			/// </summary>
			Empty,
			/// <summary>
			/// Checkbox.
			/// </summary>
			CheckBox,
		}
	}
}
