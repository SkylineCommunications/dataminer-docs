---
uid: GetParameter
---

# GetParameter

Use this method to retrieve the data of a particular parameter.

## Input

| Item        | Format  | Description                                                                                                 |
|-------------|---------|-------------------------------------------------------------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                            |
| DmaID       | Integer | The DataMiner Agent ID.                                                                                     |
| ElementID   | Integer | The element ID.                                                                                             |
| ParameterID | Integer | The parameter ID.                                                                                           |
| TableIndex  | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |

## Output

| Item               | Format                                                   | Description                          |
|--------------------|----------------------------------------------------------|--------------------------------------|
| GetParameterResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameter. |

