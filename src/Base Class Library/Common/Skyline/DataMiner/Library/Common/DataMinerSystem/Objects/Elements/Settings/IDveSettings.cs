using System;

namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner element DVE settings interface.
	/// </summary>
    public interface IDveSettings
    {
		/// <summary>
		/// Gets a value indicating whether this element is a DVE child.
		/// </summary>
		/// <value><c>true</c> if this element is a DVE child element; otherwise, <c>false</c>.</value>
		bool IsChild { get; }

		/// <summary>
		/// Gets or sets a value indicating whether DVE creation is enabled for this element.
		/// </summary>
		/// <value><c>true</c> if the element DVE generation is enabled; otherwise, <c>false</c>.</value>
		/// <exception cref="NotSupportedException">The element is not a DVE parent element.</exception>
		bool IsDveCreationEnabled { get; set; }

		/// <summary>
		/// Gets a value indicating whether this element is a DVE parent.
		/// </summary>
		/// <value><c>true</c> if the element is a DVE parent element; otherwise, <c>false</c>.</value>
		bool IsParent { get; }

		/// <summary>
		/// Gets the parent element.
		/// </summary>
		/// <value>The parent element.</value>
		IDmsElement Parent { get; }
    }
}