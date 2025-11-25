---
uid: GetSLAElementConfiguration
---

# GetSLAElementConfiguration

Use this method to retrieve the configuration for a specified SLA element.

## Input

| Item       | Format  | Description                                               |
|------------|---------|-----------------------------------------------------------|
| connection | String  | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                   |
| elementID  | Integer | The ID of the SLA element.                                |

## Output

| Item | Format | Description |
|--|--|--|
| GetSLAElementConfigurationResult | [DMASLAElementConfiguration](xref:DMASLAElementConfiguration) | The configuration of the specified SLA element. |
