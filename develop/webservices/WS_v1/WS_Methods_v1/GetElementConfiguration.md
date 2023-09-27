---
uid: GetElementConfiguration
---

# GetElementConfiguration

Use this method to retrieve the configuration of a specified element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                              |
| elementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementConfigurationResult | [DMAElementConfiguration](xref:DMAElementConfiguration) | The configuration of the specified element. |
