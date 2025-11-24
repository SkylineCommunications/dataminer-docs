---
uid: GetBookingsForJobSection
---

# GetBookingsForJobSection

Use this method to retrieve a list of the bookings for a specific job section.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
