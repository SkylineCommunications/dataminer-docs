---
uid: GetBookingsForJobSection
---

# GetBookingsForJobSection

Use this method to retrieve a list of the bookings for a specific job section.

<!-- Available from DataMiner 9.6.11 onwards. -->

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID               | String | The ID of the job.                                   |
| sectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item | Format | Description |
|--|--|--|
| GetBookingsForJobSectionResult | Array of [DMABookingLite](xref:DMABookingLite) | The bookings for the specified job section. |
