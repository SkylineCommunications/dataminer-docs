---
uid: GetJobTemplate
---

# GetJobTemplate

Use this method to retrieve a specific job template. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplateV2](xref:GetJobTemplateV2).

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| templateID | String | The ID of the job template.                          |

## Output

| Item                 | Format                                | Description                 |
|----------------------|---------------------------------------|-----------------------------|
| GetJobTemplateResult | [DMAJobTemplate](xref:DMAJobTemplate) | The requested job template. |
