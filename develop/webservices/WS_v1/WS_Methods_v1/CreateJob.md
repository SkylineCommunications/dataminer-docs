---
uid: CreateJob
---

# CreateJob

Use this method to create a job.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| domainID   | Integer | The job domain ID. |
| job        | [DMAJob](xref:DMAJob) | The ID, name, start time and end time of the job, as well as the various job sections. |

## Output

| Item             | Format | Description                |
|------------------|--------|----------------------------|
| CreateJobResult  | String | The ID of the created job. |
