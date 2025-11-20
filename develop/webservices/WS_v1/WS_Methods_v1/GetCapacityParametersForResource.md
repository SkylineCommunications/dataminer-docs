---
uid: GetCapacityParametersForResource
---

# GetCapacityParametersForResource

Use this method to retrieve all the capacity parameters for a specific resource.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| resourceID | String | The resource ID.                                     |

## Output

| Item                                    | Format                            | Description                                         |
|-----------------------------------------|-----------------------------------|-----------------------------------------------------|
| GetCapacityParametersForResourceResult | Array of [DMAProfileParameterLite](xref:DMAProfileParameterLite) | The ID and name of each of the capacity parameters. |
