using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents options related to subscript execution.
	/// </summary>
	public class SubScriptOptions
	{
		/// <summary>
		/// Gets or sets a value indicating whether the script is allowed to steal the element lock from another user.
		/// </summary>
		/// <value><c>true</c> if the script is allowed to steal the element lock from another user; otherwise, <c>false</c>.</value>
		public bool ForceLockElements { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script output of the subscript merges the full script output of the current running script.
		/// </summary>
		/// <value><c>true</c> if the script output of the subscript merges the full script output of the current running script; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>true</c>.</para>
		/// <para>If <c>false</c>, the script output of the subscript has no impact on the script output of the current script.</para>
		/// <para>Feature introduced in DataMiner 10.0.2 (RN 23936).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// var scriptOptions = engine.PrepareSubScript("MyScript");
		/// scriptOptions.InheritScriptOutput = true;
		/// scriptOptions.StartScript();
		/// </code>
		/// </example>
		public bool InheritScriptOutput { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script is allowed to lock the elements it needs.
		/// </summary>
		/// <value><c>true</c> if the script is allowed to lock the elements it needs; otherwise, <c>false</c>.</value>
		public bool LockElements { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script will verify the outcome of "set parameter" actions.
		/// </summary>
		/// <value><c>true</c> if the script will verify the outcome of "set parameter" actions; otherwise, <c>false</c>.</value>
		public bool PerformChecks { get; set; }

		/// <summary>
		/// Gets or sets the name of the subscript. 
		/// </summary>
		/// <value>The name of the subscript.</value>
		public string ScriptName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script will be executed synchronously.
		/// </summary>
		/// <value><c>true</c> if the script will be executed synchronously; otherwise, <c>false</c>.</value>
		public bool Synchronous { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script will delay execution instead of failing when another script is running on the same element or when the element is locked by another user.
		/// </summary>
		/// <value><c>true</c> if the script will delay execution instead of failing when another script is running on the same element or when the element is locked by another user; otherwise, <c>false</c>.</value>
		public bool WaitWhenLocked { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the script will return more detailed error information instead of throwing an exception. This is supported from DataMiner 10.3.0/10.2.7 onwards.
		/// </summary>
		/// <value><c>true</c> if the script will return more detailed error info instead of throwing an exception; otherwise, <c>false</c>.</value>
		public bool ExtendedErrorInfo { get; set; }

		/// <summary>
		/// Gets a value indicating whether the script had an error and the <see cref="SubScriptOptions.ExtendedErrorInfo"/> was <c>true</c>. This is supported from DataMiner 10.3.0/10.2.7 onwards.
		/// </summary>
		/// <value><c>true</c> if the script had an error and the <see cref="SubScriptOptions.ExtendedErrorInfo"/> was <c>true</c>; otherwise, <c>false</c>.</value>
		public bool HadError { get; }

		/// <summary>
		/// Gets or sets a value indicating whether the script will generate a 'Script started' information event. This is supported from DataMiner 10.3.0/10.2.8 onwards.
		/// </summary>
		/// <value><c>true</c> if the script will not generate a 'Script started' information event; otherwise, <c>false</c>.</value>
		public bool SkipStartedInfoEvent { get; set; }

		/// <summary>
		/// Links a dummy from the main script to a dummy from a subscript.
		/// </summary>
		/// <param name="name">The name of the dummy element in the subscript.</param>
		/// <param name="dummy">The dummy element to link.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="name"/> is <see langword="null"/><br />
		/// -or-<br/>
		/// <paramref name="dummy"/> is <see langword="null"/>.
		/// </exception>
		/// <example>
		/// <code>
		/// var dummy = engine.GetDummy("myDummy");
		/// 
		/// var script = engine.PrepareSubScript("My SubScript");
		/// script.SelectDummy("matrix", dummy);
		/// script.SelectScriptParam("input", Convert.ToString(inputId));
		/// script.SelectScriptParam("output", Convert.ToString(outputId));
		/// script.StartScript();
		/// </code>
		/// </example>
		public void SelectDummy(string name, IActionableElement dummy) { }

		/// <summary>
		/// Links a dummy from the main script to a dummy from a subscript.
		/// </summary>
		/// <param name="id">The ID of the dummy element in the subscript.</param>
		/// <param name="dummy">The dummy element to link.</param>
		/// <exception cref="ArgumentNullException"><paramref name="dummy"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// var dummy = engine.GetDummy("myDummy");
		/// 
		/// var script = engine.PrepareSubScript("My SubScript");
		/// script.SelectDummy(1, dummy);
		/// script.SelectScriptParam("input", Convert.ToString(inputId));
		/// script.SelectScriptParam("output", Convert.ToString(outputId));
		/// script.StartScript();
		/// </code>
		/// </example>
		public void SelectDummy(int id, IActionableElement dummy) { }

		/// <summary>
		/// Links a dummy from the main script to a dummy from a subscript.
		/// </summary>
		/// <param name="dummyid">The ID of the dummy element in the subscript.</param>
		/// <param name="dmaid">DataMiner Agent ID of the dummy element.</param>
		/// <param name="eid">Element ID of the dummy element.</param>
		/// <example>
		/// <code>
		/// var script = engine.PrepareSubScript("My SubScript");
		///
		/// script.SelectDummy(1, 200, 400);
		/// script.SelectScriptParam("input", Convert.ToString(inputId));
		/// script.SelectScriptParam("output", Convert.ToString(outputId));
		/// script.StartScript();
		/// </code>
		/// </example>
		public void SelectDummy(int dummyid, int dmaid, int eid) { }

		/// <summary>
		/// Selects a dummy from the main script to be used as a dummy in the subscript.
		/// </summary>
		/// <param name="name">The name of the dummy element in the subscript.</param>
		/// <param name="dmaid">DataMiner Agent ID of the dummy element.</param>
		/// <param name="eid">Element ID of the dummy element.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// var script = engine.PrepareSubScript("My SubScript");
		///
		/// script.SelectDummy("matrix", 200, 400);
		/// script.SelectScriptParam("input", Convert.ToString(inputId));
		/// script.SelectScriptParam("output", Convert.ToString(outputId));
		/// script.StartScript();
		/// </code>
		/// </example>
		public void SelectDummy(string name, int dmaid, int eid) { }

		/// <summary>
		/// Selects the persistent memory file with the specified name to be used as the script memory with the specified ID in the subscript.
		/// </summary>
		/// <param name="id">The ID of the script memory in the subscript.</param>
		/// <param name="val">The name of the physical script memory file.</param>
		/// <exception cref="ArgumentNullException"><paramref name="val"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// var subscript = engine.PrepareSubScript("MySybscript");
		/// subscript.SelectMemory(1, "file1");	// The script memory of the subscript with ID 1 will be linked to the physical memory file with name "file1".
		///
		/// subscript.StartScript();
		/// </code>
		/// </example>
		public void SelectMemory(int id, string val) { }

		/// <summary>
		/// Selects a persistent script memory from the main script to be used as the persistent script memory with the specified ID in the subscript.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="memory"></param>
		/// <exception cref="ArgumentNullException"><paramref name="memory"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <para>Main script:</para>
		/// <code>
		/// var memory = engine.GetMemory("parentMemory");	// The parent script has a script memory with name "parentMemory".
		/// memory.Set(1, "MyValue");	// The first entry of this memory is set to the value "MyValue".
		///
		/// var subscript = engine.PrepareSubScript("MySubscript");
		///
		/// subscript.SelectMemory(1, memory); // The subscript has a script memory with ID 1 and this memory will be linked to the parent memory.
		/// subscript.StartScript();
		/// </code>
		/// <para>Sub-script:</para>
		/// <code>
		/// var memory = engine.GetMemory(1);
		/// engine.GenerateInformation(Convert.ToString(memory.Get(1))); // This will generate an information event with value: "MyValue".
		/// </code>
		/// </example>
		public void SelectMemory(int id, ScriptMemory memory) { }

		/// <summary>
		/// Selects the persistent memory file with the specified name to be used as the script memory with the specified ID in the subscript.
		/// </summary>
		/// <param name="name">The name of the script memory in the subscript.</param>
		/// <param name="val">The name of the persistent script memory file.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="name"/> is <see langword="null"/><br />
		/// -or-<br />
		/// <paramref name="val"/> is <see langword="null"/>.
		/// </exception>
		/// <example>
		/// <code>
		/// var subscript = engine.PrepareSubScript("MySubscript");
		/// subscript.SelectMemory("memory1", "file1");	// The script memory of the subscript with name "memory1" will be linked to the physical memory file with name "file1".
		///
		/// subscript.StartScript();
		/// </code>
		/// </example>
		public void SelectMemory(string name, string val) { }

		/// <summary>
		/// Selects a persistent script memory from the main script to be used as the persistent script memory in the subscript.
		/// </summary>
		/// <param name="name">The name of the script memory of the subscript.</param>
		/// <param name="memory">The script memory of the main script to link.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="name"/> is <see langword="null"/><br />
		/// -or-<br />
		/// <paramref name="memory"/> is <see langword="null"/>.
		/// </exception>
		/// <example>
		/// <para>Main script:</para>
		/// <code>
		/// var memory = engine.GetMemory("parentMemory");	// The parent script has a script memory with name "parentMemory".
		/// memory.Set(1, "MyValue");	// The first entry of this memory is set to the value "MyValue".
		///
		/// var subscript = engine.PrepareSubScript("MySubscript");
		///
		/// subscript.SelectMemory("subscriptMemory", memory); // The subscript has a script memory with name "subscriptMemory" and this memory will be linked to the parent memory.
		/// subscript.StartScript();
		/// </code>
		/// <para>Sub-script:</para>
		/// <code>
		/// var memory = engine.GetMemory("subscriptMemory");
		/// engine.GenerateInformation(Convert.ToString(memory.Get(1))); // This will generate an information event with value: "MyValue".
		/// </code>
		/// </example>
		public void SelectMemory(string name, ScriptMemory memory) { }

		/// <summary>
		/// Links a script parameter from the main script to a script parameter from a subscript.
		/// </summary>
		/// <param name="id">The ID of the script parameter in the subscript.</param>
		/// <param name="param">The script parameter of the main script to link to the script parameter of the subscript.</param>
		/// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <para>Parent script:</para>
		/// <code>
		/// var myParam = engine.GetScriptParam("parentParam");
		/// myParam.SetParamValue("MyValue");
		///
		/// var subscript = engine.PrepareSubScript("MySybscript");
		/// 
		/// subscript.SelectScriptParam(1, myParam);
		///
		/// subscript.StartScript();
		/// </code>
		/// <para>Sub-script:</para>
		/// <code>
		/// var myParam = engine.GetScriptParam(1);
		///
		/// engine.GenerateInformation(myParam.Value);	// This will generate an information event with value "MyValue".
		/// </code>
		/// </example>
		public void SelectScriptParam(int id, ScriptParam param) { }

		/// <summary>
		/// Sets the script parameter of the subscript with the specified ID to the specified value.
		/// </summary>
		/// <param name="id">The ID of the script parameter in the subscript.</param>
		/// <param name="val">The value to set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="val"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// var subscript = engine.PrepareSubScript("MySybscript");
		///
		/// subscript.SelectScriptParam(1, "myValue");
		/// 
		/// subscript.StartScript();
		/// </code>
		/// </example>
		public void SelectScriptParam(int id, string val) { }

		/// <summary>
		/// Links a script parameter from the main script to a script parameter from a subscript.
		/// </summary>
		/// <param name="name">The name of the script parameter in the subscript.</param>
		/// <param name="param">The script parameter of the main script to link to the script parameter of the subscript.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="name"/> is <see langword="null"/><br />
		/// -or-<br/>
		/// <paramref name="param"/> is <see langword="null"/>.
		/// </exception>
		/// <example>
		/// <para>Parent script:</para>
		/// <code>
		/// var myParam = engine.GetScriptParam("parentParam");
		/// myParam.SetParamValue("MyValue");
		///
		/// var subscript = engine.PrepareSubScript("MySybscript");
		/// 
		/// subscript.SelectScriptParam("subscriptParam", myParam);
		///
		/// subscript.StartScript();
		/// </code>
		/// <para>Sub-script:</para>
		/// <code>
		/// var myParam = engine.GetScriptParam("subscriptParam");
		///
		/// engine.GenerateInformation(myParam.Value);	// This will generate an information event with value "MyValue".
		/// </code>
		/// </example>
		public void SelectScriptParam(string name, ScriptParam param) { }

		/// <summary>
		/// Sets the script parameter of the subscript with the specified name to the specified value.
		/// </summary>
		/// <param name="name">The name of the script parameter in the subscript.</param>
		/// <param name="val">The value to set.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="name"/> is <see langword="null"/><br />
		/// -or-<br />
		/// <paramref name="val"/> is <see langword="null"/>.
		/// </exception>
		/// <example>
		/// <code>
		/// var subscript = engine.PrepareSubScript("MySybscript");
		///
		/// subscript.SelectScriptParam("subscriptParam", "myValue");
		/// 
		/// subscript.StartScript();
		/// </code>
		/// </example>
		public void SelectScriptParam(string name, string val) { }

		/// <summary>
		/// Starts the subscript.
		/// </summary>
		/// <exception cref="DataMinerException">Running the sub-script failed.</exception>
		/// <example>
		/// <code>
		/// var script = engine.PrepareSubScript("My SubScript");
		///
		/// script.SelectDummy("matrix", 200, 400);
		/// script.SelectScriptParam("input", Convert.ToString(inputId));
		/// script.SelectScriptParam("output", Convert.ToString(outputId));
		/// script.StartScript();
		/// </code>
		/// </example>
		public void StartScript() { }

		/// <summary>
		/// Returns a copy of the script output of the current script and, if the <see cref="SubScriptOptions.InheritScriptOutput" /> option is set to <c>true</c>, the child scripts. For more information, see below.
		/// </summary>
		/// <returns>The script results.</returns>
		/// <remarks>This method can be used to pass information from a subscript to the parent script.
		/// Feature introduced in DataMiner 9.6.8 (RN 21952).</remarks>
		public Dictionary<string, string> GetScriptResult()
		{
			return null; // this._engine._scriptOutput;
		}

		/// <summary>
		/// Returns the error messages of the script after execution when the <see cref="SubScriptOptions.ExtendedErrorInfo"/> option is set to <c>true</c>. This is supported from DataMiner 10.3.0/10.2.7 onwards.
		/// </summary>
		/// <returns>The error messages of the script.</returns>
		/// <example>
		/// <code>
		/// var script = engine.PrepareSubScript("SRM_PFL_Ericsson_Decoder");
		/// script.ExtendedErrorInfo = true;
		///
		/// script.SelectScriptParam("Info", "{}");
		/// script.SelectScriptParam("ProfileInstance", "{}");
		/// script.SelectDummy("dummy1", dmaId, elementId);
		///
		/// script.StartScript();
		///
		/// if (script.HadError)
		/// {
		///   string[] errors = script.GetErrorMessages();
		///   // Handle errors...
		/// }
		/// </code>
		/// </example>
		public string[] GetErrorMessages()
		{
			return null;
		}
	}
}
