using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Messages
{
	public enum ParameterDisplayType
	{
		/// <summary>
		/// No display type specified. In general, you should never encounter this value.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// The parameter is enabled.
		/// </summary>
		Enabled = 1,

		/// <summary>
		/// The parameter is disabled and should be grayed out.
		/// </summary>
		Disabled = 2
	}
}
