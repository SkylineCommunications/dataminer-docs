---
uid: GetParameterValueByElementName
---

# GetParameterValueByElementName

Use this method to request the current state and current value(s) of specific parameters of an element (referenced by name).

> [!NOTE]
> If you want to retrieve values from tables, specify table IDs and not column IDs.

## Input

| Item        | Format          | Description                                   |
|-------------|-----------------|-----------------------------------------------|
| Connection  | String          | The connection ID. See [Connect](xref:Connect). |
| ElementName | String          | The element name.                             |
| Parameters  | Array of string | The names or IDs of the requested parameters. |

## Output

| Item                                  | Format                                                                        | Description                                 |
|---------------------------------------|-------------------------------------------------------------------------------|---------------------------------------------|
| GetParameterValueBy­ElementNameResult | Array of ParamValue (see[ParamValue](xref:ParamValue)) | The properties of the requested parameters. |

