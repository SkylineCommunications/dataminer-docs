---
uid: SetParameterValueByElementID
---

# SetParameterValueByElementID

Use this method to update the value of a parameter linked to an element (referenced by ID).

> [!NOTE]
> Currently, this method can only be used to update single-value parameters of type String.

## Input

| Item       | Format  | Description                                     |
|------------|---------|-------------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect). |
| DMAID      | Integer | The DataMiner Agent ID.                         |
| ElementID  | Integer | The element ID.                                 |
| ParamName  | String  | The parameter name.                             |
| paramPKey  | Object  | The primary key of a row.                       |
| paramDKey  | Object  | The display key of a row.                       |
| ParamValue | Object  | The new parameter value.                        |

> [!NOTE]
> To do a parameter set on a certain cell of a table, specify the table column parameter name and either the display key or the primary key of the row.

## Output

None.
