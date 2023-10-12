---
uid: SetSpectrumParameter
---

# SetSpectrumParameter

Use this method to set a particular spectrum parameter (available from DataMiner 9.5.5 onwards).

This method is obsolete from DataMiner 10.3.5/10.4.0 onwards. <!-- RN 36364 -->

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The ID of the spectrum parameter. |
| tableIndex | String | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| value | Double | The value to which the parameter should be set. |
| sessionID | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |

## Output

None.
