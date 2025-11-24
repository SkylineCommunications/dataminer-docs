---
uid: GetJobAttachmentNames
---

# GetJobAttachmentNames

Use this method to retrieve the names of all files attached to a specific job.

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

| Item                        | Format          | Description                                           |
|-----------------------------|-----------------|-------------------------------------------------------|
| GetJobAttachmentNamesResult | Array of string | The names of the files attached to the specified job. |
