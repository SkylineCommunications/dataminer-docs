---
uid: SetSpectrumParameter
---

# SetSpectrumParameter

Use this method to set a particular spectrum parameter (available from DataMiner 9.5.5 onwards).

## Input

| Item        | Format           | Description                                                                                                 |
|-------------|------------------|-------------------------------------------------------------------------------------------------------------|
| Connection  | String           | The connection ID. See [ConnectApp](xref:ConnectApp) .                            |
| DmaID       | Integer          | The DataMiner Agent ID.                                                                                     |
| ElementID   | Integer          | The element ID.                                                                                             |
| ParameterID | Integer          | The ID of the spectrum parameter.                                                                           |
| TableIndex  | String           | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| Value       | Double           | The value to which the parameter should be set.                                                             |
| SessionID   | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started      |

## Output

None.

