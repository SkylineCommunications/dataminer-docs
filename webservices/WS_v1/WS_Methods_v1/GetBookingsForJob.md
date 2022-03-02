---
uid: GetBookingsForJob
---

# GetBookingsForJob

Use this method to retrieve a list of the bookings for a specific job.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| JobID      | String | The ID of the job.                                   |

## Output

| Item                     | Format                                                                                      | Description                         |
|--------------------------|---------------------------------------------------------------------------------------------|-------------------------------------|
| GetBookingsForJob­Result | Array of DMABooking­Lite (see [DMABookingLite](xref:DMABookingLite)) | The bookings for the specified job. |
