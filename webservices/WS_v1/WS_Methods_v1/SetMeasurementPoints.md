---
uid: SetMeasurementPoints
---

# SetMeasurementPoints

Use this method to set the measurement point cycle of a spectrum analyzer (available from DataMiner 9.5.5 onwards).

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID | Integer | The DataMiner Agent ID. |
| ElementID | Integer | The element ID. |
| Measpts | Array of unsigned integers | An array of measurement point IDs |
| SessionID | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |

## Output

None.
