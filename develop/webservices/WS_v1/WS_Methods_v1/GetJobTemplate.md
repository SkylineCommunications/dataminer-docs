---
uid: GetJobTemplate
---

# GetJobTemplate

Use this method to retrieve a specific job template. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplateV2](xref:GetJobTemplateV2).

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
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
