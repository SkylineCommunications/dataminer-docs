---
uid: GetJobTemplateV2
---

# GetJobTemplateV2

Use this method to retrieve a specific job template from a domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| templateID | String | The ID of the job template.                          |
| domainID   | String | The domain ID.                                       |

## Output

| Item                    | Format                               | Description                 |
|-------------------------|--------------------------------------|-----------------------------|
| GetJobTemplateV2Result | [DMAJobTemplate](xref:DMAJobTemplate) | The requested job template. |
