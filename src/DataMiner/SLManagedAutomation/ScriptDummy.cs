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
		/// string elementName = element.Name; // Returns "dummy1".
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


		public virtual void ConnectMatrixCrosspoint(string name, string input, string output) { }
		public virtual void ConnectMatrixCrosspoint(int pid, int input, int output) { }
		public virtual void ConnectMatrixCrosspoint(string name, int input, int output) { }
		public virtual void ConnectMatrixCrosspoint(int pid, string input, string output) { }
		public virtual void DisconnectMatrixCrosspoint(string name, string input, string output) { }
		public virtual void DisconnectMatrixCrosspoint(string name, int input, int output) { }
		public virtual void DisconnectMatrixCrosspoint(int pid, string input, string output) { }
		public virtual void DisconnectMatrixCrosspoint(int pid, int input, int output) { }
		public virtual string FindDisplayKey(int pid, string primaryKey) { return ""; }
		public virtual string FindDisplayKey(string parameterName, string displayKey) { return ""; }
		public virtual int FindParameterID(string name) { return 0; }
		public virtual int FindParameterID(string name, bool writeParam) { return 0; }
		public virtual string FindPrimaryKey(int pid, string displayKey) { return ""; }
		public virtual string FindPrimaryKey(string parameterName, string displayKey) { return ""; }
		public virtual string FindView() { return ""; }
		public virtual string[] FindViews() { return null; }
		public virtual int FindWriteParameterID(string name) { return 0; }
		//public virtual DcfConnection[] GetConnections() { return null; }
		public virtual string GetDisplayValue(int pid, string rawValue) { return ""; }
		public virtual string GetDisplayValue(string name, string rawValue) { return ""; }
		public virtual Interface GetInterface(string customName) { return null; }
		public virtual Interface GetInterface(int interfaceID) { return null; }

		/// <summary>
		/// Retrieves the internal interfaces of this dummy.
		/// </summary>
		/// <returns>The internal interfaces.</returns>
		/// <remarks>Feature introduced in DataMiner 10.1.5 (RN 29314).</remarks>
		public virtual Interface[] GetInternalInterfaces() { return null; }

		/// <summary>
		/// Retrieves the external interfaces of this dummy.
		/// </summary>
		/// <returns>The external interfaces.</returns>
		/// <remarks>Feature introduced in DataMiner 10.1.5 (RN 29314).</remarks>
		public virtual Interface[] GetExternalInterfaces() { return null; }

		public virtual Interface[] GetInterfaces() { return null; }
		public virtual Interface[] GetInterfacesByName(string filter, bool custom) { return null; }
		public virtual Interface[] GetInterfacesByType(string type) { return null; }
		public virtual int GetMatrixInputForOutput(int pid, string output) { return 0; }
		public virtual int GetMatrixInputForOutput(string name, int output) { return 0; }
		public virtual int GetMatrixInputForOutput(string name, string output) { return 0; }
		public virtual int GetMatrixInputForOutput(int pid, int output) { return 0; }
		public virtual object GetParameter(string name) { return null; }
		public virtual object GetParameter(int pid) { return null; }
		public virtual object GetParameter(int pid, string idx) { return null; }
		public virtual object GetParameter(string name, string idx) { return null; }
		public virtual object GetParameterByPrimaryKey(string name, string primaryKey) { return null; }
		public virtual object GetParameterByPrimaryKey(int pid, string primaryKey) { return null; }
		public virtual string GetParameterDisplay(int pid) { return ""; }
		public virtual string GetParameterDisplay(string name) { return ""; }
		public virtual string GetParameterDisplay(string name, string idx) { return ""; }
		public virtual string GetParameterDisplay(int pid, string idx) { return ""; }
		public virtual string GetParameterDisplayByPrimaryKey(int pid, string primaryKey) { return ""; }
		public virtual string GetParameterDisplayByPrimaryKey(string name, string primaryKey) { return ""; }
		public virtual string GetPropertyValue(string propertyName) { return ""; }
		public virtual string GetRawValue(string name, string displayValue) { return ""; }
		public virtual string GetRawValue(int pid, string displayValue) { return ""; }
		public virtual int GetReadParameterIDFromWrite(string name) { return 0; }
		public virtual int GetReadParameterIDFromWrite(int pid) { return 0; }
		public virtual SpectrumPreset GetSpectrumPreset(string name) { return null; }
		public virtual string[] GetTableDisplayKeys(string tableParameterName) { return null; }
		public virtual string[] GetTableDisplayKeys(int tablePid) { return null; }
		public virtual DynamicTableIndicesResponse GetTableKeyMappings(string tableParameterName) { return null; }
		public virtual DynamicTableIndicesResponse GetTableKeyMappings(int tablePid) { return null; }
		public virtual string[] GetTablePrimaryKeys(string tableParameterName) { return null; }
		public virtual string[] GetTablePrimaryKeys(int tablePid) { return null; }
		public virtual int GetWriteParameterIDFromRead(int pid) { return 0; }
		public virtual int GetWriteParameterIDFromRead(string name) { return 0; }
		public virtual bool HasProperty(string propertyName) { return false; }
		public virtual bool IsMatrixCrosspointConnected(string name, string input, string output) { return false; }
		public virtual bool IsMatrixCrosspointConnected(string name, int input, int output) { return false; }
		public virtual bool IsMatrixCrosspointConnected(int pid, string input, string output) { return false; }
		public virtual bool IsMatrixCrosspointConnected(int pid, int input, int output) { return false; }
		public virtual void Mask(string reason) { }
		public virtual void Mask(string reason, int amountOfSeconds) { }
		public virtual void MaskUntilNormal(string reason) { }
		public virtual void MatrixEnableInputLine(string parameterName, int index, bool state) { }
		public virtual void MatrixEnableInputLine(int pid, int index, bool state) { }
		public virtual void MatrixEnableInputLine(string parameterName, string inputLineLabel, bool state) { }
		public virtual void MatrixEnableInputLine(int pid, string inputLineLabel, bool state) { }
		public virtual void MatrixEnableLine(int pid, bool input, string lineLabel, bool state) { }
		public virtual void MatrixEnableLine(int pid, bool input, int index, bool state) { }
		public virtual void MatrixEnableLine(string parameterName, bool input, string lineLabel, bool state) { }
		public virtual void MatrixEnableLine(string parameterName, bool input, int index, bool state) { }
		public virtual void MatrixEnableOutputLine(string parameterName, string outputLineLabel, bool state) { }
		public virtual void MatrixEnableOutputLine(int pid, int index, bool state) { }
		public virtual void MatrixEnableOutputLine(int pid, string outputLineLabel, bool state) { }
		public virtual void MatrixEnableOutputLine(string parameterName, int index, bool state) { }
		public virtual bool MatrixGetFollowMode(int pid, string outputLabel) { return false; }
		public virtual bool MatrixGetFollowMode(int pid, int index) { return false; }
		public virtual bool MatrixGetFollowMode(string parameterName, int index) { return false; }
		public virtual bool MatrixGetFollowMode(string parameterName, string outputLabel) { return false; }
		public virtual int MatrixGetIndexFromLabel(int pid, bool input, string label) { return 0; }
		public virtual int MatrixGetIndexFromLabel(string parameterName, bool input, string label) { return 0; }
		public virtual int MatrixGetInputIndexFromInputLabel(string parameterName, string inputLabel) { return 0; }
		public virtual int MatrixGetInputIndexFromInputLabel(int pid, string inputLabel) { return 0; }
		public virtual string MatrixGetInputLabel(int pid, int index) { return null; }
		public virtual string MatrixGetInputLabel(string parameterName, int index) { return null; }
		public virtual bool MatrixGetInputLockMode(string parameterName, string inputLabel) { return false; }
		public virtual bool MatrixGetInputLockMode(string parameterName, int index) { return false; }
		public virtual bool MatrixGetInputLockMode(int pid, string inputLabel) { return false; }
		public virtual bool MatrixGetInputLockMode(int pid, int index) { return false; }
		public virtual string MatrixGetLabel(int pid, bool input, int index) { return null; }
		public virtual string MatrixGetLabel(string parameterName, bool input, int index) { return null; }
		public virtual bool MatrixGetLockMode(int pid, bool input, string label) { return false; }
		public virtual bool MatrixGetLockMode(int pid, bool input, int index) { return false; }
		public virtual bool MatrixGetLockMode(string parameterName, bool input, int index) { return false; }
		public virtual bool MatrixGetLockMode(string parameterName, bool input, string label) { return false; }
		public virtual int MatrixGetOutputIndexFromOutputLabel(int pid, string outputLabel) { return 0; }
		public virtual int MatrixGetOutputIndexFromOutputLabel(string parameterName, string outputLabel) { return 0; }
		public virtual string MatrixGetOutputLabel(int pid, int index) { return null; }
		public virtual string MatrixGetOutputLabel(string parameterName, int index) { return null; }
		public virtual bool MatrixGetOutputLockMode(int pid, int index) { return false; }
		public virtual bool MatrixGetOutputLockMode(int pid, string outputLabel) { return false; }
		public virtual bool MatrixGetOutputLockMode(string parameterName, int index) { return false; }
		public virtual bool MatrixGetOutputLockMode(string parameterName, string outputLabel) { return false; }
		public virtual bool MatrixIsInputLineEnabled(int pid, string lineLabel) { return false; }
		public virtual bool MatrixIsInputLineEnabled(string parameterName, string lineLabel) { return false; }
		public virtual bool MatrixIsInputLineEnabled(string parameterName, int index) { return false; }
		public virtual bool MatrixIsInputLineEnabled(int pid, int index) { return false; }
		public virtual bool MatrixIsLineEnabled(string parameterName, bool input, string lineLabel) { return false; }
		public virtual bool MatrixIsLineEnabled(string parameterName, bool input, int index) { return false; }
		public virtual bool MatrixIsLineEnabled(int pid, bool input, string lineLabel) { return false; }
		public virtual bool MatrixIsLineEnabled(int pid, bool input, int index) { return false; }
		public virtual bool MatrixIsOutputLineEnabled(int pid, int index) { return false; }
		public virtual bool MatrixIsOutputLineEnabled(int pid, string lineLabel) { return false; }
		public virtual bool MatrixIsOutputLineEnabled(string parameterName, string lineLabel) { return false; }
		public virtual bool MatrixIsOutputLineEnabled(string parameterName, int index) { return false; }
		public virtual void MatrixSetFollowMaster(string parameterName, int master, int slave) { }
		public virtual void MatrixSetFollowMaster(int pid, string masterLabel, string slaveLabel) { }
		public virtual void MatrixSetFollowMaster(string parameterName, string masterLabel, string slaveLabel) { }
		public virtual void MatrixSetFollowMaster(int pid, int master, int slave) { }
		public virtual void MatrixSetFollowMode(string parameterName, string outputLabel, bool mode) { }
		public virtual void MatrixSetFollowMode(int pid, string outputLabel, bool mode) { }
		public virtual void MatrixSetFollowMode(string parameterName, int index, bool mode) { }
		public virtual void MatrixSetFollowMode(int pid, int index, bool mode) { }
		public virtual void MatrixSetInputLabel(int pid, int index, string newName) { }
		public virtual void MatrixSetInputLabel(string parameterName, string oldName, string newName) { }
		public virtual void MatrixSetInputLabel(int pid, string oldName, string newName) { }
		public virtual void MatrixSetInputLabel(string parameterName, int index, string newName) { }
		public virtual void MatrixSetInputLockMode(int pid, string inputLabel, bool mode) { }
		public virtual void MatrixSetInputLockMode(int pid, int index, bool mode) { }
		public virtual void MatrixSetInputLockMode(string parameterName, string inputLabel, bool mode) { }
		public virtual void MatrixSetInputLockMode(string parameterName, int index, bool mode) { }
		public virtual void MatrixSetLabel(string parameterName, bool input, string oldName, string newName) { }
		public virtual void MatrixSetLabel(int pid, bool input, int index, string newName) { }
		public virtual void MatrixSetLabel(int pid, bool input, string oldName, string newName) { }
		public virtual void MatrixSetLabel(string parameterName, bool input, int index, string newName) { }
		public virtual void MatrixSetLockMode(int pid, bool input, string label, bool mode) { }
		public virtual void MatrixSetLockMode(string parameterName, bool input, int index, bool mode) { }
		public virtual void MatrixSetLockMode(string parameterName, bool input, string label, bool mode) { }
		public virtual void MatrixSetLockMode(int pid, bool input, int index, bool mode) { }
		public virtual void MatrixSetOutputLabel(string parameterName, int index, string newName) { }
		public virtual void MatrixSetOutputLabel(int pid, string oldName, string newName) { }
		public virtual void MatrixSetOutputLabel(int pid, int index, string newName) { }
		public virtual void MatrixSetOutputLabel(string parameterName, string oldName, string newName) { }
		public virtual void MatrixSetOutputLockMode(string parameterName, int index, bool mode) { }
		public virtual void MatrixSetOutputLockMode(int pid, string outputLabel, bool mode) { }
		public virtual void MatrixSetOutputLockMode(int pid, int index, bool mode) { }
		public virtual void MatrixSetOutputLockMode(string parameterName, string outputLabel, bool mode) { }
		public virtual void MatrixStopBeingMaster(string parameterName, int master) { }
		public virtual void MatrixStopBeingMaster(string parameterName, string masterLabel) { }
		public virtual void MatrixStopBeingMaster(int pid, string masterLabel) { }
		public virtual void MatrixStopBeingMaster(int pid, int master) { }

		/// <summary>
		/// Pauses the element.
		/// </summary>
		public virtual void Pause() { }

		/// <summary>
		/// Removes the assigned alarm template.
		/// </summary>
		public virtual void RemoveAlarmTemplate() { }

		/// <summary>
		/// Removes the assigned trend template.
		/// </summary>
		public virtual void RemoveTrendTemplate() { }

		/// <summary>
		/// Restarts the element.
		/// </summary>
		public virtual void Restart() { }
		public virtual void SetAlarmTemplate(string name) { }
		public virtual void SetParameter(string name, object value) { }
		public virtual void SetParameter(int pid, object value) { }
		public virtual void SetParameter(string name, string idx, object value) { }
		public virtual void SetParameter(int pid, string idx, object value) { }
		public virtual void SetParameterByPrimaryKey(int pid, string primaryKey, object value) { }
		public virtual void SetParameterByPrimaryKey(string name, string primaryKey, object value) { }
		public virtual void SetPropertyValue(string propertyName, string propertyValue) { }
		public virtual void SetTrendTemplate(string name) { }
		public virtual void SpectrumDisableMonitor(int monitorId) { }
		public virtual void SpectrumDisableMonitor(string monitorName) { }
		public virtual void SpectrumEnableMonitor(int monitorId) { }
		public virtual void SpectrumEnableMonitor(string monitorName) { }
		public virtual int SpectrumFindMeasurementPointIdByName(string measurementPointName) { return 0; }
		public virtual int SpectrumFindMonitorIdByName(string monitorName) { return 0; }
		public virtual bool SpectrumIsMonitorEnabled(int monitorId) { return false; }
		public virtual bool SpectrumIsMonitorEnabled(string monitorName) { return false; }
		public virtual void SpectrumSelectMeasurementPointsForMonitor(string monitorName, params string[] measurementPointNames) { }
		public virtual void SpectrumSelectMeasurementPointsForMonitor(int monitorId, params int[] measurementPointIds) { }

		/// <summary>
		/// Starts the element.
		/// </summary>
		public virtual void Start() { }

		/// <summary>
		/// Stops the element.
		/// </summary>
		public virtual void Stop() { }

		/// <summary>
		/// Unmasks the element.
		/// </summary>
		public virtual void Unmask() { }
	}
}