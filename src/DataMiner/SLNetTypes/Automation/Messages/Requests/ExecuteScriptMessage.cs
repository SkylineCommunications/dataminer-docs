using System;
using System.Globalization;
using Skyline.DataMiner.Net.Automation;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a message for executing an Automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// try
	/// {
	///		string[] scriptOptions = { "OPTIONS:0", "CHECKSETS:TRUE", "EXTENDED_ERROR_INFO", "DEFER:TRUE" };
	///
	///		ExecuteScriptMessage message = new ExecuteScriptMessage
	///		{
	///			ScriptName = "Automation script",
	///			Options = new SA(scriptOptions),
	///		};
	///
	///		var response = protocol.ExecuteScript(message);
	///		bool succeeded = response != null &amp;&amp; !response.HadError;
	///
	///		if (!succeeded)
	///		{
	///			// Script did not succeed.
	///		}
	///	}
	///	catch (Exception ex)
	///	{
	///		protocol.Log("QA" + protocol.QActionID + "|" + protocol.GetTriggerParameter() + "|Run|Exception thrown:" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
	/// }
	///	</code>
	/// </example>
	[Serializable]
	//[DataMinerSecurity(PermissionFlags.AutomationExecuteScripts)]
	public class ExecuteScriptMessage //: TargetedClientRequestMessage, IAutomationScriptRequestMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteScriptMessage"/> class.
		/// </summary>
		public ExecuteScriptMessage() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteScriptMessage"/> class using the Automation script name.
		/// </summary>
		/// <param name="scriptName">Name of the Automation script to run.</param>
		public ExecuteScriptMessage(string scriptName)
			: this(-1, scriptName)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteScriptMessage"/> class using the DataMiner agent ID and the script name.
		/// </summary>
		/// <param name="dataMinerID">ID of the DataMiner Agent that needs to handle the client Request.</param>
		/// <param name="scriptName">Name of the script to run.</param>
		public ExecuteScriptMessage(int dataMinerID, string scriptName)
			//: base(dataMinerID)
		{
		}

		/// <summary>
		/// Name of the script to run.
		/// </summary>
		public string ScriptName;

		/// <summary>
		/// Options to be passed along to the script. These options include info about which elements are linked to which dummies.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		///		<item>
		///			<description>CHECKSETS: To set the option "After executing a SET command, check if the read parameter has been set to the new value", provide an entry with the value "CHECKSETS:TRUE". Otherwise, provide an entry "CHECKSETS:FALSE".</description>
		///		</item>
		///		<item>
		///			<description>"OPTIONS:int": A number of options can be set by providing an entry "OPTIONS:X, where X is a number that is a bitwise combination of the flags defined below.
		///			<list type="table">
		///			<listheader>
		///				<term>Name</term>
		///				<term>Value</term>
		///				<term>Description</term>
		///			 </listheader>
		///			 <item>
		///				<term>None</term>
		///				<term>0x0</term>
		///				<term>None</term>
		///			</item>
		///			 <item>
		///				<term>Lock</term>
		///				<term>0x1</term>
		///				<term>Lock elements</term> 
		///			</item>
		///			 <item>
		///				<term>Force lock</term>
		///				<term>0x2</term>
		///				<term>Force lock elements. Note: when this is set, "Lock elements" must also be set.</term>
		///			</item>
		///			 <item>
		///				<term>NoWait</term>
		///				<term>0x4</term>
		///				<term>Disable wait when locked or busy.</term> 
		///			</item>
		///			 <item>
		///				<term>SchedulerMarkElementsInUseVisio</term>
		///				<term>0x8</term>
		///				<term>Mark dummy elements 'In Use' once task is active and scheduled (RN 5687).</term>
		///			</item>
		///			 <item>
		///				<term>AllowUndef</term>
		///				<term>0x10</term>
		///				<term>Allows GetParameter to return NULL when parameter value is undefined.</term> 
		///			</item>
		///			<item>
		///				<term>SkipInfoEventsSet</term>
		///				<term>0x20</term>
		///				<term>Information events should NOT be generated for SETs executed from script.</term>
		///			</item>
		///			<item>
		///				<term>Debug</term>
		///				<term>0x40</term>
		///				<term>Comment type statements will be logged to information messages.</term>
		///			</item>
		///			</list>
		///			For example, to run a script with the "Disable wait when locked or busy" and "Mark dummy elements 'In Use' once task is active and scheduled", add an entry "OPTIONS:12".
		///			</description>
		///		</item>
		///		<item>
		///			<description>"PROTOCOL:protid:dmaid:eid": Defines a protocol mapping. To specify a dummy, provide an entry "PROTOCOL:X:Y:Z", where X is the 1-based dummy number, Y is the Agent ID of the element and Z is the element ID of the element (e.g. "PROTOCOL:1:132:512460"). If the dummy can be empty, you can also specify "*" as values for Y and Z.</description>
		///		</item>
		///		<item>
		///			<description>"PROTOCOLBYNAME:protName:dmaid:eid": Defines a protocol mapping by name. To specify a dummy, provide an entry "PROTOCOLBYNAME:X:Y:Z", where X is the name of the dummy, Y is the Agent ID of the element and Z is the element ID of the element (e.g. "PROTOCOLBYNAME:myDummy:132:512460"). If the dummy can be empty, you can also specify "*" as values for Y and Z.</description>
		///		</item>
		///		<item>
		///			<description>"PARAMETER:id:value": To specify the value of a script parameter, provide an entry "PARAMETER:X:Y", where X is the 1-based parameter number and Y is the parameter value (e.g. "PARAMETER:1:MyValue").</description>
		///		</item>
		///		<item>
		///			<description>"PARAMETERBYNAME:paramName:value": To specify the value of a script parameter by name, provide an entry "PARAMETERBYNAME:X:Y", where X is the script parameter name and Y is the parameter value (e.g. "PARAMETERBYNAME:myParam:MyValue").</description>
		///		</item>
		///		<item>
		///			<description>"MEMORY:id:filename": To specify a memory file, provide an entry "MEMORY:X:Y", where X is the 1-based memory and Y is the memory file name (e.g. "MEMORY:1:memory 2")</description>
		///		</item>
		///		<item>
		///			<description>"MEMORYBYNAME:id:filename": To specify a memory file by name, provide an entry "MEMORYBYNAME:X:Y", where X is the memory description and Y is the memory file name (e.g. "MEMORYBYNAME:myMemory:memory 2")</description>
		///		</item>
		///		<item>
		///			<description>"INTERACTIVE" To allow interactive execution, provide the following entries: "INTERACTIVE". When the "INTERACTIVE" option is provided, the DEFER option should be set to TRUE.</description>
		///		</item>
		///		<item>
		///			<description>"DEFER:bool": To activate the option "Wait for the script to finish before continuing", provide the following entry: "DEFER:FALSE".</description>
		///		</item>
		///		<item>
		///			<description>"EXTENDED_ERROR_INFO": To return the error info and HRESULT in the response, specify "EXTENDED_ERROR_INFO".</description>
		///		</item>
		///		<item>
		///			<description>"USER:cookie": User executing the script.</description>
		///		</item>
		///		<item>
		///			<description>"SKIP_STARTED_INFO_EVENT:bool": Disables the 'Script started' information event generation. This is supported from DataMiner 10.3.0/10.2.8 onwards.</description>
		///		</item>
		/// </list>
		/// </remarks>
		public SA Options;

		/// <summary>
		/// Gets or sets a custom entry point of the Automation script.
		/// </summary>
		/// <value>The custom entry point of the Automation script.</value>
		public AutomationEntryPoint CustomEntryPoint { get; set; }

		//[Obsolete("Obsolete as of v7.0.3. This method will be removed in a future version.", true)]
		//public override bool IsValid()
		//{
		//	return true;
		//}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return "";
		}
	}
}