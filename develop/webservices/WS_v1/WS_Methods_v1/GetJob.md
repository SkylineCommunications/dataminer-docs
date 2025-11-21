---
uid: GetJob
---

# GetJob

Use this method to retrieve a specific job.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String | The ID of the job domain.                            |
| jobID      | String | The ID of the job.                                   |

## Output

| Item         | Format                | Description        |
|--------------|-----------------------|--------------------|
| GetJobResult | [DMAJob](xref:DMAJob) | The requested job. |
