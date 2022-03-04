---
uid: GetParameterValueByIds
---

# GetParameterValueByIds

Use this method to request the value of a specific parameter (referenced by DataMiner Agent ID, element ID, and parameter ID).

> [!NOTE]
> If you request the value of a column parameter, then the method will return only a single cell.

## Input

| Item        | Format  | Description                                   |
|-------------|---------|-----------------------------------------------|
| Connection  | String  | The connection ID. See [Connect](xref:Connect). |
| DataminerID | Integer | The DataMiner Agent ID.                       |
| ElementID   | Integer | The element ID.                               |
| ParameterID | Integer | The parameter ID.                             |
| TableIndex  | String  | The table index.                              |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterValue­ByIdsResult | [ParamValue](xref:ParamValue) | The properties of the requested parameter. |
