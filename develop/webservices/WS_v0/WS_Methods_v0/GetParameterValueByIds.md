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
| connection  | String  | The connection ID. See [Connect](xref:Connect). |
| dataminerID | Integer | The DataMiner Agent ID.                       |
| elementID   | Integer | The element ID.                               |
| parameterID | Integer | The parameter ID.                             |
| tableIndex  | String  | The table index.                              |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterValueByIdsResult | [ParamValue](xref:ParamValue) | The properties of the requested parameter. |
