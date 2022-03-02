---
uid: GetCapacityParametersForResource
---

# GetCapacityParametersForResource

Use this method to retrieve all the capacity parameters for a specific resource. Available from DataMiner 10.0.2 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ResourceID | String | The resource ID.                                     |

## Output

| Item                                    | Format                            | Description                                         |
|-----------------------------------------|-----------------------------------|-----------------------------------------------------|
| GetCapacityParame­tersForResourceResult | Array of DMAProfilePa­rameterLite | The ID and name of each of the capacity parameters. |
