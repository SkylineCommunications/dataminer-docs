---
uid: GetJobsHistory
---

# GetJobsHistory

Use this method to retrieve all changes that were made to a job, with the most recent changes first.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
