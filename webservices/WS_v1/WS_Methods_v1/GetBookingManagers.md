---
uid: GetBookingManagers
---

# GetBookingManagers

Use this method to retrieve a list of all booking manager elements in the DataMiner System.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetBookingManagers­Result | Array of [DMABookingManager](xref:DMABookingManager) | The booking manager elements in the DataMiner System. |
