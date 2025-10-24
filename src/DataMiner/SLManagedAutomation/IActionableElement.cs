using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents an actionable element.
	/// </summary>
	/// <remarks>Refer to <see cref="Element"/> for an overview of the available properties and methods.</remarks>
	public interface IActionableElement
    {
        /// <summary>
        /// Gets the ID of the DataMiner Agent on which the element was created.
        /// </summary>
        /// <value>The ID of the DataMiner Agent on which the element was created.</value>
		int DmaId { get; }

        /// <summary>
        /// Gets the ID of the element that is linked to the dummy.
        /// </summary>
        /// <value>The ID of the element that is linked to the dummy.</value>
		int ElementId { get; }

        /// <summary>
        /// Gets the element info message.
        /// </summary>
        /// <value>The element info message.</value>
		ElementInfoEventMessage ElementInfo { get; }

        /// <summary>
        /// Gets the name of the element that is linked to the dummy.
        /// </summary>
        /// <value>The name of the element that is linked to the dummy.</value>
		string ElementName { get; }

        /// <summary>
        /// Gets the ID of the underlying dummy that is linked to the element. 
        /// This is not the ID of the element itself. To retrieve that one, use the <see cref="Element.ElementId"/> property.
        /// </summary>
        /// <value>The ID of the underlying dummy that is linked to the element.</value>
		int Id { get; }

        /// <summary>
        /// Gets a value indicating whether this element is active.
        /// </summary>
        /// <value><c>true</c> if the element is active (not stopped or paused); otherwise, <c>false</c>.</value>
        bool IsActive { get; }

        /// <summary>
        /// Gets the name of the underlying dummy that is linked to the element.
        /// This is not the name of the element itself. To retrieve that one, use the <see cref="Element.ElementName"/> property.
        /// </summary>
        /// <value>The name of the underlying dummy that is linked to the element.</value>
        /// <remarks>
        /// <note type="note">
        /// <para>This property returns the following string: "_&lt;agentID&gt;_&lt;elementID&gt; (e.g. "_100_5612"). To retrieve the element name, use the <see cref="Element.ElementName"/> property.</para>
        /// </note>
        /// </remarks>
        /// </example>
		string Name { get; }

        /// <summary>
        /// Gets the polling IP address of the element that is linked to the dummy.
        /// </summary>
        /// <value>The polling IP address of the element that is linked to the dummy.</value>
		string PollingIP { get; }

        /// <summary>
        /// Gets the protocol info message.
        /// </summary>
        /// <value>The protocol info message.</value>
		GetProtocolInfoResponseMessage Protocol { get; }

        /// <summary>
        /// Gets the name of the protocol used by this element.
        /// </summary>
        /// <value>The name of the protocol used by this element.</value>
		string ProtocolName { get; }

        /// <summary>
        /// Gets the protocol version used by this element.
        /// </summary>
        /// <value>The protocol version used by this element.</value>
		string ProtocolVersion { get; }

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <remarks>
        /// <para>The input must be in the range 1..nrOfInputs.</para>
        /// <para>The output must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        void ConnectMatrixCrosspoint(int pid, int input, int output);

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
		void ConnectMatrixCrosspoint(int pid, string input, string output);

        /// <summary>
        /// Connects the specified matrix crosspoint.
		/// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void ConnectMatrixCrosspoint(string name, int input, int output);

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void ConnectMatrixCrosspoint(string name, string input, string output);

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
		void DisconnectMatrixCrosspoint(int pid, string input, string output);

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <remarks>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
		void DisconnectMatrixCrosspoint(int pid, int input, int output);

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void DisconnectMatrixCrosspoint(string name, int input, int output);

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void DisconnectMatrixCrosspoint(string name, string input, string output);

        /// <summary>
        /// Gets the display key that corresponds with the specified primary key.
        /// </summary>
        /// <param name="pid">The ID of the table or column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The display key that corresponds with the specified primary key or <see langword="null"/> if not found.</returns>
		string FindDisplayKey(int pid, string primaryKey);

        /// <summary>
        /// Gets the display key that corresponds with the specified primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the table or column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The display key that corresponds with the specified primary key or <see langword="null"/> if not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string FindDisplayKey(string parameterName, string primaryKey);

        /// <summary>
        /// Gets the ID that corresponds with the specified parameter name.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The ID that corresponds with the specified parameter name or -1 if the parameter was not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int FindParameterID(string name);

        /// <summary>
        /// Gets the ID that corresponds with the specified parameter name.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="writeParam"><c>true</c> if the specified parameter is a write parameter; otherwise, <c>false</c>.</param>
        /// <returns>The ID that corresponds with the specified parameter name or -1 if the parameter was not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int FindParameterID(string name, bool writeParam);

        /// <summary>
        /// Gets the primary key that corresponds with the specified display key.
        /// </summary>
        /// <param name="pid">The ID of the table or column parameter.</param>
        /// <param name="displayKey">The display key.</param>
        /// <returns>The primary key that corresponds with the specified display key or <see langword="null"/> if not found.</returns>
		string FindPrimaryKey(int pid, string displayKey);

        /// <summary>
        /// Gets the primary key that corresponds with the specified display key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the table or column parameter.</param>
        /// <param name="displayKey">The display key.</param>
        /// <returns>The primary key that corresponds with the specified display key or <see langword="null"/> if not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string FindPrimaryKey(string parameterName, string displayKey);

        /// <summary>
        /// Gets the name of the view this element is a member of.
        /// </summary>
        /// <returns>The name of the view this element is a member of.</returns>
        /// <remarks><para>If an element is a member of multiple views, this method only returns one of them. If you want all views, use the <see cref="FindViews"/> method.</para></remarks>
		string FindView();

        /// <summary>
        /// Gets the names of all the views this element is a member of.
        /// </summary>
        /// <returns>The names of the views this element is a member of.</returns>
		string[] FindViews();

        /// <summary>
        /// Gets the ID of the write parameter with the specified name.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the write parameter.</param>
        /// <returns>The ID of the write parameter with the specified name or -1 if the write parameter was not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int FindWriteParameterID(string name);

        /// <summary>
        /// Gets the display value that corresponds with the specified raw value of the specified parameter.
        /// </summary>
        /// <param name="pid">The ID of the parameter.</param>
        /// <param name="rawValue">The raw value for which the display value has to be determined.</param>
        /// <returns>The display value that corresponds with the specified raw value.<br />
        /// In case the parameter was not found, the specified value in <paramref name="rawValue"/> is returned.<br />
        /// In case the parameter was found, but the raw value is not specified in the parameter, the specified value in <paramref name="rawValue"/> is returned.
        /// </returns>
        /// <remarks>Used with parameters defining discrete entries to retrieve the display value (e.g. "Main") for a specific value (e.g. “1”).</remarks>
		string GetDisplayValue(int pid, string rawValue);

        /// <summary>
        /// Gets the display value that corresponds with the specified raw value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="rawValue">The raw value for which the display value has to be determined.</param>
        /// <returns>The display value that corresponds with the specified raw value.<br />
        /// In case the parameter was not found, the specified value in <paramref name="rawValue"/> is returned.<br />
        /// In case the parameter was found, but the raw value is not specified in the parameter, the specified value in <paramref name="rawValue"/> is returned.
        /// </returns>
        /// <remarks>Used with parameters defining discrete entries to retrieve the display value (e.g. "Main") for a specific value (e.g. “1”).</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string GetDisplayValue(string name, string rawValue);

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
		int GetMatrixInputForOutput(int pid, string output);

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <remarks><paramref name="output"/> must be in the range 1..nrOfOutputs.</remarks>
		int GetMatrixInputForOutput(int pid, int output);

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int GetMatrixInputForOutput(string name, int output);

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The label of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int GetMatrixInputForOutput(string name, string output);

        /// <summary>
        /// Gets the value of the specified parameter.
        /// </summary>
        /// <param name="pid">The ID of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
		object GetParameter(int pid);

        /// <summary>
        /// Gets the value of the specified table cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The value of the parameter.</returns>
        /// </example>
		object GetParameter(int pid, string idx);

        /// <summary>
        /// Gets the value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        object GetParameter(string name);

        /// <summary>
        /// Gets the value of the specified table cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The value of the parameter.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        object GetParameter(string name, string idx);

        /// <summary>
        /// Gets the value of the specified table cell using the primary key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The value of the parameter or <see langword="null"/> if no row with the specified primary key was found.</returns>
        /// <remarks>
        /// <para>If a column is hidden by an information template, the value for a cell of that column can no longer be retrieved by this method (null is returned). However, the value can still be retrieved using the <see cref="GetParameter(int, string)"/> method. Using the GetParameter method is therefore recommended.</para>
        /// </remarks>
		object GetParameterByPrimaryKey(int pid, string primaryKey);

        /// <summary>
        /// Gets the value of the specified table cell using the primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The value of the parameter or <see langword="null"/> if no row with the specified primary key was found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        object GetParameterByPrimaryKey(string name, string primaryKey);

        /// <summary>
        /// Gets the display value of the specified standalone parameter.
        /// </summary>
        /// <param name="pid">The ID of the standalone parameter.</param>
        /// <returns>The display value of the specified standalone parameter.</returns>
        /// <remarks>Useful for discrete parameters.</remarks>
		string GetParameterDisplay(int pid);

        /// <summary>
        /// Gets the display value of the specified table cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <remarks>Useful for discrete parameters.</remarks>
		string GetParameterDisplay(int pid, string idx);

        /// <summary>
        /// Gets the display value of the specified standalone parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the standalone parameter.</param>
        /// <returns>The display value of the specified standalone parameter.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string GetParameterDisplay(string name);

        /// <summary>
        /// Gets the display value of the specified table cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string GetParameterDisplay(string name, string idx);

        /// <summary>
        /// Gets the display value of the specified table cell using the column name and row primary key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
		string GetParameterDisplayByPrimaryKey(int pid, string primaryKey);

        /// <summary>
        /// Gets the display value of the specified table cell using the column name and row primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string GetParameterDisplayByPrimaryKey(string name, string primaryKey);

        /// <summary>
        /// Gets the value of the specified element property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The property value or <see langword="null"/> when not found.</returns>
		string GetPropertyValue(string propertyName);

        /// <summary>
        /// Gets the value that corresponds with the specified display value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="displayValue">The display value for which the raw value has to be determined.</param>
        /// <returns>The raw value that corresponds with the specified display value.<br />
        /// In case the parameter was not found, the specified value in <paramref name="displayValue"/> is returned.<br />
        /// In case the parameter was found, but the display value is not specified in the parameter, <see langword="null"/> is returned.
        /// </returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Used with parameters defining discrete entries to retrieve the raw value (e.g. "1") for a specific display value (e.g. “Main”).</para>
        /// </remarks>
		string GetRawValue(int pid, string displayValue);

        /// <summary>
        /// Gets the value that corresponds with the specified display value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="displayValue">The display value for which the raw value has to be determined.</param>
        /// <returns>The raw value that corresponds with the specified display value.<br />
        /// In case the parameter was not found, the specified value in <paramref name="displayValue"/> is returned.<br />
        /// In case the parameter was found, but the display value is not specified in the parameter, <see langword="null"/> is returned.
        /// </returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Used with parameters defining discrete entries to retrieve the raw value (e.g. "1") for a specific display value (e.g. “Main”).</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string GetRawValue(string name, string displayValue);

        /// <summary>
        /// Gets the ID of the read parameter that corresponds with the specified write parameter ID.
        /// </summary>
        /// <param name="pid">The ID of the write parameter.</param>
        /// <returns>The ID of the corresponding read parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
		int GetReadParameterIDFromWrite(int pid);

        /// <summary>
        /// Gets the ID of the read parameter that corresponds with the specified write parameter ID.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the write parameter.</param>
        /// <returns>The ID of the corresponding read parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int GetReadParameterIDFromWrite(string name);

        /// <summary>
        /// Gets an object that can be used to change the specified preset.
        /// </summary>
        /// <param name="name">The preset name.</param>
        /// <returns>An object that can be used to change the specified preset.</returns>
		SpectrumPreset GetSpectrumPreset(string name);

        /// <summary>
        /// Gets the display keys of the specified table.
        /// </summary>
        /// <param name="tablePid">The table or column parameter ID.</param>
        /// <returns>The display keys.</returns>
		string[] GetTableDisplayKeys(int tablePid);

        /// <summary>
        /// Gets the display keys of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter ID.</param>
        /// <returns>The display keys.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string[] GetTableDisplayKeys(string tableParameterName);

        /// <summary>
        /// Gets the primary key to display key map of the specified table.
        /// </summary>
        /// <param name="tablePid">The ID of the table or column parameter.</param>
        /// <returns>The primary key to display key map of the specified table.</returns>
		DynamicTableIndicesResponse GetTableKeyMappings(int tablePid);

        /// <summary>
        /// Gets the primary key to display key map of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter.</param>
        /// <returns>The primary key to display key map of the specified table.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        DynamicTableIndicesResponse GetTableKeyMappings(string tableParameterName);

        /// <summary>
        /// Gets the primary keys of the specified table.
        /// </summary>
        /// <param name="tablePid">The ID of the table or column parameter.</param>
        /// <returns>The primary keys of the specified table.</returns>
		string[] GetTablePrimaryKeys(int tablePid);

        /// <summary>
        /// Gets the primary keys of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter.</param>
        /// <returns>The primary keys of the specified table.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string[] GetTablePrimaryKeys(string tableParameterName);

        /// <summary>
        /// Gets the ID of the write parameter that corresponds with the specified read parameter.
        /// </summary>
        /// <param name="pid">The ID of the read parameter.</param>
        /// <returns>The ID of the corresponding write parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
		int GetWriteParameterIDFromRead(int pid);

        /// <summary>
        /// Gets the ID of the write parameter that corresponds with the specified read parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the read parameter.</param>
        /// <returns>The ID of the corresponding write parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int GetWriteParameterIDFromRead(string name);

        /// <summary>
        /// Returns a value indicating whether the element has a property with the specified name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>true</c> if the element has a property with the specified name; otherwise, <c>false</c>.</returns>
		bool HasProperty(string propertyName);

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
		bool IsMatrixCrosspointConnected(int pid, string input, string output);

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
		bool IsMatrixCrosspointConnected(int pid, int input, int output);

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool IsMatrixCrosspointConnected(string name, string input, string output);

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool IsMatrixCrosspointConnected(string name, int input, int output);

        /// <summary>
        /// Masks the element that is linked to the dummy.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
		void Mask(string reason);

        /// <summary>
        /// Masks the element that is linked to the dummy for the specified period of time.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
        /// <param name="amountOfSeconds">The number of seconds to mask the element.</param>
		void Mask(string reason, int amountOfSeconds);

        /// <summary>
        /// Masks the element that is linked to the dummy until all its alarms have been cleared.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
		void MaskUntilNormal(string reason);

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLineLabel">The label of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
		void MatrixEnableInputLine(int pid, string inputLineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <remarks>The input index must be in the range 1..nrOfInputs.</remarks>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
		void MatrixEnableInputLine(int pid, int index, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <remarks>The input index must be in the range 1..nrOfInputs.</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableInputLine(string parameterName, int index, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLineLabel">The label of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableInputLine(string parameterName, string inputLineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		void MatrixEnableLine(int pid, bool input, int index, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
		void MatrixEnableLine(int pid, bool input, string lineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableLine(string parameterName, bool input, int index, bool state);

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableLine(string parameterName, bool input, string lineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
		void MatrixEnableOutputLine(int pid, int index, bool state);

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLineLabel">The label of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
		void MatrixEnableOutputLine(int pid, string outputLineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLineLabel">The label of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableOutputLine(string parameterName, string outputLineLabel, bool state);

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixEnableOutputLine(string parameterName, int index, bool state);

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
		bool MatrixGetFollowMode(int pid, int index);

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
		bool MatrixGetFollowMode(int pid, string outputLabel);

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetFollowMode(string parameterName, string outputLabel);

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para></para><paramref name="index"/> must be in the range 1..nrOfOutputs.
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetFollowMode(string parameterName, int index);

        /// <summary>
        /// Gets the index of the input or output that corresponds with the specified input or output label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified label is an input label; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input (or output in case <paramref name="input" /> is <c>false</c>).</param>
        /// <returns>The corresponding index.</returns>
        /// <remarks>The returned index is in the range 1..nrOfInputs or 1..nrOfOutputs.</remarks>
		int MatrixGetIndexFromLabel(int pid, bool input, string label);

        /// <summary>
        /// Gets the index of the input or output that corresponds with the specified input or output label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified label is an input label; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input (or output in case <paramref name="input" /> is <c>false</c>).</param>
        /// <returns>The corresponding index.</returns>
        /// <remarks>The returned index is in the range 1..nrOfInputs or 1..nrOfOutputs.</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int MatrixGetIndexFromLabel(string parameterName, bool input, string label);

        /// <summary>
        /// Gets the index of the input that corresponds with the specified input label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the input.</param>
        /// <returns>The corresponding input index.</returns>
        /// <remarks>The returned index is in the range 1..nrOfInputs.</remarks>
		int MatrixGetInputIndexFromInputLabel(int pid, string inputLabel);

        /// <summary>
        /// Gets the index of the input that corresponds with the specified input label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the input.</param>
        /// <returns>The corresponding input index.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>The returned index is in the range 1..nrOfInputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int MatrixGetInputIndexFromInputLabel(string parameterName, string inputLabel);

        /// <summary>
        /// Gets the label of the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <returns>The label of the specified matrix input.</returns>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
		string MatrixGetInputLabel(int pid, int index);

        /// <summary>
        /// Gets the label of the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <returns>The label of the specified matrix input.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string MatrixGetInputLabel(string parameterName, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
		bool MatrixGetInputLockMode(int pid, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
		bool MatrixGetInputLockMode(int pid, string inputLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetInputLockMode(string parameterName, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetInputLockMode(string parameterName, string inputLabel);

        /// <summary>
        /// Gets the label of the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		string MatrixGetLabel(int pid, bool input, int index);

        /// <summary>
        /// Gets the label of the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string MatrixGetLabel(string parameterName, bool input, int index);

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		bool MatrixGetLockMode(int pid, bool input, int index);

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
		bool MatrixGetLockMode(int pid, bool input, string label);

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetLockMode(string parameterName, bool input, string label);

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetLockMode(string parameterName, bool input, int index);

        /// <summary>
        /// Gets the index of the output that corresponds with the specified output label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns>The corresponding output index.</returns>
        /// <remarks>The returned output is in the range 1..nrOfOutputs.</remarks>
		int MatrixGetOutputIndexFromOutputLabel(int pid, string outputLabel);

        /// <summary>
        /// Gets the index of the output that corresponds with the specified output label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns>The corresponding output index.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>The returned output is in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        int MatrixGetOutputIndexFromOutputLabel(string parameterName, string outputLabel);

        /// <summary>
        /// Gets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The output index. </param>
        /// <returns>The label of the specified matrix output.</returns>
		string MatrixGetOutputLabel(int pid, int index);

        /// <summary>
        /// Gets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The output index. </param>
        /// <returns>The label of the specified matrix output.</returns>
        /// <remarks>The index of the output must be in the range 1..nrOfOutputs.</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        string MatrixGetOutputLabel(string parameterName, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
		bool MatrixGetOutputLockMode(int pid, string outputLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
		bool MatrixGetOutputLockMode(int pid, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetOutputLockMode(string parameterName, string outputLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixGetOutputLockMode(string parameterName, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
		bool MatrixIsInputLineEnabled(int pid, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
		bool MatrixIsInputLineEnabled(int pid, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>The specified input index must be in the range 1..nrOfInputs.</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsInputLineEnabled(string parameterName, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsInputLineEnabled(string parameterName, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
		bool MatrixIsLineEnabled(int pid, bool input, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		bool MatrixIsLineEnabled(int pid, bool input, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsLineEnabled(string parameterName, bool input, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsLineEnabled(string parameterName, bool input, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
		bool MatrixIsOutputLineEnabled(int pid, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
		bool MatrixIsOutputLineEnabled(int pid, int index);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsOutputLineEnabled(string parameterName, string lineLabel);

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        bool MatrixIsOutputLineEnabled(string parameterName, int index);

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <param name="slaveLabel">The label of the slave output.</param>
		void MatrixSetFollowMaster(int pid, string masterLabel, string slaveLabel);

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <param name="slave">The index of the slave output.</param>
		void MatrixSetFollowMaster(int pid, int master, int slave);

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <param name="slaveLabel">The label of the slave output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetFollowMaster(string parameterName, string masterLabel, string slaveLabel);

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <param name="slave">The index of the slave output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="master"/> must be in the range 1..nrOfOutputs.</para>
        /// <para><paramref name="slave"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetFollowMaster(string parameterName, int master, int slave);

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
		void MatrixSetFollowMode(int pid, int index, bool mode);

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
		void MatrixSetFollowMode(int pid, string outputLabel, bool mode);

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetFollowMode(string parameterName, int index, bool mode);

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetFollowMode(string parameterName, string outputLabel, bool mode);

        /// <summary>
        /// Sets the label of the specified input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
		void MatrixSetInputLabel(int pid, int index, string newName);

        /// <summary>
        /// Sets the label of the specified input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="oldName">The label of the input.</param>
        /// <param name="newName">The new input label.</param>
		void MatrixSetInputLabel(int pid, string oldName, string newName);

        /// <summary>
        /// Sets the label of the specified input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetInputLabel(string parameterName, int index, string newName);

        /// <summary>
        /// Sets the label of the specified input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="oldName">The label of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetInputLabel(string parameterName, string oldName, string newName);

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
		void MatrixSetInputLockMode(int pid, string inputLabel, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
		void MatrixSetInputLockMode(int pid, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetInputLockMode(string parameterName, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetInputLockMode(string parameterName, string inputLabel, bool mode);

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		void MatrixSetLabel(int pid, bool input, int index, string newName);

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="oldName">The label of the input or output.</param>
        /// <param name="newName">The new label.</param>
		void MatrixSetLabel(int pid, bool input, string oldName, string newName);

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetLabel(string parameterName, bool input, int index, string newName);

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="oldName">The label of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetLabel(string parameterName, bool input, string oldName, string newName);

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
		void MatrixSetLockMode(int pid, bool input, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
		void MatrixSetLockMode(int pid, bool input, string label, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetLockMode(string parameterName, bool input, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetLockMode(string parameterName, bool input, string label, bool mode);

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="oldName">The label of the output.</param>
        /// <param name="newName">The new output label.</param>
		void MatrixSetOutputLabel(int pid, string oldName, string newName);

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="newName">The new output label.</param>
		void MatrixSetOutputLabel(int pid, int index, string newName);

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="oldName">The label of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetOutputLabel(string parameterName, string oldName, string newName);

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetOutputLabel(string parameterName, int index, string newName);

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
		void MatrixSetOutputLockMode(int pid, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
		void MatrixSetOutputLockMode(int pid, string outputLabel, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetOutputLockMode(string parameterName, int index, bool mode);

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixSetOutputLockMode(string parameterName, string outputLabel, bool mode);

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
		void MatrixStopBeingMaster(int pid, string masterLabel);

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
		void MatrixStopBeingMaster(int pid, int master);

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixStopBeingMaster(string parameterName, string masterLabel);

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void MatrixStopBeingMaster(string parameterName, int master);

        /// <summary>
        /// Pauses the element that is linked to the dummy.
        /// </summary>
		void Pause();

        /// <summary>
        /// Removes the link between this element and the alarm template that is assigned to it. This sets the element to “Not Monitored”.
        /// </summary>
		void RemoveAlarmTemplate();

        /// <summary>
        /// Removes the link between an element and the trend template that is assigned to it. This disables trending for the element.
        /// </summary>
		void RemoveTrendTemplate();

        /// <summary>
        /// Restarts the element that is linked to the dummy.
        /// </summary>
		void Restart();

        /// <summary>
        /// Assigns the specified alarm template to the element.
        /// </summary>
        /// <param name="name">The name of the alarm template.</param>
		void SetAlarmTemplate(string name);

        /// <summary>
        /// Sets the value of the specified parameter.
        /// </summary>
        /// <param name="pid">The parameter ID.</param>
        /// <param name="value">The value to set.</param>
		void SetParameter(int pid, object value);

        /// <summary>
        /// Sets the value of the specified cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The display key of the row.</param>
        /// <param name="value">The value to set.</param>
		void SetParameter(int pid, string idx, object value);

        /// <summary>
        /// Sets the value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The value to set.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void SetParameter(string name, object value);

        /// <summary>
        /// Sets the value of the specified cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The display key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        void SetParameter(string name, string idx, object value);

        /// <summary>
        /// Sets the value of a cell specified using the primary key instead of the display key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <param name="value">The value to set.</param>
		void SetParameterByPrimaryKey(int pid, string primaryKey, object value);
        [Obsolete("Use overloads with parameter ID instead of name.")]

        /// <summary>
        /// Sets the value of a cell specified using the primary key instead of the display key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        void SetParameterByPrimaryKey(string name, string primaryKey, object value);

        /// <summary>
        /// Sets the value of a writable element property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyValue">The value to set.</param>
        /// <remarks>
        /// <para>From DataMiner 10.0.5 (RN 25025, RN 25195) onwards, this method will only return after having checked that the property was set correctly.</para>
        /// <para>Prior to DataMiner 10.0.5, when the value of an element property was updated using the SetPropertyValue method on an Element object and immediately retrieved using the GetPropertyValue method, in some cases, the value returned by that last method would incorrectly be the previous value.</para>
        /// <note type="note">
        /// <para>The SetPropertyValue method will only perform the above-mentioned check when the “check sets” option is enabled.</para>
        /// <list type="bullet">
        /// <item>
        /// <description>Before launching a script in Cube, select the “After executing a SET command, check if the read parameter or property has been set to the new value” checkbox in the script execution window.</description>
        /// </item>
        /// <item>
        /// <description>When launching a script using ExecuteScriptMessage, make sure to activate the CHECKSETS option(“CHECKSETS:TRUE”).</description>
        /// </item>
        /// </list>
        /// <para>With this option enabled, the SetPropertyValue method will take slightly longer to execute. When a large number of properties need to be updated that do not need to be retrieved immediately, you can disable this option in order to increase performance.</para>
        /// </note>
        /// </remarks>
		void SetPropertyValue(string propertyName, string propertyValue);

        /// <summary>
        /// Assigns the specified trend template to the element.
        /// </summary>
        /// <param name="name">The name of the trend template to assign.</param>
		void SetTrendTemplate(string name);

        /// <summary>
        /// Disables a spectrum monitor.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
		void SpectrumDisableMonitor(string monitorName);

        /// <summary>
        /// Disables a spectrum monitor.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
		void SpectrumDisableMonitor(int monitorId);

        /// <summary>
        /// Enables a spectrum monitor.
        /// </summary>
        /// <param name="monitorName">The name of the monitor.</param>
		void SpectrumEnableMonitor(string monitorName);

        /// <summary>
        /// Enables a spectrum monitor.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
		void SpectrumEnableMonitor(int monitorId);

        /// <summary>
        /// Gets the ID that corresponds with the specified spectrum measurement point name. 
        /// </summary>
        /// <param name="measurementPointName">The name of the measurement point.</param>
        /// <returns>The ID that corresponds with the specified spectrum measurement point name or -1 when not found.</returns>
		int SpectrumFindMeasurementPointIdByName(string measurementPointName);

        /// <summary>
        /// Gets the ID that corresponds with the specified spectrum monitor name.
        /// </summary>
        /// <param name="monitorName">The spectrum monitor name.</param>
        /// <returns>The ID that corresponds with the specified spectrum monitor name or -1 when not found.</returns>
		int SpectrumFindMonitorIdByName(string monitorName);

        /// <summary>
        /// Returns a value indicating whether the specified spectrum monitor is enabled.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
        /// <returns><c>true</c> if the specified spectrum monitor is enabled; otherwise, <c>false</c>.</returns>
		bool SpectrumIsMonitorEnabled(string monitorName);

        /// <summary>
        /// Returns a value indicating whether the specified spectrum monitor is enabled.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <returns><c>true</c> if the specified spectrum monitor is enabled; otherwise, <c>false</c>.</returns>
		bool SpectrumIsMonitorEnabled(int monitorId);

        /// <summary>
        /// Selects the measurement point(s) on which a spectrum monitor has to be executed.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
        /// <param name="measurementPointNames">The names of the measurement points.</param>
		void SpectrumSelectMeasurementPointsForMonitor(string monitorName, params string[] measurementPointNames);

        /// <summary>
        /// Selects the measurement point(s) on which a spectrum monitor has to be executed.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <param name="measurementPointIds">The IDs of the measurement points.</param>
		void SpectrumSelectMeasurementPointsForMonitor(int monitorId, params int[] measurementPointIds);

        /// <summary>
        /// Starts the element that is linked to the dummy.
        /// </summary>
		void Start();

        /// <summary>
        /// Stops the element that is linked to the dummy.
        /// </summary>
		void Stop();

        /// <summary>
        /// Unmasks the element that is linked to the dummy.
        /// </summary>
		void Unmask();
	}
}