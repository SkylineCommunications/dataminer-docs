---
uid: NT_UPDATE_PORTS_XML
---

# NT_UPDATE_PORTS_XML (128)

Updates the configuration of the specified matrix.

```csharp
int agentId = 346; // For DELT compatibility.
int elementId = 806;
int parameterId = 4000;
int changeType = 9;

string updateConfig = changeType + ";" + elementId + ";" + parameterId + ";" + agentId;

int inputs = 8;
int outputs = 8;

string updateValue = inputs + ";" + outputs;

int result = (int) protocol.NotifyDataMinerQueued(128, updateConfig, updateValue);

if (result != 0)
{
    protocol.Log("QA" + protocol.QActionID + "|Port update failed: " + updateConfig + ", " + updateValue, LogType.Error, LogLevel.NoLogging);
}

protocol.SendToDisplay(4000);
```

## Parameters

- updateConfig (string): String formatted as follows:
"ChangeType;elementID;parameterID;agentID".
  
  ChangeType is an integer that can take one of the following values:

  |ChangeType|Description|
  |--- |--- |
  |0|Label|
  |1|State|
  |2|Current settings|
  |3|Page info|
  |4|Not allowed|
  |5|Allowed|
  |6|Lock info|
  |7|Follow info|
  |8|Master info|
  |9|Size|
  |10|Matrix layout (supported from DataMiner 10.0.8 (RN 25456, RN 25892) onwards)|

- updateValue (string): Updated value. The format of this string depends on the specified changeType. To set the size of the matrix, the updateValue string needs to be formatted as follows: inputs + ";" + outputs.

## Return Value

- (int): Indicates if the update succeeded or not. 0 = Succeeded, 1 = Failed.

## Remarks

- When an update is performed, DataMiner creates a file, *labels.xml*, containing the updated matrix configuration (which is stored in the folder of the element `C:\Skyline DataMiner\Elements\[Element Name]`).
- The size of a matrix can never be larger than the size that is hard-coded in the driver.
- From DataMiner 9.6.11 (RN 23052) onwards, when labels are updated on a matrix element with the Notify DataMiner call NT_UPDATE_PORTS_XML (128), at most one information event will be generated with parameter description "Link File" and value "edited by ...".
- Bulk edit: It is also possible to group multiple updates in one call. To perform a bulk update, the parameters should be formatted as follows:
  - updateConfigs (object[]): Contains the different update configurations, where each entry is a uint[] with the following structure:
    - updateConfig[0]: Denotes the type of change. Refer to the table for the single update for more info on the possible values.
    - updateConfig[1]: Element ID
    - updateConfig[2]: Matrix parameter ID
    - updateConfig[3]: Agent ID
    - updateConfig[4]: Flag indicating whether a parameter of type "discreet info" should not be triggered. 1: no discreet info trigger. Feature introduced in DataMiner 9.6.11 (RN 23052).
  - updateValues (object[]): Contains the different update values, where each entry is a string[], with the following structure:
    - updateValue[0]: Depends on the type of change. This corresponds with the first part (before the semicolon) of the updateValue string in the single call.
    - updateValue[1]: Depends on the type of change. This corresponds with the second part (after the semicolon) of the updateValue string in the single call.

    Example:

    ```csharp
    uint agentId = 346; // For DELT compatibility.
    uint elementId = 531923;
    uint parameterId = 4000;
    uint changeType = 0;
    uint updateFileAtOnceNoDiscreetInfoTrigger = 1;
    
    uint[] updateConfig = new uint[5];
    
    updateConfig[0] = changeType;
    updateConfig[1] = elementId;
    updateConfig[2] = parameterId;
    updateConfig[3] = agentId;
    updateConfig[4] = updateFileAtOnceNoDiscreetInfoTrigger;
    
    string[] updateValue1 = new string[2];
    
    updateValue1[0] = "1";
    updateValue1[1] = "In A";
    
    string[] updateValue2 = new string[2];
    
    updateValue2[0] = "2";
    updateValue2[1] = "In B";
    
    object[] updateConfigs = new object[] { updateConfig, updateConfig };
    object[] updateValues = new object[] { updateValue1, updateValue2 };
    
    int result = protocol.NotifyDataMinerQueued((int)NotifyType.UpdatePortsXml, updateConfigs, updateValues);
    ```

## Examples

- Setting the label of input 1 to "Test":

  ```csharp
  protocol.NotifyDataMinerQueued(128, "0;" +elementId+";"+parameterId+";"+agentId, "1;test");
  ```

- Setting state of input 1 to disabled:

  ```csharp
  protocol.NotifyDataMinerQueued(128, "1;" +elementId+";"+parameterId+";"+agentId, "1;disabled");
  ```

- Setting input 1 to page "testpage":

  ```csharp
  protocol.NotifyDataMinerQueued(128, "3;" +elementId+";"+parameterId+";"+agentId, "1;testpage");
  ```

- Setting output 1 and 2 to not allowed for input 1:

  ```csharp
  protocol.NotifyDataMinerQueued(128, "4;" +elementId+";"+parameterId+";"+agentId, "1;17,18");
  ```

- Setting output 1 and 2 to allowed for input 1:

  ```csharp
  protocol.NotifyDataMinerQueued(128, "5;" +elementId+";"+parameterId+";"+agentId, "1;17,18");
  ```

- Locking output 8 (16x16 matrix):

  ```csharp
  protocol.NotifyDataMinerQueued(128, "6;" +elementId+";"+parameterId+";"+agentId, "24;true");
  ```

- Output 1 is master of output 10:

  ```csharp
  protocol.NotifyDataMinerQueued(128, "7;" +elementId+";"+parameterId+";"+agentId, "17;23");
  ```

- Enable follow mode on output 10 (16x16 matrix):

  ```csharp
  protocol.NotifyDataMinerQueued(128, "8;" +elementId+";"+parameterId+";"+agentId, "26;true");
  ```

- Setting the matrix layout:

  Currently the following layouts are supported: InputLeftOutputTop and InputTopOutputLeft.

  ```csharp
  protocol.NotifyDataMiner(128 /* NT_UPDATE_PORTS_XML */, "10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]", "InputLeftOutputTop");
  protocol.NotifyDataMiner(128 /* NT_UPDATE_PORTS_XML */, "10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]", "InputTopOutputLeft");
  protocol.NotifyDataMiner(128 /* NT_UPDATE_PORTS_XML */, "10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]", MatrixLayoutOptions.INPUT_LEFT_OUTPUT_TOP);
  protocol.NotifyDataMiner(128 /* NT_UPDATE_PORTS_XML */, "10;[ELEMENT_ID];[MATRIX_PARAM_ID];[DMA_ID]", MatrixLayoutOptions.INPUT_TOP_OUTPUT_LEFT);
  ```

  > [!NOTE]
  > MatrixLayoutOptions is defined in the Skyline.DataMiner.Net.Matrices namespace (SLNetTypes.dll)
