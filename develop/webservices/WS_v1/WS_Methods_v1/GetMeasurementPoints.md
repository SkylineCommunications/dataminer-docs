---
uid: GetMeasurementPoints
---

# GetMeasurementPoints

Use this method to retrieve information about measurement points.

## Input

| Item       | Format           | Description                                                                                            |
|------------|------------------|--------------------------------------------------------------------------------------------------------|
| connection | String           | The connection ID. See [ConnectApp](xref:ConnectApp).                                                  |
| dmaID      | Integer          | The DataMiner Agent ID.                                                                                |
| elementID  | Integer          | The element ID.                                                                                        |

## Output

| Item | Format | Description |
|--|--|--|
| GetMeasurementPointsResult | Array of [DMASpectrumMeasptModel](xref:DMASpectrumMeasptModel) | An array containing information on each measurement point. |
