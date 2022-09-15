---
uid: GetParameterByName
---

# GetParameterByName

Use this method to retrieve the data of a particular parameter by name.

## Input

| Item          | Format  | Description                                                                                                 |
|---------------|---------|-------------------------------------------------------------------------------------------------------------|
| connection    | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| elementName   | String  | The element name.                                                                                           |
| parameterName | Integer | The parameter name.                                                                                         |
| tableIndex    | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterByNameResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameter. |
