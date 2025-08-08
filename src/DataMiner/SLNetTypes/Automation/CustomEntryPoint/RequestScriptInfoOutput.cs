using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Automation
{
	/// <summary>
	/// Represents the output of a <see cref="AutomationEntryPoint.Types.OnRequestScriptInfo"/> entry point method.
	/// </summary>
	/// <remarks>
	/// <note type="note">Available from DataMiner 10.5.7/10.6.0 onwards.</note><!-- RN 42969 -->
	/// </remarks>
	[Serializable]
	public class RequestScriptInfoOutput
	{
		/// <summary>
		/// Gets or sets the key/value pairs that represent the output data of the entry point.
		/// </summary>
		public Dictionary<string, string> Data { get; set; }
	}
}