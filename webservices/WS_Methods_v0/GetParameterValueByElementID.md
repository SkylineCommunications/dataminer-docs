---
uid: GetParameterValueByElementID
---

# GetParameterValueByElementID

Use this method to request the current state and current value(s) of specific parameters of an element (referenced by ID).

## Input

| Item       | Format          | Description                                   |
|------------|-----------------|-----------------------------------------------|
| Connection | String          | The connection ID. See [Connect](xref:Connect). |
| DmaID      | Integer         | The DataMiner Agent ID.                       |
| ElementID  | Integer         | The element ID.                               |
| Parameters | Array of string | The names or IDs of the requested parameters. |

## Output

| Item                                | Format                                                                        | Description                                 |
|-------------------------------------|-------------------------------------------------------------------------------|---------------------------------------------|
| GetParameterValueBy­ElementIDResult | Array of ParamValue (see[ParamValue](xref:ParamValue)) | The properties of the requested parameters. |

