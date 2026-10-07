---
uid: DeleteJobs
---

# DeleteJobs

Use this method to delete several jobs at the same time. If any of the specified jobs cannot be found, these will be skipped.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format          | Description                                          |
|------------|-----------------|------------------------------------------------------|
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String          | The ID of the job domain.                            |
| jobIDs     | Array of string | The IDs of the jobs.                                 |

## Output

| Item             | Format          | Description                                                                     |
|------------------|-----------------|---------------------------------------------------------------------------------|
| DeleteJobsResult | Array of string | A list of the successfully removed jobs and the jobs that failed to be removed. |
