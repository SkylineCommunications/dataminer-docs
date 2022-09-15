---
uid: GetResourceCapacityTrend
---

# GetResourceCapacityTrend

Use this method to retrieve data points and info over time for a specific capacity and resource.

Available from DataMiner 10.0.2 onwards.

## Input

| Item              | Format       | Description                                                                          |
|-------------------|--------------|--------------------------------------------------------------------------------------|
| connection        | String       | The connection ID. See [ConnectApp](xref:ConnectApp).     |
| resourceID        | String       | The resource ID.                                                                     |
| capacityProfileID | String       | The ID of the capacity profile.                                                      |
| sinceUTC          | Long integer | The starting time (in UTC format) from which data points and info must be retrieved. |
| untilUTC          | Long integer | The end time (in UTC format) until which data points and info must be retrieved.     |

## Output

| Item | Format | Description |
|--|--|--|
| GetResourceCapacityTrendResult | DMAResourceCapacityTrend | The trend data points for the specified capacity and resource, along with booking information and information on the maximum capacity. |
