---
uid: GetMonitoredParametersForElement
---

# GetMonitoredParametersForElement

Use this method to retrieve all the monitored parameters for a specified element. Available from DataMiner 9.5.8 onwards.

## Input

| Item                | Format  | Description                                                                      |
|---------------------|---------|----------------------------------------------------------------------------------|
| Connection          | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID               | Integer | The DataMiner Agent ID.                                                          |
| ElementID           | Integer | The element ID.                                                                  |
| IncludeTableIndices | Boolean | Indicates whether table indices should be included.                              |

## Output

| Item                                    | Format                                                                               | Description                                         |
|-----------------------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------|
| GetMonitoredParame­tersForElementResult | Array of DMAParameter (see [DMAParameter](xref:DMAParameter)) | The monitored parameters for the specified element. |

