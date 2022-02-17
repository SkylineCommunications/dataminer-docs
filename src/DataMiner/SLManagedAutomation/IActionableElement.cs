using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents an actionable element.
	/// </summary>
	/// <remarks>Refer to <see cref="Element"/> for an overview of the available properties and methods.</remarks>
	public interface IActionableElement
	{
		int DmaId { get; }
		int ElementId { get; }
		ElementInfoEventMessage ElementInfo { get; }
		string ElementName { get; }
		int Id { get; }
		bool IsActive { get; }
		string Name { get; }
		string PollingIP { get; }
		GetProtocolInfoResponseMessage Protocol { get; }
		string ProtocolName { get; }
		string ProtocolVersion { get; }

		void ConnectMatrixCrosspoint(int pid, int input, int output);
		void ConnectMatrixCrosspoint(int pid, string input, string output);
		void ConnectMatrixCrosspoint(string name, string input, string output);
		void ConnectMatrixCrosspoint(string name, int input, int output);
		void DisconnectMatrixCrosspoint(int pid, string input, string output);
		void DisconnectMatrixCrosspoint(string name, int input, int output);
		void DisconnectMatrixCrosspoint(string name, string input, string output);
		void DisconnectMatrixCrosspoint(int pid, int input, int output);
		string FindDisplayKey(string parameterName, string displayKey);
		string FindDisplayKey(int pid, string primaryKey);
		int FindParameterID(string name);
		int FindParameterID(string name, bool writeParam);
		string FindPrimaryKey(string parameterName, string displayKey);
		string FindPrimaryKey(int pid, string displayKey);
		string FindView();
		string[] FindViews();
		int FindWriteParameterID(string name);
		string GetDisplayValue(string name, string rawValue);
		string GetDisplayValue(int pid, string rawValue);
		int GetMatrixInputForOutput(int pid, string output);
		int GetMatrixInputForOutput(string name, int output);
		int GetMatrixInputForOutput(string name, string output);
		int GetMatrixInputForOutput(int pid, int output);
		object GetParameter(int pid);
		object GetParameter(string name);
		object GetParameter(string name, string idx);
		object GetParameter(int pid, string idx);
		object GetParameterByPrimaryKey(string name, string primaryKey);
		object GetParameterByPrimaryKey(int pid, string primaryKey);
		string GetParameterDisplay(string name);
		string GetParameterDisplay(int pid);
		string GetParameterDisplay(int pid, string idx);
		string GetParameterDisplay(string name, string idx);
		string GetParameterDisplayByPrimaryKey(int pid, string primaryKey);
		string GetParameterDisplayByPrimaryKey(string name, string primaryKey);
		string GetPropertyValue(string propertyName);
		string GetRawValue(int pid, string displayValue);
		string GetRawValue(string name, string displayValue);
		int GetReadParameterIDFromWrite(int pid);
		int GetReadParameterIDFromWrite(string name);
		SpectrumPreset GetSpectrumPreset(string name);
		string[] GetTableDisplayKeys(int tablePid);
		string[] GetTableDisplayKeys(string tableParameterName);
		DynamicTableIndicesResponse GetTableKeyMappings(string tableParameterName);
		DynamicTableIndicesResponse GetTableKeyMappings(int tablePid);
		string[] GetTablePrimaryKeys(int tablePid);
		string[] GetTablePrimaryKeys(string tableParameterName);
		int GetWriteParameterIDFromRead(int pid);
		int GetWriteParameterIDFromRead(string name);
		bool HasProperty(string propertyName);
		bool IsMatrixCrosspointConnected(int pid, int input, int output);
		bool IsMatrixCrosspointConnected(string name, string input, string output);
		bool IsMatrixCrosspointConnected(string name, int input, int output);
		bool IsMatrixCrosspointConnected(int pid, string input, string output);
		void Mask(string reason);
		void Mask(string reason, int amountOfSeconds);
		void MaskUntilNormal(string reason);
		void MatrixEnableInputLine(string parameterName, int index, bool state);
		void MatrixEnableInputLine(string parameterName, string inputLineLabel, bool state);
		void MatrixEnableInputLine(int pid, string inputLineLabel, bool state);
		void MatrixEnableInputLine(int pid, int index, bool state);
		void MatrixEnableLine(int pid, bool input, int index, bool state);
		void MatrixEnableLine(int pid, bool input, string lineLabel, bool state);
		void MatrixEnableLine(string parameterName, bool input, int index, bool state);
		void MatrixEnableLine(string parameterName, bool input, string lineLabel, bool state);
		void MatrixEnableOutputLine(int pid, int index, bool state);
		void MatrixEnableOutputLine(int pid, string outputLineLabel, bool state);
		void MatrixEnableOutputLine(string parameterName, string outputLineLabel, bool state);
		void MatrixEnableOutputLine(string parameterName, int index, bool state);
		bool MatrixGetFollowMode(string parameterName, string outputLabel);
		bool MatrixGetFollowMode(string parameterName, int index);
		bool MatrixGetFollowMode(int pid, string outputLabel);
		bool MatrixGetFollowMode(int pid, int index);
		int MatrixGetIndexFromLabel(string parameterName, bool input, string label);
		int MatrixGetIndexFromLabel(int pid, bool input, string label);
		int MatrixGetInputIndexFromInputLabel(int pid, string inputLabel);
		int MatrixGetInputIndexFromInputLabel(string parameterName, string inputLabel);
		string MatrixGetInputLabel(int pid, int index);
		string MatrixGetInputLabel(string parameterName, int index);
		bool MatrixGetInputLockMode(int pid, int index);
		bool MatrixGetInputLockMode(int pid, string inputLabel);
		bool MatrixGetInputLockMode(string parameterName, int index);
		bool MatrixGetInputLockMode(string parameterName, string inputLabel);
		string MatrixGetLabel(int pid, bool input, int index);
		string MatrixGetLabel(string parameterName, bool input, int index);
		bool MatrixGetLockMode(int pid, bool input, int index);
		bool MatrixGetLockMode(int pid, bool input, string label);
		bool MatrixGetLockMode(string parameterName, bool input, string label);
		bool MatrixGetLockMode(string parameterName, bool input, int index);
		int MatrixGetOutputIndexFromOutputLabel(string parameterName, string outputLabel);
		int MatrixGetOutputIndexFromOutputLabel(int pid, string outputLabel);
		string MatrixGetOutputLabel(string parameterName, int index);
		string MatrixGetOutputLabel(int pid, int index);
		bool MatrixGetOutputLockMode(int pid, string outputLabel);
		bool MatrixGetOutputLockMode(int pid, int index);
		bool MatrixGetOutputLockMode(string parameterName, string outputLabel);
		bool MatrixGetOutputLockMode(string parameterName, int index);
		bool MatrixIsInputLineEnabled(int pid, string lineLabel);
		bool MatrixIsInputLineEnabled(string parameterName, int index);
		bool MatrixIsInputLineEnabled(string parameterName, string lineLabel);
		bool MatrixIsInputLineEnabled(int pid, int index);
		bool MatrixIsLineEnabled(string parameterName, bool input, string lineLabel);
		bool MatrixIsLineEnabled(string parameterName, bool input, int index);
		bool MatrixIsLineEnabled(int pid, bool input, string lineLabel);
		bool MatrixIsLineEnabled(int pid, bool input, int index);
		bool MatrixIsOutputLineEnabled(string parameterName, string lineLabel);
		bool MatrixIsOutputLineEnabled(string parameterName, int index);
		bool MatrixIsOutputLineEnabled(int pid, string lineLabel);
		bool MatrixIsOutputLineEnabled(int pid, int index);
		void MatrixSetFollowMaster(string parameterName, string masterLabel, string slaveLabel);
		void MatrixSetFollowMaster(string parameterName, int master, int slave);
		void MatrixSetFollowMaster(int pid, string masterLabel, string slaveLabel);
		void MatrixSetFollowMaster(int pid, int master, int slave);
		void MatrixSetFollowMode(int pid, int index, bool mode);
		void MatrixSetFollowMode(int pid, string outputLabel, bool mode);
		void MatrixSetFollowMode(string parameterName, int index, bool mode);
		void MatrixSetFollowMode(string parameterName, string outputLabel, bool mode);
		void MatrixSetInputLabel(int pid, int index, string newName);
		void MatrixSetInputLabel(int pid, string oldName, string newName);
		void MatrixSetInputLabel(string parameterName, int index, string newName);
		void MatrixSetInputLabel(string parameterName, string oldName, string newName);
		void MatrixSetInputLockMode(int pid, string inputLabel, bool mode);
		void MatrixSetInputLockMode(int pid, int index, bool mode);
		void MatrixSetInputLockMode(string parameterName, int index, bool mode);
		void MatrixSetInputLockMode(string parameterName, string inputLabel, bool mode);
		void MatrixSetLabel(string parameterName, bool input, string oldName, string newName);
		void MatrixSetLabel(string parameterName, bool input, int index, string newName);
		void MatrixSetLabel(int pid, bool input, string oldName, string newName);
		void MatrixSetLabel(int pid, bool input, int index, string newName);
		void MatrixSetLockMode(int pid, bool input, string label, bool mode);
		void MatrixSetLockMode(string parameterName, bool input, int index, bool mode);
		void MatrixSetLockMode(int pid, bool input, int index, bool mode);
		void MatrixSetLockMode(string parameterName, bool input, string label, bool mode);
		void MatrixSetOutputLabel(string parameterName, string oldName, string newName);
		void MatrixSetOutputLabel(string parameterName, int index, string newName);
		void MatrixSetOutputLabel(int pid, string oldName, string newName);
		void MatrixSetOutputLabel(int pid, int index, string newName);
		void MatrixSetOutputLockMode(int pid, int index, bool mode);
		void MatrixSetOutputLockMode(int pid, string outputLabel, bool mode);
		void MatrixSetOutputLockMode(string parameterName, int index, bool mode);
		void MatrixSetOutputLockMode(string parameterName, string outputLabel, bool mode);
		void MatrixStopBeingMaster(string parameterName, string masterLabel);
		void MatrixStopBeingMaster(string parameterName, int master);
		void MatrixStopBeingMaster(int pid, string masterLabel);
		void MatrixStopBeingMaster(int pid, int master);
		void Pause();
		void RemoveAlarmTemplate();
		void RemoveTrendTemplate();
		void Restart();
		void SetAlarmTemplate(string name);
		void SetParameter(int pid, object value);
		void SetParameter(string name, object value);
		void SetParameter(string name, string idx, object value);
		void SetParameter(int pid, string idx, object value);
		void SetParameterByPrimaryKey(string name, string primaryKey, object value);
		void SetParameterByPrimaryKey(int pid, string primaryKey, object value);
		void SetPropertyValue(string propertyName, string propertyValue);
		void SetTrendTemplate(string name);
		void SpectrumDisableMonitor(int monitorId);
		void SpectrumDisableMonitor(string monitorName);
		void SpectrumEnableMonitor(string monitorName);
		void SpectrumEnableMonitor(int monitorId);
		int SpectrumFindMeasurementPointIdByName(string measurementPointName);
		int SpectrumFindMonitorIdByName(string monitorName);
		bool SpectrumIsMonitorEnabled(string monitorName);
		bool SpectrumIsMonitorEnabled(int monitorId);
		void SpectrumSelectMeasurementPointsForMonitor(string monitorName, params string[] measurementPointNames);
		void SpectrumSelectMeasurementPointsForMonitor(int monitorId, params int[] measurementPointIds);
		void Start();
		void Stop();
		void Unmask();
	}
}