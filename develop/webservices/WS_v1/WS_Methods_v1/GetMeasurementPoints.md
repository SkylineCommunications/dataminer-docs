---
uid: GetMeasurementPoints
---

# GetMeasurementPoints

Use this method to retrieve information about measurement points (available from DataMiner 9.5.5 onwards).

## Input

| Item       | Format           | Description                                                                                            |
|------------|------------------|--------------------------------------------------------------------------------------------------------|
| connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp).                       |
| dmaID      | Integer          | The DataMiner Agent ID.                                                                                |
| elementID  | Integer          | The element ID.                                                                                        |
| sessionID  | Unsigned integer | The client subscription ID from the WebSocket subscription with which the spectrum session was started |

## Output

| Item | Format | Description |
|--|--|--|
| GetMeasurementPointsResult | Array of [DMASpectrumMeasptModel](xref:DMASpectrumMeasptModel) | An array containing information on each measurement point. |
