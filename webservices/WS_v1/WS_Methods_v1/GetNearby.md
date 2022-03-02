---
uid: GetNearby
---

# GetNearby

Use this method to retrieve all the nearby elements and services based on latitude and longitude.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| Latitude   | Double | Latitude.                                                                        |
| Longitude  | Double | Longitude.                                                                       |
| Accuracy   | Double | Accuracy (in meters).                                                            |

## Output

| Item | Format | Description |
|--|--|--|
| GetNearbyResult | Array of [DMARecent](xref:DMARecent) | The list of all the nearby elements and services. |
