---
uid: GetElementConfiguration
---

# GetElementConfiguration

Use this method to retrieve the configuration of a specified element.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                              |
| ElementID  | Integer | The element ID.                                      |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementConfigura­tionResult | [DMAElementConfiguration](xref:DMAElementConfiguration) | The configuration of the specified element. |
