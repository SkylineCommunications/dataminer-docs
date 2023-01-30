---
uid: GetServicePropertiesByName
---

# GetServicePropertiesByName

Use this method to request the properties of a specific service (referenced by name).

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| connection  | String | The connection ID. See [Connect](xref:Connect). |
| ServiceName | String | The service name.                             |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicePropertiesByNameResult | Array of [ParamValue](xref:ParamValue) | All properties of the specified service (and their current values). |
