---
uid: GetMeasurementPoints
---

# GetMeasurementPoints

Use this method to retrieve information about measurement points.

<!-- Available from DataMiner 9.5.5 onwards. -->

## Input

| Item       | Format           | Description                                                                                            |
|------------|------------------|--------------------------------------------------------------------------------------------------------|
| connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp).                                                  |
| dmaID      | Integer          | The DataMiner Agent ID.                                                                                |
| elementID  | Integer          | The element ID.                                                                                        |

<!-- > [!NOTE]
> Up to DataMiner version 10.1.0/10.0.11, apart from the above-mentioned fields, also a session ID had to be passed to the method: the client subscription ID (unsigned integer) from the WebSocket subscription with which the spectrum session was started. --><!-- RN 26970 -->

## Output

| Item | Format | Description |
|--|--|--|
| GetMeasurementPointsResult | Array of [DMASpectrumMeasptModel](xref:DMASpectrumMeasptModel) | An array containing information on each measurement point. |
