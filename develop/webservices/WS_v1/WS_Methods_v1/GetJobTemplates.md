---
uid: GetJobTemplates
---

# GetJobTemplates

Use this method to retrieve all the job templates available in the system. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplatesV2](xref:GetJobTemplatesV2).

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobTemplatesResult | Array of [DMAJobTemplate](xref:DMAJobTemplate) | The available job templates. |
