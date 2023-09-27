---
uid: GetParameterValueByElementID
---

# GetParameterValueByElementID

Use this method to request the current state and current value(s) of specific parameters of an element (referenced by ID).

## Input

| Item       | Format          | Description                                   |
|------------|-----------------|-----------------------------------------------|
| connection | String          | The connection ID. See [Connect](xref:Connect). |
| DMAID      | Integer         | The DataMiner Agent ID.                       |
| ElementID  | Integer         | The element ID.                               |
| parameters | Array of string | The names or IDs of the requested parameters. |

## Output

| Item | Format | Description |
|--|--|--|
| GetParameterValueByElementIDResult | Array of [ParamValue](xref:ParamValue) | The properties of the requested parameters. |
