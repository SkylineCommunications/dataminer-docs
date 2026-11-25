---
uid: GetJobsHistory
---

# GetJobsHistory

Use this method to retrieve all changes that were made to a job, with the most recent changes first.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The job ID.                                          |

## Output

| Item                  | Format                        | Description                                                  |
|-----------------------|-------------------------------|--------------------------------------------------------------|
| GetJobsHistoryResult  | Array of DMAJobHistoryChange  | The changes that were made to the specified job in the past. |
