---
uid: GetMonitoredParametersForElement
---

# GetMonitoredParametersForElement

Use this method to retrieve all the monitored parameters for a specified element.

<!-- Available from DataMiner 9.5.8 onwards. -->

## Input

| Item                | Format  | Description                                           |
|---------------------|---------|-------------------------------------------------------|
| connection          | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID               | Integer | The DataMiner Agent ID.                               |
| elementID           | Integer | The element ID.                                       |
| includeTableIndices | Boolean | Indicates whether table indices should be included.   |

## Output

| Item | Format | Description |
|--|--|--|
| GetMonitoredParametersForElementResult | Array of [DMAParameter](xref:DMAParameter) | The monitored parameters for the specified element. |
