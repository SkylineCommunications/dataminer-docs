---
uid: GetMonitoredParametersForService
---

# GetMonitoredParametersForService

Use this method to retrieve all the monitored parameters for all elements of a specified service. Available from DataMiner 9.5.8 onwards.

## Input

| Item                | Format  | Description                                                                      |
|---------------------|---------|----------------------------------------------------------------------------------|
| Connection          | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID               | Integer | The DataMiner Agent ID.                                                          |
| ServiceID           | Integer | The service ID.                                                                  |
| IncludeTableIndices | Boolean | Indicates whether table indices should be included.                              |
| Filter              | String  | Optional parameter name filter supporting regular expressions.                   |

## Output

| Item                                    | Format                                                                               | Description                                         |
|-----------------------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------|
| GetMonitoredParame­tersForServiceResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The monitored parameters for the specified service. |

