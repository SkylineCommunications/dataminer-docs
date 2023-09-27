---
uid: GetBookingsForJob
---

# GetBookingsForJob

Use this method to retrieve a list of the bookings for a specific job.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The ID of the job.                                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetBookingsForJobResult | Array of [DMABookingLite](xref:DMABookingLite) | The bookings for the specified job. |
