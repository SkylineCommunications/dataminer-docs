---
uid: GetServiceTemplate
---

# GetServiceTemplate

Use this method to retrieve an existing service template. Available from DataMiner 10.2.1/10.3.0 onwards.

## Input

| Item              | Format  | Description                                                                          |
|-------------------|---------|--------------------------------------------------------------------------------------|
| Connection        | String  | The connection string. See [ConnectApp](xref:ConnectApp) . |
| DmaID             | Integer | The DataMiner Agent ID.                                                              |
| ServiceTemplateID | Integer | The service template ID.                                                             |

## Output

| Item                      | Format                   | Description                                                               |
|---------------------------|--------------------------|---------------------------------------------------------------------------|
| GetServiceTemplate­Result | DMAServiceTemplate array | See [DMAServiceTemplate](xref:DMAServiceTemplate). |

