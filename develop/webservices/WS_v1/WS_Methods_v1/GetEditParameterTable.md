---
uid: GetEditParameterTable
---

# GetEditParameterTable

Use this method to retrieve all the information necessary to be able to present users with a control that allows them to update a specific cell of a table parameter.

## Input

| Item        | Format  | Description                                          |
|-------------|---------|------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID       | Integer | The DataMiner Agent ID.                              |
| ElementID   | Integer | The element ID.                                      |
| ParameterID | Integer | The parameter ID.                                    |
| TableIndex  | String  | The table index.                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetEditParameterTable­Result | [DMAParameterEdit](xref:DMAParameterEdit) | The properties of the specified parameter. |
