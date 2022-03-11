---
uid: GetParameterByName
---

# GetParameterByName

Use this method to retrieve the data of a particular parameter by name.

## Input

| Item          | Format  | Description                                                                                                 |
|---------------|---------|-------------------------------------------------------------------------------------------------------------|
| Connection    | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| ElementName   | String  | The element name.                                                                                           |
| ParameterName | Integer | The parameter name.                                                                                         |
| TableIndex    | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |

## Output

| Item                      | Format                                                   | Description                          |
|---------------------------|----------------------------------------------------------|--------------------------------------|
| GetParameterByName­Result | [DMAParameter](xref:DMAParameter) | The data of the specified parameter. |
