using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Profiles
{
	public enum ProfileParameterCategory
	{
		/// <summary>
		/// If this parameter can be monitored.
		/// </summary>
		Monitoring = 1,

		/// <summary>
		/// If this parameter can be used as configuration for the device.
		/// </summary>
		Configuration = 2,

		/// <summary>
		/// If this parameter can represent the capabilities of a device.
		/// </summary>
		Capability = 4,

		/// <summary>
		/// If this parameter can represent the capacities of a device.
		/// </summary>
		Capacity = 8,
	}

	public class Parameter
	{
		public enum ParameterType
		{
			Undefined,
			Number,
			Text,
			Discrete
		}

		
	}
}
