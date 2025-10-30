using System;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Automation
{
    /// <summary>
    /// Represents a script dummy.
    /// </summary>
    /// <remarks>
    /// <para>See also: <see cref="Element"/> class.</para>
    /// </remarks>
    public class ScriptDummy : IActionableElement
    {
        /// <summary>
        /// Gets the DataMiner Agent ID.
        /// </summary>
        /// <value>The DataMiner Agent ID.</value>
        public virtual int DmaId { get; }

        /// <summary>
        /// Gets the element ID.
        /// </summary>
        /// <value>The element ID.</value>
        public virtual int ElementId { get; }

        /// <summary>
        /// Gets the <see cref="ElementInfoEventMessage"/> object.
        /// </summary>
        /// <value>The <see cref="ElementInfoEventMessage"/> object.</value>
        public virtual ElementInfoEventMessage ElementInfo { get; }

        /// <summary>
        /// Gets the element name.
        /// </summary>
        /// <value>The element name.</value>
        public virtual string ElementName { get; }

        /// <summary>
        /// Gets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public virtual int Id { get; }

        ///// <summary>
        ///// Gets the <see cref="InterfaceInfoEventMessage"/> object.
        ///// </summary>
        //public virtual InterfaceInfoEventMessage InterfaceInfo { get; }

        /// <summary>
        /// Gets a value indicating whether this element is active.
        /// </summary>
        /// <value><c>true</c> if the element is active (not stopped or paused); otherwise, <c>false</c>.</value>
        public virtual bool IsActive { get; }

        /// <summary>
        /// Gets the name of the dummy.
        /// </summary>
        /// <value>The name of the dummy.</value>
        /// <remarks>
        /// <note type="note">
        /// <para>To retrieve the name of the element the dummy is linked to, use the <see cref="ScriptDummy.ElementName"/> property.</para>
        /// </note>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string elementName = dummy.Name; // Returns "dummy1".
        /// </code>
        /// </example>
        public virtual string Name { get; }

        /// <summary>
        /// Gets the polling IP address.
        /// </summary>
        /// <value>The polling IP address.</value>
        public virtual string PollingIP { get; }

        /// <summary>
        /// Gets the protocol info response message.
        /// </summary>
        /// <value>The protocol info response message.</value>
        public virtual GetProtocolInfoResponseMessage Protocol { get; }

        /// <summary>
        /// Gets the protocol name.
        /// </summary>
        /// <value>The protocol name.</value>
        public virtual string ProtocolName { get; }

        /// <summary>
        /// Gets the protocol version.
        /// </summary>
        /// <value>The protocol version.</value>
        public virtual string ProtocolVersion { get; }

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is not in the range 1..nrOfInputs.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The input must be in the range 1..nrOfInputs.</para>
        /// <para>The output must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.ConnectMatrixCrosspoint(1000, 1, 10);
        /// </code>
        /// </example>
        public virtual void ConnectMatrixCrosspoint(int pid, int input, int output) { }

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.ConnectMatrixCrosspoint(1000, "Input 1", "Output 10");
        /// </code>
        /// </example>
        public virtual void ConnectMatrixCrosspoint(int pid, string input, string output) { }

        /// <summary>
        /// Connects the specified matrix crosspoint.
		/// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is not in the range 1..nrOfInputs.<br />
        /// -or-<br />
        /// <paramref name="output"/>  is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.ConnectMatrixCrosspoint("Example matrix", 1, 10);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void ConnectMatrixCrosspoint(string name, int input, int output) { }

        /// <summary>
        /// Connects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.ConnectMatrixCrosspoint("Example matrix", "Input 1", "Output 10");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void ConnectMatrixCrosspoint(string name, string input, string output) { }

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.DisconnectMatrixCrosspoint(1000, "Input 1", "Output 10");
        /// </code>
        /// </example>
        public virtual void DisconnectMatrixCrosspoint(int pid, string input, string output) { }

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// </summary>
        /// <param name="pid">The ID of the matrix write parameter.</param>
        /// <param name="input">The index of the matrix input.</param>
        /// <param name="output">The index of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is not in the range 1..nrOfInputs.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.DisconnectMatrixCrosspoint(1000, 1, 10);
        /// </code>
        /// </example>
        public virtual void DisconnectMatrixCrosspoint(int pid, int input, int output) { }

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.DisconnectMatrixCrosspoint("Example matrix", 1, 10);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void DisconnectMatrixCrosspoint(string name, int input, int output) { }

        /// <summary>
        /// Disconnects the specified matrix crosspoint.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The label of the matrix input.</param>
        /// <param name="output">The label of the matrix output.</param>
        /// <exception cref="DataMinerException">
        /// The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.DisconnectMatrixCrosspoint("Example matrix", "Input 1", "Output 10");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void DisconnectMatrixCrosspoint(string name, string input, string output) { }

        /// <summary>
        /// Gets the display key that corresponds with the specified primary key.
        /// </summary>
        /// <param name="pid">The ID of the table or column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The display key that corresponds with the specified primary key or <see langword="null"/> if not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string displayKey = dummy.FindDisplayKey(1000, "1");
        /// </code>
        /// </example>
        public virtual string FindDisplayKey(int pid, string primaryKey) { return ""; }

        /// <summary>
        /// Gets the display key that corresponds with the specified primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the table or column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The display key that corresponds with the specified primary key or <see langword="null"/> if not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string displayKey = dummy.FindDisplayKey("Overview", "1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string FindDisplayKey(string parameterName, string primaryKey) { return ""; }

        /// <summary>
        /// Gets the ID that corresponds with the specified parameter name.
        /// <note>Please use a library with the mapping between parameter <see href="xref:Protocol.Params.Param.Description" >Description</see> and ID in your script instead.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The ID that corresponds with the specified parameter name or -1 if the parameter was not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int parameterId = dummy.FindParameterID("MyParameter");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use a library with the mapping between name and ID in your script instead.")]
        public virtual int FindParameterID(string name) { return 0; }

        /// <summary>
        /// Gets the ID that corresponds with the specified parameter name.
        /// <note>Please use a library with the mapping between parameter <see href="xref:Protocol.Params.Param.Description" >Description</see> and ID in your script instead.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="writeParam"><c>true</c> if the specified parameter is a write parameter; otherwise, <c>false</c>.</param>
        /// <returns>The ID that corresponds with the specified parameter name or -1 if the parameter was not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int parameterId = dummy.FindParameterID("MyParameter", true);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use a library with the mapping between name and ID in your script instead.")]
        public virtual int FindParameterID(string name, bool writeParam) { return 0; }

        /// <summary>
        /// Gets the primary key that corresponds with the specified display key.
        /// </summary>
        /// <param name="pid">The ID of the table or column parameter.</param>
        /// <param name="displayKey">The display key.</param>
        /// <returns>The primary key that corresponds with the specified display key or <see langword="null"/> if not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string primaryKey = dummy.FindPrimaryKey(1000, "Main");
        /// </code>
        /// </example>
        public virtual string FindPrimaryKey(int pid, string displayKey) { return ""; }

        /// <summary>
        /// Gets the primary key that corresponds with the specified display key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the table or column parameter.</param>
        /// <param name="displayKey">The display key.</param>
        /// <returns>The primary key that corresponds with the specified display key or <see langword="null"/> if not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string primaryKey = dummy.FindPrimaryKey("Overview", "Main");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string FindPrimaryKey(string parameterName, string displayKey) { return ""; }

        /// <summary>
        /// Gets the name of the view this element is a member of.
        /// </summary>
        /// <returns>The name of the view this element is a member of.</returns>
        /// <remarks><para>If an element is a member of multiple views, this method only returns one of them. If you want all views, use the <see cref="FindViews"/> method.</para></remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string viewName = dummy.FindView();
        /// </code>
        /// </example>
        public virtual string FindView() { return ""; }

        /// <summary>
        /// Gets the names of all the views this element is a member of.
        /// </summary>
        /// <returns>The names of the views this element is a member of.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string[] viewNames = dummy.FindViews();
        /// </code>
        /// </example>
        public virtual string[] FindViews() { return null; }

        /// <summary>
        /// Gets the ID of the write parameter with the specified name.
        /// <note>Please use a library with the mapping between parameter <see href="xref:Protocol.Params.Param.Description" >Description</see> and ID in your script instead.</note>
        /// </summary>
        /// <param name="name">The name of the write parameter.</param>
        /// <returns>The ID of the write parameter with the specified name or -1 if the write parameter was not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int parameterId = dummy.FindWriteParameterID("MyWriteParameter");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use a library with the mapping between name and ID in your script instead.")]
        public virtual int FindWriteParameterID(string name) { return 0; }

        //public virtual DcfConnection[] GetConnections() { return null; }
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
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string displayValue = dummy.GetDisplayValue(1000, "1");
        /// </code>
        /// </example>
        public virtual string GetDisplayValue(int pid, string rawValue) { return ""; }

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
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string displayValue = dummy.GetDisplayValue("MyDiscreteParameter", "1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string GetDisplayValue(string name, string rawValue) { return ""; }

        /// <summary>
        /// Retrieves the external interfaces of this dummy.
        /// </summary>
        /// <returns>The external interfaces.</returns>
        /// <remarks>Feature introduced in DataMiner 10.1.5 (RN 29314).</remarks>
        public virtual Interface[] GetExternalInterfaces()
        { return null; }

        /// <summary>
        /// Retrieves the specified DCF interface.
        /// </summary>
        /// <param name="interfaceID">The interface ID.</param>
        /// <returns>The DCF interface or <see langword="null"/> if the specified interface was not found.</returns>
        /// <remarks><note type="note">Note that the method caches the interface the first time it is retrieved, and the interface will not be updated if it changes while the script is running.</note></remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var interface = dummy.GetInterface(1);
        /// </code>
        /// </example>
        public virtual Interface GetInterface(int interfaceID) { return null; }

        /// <summary>
        /// Retrieves the specified DCF interface.
        /// </summary>
        /// <param name="customName">The name of the interface.</param>
        /// <returns>The DCF interface or <see langword="null"/> if the specified interface was not found.</returns>
        /// <remarks><note type="note">Note that the method caches the interface the first time it is retrieved, and the interface will not be updated if it changes while the script is running.</note></remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var interface = dummy.GetInterface("MyInterface");
        /// </code>
        /// </example>
        public virtual Interface GetInterface(string customName) { return null; }

        /// <summary>
        /// Retrieves all DCF interfaces of this dummy.
        /// </summary>
        /// <returns>The DCF interfaces of this dummy.</returns>
        /// <remarks><note type="note">Note that the method caches the interfaces the first time they are retrieved, and they will not be updated if they change while the script is running.</note></remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var interfaces = dummy.GetInterfaces();
        /// </code>
        /// </example>
        public virtual Interface[] GetInterfaces() { return null; }

        /// <summary>
        /// Retrieves the DCF interfaces that match the specified filter.
        /// </summary>
        /// <param name="filter">The interface name filter. Can contain wildcards.</param>
        /// <param name="custom"><c>true</c> if the custom names should be checked; otherwise, <c>false</c>.</param>
        /// <returns>The DCF interfaces that match the specified filter.</returns>
        /// <remarks>
        /// <para>Feature introduced in DataMiner 8.5.3 (RN 8867).</para>
        /// <para>If <paramref name="custom"/> is set to <c>false</c>, the name is checked.</para></remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var interfaces = dummy.GetInterfacesByName("MyInterface *", true);
        /// </code>
        /// </example>
        public virtual Interface[] GetInterfacesByName(string filter, bool custom) { return null; }

        /// <summary>
        /// Retrieves the DCF interfaces of the specified interface type.
        /// </summary>
        /// <param name="type">The interface type ("in", "out", "inout").</param>
        /// <returns>The DCF interfaces of the specified type.</returns>
        /// <remarks>
        /// <para>Feature introduced in DataMiner 8.5.3 (RN 8867).</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var interfaces = dummy.GetInterfacesByType("out");
        /// </code>
        /// </example>
        public virtual Interface[] GetInterfacesByType(string type) { return null; }

        /// <summary>
        /// Retrieves the internal interfaces of this dummy.
        /// </summary>
        /// <returns>The internal interfaces.</returns>
        /// <remarks>Feature introduced in DataMiner 10.1.5 (RN 29314).</remarks>
        public virtual Interface[] GetInternalInterfaces()
        { return null; }

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <exception cref="DataMinerException">The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified name.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int connectedInput = dummy.GetMatrixInputForOutput(1000, "Output 4");
        /// </code>
        /// </example>
        public virtual int GetMatrixInputForOutput(int pid, string output) { return 0; }

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <exception cref="DataMinerException">The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="output"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int connectedInput = dummy.GetMatrixInputForOutput(1000, 4);
        /// </code>
        /// </example>
        public virtual int GetMatrixInputForOutput(int pid, int output) { return 0; }

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <exception cref="DataMinerException">The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int connectedInput = dummy.GetMatrixInputForOutput("Example matrix", 4);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int GetMatrixInputForOutput(string name, int output) { return 0; }

        /// <summary>
        /// Gets the input that is connected to the specified output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The label of the matrix parameter.</param>
        /// <param name="output">The output.</param>
        /// <returns>The connected input or 0 if the output is not connected.</returns>
        /// <exception cref="DataMinerException">The specified matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int connectedInput = dummy.GetMatrixInputForOutput("Example matrix", "Output 4");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int GetMatrixInputForOutput(string name, string output) { return 0; }

        /// <summary>
        /// Gets an object that can be used to change the specified preset.
        /// </summary>
        /// <param name="name">The preset name.</param>
        /// <returns>An object that can be used to change the specified preset.</returns>
        /// <exception cref="DataMinerException">The element is not active.<br />
        /// -or-<br />
        /// The specified preset failed to load.</exception>
        /// <remarks>Only shared presets can be opened.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var preset = dummy.GetSpectrumPreset("Preset 1");
        /// </code>
        /// </example>
		public virtual SpectrumPreset GetSpectrumPreset(string name) { return null; }

        /// <summary>
        /// Gets the value of the specified parameter.
        /// </summary>
        /// <param name="pid">The ID of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is invalid.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter(10);
        /// </code>
        /// </example>
        public virtual object GetParameter(int pid) { return null; }

        /// <summary>
        /// Gets the value of the specified table cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The value of the parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter(1000, "1");
        /// </code>
        /// </example>
        public virtual object GetParameter(int pid, string idx) { return null; }

        /// <summary>
        /// Gets the value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter("MyParameter");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual object GetParameter(string name) { return null; }

        /// <summary>
        /// Gets the value of the specified table cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The value of the parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter("MyTableColumn", "1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual object GetParameter(string name, string idx) { return null; }

        /// <summary>
        /// Gets the value of the specified table cell using the primary key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The value of the parameter or <see langword="null"/> if no row with the specified primary key was found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter(1002, "1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>If a column is hidden by an information template, the value for a cell of that column can no longer be retrieved by this method (null is returned). However, the value can still be retrieved using the <see cref="GetParameter(int, string)"/> method. Using the GetParameter method is therefore recommended.</para>
        /// </remarks>
        public virtual object GetParameterByPrimaryKey(int pid, string primaryKey) { return null; }

        /// <summary>
        /// Gets the value of the specified table cell using the primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The value of the parameter or <see langword="null"/> if no row with the specified primary key was found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var value = dummy.GetParameter("MyTableColumn", "1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual object GetParameterByPrimaryKey(string name, string primaryKey) { return null; }

        /// <summary>
        /// Gets the display value of the specified standalone parameter.
        /// </summary>
        /// <param name="pid">The ID of the standalone parameter.</param>
        /// <returns>The display value of the specified standalone parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>Useful for discrete parameters.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplay(40);
        /// </code>
        /// </example>
        public virtual string GetParameterDisplay(int pid) { return null; }

        /// <summary>
        /// Gets the display value of the specified table cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>Useful for discrete parameters.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplay(1004, "1");
        /// </code>
        /// </example>
        public virtual string GetParameterDisplay(int pid, string idx) { return null; }

        /// <summary>
        /// Gets the display value of the specified standalone parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the standalone parameter.</param>
        /// <returns>The display value of the specified standalone parameter.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplay("MyParam");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string GetParameterDisplay(string name) { return null; }

        /// <summary>
        /// Gets the display value of the specified table cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The primary key or display key.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplay("MyColumn", "1");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string GetParameterDisplay(string name, string idx) { return null; }

        /// <summary>
        /// Gets the display value of the specified table cell using the column name and row primary key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>Useful for discrete parameters.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplayByPrimaryKey(1004, "1");
        /// </code>
        /// </example>
        public virtual string GetParameterDisplayByPrimaryKey(int pid, string primaryKey) { return ""; }

        /// <summary>
        /// Gets the display value of the specified table cell using the column name and row primary key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <returns>The display value of the specified table cell or "Not Initialized" if the specified row was not found.</returns>
        /// <exception cref="DataMinerException">The specified parameter was not found.<br />
        /// -or-<br />
        /// The specified parameter is incorrect.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>Useful for discrete parameters.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var displayValue = dummy.GetParameterDisplayByPrimaryKey("MyColumn", "1");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string GetParameterDisplayByPrimaryKey(string name, string primaryKey) { return ""; }

        /// <summary>
        /// Gets the value of the specified element property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The property value or <see langword="null"/> when not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var propertyValue = dummy.GetPropertyValue("MyProperty");
        /// </code>
        /// </example>
        public virtual string GetPropertyValue(string propertyName) { return ""; }

        /// <summary>
        /// Gets the value that corresponds with the specified display value of the specified parameter.
        /// </summary>
        /// <param name="pid">The ID of the parameter.</param>
        /// <param name="displayValue">The display value for which the raw value has to be determined.</param>
        /// <returns>The raw value that corresponds with the specified display value.<br />
        /// In case the parameter was not found, the specified value in <paramref name="displayValue"/> is returned.<br />
        /// In case the parameter was found, but the display value is not specified in the parameter, <see langword="null"/> is returned.
        /// </returns>
        /// <remarks>Used with parameters defining discrete entries to retrieve the raw value (e.g. "1") for a specific display value (e.g. “Main”).</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string rawValue = dummy.GetRawValue(100, "Main");
        /// </code>
        /// </example>
        public virtual string GetRawValue(int pid, string displayValue) { return ""; }

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
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string rawValue = dummy.GetRawValue("MyDiscreteParameter", "Main");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string GetRawValue(string name, string displayValue) { return ""; }

        /// <summary>
        /// Gets the ID of the read parameter that corresponds with the specified write parameter ID.
        /// </summary>
        /// <param name="pid">The ID of the write parameter.</param>
        /// <returns>The ID of the corresponding read parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int readParameterId = dummy.GetReadParameterIDFromWrite(101);
        /// </code>
        /// </example>
        public virtual int GetReadParameterIDFromWrite(int pid) { return 0; }

        /// <summary>
        /// Gets the ID of the read parameter that corresponds with the specified write parameter ID.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the write parameter.</param>
        /// <returns>The ID of the corresponding read parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int readParameterId = dummy.GetReadParameterIDFromWrite("MyParameter");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int GetReadParameterIDFromWrite(string name) { return 0; }

        /// <summary>
        /// Gets the display keys of the specified table.
        /// </summary>
        /// <param name="tablePid">The table or column parameter ID.</param>
        /// <returns>The display keys.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string[] displayKeys = dummy.GetTableDisplayKeys(1000);
        /// </code>
        /// </example>
        public virtual string[] GetTableDisplayKeys(int tablePid) { return null; }

        /// <summary>
        /// Gets the display keys of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter ID.</param>
        /// <returns>The display keys.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string[] displayKeys = dummy.GetTableDisplayKeys("MyTable");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string[] GetTableDisplayKeys(string tableParameterName) { return null; }

        /// <summary>
        /// Gets the primary key to display key map of the specified table.
        /// </summary>
        /// <param name="tablePid">The ID of the table or column parameter.</param>
        /// <returns>The primary key to display key map of the specified table.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var keyMap = dummy.GetTableKeyMappings(1000);
        /// </code>
        /// </example>
        public virtual DynamicTableIndicesResponse GetTableKeyMappings(int tablePid) { return null; }

        /// <summary>
        /// Gets the primary key to display key map of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter.</param>
        /// <returns>The primary key to display key map of the specified table.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// var keyMap = dummy.GetTableKeyMappings("MyTable");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual DynamicTableIndicesResponse GetTableKeyMappings(string tableParameterName) { return null; }

        /// <summary>
        /// Gets the primary keys of the specified table.
        /// </summary>
        /// <param name="tablePid">The ID of the table or column parameter.</param>
        /// <returns>The primary keys of the specified table.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string[] primaryKeys = dummy.GetTablePrimaryKeys(1000);
        /// </code>
        /// </example>
        public virtual string[] GetTablePrimaryKeys(int tablePid) { return null; }

        /// <summary>
        /// Gets the primary keys of the specified table.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="tableParameterName">The name of the table or column parameter.</param>
        /// <returns>The primary keys of the specified table.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string[] primaryKeys = dummy.GetTablePrimaryKeys("MyTable");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="tableParameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string[] GetTablePrimaryKeys(string tableParameterName) { return null; }

        /// <summary>
        /// Gets the ID of the write parameter that corresponds with the specified read parameter.
        /// </summary>
        /// <param name="pid">The ID of the read parameter.</param>
        /// <returns>The ID of the corresponding write parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int writeParameterId = dummy.GetWriteParameterIDFromRead(100);
        /// </code>
        /// </example>
        public virtual int GetWriteParameterIDFromRead(int pid) { return 0; }

        /// <summary>
        /// Gets the ID of the write parameter that corresponds with the specified read parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the read parameter.</param>
        /// <returns>The ID of the corresponding write parameter. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int writeParameterId = dummy.GetWriteParameterIDFromRead("MyParameter");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int GetWriteParameterIDFromRead(string name) { return 0; }

        /// <summary>
        /// Returns a value indicating whether the element has a property with the specified name.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><c>true</c> if the element has a property with the specified name; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool hasProperty = dummy.HasProperty("MyProperty");
        /// </code>
        /// </example>
        public virtual bool HasProperty(string propertyName) { return false; }

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no matrix input with the specified input label..<br />
        /// -or-<br />
        /// There is no matrix output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isConnected = dummy.IsMatrixCrosspointConnected(1000, "Input 1", "Output 7");
        /// </code>
        /// </example>
        public virtual bool IsMatrixCrosspointConnected(int pid, string input, string output) { return false; }

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is not in the range 1..nrOfInputs.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isConnected = dummy.IsMatrixCrosspointConnected(1000, 1, 7);
        /// </code>
        /// </example>
        public virtual bool IsMatrixCrosspointConnected(int pid, int input, int output) { return false; }

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is not in the range 1..nrOfInputs.<br />
        /// -or-<br />
        /// <paramref name="output"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="input"/> must be in the range 1..nrOfInputs.</para>
        /// <para><paramref name="output"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isConnected = dummy.IsMatrixCrosspointConnected("Example matrix", 1, 7);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool IsMatrixCrosspointConnected(string name, int input, int output) { return false; }

        /// <summary>
        /// Returns a value indicating whether the specified matrix crosspoint is connected.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the matrix parameter.</param>
        /// <param name="input">The matrix input.</param>
        /// <param name="output">The matrix output.</param>
        /// <returns><c>true</c> if the specified matrix crosspoint is connected; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no matrix input with the specified input label..<br />
        /// -or-<br />
        /// There is no matrix output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isConnected = dummy.IsMatrixCrosspointConnected("Example matrix", "Input 1", "Output 7");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool IsMatrixCrosspointConnected(string name, string input, string output) { return false; }

        /// <summary>
        /// Masks the element that is linked to the dummy.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Mask("Maintenance window.");
        /// </code>
        /// </example>
        public virtual void Mask(string reason) { }

        /// <summary>
        /// Masks the element that is linked to the dummy for the specified period of time.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
        /// <param name="amountOfSeconds">The number of seconds to mask the dummy.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Mask("Maintenance window.", 7200);
        /// </code>
        /// </example>
        public virtual void Mask(string reason, int amountOfSeconds) { }

        /// <summary>
        /// Masks the element that is linked to the dummy until all its alarms have been cleared.
        /// </summary>
        /// <param name="reason">The reason why the element is masked.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MaskUntilNormal("Suppressed.");
        /// </code>
        /// </example>
        public virtual void MaskUntilNormal(string reason) { }

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLineLabel">The label of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableInputLine(1000, "Input 4", true);
        /// </code>
        /// </example>
        public virtual void MatrixEnableInputLine(int pid, string inputLineLabel, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <remarks>The input index must be in the range 1..nrOfInputs.</remarks>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableInputLine(1000, 2, false);
        /// </code>
        /// </example>
        public virtual void MatrixEnableInputLine(int pid, int index, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <remarks>The input index must be in the range 1..nrOfInputs.</remarks>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableInputLine("Example Matrix", 2, false);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableInputLine(string parameterName, int index, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLineLabel">The label of the input.</param>
        /// <param name="state"><c>true</c> to enable the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableInputLine("Example Matrix", "Input 4", false);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableInputLine(string parameterName, string inputLineLabel, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableLine(1000, true, "Input 4", false);
        /// </code>
        /// </example>
        public virtual void MatrixEnableLine(int pid, bool input, string lineLabel, bool state) { }

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
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableLine(1000, true, 4, false);
        /// </code>
        /// </example>
        public virtual void MatrixEnableLine(int pid, bool input, int index, bool state) { }

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
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableLine("Example Matrix", true, 4, false);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableLine(string parameterName, bool input, int index, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the input or output.</param>
        /// <param name="state"><c>true</c> to enable the input or output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableLine("Example Matrix", false, "Output 4", true);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableLine(string parameterName, bool input, string lineLabel, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableOutputLine(1000, 2, false);
        /// </code>
        /// </example>
        public virtual void MatrixEnableOutputLine(int pid, int index, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLineLabel">The label of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableOutputLine(1000, "Output 2", false);
        /// </code>
        /// </example>
        public virtual void MatrixEnableOutputLine(int pid, string outputLineLabel, bool state) { }

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
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableOutputLine("Example Matrix", 2, false);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableOutputLine(string parameterName, int index, bool state) { }

        /// <summary>
        /// Enables or disables the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLineLabel">The label of the output.</param>
        /// <param name="state"><c>true</c> to enable the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixEnableOutputLine("Example Matrix", "Output 2", false);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixEnableOutputLine(string parameterName, string outputLineLabel, bool state) { }

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixGetFollowMode(1000, 1);
        /// </code>
        /// </example>
        public virtual bool MatrixGetFollowMode(int pid, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixGetFollowMode(1000, "Output 1");
        /// </code>
        /// </example>
        public virtual bool MatrixGetFollowMode(int pid, string outputLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para></para><paramref name="index"/> must be in the range 1..nrOfOutputs.
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixGetFollowMode("Example Matrix", 1);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetFollowMode(string parameterName, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether "follow mode" is enabled on the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns><c>true</c> if the "follow mode" is enabled on the specified matrix output; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixGetFollowMode("Example Matrix", "Output 1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetFollowMode(string parameterName, string outputLabel) { return false; }

        /// <summary>
        /// Gets the index of the input or output that corresponds with the specified input or output label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified label is an input label; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input (or output in case <paramref name="input" /> is <c>false</c>).</param>
        /// <returns>The corresponding index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter is not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.</exception>
        /// <remarks>The returned index is in the range 1..nrOfInputs or 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetIndexFromLabel(1000, false, "Output 10");
        /// </code>
        /// </example>
        public virtual int MatrixGetIndexFromLabel(int pid, bool input, string label) { return 0; }

        /// <summary>
        /// Gets the index of the input or output that corresponds with the specified input or output label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified label is an input label; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input (or output in case <paramref name="input" /> is <c>false</c>).</param>
        /// <returns>The corresponding index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter is not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.</exception>
        /// <remarks>The returned index is in the range 1..nrOfInputs or 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetIndexFromLabel("Example Matrix", false, "Output 10");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int MatrixGetIndexFromLabel(string parameterName, bool input, string label) { return 0; }

        /// <summary>
        /// Gets the index of the input that corresponds with the specified input label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the input.</param>
        /// <returns>The corresponding input index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// </exception>
        /// <remarks>The returned index is in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetInputIndexFromInputLabel(1000, "Input 10");
        /// </code>
        /// </example>
        public virtual int MatrixGetInputIndexFromInputLabel(int pid, string inputLabel) { return 0; }

        /// <summary>
        /// Gets the index of the input that corresponds with the specified input label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the input.</param>
        /// <returns>The corresponding input index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>The returned index is in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetInputIndexFromInputLabel("Example Matrix", "Input 10");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int MatrixGetInputIndexFromInputLabel(string parameterName, string inputLabel) { return 0; }

        /// <summary>
        /// Gets the label of the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <returns>The label of the specified matrix input.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.<br />
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string inputLabel = dummy.MatrixGetInputLabel(1000, 10);
        /// </code>
        /// </example>
        public virtual string MatrixGetInputLabel(int pid, int index) { return ""; }

        /// <summary>
        /// Gets the label of the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <returns>The label of the specified matrix input.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.<br />
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string inputLabel = dummy.MatrixGetInputLabel("Example matrix", 10);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string MatrixGetInputLabel(string parameterName, int index) { return ""; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetInputLockMode(1000, "Input 1");
        /// </code>
        /// </example>
        public virtual bool MatrixGetInputLockMode(int pid, string inputLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.<br />
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetInputLockMode(1000, 4);
        /// </code>
        /// </example>
        public virtual bool MatrixGetInputLockMode(int pid, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.<br />
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetInputLockMode("Example matrix", 10);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetInputLockMode(string parameterName, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetInputLockMode("Example matrix", "Input 1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetInputLockMode(string parameterName, string inputLabel) { return false; }

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
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLabel(1000, true, 1);
        /// </code>
        /// </example>
        public virtual string MatrixGetLabel(int pid, bool input, int index) { return ""; }

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
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLabel("Example Matrix", true, 1);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string MatrixGetLabel(string parameterName, bool input, int index) { return ""; }

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLockMode(1000, true, "Input 10");
        /// </code>
        /// </example>
        public virtual bool MatrixGetLockMode(int pid, bool input, string label) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLockMode(1000, true, 10);
        /// </code>
        /// </example>
        public virtual bool MatrixGetLockMode(int pid, bool input, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified input label.<br />
        /// -or-<br />
        /// There is no output with the specified output label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLockMode("Example Matrix", true, "Input 10");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetLockMode(string parameterName, bool input, string label) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified input or output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <returns>The label of the specified matrix input or output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetLockMode("Example Matrix", true, 10);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetLockMode(string parameterName, bool input, int index) { return false; }

        /// <summary>
        /// Gets the index of the output that corresponds with the specified output label.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns>The corresponding output index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter is not found.</exception>
        /// <remarks>The returned output is in the range 1..nrOfOutputs.</remarks>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified output label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetOutputIndexFromOutputLabel(1000, "Output 10");
        /// </code>
        /// </example>
        public virtual int MatrixGetOutputIndexFromOutputLabel(int pid, string outputLabel) { return 0; }

        /// <summary>
        /// Gets the index of the output that corresponds with the specified output label.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <returns>The corresponding output index.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified output label.<br />
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para>The returned output is in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int index = dummy.MatrixGetOutputIndexFromOutputLabel("Example matrix", "Output 10");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual int MatrixGetOutputIndexFromOutputLabel(string parameterName, string outputLabel) { return 0; }

        /// <summary>
        /// Gets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The output index. </param>
        /// <returns>The label of the specified matrix output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter is not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>The index of the output must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetOutputLabel(1000, 10);
        /// </code>
        /// </example>
        public virtual string MatrixGetOutputLabel(int pid, int index) { return ""; }

        /// <summary>
        /// Gets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The output index. </param>
        /// <returns>The label of the specified matrix output.</returns>
        /// <exception cref="DataMinerException">The matrix parameter is not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>The index of the output must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// string label = dummy.MatrixGetOutputLabel("Example Matrix", 10);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual string MatrixGetOutputLabel(string parameterName, int index) { return ""; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetOutputLockMode(1000, "Output 4");
        /// </code>
        /// </example>
        public virtual bool MatrixGetOutputLockMode(int pid, string outputLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>The specified output index must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetOutputLockMode(1000, 4);
        /// </code>
        /// </example>
        public virtual bool MatrixGetOutputLockMode(int pid, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetOutputLockMode("Example matrix", "Output 4");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetOutputLockMode(string parameterName, string outputLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is locked.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is locked; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>The specified output index must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isLocked = dummy.MatrixGetOutputLockMode("Example Matrix", 4);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixGetOutputLockMode(string parameterName, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks>The specified input index must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsInputLineEnabled(1000, 4);
        /// </code></example>
        public virtual bool MatrixIsInputLineEnabled(int pid, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsInputLineEnabled(1000, "Input 4");
        /// </code></example>
        public virtual bool MatrixIsInputLineEnabled(int pid, string lineLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks>The specified input index must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsInputLineEnabled("Example Matrix", 4);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsInputLineEnabled(string parameterName, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix input.</param>
        /// <returns><c>true</c> if the specified matrix input is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsInputLineEnabled("Example Matrix", "Input 4");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsInputLineEnabled(string parameterName, string lineLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// There is no output with the specified label and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsLineEnabled(1000, true, "Input 4");
        /// </code>
        /// </example>
        public virtual bool MatrixIsLineEnabled(int pid, bool input, string lineLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsLineEnabled(1000, true, 4);
        /// </code>
        /// </example>
        public virtual bool MatrixIsLineEnabled(int pid, bool input, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsLineEnabled("Example Matrix", true, 4);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsLineEnabled(string parameterName, bool input, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix input or output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="lineLabel">The label of the matrix input or output.</param>
        /// <returns><c>true</c> if the specified matrix input or output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// There is no output with the specified label and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isInputEnabled = dummy.MatrixIsLineEnabled("Example Matrix", true, "Input 4");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsLineEnabled(string parameterName, bool input, string lineLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>The specified output index must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isOutputEnabled = dummy.MatrixIsOutputLineEnabled(1000, 4);
        /// </code>
        /// </example>
        public virtual bool MatrixIsOutputLineEnabled(int pid, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isOutputEnabled = dummy.MatrixIsOutputLineEnabled(1000, "Output 4");
        /// </code>
        /// </example>
        public virtual bool MatrixIsOutputLineEnabled(int pid, string lineLabel) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>The specified output index must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isOutputEnabled = dummy.MatrixIsOutputLineEnabled("Example Matrix", 4);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsOutputLineEnabled(string parameterName, int index) { return false; }

        /// <summary>
        /// Gets a value indicating whether the specified matrix output is enabled.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="lineLabel">The label of the matrix output.</param>
        /// <returns><c>true</c> if the specified matrix output is enabled; otherwise, <c>false</c>.</returns>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isOutputEnabled = dummy.MatrixIsInputLineEnabled("Example Matrix", "Output 4");
        /// </code></example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual bool MatrixIsOutputLineEnabled(string parameterName, string lineLabel) { return false; }

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <param name="slave">The index of the slave output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="master"/> is not in the range 1..nrOfOutputs.<br />
        /// -or-<br />
        /// <paramref name="slave"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>
        /// <para><paramref name="master"/> must be in the range 1..nrOfOutputs.</para>
        /// <para><paramref name="slave"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMaster(1000, 4, 6);
        /// </code>
        /// </example>
        public virtual void MatrixSetFollowMaster(int pid, int master, int slave) { }

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <param name="slaveLabel">The label of the slave output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified master label.<br />
        /// -or-<br />
        /// There is no output with the specified slave label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMaster(1000, "Output 4", "Output 6");
        /// </code>
        /// </example>
        public virtual void MatrixSetFollowMaster(int pid, string masterLabel, string slaveLabel) { }

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <param name="slave">The index of the slave output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="master"/> is not in the range 1..nrOfOutputs.<br />
        /// -or-<br />
        /// <paramref name="slave"/> is not in the range 1..nrOfOutputs.<br />
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="master"/> must be in the range 1..nrOfOutputs.</para>
        /// <para><paramref name="slave"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMaster("Example Matrix", 4, 6);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetFollowMaster(string parameterName, int master, int slave) { }

        /// <summary>
        /// Configures a slave output to follow a master output on the specified matrix.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <param name="slaveLabel">The label of the slave output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified master label.<br />
        /// -or-<br />
        /// There is no output with the specified slave label.<br />
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMaster("Example Matrix", "Output 4", "Output 6");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetFollowMaster(string parameterName, string masterLabel, string slaveLabel) { }

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMode(1000, 10, false);
        /// </code>
        /// </example>
        public virtual void MatrixSetFollowMode(int pid, int index, bool mode) { }

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMode(1000, "Output 10", false);
        /// </code>
        /// </example>
        public virtual void MatrixSetFollowMode(int pid, string outputLabel, bool mode) { }

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMode("Example Matrix", 10, false);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetFollowMode(string parameterName, int index, bool mode) { }

        /// <summary>
        /// Enables or disables the ‘follow mode’ of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the output.</param>
        /// <param name="mode"><c>true</c> if ‘follow mode’ must be enabled; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetFollowMode("Example Matrix", "Output 10", false);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetFollowMode(string parameterName, string outputLabel, bool mode) { }

        /// <summary>
        /// Sets the label of the specified input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLabel(1000, 10, "Main");
        /// </code>
        /// </example>
        public virtual void MatrixSetInputLabel(int pid, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="oldName">The label of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLabel(1000, "Input 1", "Main");
        /// </code>
        /// </example>
        public virtual void MatrixSetInputLabel(int pid, string oldName, string newName) { }

        /// <summary>
        /// Sets the label of the specified input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLabel("Example Matrix", 10, "Main");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetInputLabel(string parameterName, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="oldName">The label of the input.</param>
        /// <param name="newName">The new input label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLabel("Example Matrix", "Input 1", "Main");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetInputLabel(string parameterName, string oldName, string newName) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br/>
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLockMode(1000, "Input 1", true);
        /// </code>
        /// </example>
        public virtual void MatrixSetInputLockMode(int pid, string inputLabel, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br/>
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLockMode(1000, 1, true);
        /// </code>
        /// </example>
        public virtual void MatrixSetInputLockMode(int pid, int index, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfInputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLockMode("Example matrix", 1, true);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetInputLockMode(string parameterName, int index, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="inputLabel">The label of the matrix input.</param>
        /// <param name="mode"><c>true</c> to lock the input; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br/>
        /// There is no input with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetInputLockMode("Example matrix", "Input 2", true);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetInputLockMode(string parameterName, string inputLabel, bool mode) { }

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLabel(1000, true, 4, "Main");
        /// </code>
        /// </example>
        public virtual void MatrixSetLabel(int pid, bool input, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="oldName">The label of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>true</c> and there is no input with the specified label.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>false</c> and there is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLabel(1000, true, "Input 1", "Main");
        /// </code>
        /// </example>
        public virtual void MatrixSetLabel(int pid, bool input, string oldName, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLabel("Example Matrix", true, 4, "Main");
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetLabel(string parameterName, bool input, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="oldName">The label of the input or output.</param>
        /// <param name="newName">The new label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>true</c> and there is no input with the specified label.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>false</c> and there is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLabel("Example Matrix", true, "Input 1", "Main");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetLabel(string parameterName, bool input, string oldName, string newName) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLockMode(1000, true, 4, false);
        /// </code>
        /// </example>
        public virtual void MatrixSetLockMode(int pid, bool input, int index, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>true</c> and there is no input with the specified label.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>false</c> and there is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLockMode(1000, true, "Input 4", false);
        /// </code>
        /// </example>
        public virtual void MatrixSetLockMode(int pid, bool input, string label, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="label">The label of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>true</c> and there is no input with the specified label.<br />
        /// -or-<br />
        /// <paramref name="input"/> is <c>false</c> and there is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLockMode("Example Matrix", true, "Input 4", false);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetLockMode(string parameterName, bool input, string label, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix input or output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="input"><c>true</c> if the specified index is an input; otherwise, <c>false</c>.</param>
        /// <param name="index">The index of the input or output.</param>
        /// <param name="mode"><c>true</c> if the input or output must be locked; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfInputs and <paramref name="input"/> is <c>true</c>.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs and <paramref name="input"/> is <c>false</c>.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfInputs if <paramref name="input"/> is <c>true</c>.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs if <paramref name="input"/> is <c>false</c>.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetLockMode("Example Matrix", true, 4, false);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetLockMode(string parameterName, bool input, int index, bool mode) { }

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="oldName">The label of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLabel(1000, "Output 1", "A");
        /// </code>
        /// </example>
        public virtual void MatrixSetOutputLabel(int pid, string oldName, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLabel(1000, 10, "A");
        /// </code>
        /// </example>
        public virtual void MatrixSetOutputLabel(int pid, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLabel("Example Matrix", 10, "A");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetOutputLabel(string parameterName, int index, string newName) { }

        /// <summary>
        /// Sets the label of the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="oldName">The label of the output.</param>
        /// <param name="newName">The new output label.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLabel("Example Matrix", "Output 1", "A");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetOutputLabel(string parameterName, string oldName, string newName) { }

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks><paramref name="index"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLockMode(1000, 1, true);
        /// </code>
        /// </example>
        public virtual void MatrixSetOutputLockMode(int pid, int index, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLockMode(1000, "Output 1", true);
        /// </code>
        /// </example>
        public virtual void MatrixSetOutputLockMode(int pid, string outputLabel, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="outputLabel">The label of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLockMode("Example Matrix", "Output 1", true);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetOutputLockMode(string parameterName, string outputLabel, bool mode) { }

        /// <summary>
        /// Locks or unlocks the specified matrix output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="index">The index of the matrix output.</param>
        /// <param name="mode"><c>true</c> to lock the output; otherwise, <c>false</c>.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="index"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// <para><paramref name="index"/> must be in the range 1..nrOfOutputs.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixSetOutputLockMode("Example matrix", 1, true);
        /// </code>
        /// </example>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixSetOutputLockMode(string parameterName, int index, bool mode) { }

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixStopBeingMaster(1000, "Output 1");
        /// </code>
        /// </example>
        public virtual void MatrixStopBeingMaster(int pid, string masterLabel) { }

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// </summary>
        /// <param name="pid">The ID of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="master"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <example>
        /// <remarks><paramref name="master"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixStopBeingMaster(1000, 1);
        /// </code>
        /// </example>
        public virtual void MatrixStopBeingMaster(int pid, int master) { }

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="masterLabel">The label of the master output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// There is no output with the specified label.
        /// </exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixStopBeingMaster("Example Matrix", "Output 1");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixStopBeingMaster(string parameterName, string masterLabel) { }

        /// <summary>
        /// Stops the specified matrix output from being a master output.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="parameterName">The name of the matrix parameter.</param>
        /// <param name="master">The index of the master output.</param>
        /// <exception cref="DataMinerException">The matrix parameter was not found.<br />
        /// -or-<br />
        /// <paramref name="master"/> is not in the range 1..nrOfOutputs.
        /// </exception>
        /// <example>
        /// <remarks><paramref name="master"/> must be in the range 1..nrOfOutputs.</remarks>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.MatrixStopBeingMaster("Example Matrix", 1);
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="parameterName"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void MatrixStopBeingMaster(string parameterName, int master) { }

        /// <summary>
        /// Pauses the element that is linked to the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Pause();
        /// </code>
        /// </example>
        public virtual void Pause() { }

        /// <summary>
        /// Removes the link between this element and the alarm template that is assigned to it. This sets the element to “Not Monitored”.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.RemoveAlarmTemplate();
        /// </code>
        /// </example>
        public virtual void RemoveAlarmTemplate() { }

        /// <summary>
        /// Removes the link between an element and the trend template that is assigned to it. This disables trending for the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.RemoveTrendTemplate();
        /// </code>
        /// </example>
        public virtual void RemoveTrendTemplate() { }

        /// <summary>
        /// Restarts the element that is linked to the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Restart();
        /// </code>
        /// </example>
        public virtual void Restart() { }

        /// <summary>
        /// Assigns the specified alarm template to the dummy.
        /// </summary>
        /// <param name="name">The name of the alarm template.</param>
        /// <exception cref="DataMinerException"><paramref name="name"/> is invalid.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetAlarmTemplate("Template 1");
        /// </code>
        /// </example>
        public virtual void SetAlarmTemplate(string name) { }

        /// <summary>
        /// Sets the value of the specified parameter.
        /// </summary>
        /// <param name="pid">The parameter ID.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="pid"/> is invalid.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameter(100, "Example Value");
        /// </code>
        /// </example>
        public virtual void SetParameter(int pid, object value) { }

        /// <summary>
        /// Sets the value of the specified cell.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="idx">The display key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="pid"/> is invalid.</exception>
        /// -or-<br />
        /// There is no row with the specified display key.
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameter(5003, "Row 1", "Example Value");
        /// </code>
        /// </example>
        public virtual void SetParameter(int pid, string idx, object value) { }

        /// <summary>
        /// Sets the value of the specified parameter.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="name"/> is invalid.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameter("Example Parameter", "Example Value");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void SetParameter(string name, object value) { }

        /// <summary>
        /// Sets the value of the specified cell.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="idx">The display key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="name"/> is invalid.</exception>
        /// -or-<br />
        /// There is no row with the specified display key.
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameter("Example Column Parameter", "Row 1", "Example Value");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void SetParameter(string name, string idx, object value) { }

        /// <summary>
        /// Sets the value of a cell specified using the primary key instead of the display key.
        /// </summary>
        /// <param name="pid">The ID of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="pid"/> is invalid.</exception>
        /// -or-<br />
        /// There is no row with the specified primary key.
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameterByPrimaryKey(5003, "Row 1", "Example Value");
        /// </code>
        /// </example>
        public virtual void SetParameterByPrimaryKey(int pid, string primaryKey, object value) { }

        /// <summary>
        /// Sets the value of a cell specified using the primary key instead of the display key.
        /// <note>Please use instead an overload that takes the parameter ID to prevent issues in case the parameter <see href="xref:Protocol.Params.Param.Description">Description</see> changes.</note>
        /// </summary>
        /// <param name="name">The name of the column parameter.</param>
        /// <param name="primaryKey">The primary key of the row.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="DataMinerException"><paramref name="name"/> is invalid.</exception>
        /// -or-<br />
        /// There is no row with the specified primary key.
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetParameterByPrimaryKey("Example Column Parameter", "Row 1", "Example Value");
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>The specified value for the <paramref name="name"/> argument should be the value of the <see href="xref:Protocol.Params.Param.Description" >Description</see> tag of the parameter and not the value of the <see href="xref:Protocol.Params.Param.Name" >Name</see> tag.</para>
        /// </remarks>
        [Obsolete("Use overloads with parameter ID instead of name.")]
        public virtual void SetParameterByPrimaryKey(string name, string primaryKey, object value) { }

        /// <summary>
        /// Sets the value of a writable element property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyValue">The value to set.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetPropertyValue("My Custom Property", "Example Value");
        /// </code>
        /// </example>
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
        public virtual void SetPropertyValue(string propertyName, string propertyValue) { }

        /// <summary>
        /// Assigns the specified trend template to the dummy.
        /// </summary>
        /// <param name="name">The name of the trend template to assign.</param>
        /// <exception cref="DataMinerException">There is no trend template with the specified name.</exception>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SetTrendTemplate("Trend Template 1");
        /// </code>
        /// </example>
        public virtual void SetTrendTemplate(string name) { }

        /// <summary>
        /// Disables a spectrum monitor.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumDisableMonitor("Monitor Name");
        /// </code>
        /// </example>
        public virtual void SpectrumDisableMonitor(string monitorName) { }

        /// <summary>
        /// Disables a spectrum monitor.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumDisableMonitor(1);
        /// </code>
        /// </example>
        public virtual void SpectrumDisableMonitor(int monitorId) { }

        /// <summary>
        /// Enables a spectrum monitor.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumEnableMonitor(1);
        /// </code>
        /// </example>
        public virtual void SpectrumEnableMonitor(int monitorId) { }

        /// <summary>
        /// Enables a spectrum monitor.
        /// </summary>
        /// <param name="monitorName">The name of the monitor.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumEnableMonitor("Monitor Name");
        /// </code>
        /// </example>
        public virtual void SpectrumEnableMonitor(string monitorName) { }

        /// <summary>
        /// Gets the ID that corresponds with the specified spectrum measurement point name. 
        /// </summary>
        /// <param name="measurementPointName">The name of the measurement point.</param>
        /// <returns>The ID that corresponds with the specified spectrum measurement point name or -1 when not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int measurementPointId = dummy.SpectrumFindMeasurementPointIdByName("MyMeasurement PointName");
        /// </code>
        /// </example>
        public virtual int SpectrumFindMeasurementPointIdByName(string measurementPointName) { return 0; }

        /// <summary>
        /// Gets the ID that corresponds with the specified spectrum monitor name.
        /// </summary>
        /// <param name="monitorName">The spectrum monitor name.</param>
        /// <returns>The ID that corresponds with the specified spectrum monitor name or -1 when not found.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// int monitorId = dummy.SpectrumFindMonitorIdByName("MyMonitorName");
        /// </code>
        /// </example>
        public virtual int SpectrumFindMonitorIdByName(string monitorName) { return 0; }

        /// <summary>
        /// Returns a value indicating whether the specified spectrum monitor is enabled.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
        /// <returns><c>true</c> if the specified spectrum monitor is enabled; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isEnabled = dummy.SpectrumIsMonitorEnabled("MyMonitorName");
        /// </code>
        /// </example>
        public virtual bool SpectrumIsMonitorEnabled(string monitorName) { return false; }

        /// <summary>
        /// Returns a value indicating whether the specified spectrum monitor is enabled.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <returns><c>true</c> if the specified spectrum monitor is enabled; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// bool isEnabled = dummy.SpectrumIsMonitorEnabled("MyMonitorName");
        /// </code>
        /// </example>
        public virtual bool SpectrumIsMonitorEnabled(int monitorId) { return false; }

        /// <summary>
        /// Selects the measurement point(s) on which a spectrum monitor has to be executed.
        /// </summary>
        /// <param name="monitorName">The name of the spectrum monitor.</param>
        /// <param name="measurementPointNames">The names of the measurement points.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumSelectMeasurementPointsForMonitor("MyMonitorName", new string[]{"MyMeasurementPoint"});
        /// </code>
        /// </example>
        public virtual void SpectrumSelectMeasurementPointsForMonitor(string monitorName, params string[] measurementPointNames) { }

        /// <summary>
        /// Selects the measurement point(s) on which a spectrum monitor has to be executed.
        /// </summary>
        /// <param name="monitorId">The ID of the spectrum monitor.</param>
        /// <param name="measurementPointIds">The IDs of the measurement points.</param>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.SpectrumSelectMeasurementPointsForMonitor("MyMonitorName", new int[]{1, 2});
        /// </code>
        /// </example>
        public virtual void SpectrumSelectMeasurementPointsForMonitor(int monitorId, params int[] measurementPointIds) { }

        /// <summary>
        /// Starts the element that is linked to the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Start();
        /// </code>
        /// </example>
        public virtual void Start() { }

        /// <summary>
        /// Stops the element that is linked to the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Stop();
        /// </code>
        /// </example>
        public virtual void Stop() { }

        /// <summary>
        /// Unmasks the element that is linked to the dummy.
        /// </summary>
        /// <example>
        /// <code>
        /// var dummy = engine.GetDummy("dummy1");
        /// dummy.Unmask();
        /// </code>
        /// </example>
        public virtual void Unmask() { }
    }
}