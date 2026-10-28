---
uid: GetBookingsForJobSection
---

# GetBookingsForJobSection

Use this method to retrieve a list of the bookings for a specific job section.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

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
