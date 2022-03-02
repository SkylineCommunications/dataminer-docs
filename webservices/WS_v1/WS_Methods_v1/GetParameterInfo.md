---
uid: GetParameterInfo
---

# GetParameterInfo

Use this method to retrieve general information for a particular parameter.

## Input

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                                                          |
| ElementID   | Integer | The element ID.                                                                  |
| ParameterID | Integer | The parameter ID.                                                                |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterInfoResult | [DMAParameterInfo](xref:DMAParameterInfo) | The general information on the specified parameter. |
