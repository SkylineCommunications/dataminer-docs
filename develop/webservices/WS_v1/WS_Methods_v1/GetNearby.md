---
uid: GetNearby
---

# GetNearby

Use this method to retrieve all the nearby elements and services based on latitude and longitude.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| latitude   | Double | Latitude.                                             |
| longitude  | Double | Longitude.                                            |
| accuracy   | Double | Accuracy (in meters).                                 |

## Output

| Item | Format | Description |
|--|--|--|
| GetNearbyResult | Array of [DMARecent](xref:DMARecent) | The list of all the nearby elements and services. |
