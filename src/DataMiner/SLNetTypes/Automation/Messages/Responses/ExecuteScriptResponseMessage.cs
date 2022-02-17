using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a response to a <see cref="ExecuteScriptMessage"/> message.
	/// </summary>
	[Serializable]
    public class ExecuteScriptResponseMessage : ResponseMessage, IAutomationScriptResponseMessage
    {
		/// <summary>
		/// The response.
		/// </summary>
		// <remarks>If the script succeeded, the <see cref="saRet"/> field has an entry with value 262832. This indicates the script executed successfully SL_SCRIPT_SUCCESS (0x000402B0L).</remarks>
		public SA saRet;

		/// <summary>
		/// Gets or sets the script ID.
		/// </summary>
		/// <value>The script ID.</value>
		public int ScriptID { get; set; }

		/// <summary>
		/// Gets or sets the error messages.
		/// </summary>
		/// <value>The error messages.</value>
		public string[] ErrorMessages
        {
			get;
        }

		/// <summary>
		/// Gets or sets the script output.
		/// </summary>
		/// <value>The script output.</value>
        public Dictionary<string, string> ScriptOutput { get; set; }

		/// <summary>
		/// Gets the error code.
		/// </summary>
		/// <value>The error code.</value>
		public int ErrorCode
        {
			get;
        }

		/// <summary>
		/// Gets a value indicating whether an error occurred.
		/// </summary>
		/// <value><c>true</c> if an error occurred; otherwise, <c>false</c>.</value>
		public bool HadError => ErrorCode < 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteScriptResponseMessage"/> message.
		/// </summary>
		public ExecuteScriptResponseMessage()
        {
        }

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
