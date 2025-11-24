---
uid: DeleteJobs
---

# DeleteJobs

Use this method to delete several jobs at the same time. If any of the specified jobs cannot be found, these will be skipped.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
