---
uid: GetBookingsForJobSection
---

# GetBookingsForJobSection

Use this method to retrieve a list of the bookings for a specific job section. Available from DataMiner 9.6.11 onwards.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| Connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| JobID               | String | The ID of the job.                                   |
| SectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item                            | Format                                                                                      | Description                                 |
|---------------------------------|---------------------------------------------------------------------------------------------|---------------------------------------------|
| GetBookingsForJobSec­tionResult | Array of DMABooking­Lite (see [DMABookingLite](xref:DMABookingLite)) | The bookings for the specified job section. |

