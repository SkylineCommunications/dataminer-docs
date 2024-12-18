---
uid: GetParameter
---

# GetParameter

Use this method to retrieve the data of a particular parameter.

## Input

| Item        | Format  | Description                                                                                                 |
|-------------|---------|-------------------------------------------------------------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                                       |
| dmaID       | Integer | The DataMiner Agent ID.                                                                                     |
| elementID   | Integer | The element ID.                                                                                             |
| parameterID | Integer | The parameter ID.                                                                                           |
| tableIndex  | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |

## Output

| Item               | Format                            | Description                          |
|--------------------|-----------------------------------|--------------------------------------|
| GetParameterResult | [DMAParameter](xref:DMAParameter) | The data of the specified parameter. |
