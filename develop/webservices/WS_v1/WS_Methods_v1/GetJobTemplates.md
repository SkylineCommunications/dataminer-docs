---
uid: GetJobTemplates
---

# GetJobTemplates

Use this method to retrieve all the job templates available in the system. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplatesV2](xref:GetJobTemplatesV2).

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobTemplatesResult | Array of [DMAJobTemplate](xref:DMAJobTemplate) | The available job templates. |
