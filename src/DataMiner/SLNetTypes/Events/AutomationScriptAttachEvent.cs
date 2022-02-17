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
		/// None.
		/// </summary>
		None,

		/// <summary>
		/// When present, a pop-up should be displayed instead of an information bar.
		/// </summary>
		[Obsolete("by default, a popup is displayed. This option is not needed", false)]
		DisplayPopup = 0x00000001,

		/// <summary>
		/// When present, the client should try to attach to the request immediately, without waiting for the client to click anything.
		/// </summary>
		AttachImmediately = 0x00000002
	}
}
