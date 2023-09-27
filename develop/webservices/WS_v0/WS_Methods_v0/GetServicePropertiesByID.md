---
uid: GetServicePropertiesByID
---

# GetServicePropertiesByID

Use this method to request the properties of a specific service (referenced by ID).

## Input

| Item       | Format  | Description                                   |
|------------|---------|-----------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect). |
| DMAID      | Integer | The DataMiner Agent ID.                       |
| ServiceID  | Integer | The service ID.                               |

## Output

| Item | Format | Description |
|--|--|--|
| GetServicePropertiesByIDResult | Array of [ParamValue](xref:ParamValue) | All properties of the specified service (and their current values). |
