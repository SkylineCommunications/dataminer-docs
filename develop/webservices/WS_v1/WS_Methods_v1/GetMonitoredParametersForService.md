---
uid: GetMonitoredParametersForService
---

# GetMonitoredParametersForService

Use this method to retrieve all the monitored parameters for all elements of a specified service.

## Input

| Item                | Format  | Description                                                    |
|---------------------|---------|----------------------------------------------------------------|
| connection          | String  | The connection ID. See [ConnectApp](xref:ConnectApp).          |
| dmaID               | Integer | The DataMiner Agent ID.                                        |
| serviceID           | Integer | The service ID.                                                |
| includeTableIndices | Boolean | Indicates whether table indices should be included.            |
| filter              | String  | Optional parameter name filter supporting regular expressions. |

## Output

| Item | Format | Description |
|--|--|--|
| GetMonitoredParametersForServiceResult | Array of [DMAParameter](xref:DMAParameter) | The monitored parameters for the specified service. |
