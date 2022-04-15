---
uid: SetMeasurementPoints
---

# SetMeasurementPoints

Use this method to set the measurement point cycle of a spectrum analyzer (available from DataMiner 9.5.5 onwards).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| measpts | Array of unsigned integers | An array of measurement point IDs |
| sessionID | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |

## Output

None.
