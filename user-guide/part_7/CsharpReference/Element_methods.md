## Element methods

- [ConnectMatrixCrosspoint](#connectmatrixcrosspoint)

- [DisconnectMatrixCrosspoint](#disconnectmatrixcrosspoint)

- [FindDisplayKey](#finddisplaykey)

- [FindParameterID](#findparameterid)

- [FindPrimaryKey](#findprimarykey)

- [FindView](#findview)

- [FindViews](#findviews)

- [FindWriteParameterID](#findwriteparameterid)

- [GetDisplayValue](#getdisplayvalue)

- [GetInterface](#getinterface)

- [GetInterfaces](#getinterfaces)

- [GetInterfacesByName](#getinterfacesbyname)

- [GetInterfacesByType](#getinterfacesbytype)

- [GetMatrixInputForOutput](#getmatrixinputforoutput)

- [GetParameter](#getparameter)

- [GetParameterByPrimaryKey](#getparameterbyprimarykey)

- [GetParameterDisplay](#getparameterdisplay)

- [GetParameterDisplayByPrimaryKey](#getparameterdisplaybyprimarykey)

- [GetPropertyValue](#getpropertyvalue)

- [GetRawValue](#getrawvalue)

- [GetReadParameterIDFromWrite](#getreadparameteridfromwrite)

- [GetSpectrumPreset](#getspectrumpreset)

- [GetTableDisplayKeys](#gettabledisplaykeys)

- [GetTableKeyMappings](#gettablekeymappings)

- [GetTablePrimaryKeys](#gettableprimarykeys)

- [GetWriteParameterIDFromRead](#getwriteparameteridfromread)

- [HasProperty](#hasproperty)

- [IsMatrixCrosspointConnected](#ismatrixcrosspointconnected)

- [Mask](#mask)

- [MaskUntilNormal](#maskuntilnormal)

- [MatrixEnableInputLine](#matrixenableinputline)

- [MatrixEnableLine](#matrixenableline)

- [MatrixEnableOutputLine](#matrixenableoutputline)

- [MatrixGetFollowMode](#matrixgetfollowmode)

- [MatrixGetIndexFromLabel](#matrixgetindexfromlabel)

- [MatrixGetInputIndexFromInputLabel](#matrixgetinputindexfrominputlabel)

- [MatrixGetInputLabel](#matrixgetinputlabel)

- [MatrixGetInputLockMode](#matrixgetinputlockmode)

- [MatrixGetLabel](#matrixgetlabel)

- [MatrixGetLockMode](#matrixgetlockmode)

- [MatrixGetOutputIndexFromOutputLabel](#matrixgetoutputindexfromoutputlabel)

- [MatrixGetOutputLabel](#matrixgetoutputlabel)

- [MatrixGetOutputLockMode](#matrixgetoutputlockmode)

- [MatrixIsInputLineEnabled](#matrixisinputlineenabled)

- [MatrixIsLineEnabled](#matrixislineenabled)

- [MatrixIsOutputLineEnabled](#matrixisoutputlineenabled)

- [MatrixSetFollowMaster](#matrixsetfollowmaster)

- [MatrixSetFollowMode](#matrixsetfollowmode)

- [MatrixSetInputLabel](#matrixsetinputlabel)

- [MatrixSetInputLockMode](#matrixsetinputlockmode)

- [MatrixSetLabel](#matrixsetlabel)

- [MatrixSetLockMode](#matrixsetlockmode)

- [MatrixSetOutputLabel](#matrixsetoutputlabel)

- [MatrixSetOutputLockMode](#matrixsetoutputlockmode)

- [MatrixStopBeingMaster](#matrixstopbeingmaster)

- [Pause](#pause)

- [RemoveAlarmTemplate](#removealarmtemplate)

- [RemoveTrendTemplate](#removetrendtemplate)

- [Restart](#restart)

- [SetAlarmTemplate](#setalarmtemplate)

- [SetParameter](#setparameter)

- [SetParameterByPrimaryKey](#setparameterbyprimarykey)

- [SetPropertyValue](#setpropertyvalue)

- [SetTrendTemplate](#settrendtemplate)

- [SpectrumDisableMonitor](#spectrumdisablemonitor)

- [SpectrumEnableMonitor](#spectrumenablemonitor)

- [SpectrumFindMeasurementPointIdByName](#spectrumfindmeasurementpointidbyname)

- [SpectrumFindMonitorIdByName](#spectrumfindmonitoridbyname)

- [SpectrumIsMonitorEnabled](#spectrumismonitorenabled)

- [SpectrumSelectMeasurementPointsForMonitor](#spectrumselectmeasurementpointsformonitor)

- [Start](#start)

- [Stop](#stop)

- [Unmask](#unmask)

#### ConnectMatrixCrosspoint

Connects the specified matrix crosspoint.

- *input* must be in the range 1..nrOfInputs

- *output* must be in the range 1..nrOfOutputs

- *pid* must be the ID of the matrix write parameter

```txt
void ConnectMatrixCrosspoint(int pid, int input, int output)
void ConnectMatrixCrosspoint(int pid, string input, string output)
void ConnectMatrixCrosspoint(string name, int input, int output)
void ConnectMatrixCrosspoint(string name, string input, string output)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.ConnectMatrixCrosspoint(1000, 1, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
element.ConnectMatrixCrosspoint(1000, "Input 1", "Output 10");
```

```txt
Element element = engine.FindElement(400, 2000);
element.ConnectMatrixCrosspoint("Example matrix", 1, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
element.ConnectMatrixCrosspoint("Example matrix", "Input 1", "Output 10");
```

#### DisconnectMatrixCrosspoint

Disconnects the specified matrix crosspoint.

- *input* must be in the range 1..nrOfInputs

- *output* must be in the range 1..nrOfOutputs

- *pid* must be the ID of the matrix write parameter

```txt
void DisconnectMatrixCrosspoint(int pid, int input, int output)
void DisconnectMatrixCrosspoint(int pid, string input, string output)
void DisconnectMatrixCrosspoint(string name, int input, int output)
void DisconnectMatrixCrosspoint(string name, string input, string output)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.DisconnectMatrixCrosspoint(1000, 1, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
element.DisconnectMatrixCrosspoint(1000, "Input 1", "Output 10");
```

```txt
Element element = engine.FindElement(400, 2000);
element.DisconnectMatrixCrosspoint("Example matrix", 1, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
element.DisconnectMatrixCrosspoint("Example matrix", "Input 1", "Output 10");
```

#### FindDisplayKey

Gets the display key that corresponds with the specified primary key.

Returns null of the specified primary key cannot be found.

```txt
string FindDisplayKey(int pid, string primaryKey)
string FindDisplayKey(string parameterName, string primaryKey)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string displayKey = element.FindDisplayKey(1000, "1");
```

```txt
Element element = engine.FindElement(400, 2000);
string displayKey = element.FindDisplayKey(“Overview”, "1");
```

#### FindParameterID

Gets the ID that corresponds with the specified parameter name. If the parameter is not found, -1 is returned.

```txt
int FindParameterID(string name)
int FindParameterID(string name, bool writeParam)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int parameterId = element.FindParameterID("MyParameter");
```

```txt
Element element = engine.FindElement(400, 2000);
int parameterId = element.FindParameterID("MyParameter", true);
```

#### FindPrimaryKey

Gets the primary key that corresponds with the specified display key.

Returns null if the display key cannot be found.

```txt
string FindPrimaryKey(int pid, string displayKey)
string FindPrimaryKey(string parameterName, string displayKey)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string primaryKey = element.FindPrimaryKey(1000, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
string primaryKey = element.FindPrimaryKey("Overview", "Main");
```

#### FindView

Gets the name of the view of which the specified element is a member.

If an element is a member of multiple views, this method only returns one of them. If you want all views, use the *FindViews* method.

```txt
string FindView()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string viewName = element.FindView();
```

#### FindViews

Gets the names of all the views of which the specified element is a member.

```txt
string[] FindViews()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string viewNames = element.FindViews();
```

#### FindWriteParameterID

Gets the ID of the write parameter with the specified name. If the parameter is not found, -1 is returned.

```txt
int FindWriteParameterID(string name)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
int parameterId = element.FindWriteParameterID("MyWriteParameter");
```

#### GetDisplayValue

Gets the display value that corresponds with the specified raw value of the specified parameter.

This method is used with parameters defining discrete entries to retrieve the display value (e.g. "Main") for a specific value (e.g. "1"). If the parameter is not found, the specified value in “rawValue” is returned. If the parameter is found but the raw value is not specified in the parameter, the specified value is returned.

```txt
string GetDisplayValue(int pid, string rawValue)
string GetDisplayValue(string name, string rawValue)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
string displayValue = element.GetDisplayValue(1000, "1");
```

```txt
Element element = engine.FindElement(400, 2000);
string displayValue = element.GetDisplayValue("MyDiscreteParameter", "1");
```

#### GetInterface

Retrieves the specified DataMiner Connectivity Framework interface.

Returns null if the interface cannot be found.

```txt
Interface GetInterface(int interfaceID)
Interface GetInterface(string customName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var interface = element.GetInterface(1);
```

```txt
Element element = engine.FindElement(400, 2000);
var interface = element.GetInterface("MyInterface");
```

> [!NOTE]
> The method caches the interface the first time it is retrieved. The interface will not be updated if it changes while the script is running.

#### GetInterfaces

Retrieves all DataMiner Connectivity Framework interfaces for a particular element.

```txt
Interface[] GetInterfaces()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
var interfaces = element.GetInterfaces();
```

> [!NOTE]
> The method caches the interfaces the first time they are retrieved. The interfaces will not be updated if they change while the script is running.

#### GetInterfacesByName

Retrieves DataMiner Connectivity Framework interfaces by interface name.

- “filter” can contain wildcards

- “bool”:

        - true = check the custom names on the interface

        - false = check the name fields

```txt
Interface[] GetInterfacesByName(string filter, bool custom)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
var interfaces = element.GetInterfacesByName("MyInterface *", true);
```

#### GetInterfacesByType

Retrieves the DataMiner Connectivity Framework interfaces of the specified interface type.

- “type”: can be “in”, “out”, or “inout” (regardless of case)

```txt
Interface[] GetInterfacesByType(string type)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
var interfaces = element.GetInterfacesByType("out");
```

#### GetMatrixInputForOutput

Gets the input that is connected to the specified output. Returns 0 when the output is not connected.

- *output* must be in the range 1..nrOfOutputs.

```txt
int GetMatrixInputForOutput(int pid, int output)
int GetMatrixInputForOutput(int pid, string output)
int GetMatrixInputForOutput(string name, int output)
int GetMatrixInputForOutput(string name, string output)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int connectedInput = element.GetMatrixInputForOutput(1000, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
int connectedInput = element.GetMatrixInputForOutput(1000, "Output 4");
```

```txt
Element element = engine.FindElement(400, 2000);
int connectedInput = element.GetMatrixInputForOutput("Example matrix", 4);
```

```txt
Element element = engine.FindElement(400, 2000);
int connectedInput = element.GetMatrixInputForOutput("Example matrix", "Output 4");
```

#### GetParameter

Gets the value of the specified parameter.

```txt
object GetParameter(int pid)
object GetParameter(string name)
object GetParameter(int pid, string index)
object GetParameter(string name, string index)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameter(10);
```

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameter(“MyParameter”);
```

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameter(1000, “1”);
```

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameter(“MyTableColumn”, “1”);
```

#### GetParameterByPrimaryKey

Gets the value of the specified parameter using the primary key.

Returns null if no row was found with the specified primary key.

```txt
object GetParameterByPrimaryKey(int pid, string index)
object GetParameterByPrimaryKey(string name, string index)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameterByPrimaryKey(1002, "1");
```

```txt
Element element = engine.FindElement(400, 2000);
var value = element.GetParameterByPrimaryKey("MyTableColumn", "1");
```

#### GetParameterDisplay

Gets the display value of the specified parameter. Useful for discrete parameters.

```txt
string GetParameterDisplay(int pid)
string GetParameterDisplay(string name)
string GetParameterDisplay(int pid, string index)
string GetParameterDisplay(string name, string index)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplay(40);
```

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplay("MyParam");
```

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplay(1004, "1");
```

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplay("MyColumn", "1");
```

#### GetParameterDisplayByPrimaryKey

Gets the display value of the specified table cell using the column name and the row primary key. If the specified row is not found, “Not Initialized” is returned.

```txt
string GetParameterDisplayByPrimaryKey(int pid, string primaryKey)
string GetParameterDisplayByPrimaryKey(string name, string primaryKey)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplayByPrimaryKey(1004, "1");
```

```txt
Element element = engine.FindElement(400, 2000);
var displayValue = element.GetParameterDisplayByPrimaryKey("MyColumn", "1");
```

#### GetPropertyValue

Retrieves the value of the property with the specified name for this element. If the specified property was not found in the Element.xml of this element, the return value is null.

```txt
string GetPropertyValue(string propertyName)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
var propertyValue = element.GetPropertyValue("MyProperty");
```

#### GetRawValue

Gets the value that corresponds with the specified display value of the specified parameter.

This method is used with parameters defining discrete entries to retrieve the raw value (e.g. "1") for a specific display value (e.g. "Main").

If the parameter is not found, the specified value in *displayValue* is returned. If the parameter is found, but the display value is not specified in the parameter, null is returned.

```txt
string GetRawValue(int pid, string displayValue)
string GetRawValue(string name, string displayValue)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string rawValue = element.GetRawValue(100, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
string rawValue = element.GetRawValue("MyDiscreteParameter", "Main");
```

#### GetReadParameterIDFromWrite

Gets the read parameter ID that corresponds with the specified write parameter ID. Returns -1 if the specified parameter was not found or if there is no corresponding write parameter.

```txt
int GetReadParameterIDFromWrite(int pid)
int GetReadParameterIDFromWrite(string name)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int readParameterId = element.GetReadParameterIDFromWrite(101);
```

```txt
Element element = engine.FindElement(400, 2000);
int readParameterId = element.GetReadParameterIDFromWrite("MyParameter");
```

#### GetSpectrumPreset

Gets an object that can be used to change the given preset. Only shared presets can be opened.

```txt
SpectrumPreset GetSpectrumPreset(string name)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
var preset = element.GetSpectrumPreset("Preset 1");
```

#### GetTableDisplayKeys

Gets an array with all the display keys of the specified table parameter.

```txt
string[] GetTableDisplayKeys(int tablePid)
string[] GetTableDisplayKeys(string tableParameterName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string[] displayKeys = element.GetTableDisplayKeys(1000);
```

```txt
Element element = engine.FindElement(400, 2000);
string[] displayKeys = element.GetTableDisplayKeys(“MyTable”);
```

#### GetTableKeyMappings

Gets the primary key to display key map for the specified table parameter.

```txt
DynamicTableIndicesResponse GetTableKeyMappings(int tablePid)
DynamicTableIndicesResponse GetTableKeyMappings(string tableParameterName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
var keyMap = element.GetTableKeyMappings(1000);
```

```txt
Element element = engine.FindElement(400, 2000);
var keyMap = element.GetTableKeyMappings("MyTable");
```

#### GetTablePrimaryKeys

Gets an array with all the primary keys of the specified table parameter.

```txt
string[] GetTablePrimaryKeys(int tablePid)
string[] GetTablePrimaryKeys(string tableParameterName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string[] primaryKeys = element.GetTablePrimaryKeys(1000);
```

```txt
Element element = engine.FindElement(400, 2000);
string[] primaryKeys = element.GetTablePrimaryKeys("MyTable");
```



#### GetWriteParameterIDFromRead

Gets the write parameter ID that corresponds with the specified read parameter ID. Returns -1 in case the specified parameter was not found or if there is no corresponding write parameter.

```txt
int GetWriteParameterIDFromRead(int pid)
int GetWriteParameterIDFromRead(string name)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int writeParameterId = element.GetWriteParameterIDFromRead(1000);
```

```txt
Element element = engine.FindElement(400, 2000);
int writeParameterId = element.GetWriteParameterIDFromRead("MyParameter");
```

#### HasProperty

Determines whether the Element.xml of this element has a property defined with the specified name. Returns true if the Element.xml of this element has a property with the specified name; otherwise, false.

```txt
bool HasProperty(string propertyName)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
bool hasProperty = element.HasProperty("MyProperty");
```

#### IsMatrixCrosspointConnected

Returns true if the specified matrix crosspoint is connected.

- *input* must be in the range 1..nrOfInputs

- *output* must be in the range 1..nrOfOutputs

```txt
bool IsMatrixCrosspointConnected(int pid, int input, int output)
bool IsMatrixCrosspointConnected(int pid, string input, string output)
bool IsMatrixCrosspointConnected(string name, int input, int output)
bool IsMatrixCrosspointConnected(string name, string input, string output)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isConnected = element.IsMatrixCrosspointConnected(1000, 1, 7);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isConnected = element.IsMatrixCrosspointConnected(1000, "Input 1", "Output 7");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isConnected = element.IsMatrixCrosspointConnected("Example matrix", 1, 7);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isConnected = element.IsMatrixCrosspointConnected("Example matrix", "Input 1", "Output 7");
```

#### Mask

Masks the element that is linked to the dummy either indefinitely or for a specified period of time.

```txt
void Mask(string reason)
void Mask(string reason, int amountOfSeconds)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.Mask("Maintenance window.");
```

```txt
Element element = engine.FindElement(400, 2000);
element.Mask("Maintenance window.", 7200);
```

#### MaskUntilNormal

Masks the element that is linked to the dummy until all its alarms have been cleared.

```txt
void MaskUntilNormal(string reason)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.MaskUntilNormal("Suppressed.");
```

#### MatrixEnableInputLine

Enables or disables the specified matrix input.

- *index* must be in the range 1..nrOfInputs.

```txt
void MatrixEnableInputLine(int pid, int index, bool isEnabled)
void MatrixEnableInputLine(int pid, string inputLabel, bool isEnabled)
void MatrixEnableInputLine(String parameterName, int index, bool isEnabled)
void MatrixEnableInputLine(String parameterName, string inputLabel, bool isEnabled)
```

Examples

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableInputLine(1000, 2, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableInputLine(1000, "Input 4", true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableInputLine("Example Matrix", 2, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableInputLine("Example Matrix", "Input 4", false);
```

#### MatrixEnableLine

Enables or disables the specified matrix input or output.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
void MatrixEnableLine(int pid, bool input, int index, bool isEnabled)
void MatrixEnableLine(int pid, bool input, string label, bool isEnabled)
void MatrixEnableLine(string parameterName, bool input, int index, bool isEnabled)
void MatrixEnableLine(string parameterName, bool input, string label, bool isEnabled)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableLine(1000, true, 4, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableLine(1000, true, "Input 4", false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableLine("Example Matrix", true, 4, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableLine("Example Matrix", false, "Output 4", true);
```

#### MatrixEnableOutputLine

Enables or disables the specified matrix output.

- *index* must be in the range 1..nrOfOutputs.

```txt
void MatrixEnableOutputLine(int pid, int index, bool isEnabled)
void MatrixEnableOutputLine(int pid, string outputLabel, bool isEnabled)
void MatrixEnableOutputLine(string parameterName, int index, bool isEnabled)
void MatrixEnableOutputLine(string parameterName, string outputLabel, bool isEnabled)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableOutputLine(1000, 2, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableOutputLine("Example Matrix", 2, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableOutputLine(1000, "Output 2", false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixEnableOutputLine("Example Matrix", "Output 2", false);
```

#### MatrixGetFollowMode

Returns true if “follow mode” is enabled on the specified matrix output.

- *outputLabel* must be in the range 1..nrOfOutputs.

```txt
bool MatrixGetFollowMode(int pid, int index)
bool MatrixGetFollowMode(int pid, string outputLabel)
bool MatrixGetFollowMode(string parameterName, int index)
bool MatrixGetFollowMode(string parameterName, string outputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixGetFollowMode(1000, 1);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixGetFollowMode(1000, "Output 1");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixGetFollowMode("Example Matrix", 1);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixGetFollowMode("Example Matrix", "Output 1");
```

#### MatrixGetIndexFromLabel

Gets the index of the input or output that corresponds with the specified input or output label.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

- The returned index is in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

```txt
Int MatrixGetIndexFromLabel(int pid, bool input, string label)
Int MatrixGetIndexFromLabel(string parameterName, bool input, string label)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetIndexFromLabel(1000, false, "Output 10");
```

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetIndexFromLabel("Example Matrix", false, "Output 10");
```

#### MatrixGetInputIndexFromInputLabel

Gets the index of the input that corresponds with the specified input label.

- The returned index is in the range 1..nrOfInputs.

```txt
Int MatrixGetInputIndexFromInputLabel(int pid, string inputLabel)
Int MatrixGetInputIndexFromInputLabel(string parameterName, string inputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetInputIndexFromInputLabel(1000, "Input 10");
```

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetInputIndexFromInputLabel("Example Matrix", "Input 10");
```

#### MatrixGetInputLabel

Gets the label of the specified matrix input.

- *labelIndex* must be in the range 1..nrOfInputs.

```txt
string MatrixGetInputLabel(int pid, int labelIndex)
string MatrixGetInputLabel(string parameterName, int labelIndex)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string inputLabel = element.MatrixGetInputLabel(1000, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
string inputLabel = element.MatrixGetInputLabel("Example matrix", 10);
```

#### MatrixGetInputLockMode

Gets a value indicating whether the specified matrix input is locked.

- *index* must be in the range 1..nrOfInputs.

```txt
bool MatrixGetInputLockMode(int pid, int index)
bool MatrixGetInputLockMode(int pid, string inputLabel)
bool MatrixGetInputLockMode(string parameterName, int index)
bool MatrixGetInputLockMode(string parameterName, string inputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetInputLockMode(1000, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetInputLockMode(1000, "Input 1");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetInputLockMode("Example matrix", 10);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetInputLockMode("Example matrix", "Input 1");
```

#### MatrixGetLabel

Gets the label of the specified matrix input or output.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
string MatrixGetLabel(int pid, bool input, int index)
string MatrixGetLabel(string parameterName, bool input, int index)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLabel(1000, true, 1);
```

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLabel("Example Matrix", true, 1);
```

#### MatrixGetLockMode

Gets a value indicating whether the specified matrix input or output is locked.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
bool MatrixGetLockMode(int pid, bool input, int index)
bool MatrixGetLockMode(int pid, bool input, string label)
bool MatrixGetLockMode(string parameterName, bool input, int index)
bool MatrixGetLockMode(string parameterName, bool input, string label)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLockMode(1000, true, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLockMode(1000, true, "Input 10");
```

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLockMode("Example Matrix", true, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetLockMode("Example Matrix", true, "Input 10");
```

#### MatrixGetOutputIndexFromOutputLabel

Gets the index of the output that corresponds with the specified output label.

- The returned index is in the range 1..nrOfOutputs.

```txt
Int MatrixGetOutputIndexFromOutputLabel(int pid, string outputLabel)
Int MatrixGetOutputIndexFromOutputLabel(string parameterName, string outputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetOutputIndexFromOutputLabel(1000, "Output 10");
```

```txt
Element element = engine.FindElement(400, 2000);
int index = element.MatrixGetOutputIndexFromOutputLabel("Example matrix", "Output 10");
```

#### MatrixGetOutputLabel

Gets the label of the specified matrix output.

- *index* must be in the range 1..nrOfOutputs.

```txt
string MatrixGetOutputLabel(int pid, int index)
string MatrixGetOutputLabel(string parameterName, int index)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetOutputLabel(1000, 10);
```

```txt
Element element = engine.FindElement(400, 2000);
string label = element.MatrixGetOutputLabel("Example Matrix", 10);
```

#### MatrixGetOutputLockMode

Gets a value indicating whether the specified matrix output is locked.

- *index* must be in the range 1..nrOfOutputs.

```txt
bool MatrixGetOutputLockMode(int pid, int index)
bool MatrixGetOutputLockMode(int pid, string outputLabel)
bool MatrixGetOutputLockMode(string parameterName, int index)
bool MatrixGetOutputLockMode(string parameterName, string outputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetOutputLockMode(1000, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetOutputLockMode(1000, "Output 4");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetOutputLockMode("Example matrix", 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isLocked = element.MatrixGetOutputLockMode("Example matrix", "Output 4");
```

#### MatrixIsInputLineEnabled

Returns true if the specified matrix input is enabled.

- *index* must be in the range 1..nrOfInputs.

```txt
bool MatrixIsInputLineEnabled(int pid, int index)
bool MatrixIsInputLineEnabled(int pid, string inputLabel)
bool MatrixIsInputLineEnabled(string parameterName, int index)
bool MatrixIsInputLineEnabled(string parameterName, string inputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsInputLineEnabled(1000, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsInputLineEnabled(1000, "Input 4");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsInputLineEnabled("Example Matrix", 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsInputLineEnabled("Example Matrix", "Input 4");
```

#### MatrixIsLineEnabled

Returns true if the specified matrix input or output is enabled.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
bool MatrixIsLineEnabled(int pid, bool input, int index)
bool MatrixIsLineEnabled(int pid, bool input, string label)
bool MatrixIsLineEnabled(string parameterName, bool input, int index)
bool MatrixIsLineEnabled(string parameterName, bool input, string label)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsLineEnabled(1000, true, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsLineEnabled(1000, true, "Input 4");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsLineEnabled("Example Matrix", true, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isInputEnabled = element.MatrixIsLineEnabled("Example Matrix", true, "Input 4");
```

#### MatrixIsOutputLineEnabled

Returns true if the specified matrix output is enabled.

- *index* must be in the range 1..nrOfOutputs.

```txt
bool MatrixIsOutputLineEnabled(int pid, int index)
bool MatrixIsOutputLineEnabled(int pid, string outputLabel)
bool MatrixIsOutputLineEnabled(string parameterName, int index)
bool MatrixIsOutputLineEnabled(string parameterName, string outputLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
bool isOutputEnabled = element.MatrixIsOutputLineEnabled(1000, 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isOutputEnabled = element.MatrixIsOutputLineEnabled(1000, "Output 4");
```

```txt
Element element = engine.FindElement(400, 2000);
bool isOutputEnabled = element.MatrixIsOutputLineEnabled("Example Matrix", 4);
```

```txt
Element element = engine.FindElement(400, 2000);
bool isOutputEnabled = element.MatrixIsInputLineEnabled("Example Matrix", "Output 4");
```

#### MatrixSetFollowMaster

Configures a slave output to follow a master output on the specified matrix.

- Both *masterIndex* and *slaveIndex* must be in the range 1..nrOfOutputs.

```txt
void MatrixSetFollowMaster(int pid, int masterIndex, int slaveIndex)
void MatrixSetFollowMaster(int pid, string masterLabel, string slaveLabel)
void MatrixSetFollowMaster(string parameterName, int masterIndex, int slaveIndex)
void MatrixSetFollowMaster(string parameterName, string masterLabel, string slaveLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMaster(1000, 4, 6);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMaster(1000, "Output 4", "Output 6");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMaster("Example Matrix", 4, 6);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMaster("Example Matrix", "Output 4", "Output 6");
```

#### MatrixSetFollowMode

Enables or disables the “follow mode” of the specified matrix output.

- *outputIndex* must be in the range 1..nrOfOutputs.

```txt
void MatrixSetFollowMode(int pid, int outputIndex, bool followModeIsEnabled)
void MatrixSetFollowMode(int pid, string outputLabel, bool followModeIsEnabled)
void MatrixSetFollowMode(string parameterName, int outputIndex, bool followModeIsEnabled)
void MatrixSetFollowMode(string parameterName, string outputLabel, bool followModeIsEnabled)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMode(1000, 10, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMode(1000, "Output 10", false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMode("Example Matrix", 10, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetFollowMode("Example Matrix", "Output 10", false);
```

#### MatrixSetInputLabel

Sets the label of the specified matrix input.

- *index* must be in the range 1..nrOfInputs.

```txt
void MatrixSetInputLabel(int pid, int index, string newName)
void MatrixSetInputLabel(int pid, string oldName, string newName)
void MatrixSetInputLabel(string parameterName, int index, string newName)
void MatrixSetInputLabel(string parameterName, string oldName, string newName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLabel(1000, 10, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLabel(1000, "Input 1", "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLabel("Example Matrix", 10, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLabel("Example Matrix", "Input 1", "Main");
```

#### MatrixSetInputLockMode

Locks or unlocks the specified matrix input.

- *index* must be in the range 1..nrOfInputs.

```txt
void MatrixSetInputLockMode(int pid, int index, bool isLocked)
void MatrixSetInputLockMode(int pid, string inputLabel, bool isLocked)
void MatrixSetInputLockMode(string parameterName, int index, bool isLocked)
void MatrixSetInputLockMode(string parameterName, string inputLabel, bool isLocked)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLockMode(1000, 1, true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLockMode(1000, "Input 1", true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLockMode("Example matrix", 1, true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetInputLockMode("Example matrix", "Input 2", true);
```

#### MatrixSetLabel

Sets the label of the specified matrix input or output.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
void MatrixSetLabel(int pid, bool input, int index, string newName)
void MatrixSetLabel(int pid, bool input, string oldName, string newName)
void MatrixSetLabel(string parameterName, bool input, int index, string newName)
void MatrixSetLabel(string parameterName, bool input, string oldName, string newName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLabel(1000, true, 4, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLabel(1000, true, "Input 1", "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLabel("Example Matrix", true, 4, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLabel("Example Matrix", true, "Input 1", "Main");
```

#### MatrixSetLockMode

Locks or unlocks the specified matrix input or output.

- *index* must be in either the range 1..nrOfInputs or the range 1..nrOfOutputs.

- Set the *input* boolean to *true* if the specified index is an input, or to *false* if it is an output.

```txt
void MatrixSetLockMode(int pid, bool input, int index, bool isLocked)
void MatrixSetLockMode(int pid, bool input, string label, bool isLocked)
void MatrixSetLockMode(string parameterName, bool input, int index, bool isLocked)
void MatrixSetLockMode(string parameterName, bool input, string label, bool isLocked)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLockMode(1000, true, 4, "Main");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLockMode(1000, true, "Input 4", false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLockMode("Example Matrix", true, 4, false);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetLockMode("Example Matrix", true, "Input 4", false);
```

#### MatrixSetOutputLabel

Sets the label of the specified matrix output.

- *index* must be in the range 1..nrOfOutputs.

```txt
void MatrixSetOutputLabel(int pid, int index, string newName)
void MatrixSetOutputLabel(int pid, string oldName, string newName)
void MatrixSetOutputLabel(string parameterName, int index, string newName)
void MatrixSetOutputLabel(string parameterName, string oldName, string newName)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLabel(1000, 10, "A");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLabel(1000, "Output 1", "A");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLabel("Example Matrix", 10, "A");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLabel("Example Matrix", "Output 1", "A");
```

#### MatrixSetOutputLockMode

Locks or unlocks the specified matrix output.

- *index* must be in the range 1..nrOfOutputs.

```txt
void MatrixSetOutputLockMode(int pid, int index, bool isLocked)
void MatrixSetOutputLockMode(int pid, string outputLabel, bool isLocked)
void MatrixSetOutputLockMode(string parameterName, int index, bool isLocked)
void MatrixSetOutputLockMode(string parameterName, string outputLabel, bool isLocked)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLockMode(1000, 1, true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLockMode(1000, "Output 1", true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLockMode("Example matrix", 1, true);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixSetOutputLockMode("Example Matrix", "Output 1", true);
```

#### MatrixStopBeingMaster

Stops the specified matrix output from being a master output.

- *masterIndex* must be in the range 1..nrOfOutputs.

```txt
void MatrixStopBeingMaster(int pid, int masterIndex)
void MatrixStopBeingMaster(int pid, string masterLabel)
void MatrixStopBeingMaster(string parameterName, int masterIndex)
void MatrixStopBeingMaster(string parameterName, string masterLabel)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixStopBeingMaster(1000, 1);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixStopBeingMaster(1000, "Output 1");
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixStopBeingMaster("Example Matrix", 1);
```

```txt
Element element = engine.FindElement(400, 2000);
element.MatrixStopBeingMaster("Example Matrix", "Output 1");
```

#### Pause

Pauses the element that is linked to the dummy.

```txt
void Pause()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.Pause();
```

#### RemoveAlarmTemplate

Removes the link between an element and the alarm template that is assigned to it. In other words, sets the element to “not monitored”.

```txt
void RemoveAlarmTemplate()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.RemoveAlarmTemplate();
```

#### RemoveTrendTemplate

Removes the link between an element and the trend template that is assigned to it. In other words, disables trending for the element.

```txt
void RemoveTrendTemplate()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.RemoveTrendTemplate();
```

#### Restart

Restarts the element that is linked to the dummy.

```txt
void Restart()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.Restart();
```

#### SetAlarmTemplate

Assigns the specified alarm template to the element.

```txt
void SetAlarmTemplate(string name)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.SetAlarmTemplate("Template 1");
```

#### SetParameter

Sets the value of the specified parameter.



```txt
void SetParameter(int pid, object value)
void SetParameter(string name, object value)
void SetParameter(int pid, string index, object value)
void SetParameter(string name, string index, object value)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameter(100, "Example Value");
```

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameter("Example Parameter", "Example Value");
```

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameter(5003, "Row 1", "Example Value");
```

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameter("Example Column Parameter", "Row 1", "Example Value");
```

#### SetParameterByPrimaryKey

Sets the value of a cell specified using the primary key instead of the display key.



```txt
void SetParameterByPrimaryKey(string name, string index, object value)
void SetParameterByPrimaryKey(int pid, string index, object value)
```

Examples:

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameterByPrimaryKey(5003, "Row 1", "Example Value");
```

```txt
Element element = engine.FindElement(400, 2000);
element.SetParameterByPrimaryKey("Example Column Parameter", "Row 1", "Example Value");
```

#### SetPropertyValue

Sets the value of a writable element property.

```txt
void SetPropertyValue(string propertyName, string propertyValue)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.SetPropertyValue("My Custom Property", "Example Value");
```

> [!NOTE]
> From DataMiner 10.0.5 onwards, if the script execution option *After executing a SET command, check if the read parameter or property has been set to the new value* is selected, this method will only return after it has checked that the property has been set correctly.
>
> Note that this check causes an average delay of 50 ms. In case many property sets have to be executed and they are not immediately retrieved, we therefore recommend not to select this option.

#### SetTrendTemplate

Assigns the specified trend template to the element.

```txt
void SetTrendTemplate(string name)
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.SetTrendTemplate("Trend Template 1");
```

#### SpectrumDisableMonitor

Disables a spectrum monitor.

```txt
void SpectrumDisableMonitor(int monitorID)
void SpectrumDisableMonitor(string monitorName)
```

Example:

```txt
Element element = engine.FindElement(7, 32);
element.SpectrumDisableMonitor(1);
```

```txt
Element element = engine.FindElement(7, 32);
element.SpectrumDisableMonitor("Monitor Name");
```

#### SpectrumEnableMonitor

Enables a spectrum monitor.

```txt
void SpectrumEnableMonitor(int monitorID)
void SpectrumEnableMonitor(string monitorName)
```

Example:

```txt
Element element = engine.FindElement(7, 32);
element.SpectrumEnableMonitor(1);
```

```txt
Element element = engine.FindElement(7, 32);
element.SpectrumEnableMonitor("Monitor Name");
```

#### SpectrumFindMeasurementPointIdByName

Gets the ID that corresponds with the specified spectrum measurement point name. Returns -1 if the corresponding measurement point is not found.

```txt
int SpectrumFindMeasurementPointIdByName(string measurementPointName)
```

Example:

```txt
var element = engine.FindElement("MySpectrumElement");
int measurementPointId = element.SpectrumFindMeasurementPointIdByName("MyMeasurement PointName");
```

#### SpectrumFindMonitorIdByName

Gets the ID that corresponds with the specified spectrum monitor name. Returns -1 if the corresponding spectrum monitor is not found.

```txt
int SpectrumFindMonitorIdByName(string monitorName)
```

Example:

```txt
var element = engine.FindElement("MySpectrumElement ");
int monitorId = element.SpectrumFindMonitorIdByName("MyMonitorName");
```

#### SpectrumIsMonitorEnabled

Returns a value indicating whether the specified spectrum monitor is enabled.

```txt
bool SpectrumIsMonitorEnabled(int monitorID)
bool SpectrumIsMonitorEnabled(string monitorName)
```

Example:

```txt
var element = engine.FindElement("MySpectrumElement ");
bool isEnabled = element.SpectrumIsMonitorEnabled("MyMonitorName ");
```

#### SpectrumSelectMeasurementPointsForMonitor

Selects the measurement point(s) on which a spectrum monitor has to be executed.

```txt
void SpectrumSelectMeasurementPointsForMonitor(int monitorID, int[] measurementPointIDs)
void SpectrumSelectMeasurementPointsForMonitor(string monitorName, string[] measurementPointNames)
```

Example:

```txt
var element = engine.FindElement("MySpectrumElement ");
element.SpectrumSelectMeasurementPointsForMonitor("MyMonitorName ", new string[]{"MyMeasurementPoint"});
```

#### Start

Starts the element that is linked to the dummy.

```txt
void Start()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.Start();
```

#### Stop

Stops the element that is linked to the dummy.

```txt
void Stop()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.Stop();
```

#### Unmask

Unmasks the element that is linked to the dummy.

```txt
void Unmask()
```

Example:

```txt
Element element = engine.FindElement(400, 2000);
element.Unmask();
```
