using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Specifies the redundancy mode.
	/// </summary>
	public enum RedundancyMode
	{
		/// <summary>
		/// Undefined.
		/// </summary>
		Undefined,
		/// <summary>
		/// Automatic.
		/// </summary>
		Automatic,
		/// <summary>
		/// Manual switchback.
		/// </summary>
		ManualSwitchBack,
		/// <summary>
		/// Manual.
		/// </summary>
		Manual
	}
}
