using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Automation;
using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents options related to subscript execution of the <see cref="AutomationEntryPointType.Types.OnRequestScriptInfo"/> entry point.
	/// </summary>
	/// <remarks>
	/// <note type="note">Available from DataMiner 10.5.7/10.6.0 onwards.</note><!-- RN 42969 -->
	/// </remarks>
	public class RequestScriptInfoSubScriptOptions : SubScriptOptions
	{
		/// <summary>
		/// Gets the input for the <see cref="AutomationEntryPointType.Types.OnRequestScriptInfo"/> entry point method.
		/// </summary>
		public RequestScriptInfoInput Input => new RequestScriptInfoInput();

		/// <summary>
		/// Gets the output after starting the <see cref="AutomationEntryPointType.Types.OnRequestScriptInfo"/> entry point method.
		/// </summary>
		public RequestScriptInfoOutput Output => new RequestScriptInfoOutput();
	}
}
