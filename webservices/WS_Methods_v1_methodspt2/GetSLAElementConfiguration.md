---
uid: GetSLAElementConfiguration
---

# GetSLAElementConfiguration

Use this method to retrieve the configuration for a specified SLA element.

Available from DataMiner 9.0.5 onwards.

## Input

| Item       | Format  | Description                                                                          |
|------------|---------|--------------------------------------------------------------------------------------|
| Connection | String  | The connection string. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                              |
| ElementID  | Integer | The ID of the SLA element.                                                           |

## Output

| Item                              | Format                                                                               | Description                                     |
|-----------------------------------|--------------------------------------------------------------------------------------|-------------------------------------------------|
| GetSLAElementConfigu­rationResult | [DMASLAElementConfiguration](xref:DMASLAElementConfiguration) | The configuration of the specified SLA element. |

