---
uid: UpdateJobTemplate
---

# UpdateJobTemplate

Use this method to update an existing job template.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format         | Description                                               |
|------------|----------------|-----------------------------------------------------------|
| connection | String         | The connection string. See [ConnectApp](xref:ConnectApp). |
| template   | [DMAJobTemplate](xref:DMAJobTemplate) | The job template configuration.    |

## Output

| Item                    | Format | Description                         |
|-------------------------|--------|-------------------------------------|
| UpdateJobTemplateResult | String | The ID of the updated job template. |
