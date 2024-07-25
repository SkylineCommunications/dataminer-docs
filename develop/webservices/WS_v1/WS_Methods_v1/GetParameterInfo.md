---
uid: GetParameterInfo
---

# GetParameterInfo

Use this method to retrieve general information for a particular parameter.

## Input

| Item        | Format  | Description                                           |
|-------------|---------|-------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DataMiner Agent ID.                               |
| elementID   | Integer | The element ID.                                       |
| parameterID | Integer | The parameter ID.                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterInfoResult | [DMAParameterInfo](xref:DMAParameterInfo) | The general information on the specified parameter. |
