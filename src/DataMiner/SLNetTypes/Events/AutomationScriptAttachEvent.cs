using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Automation script attach options.
	/// </summary>
	[Serializable, Flags]
	public enum AutomationScriptAttachOptions
	{
		/// <summary>
		/// No options.
		/// </summary>
		None,

		/// <summary>
		/// Presents the user with a pop-up window instead of the default dialog box.
		/// </summary>
		[Obsolete("by default, a popup is displayed. This option is not needed", false)]
		DisplayPopup = 0x00000001,

		/// <summary>
		/// Attaches immediately, without the user having to confirm anything.
		/// </summary>
		AttachImmediately = 0x00000002
	}
}
