---
uid: CreateJobTemplate
---

# CreateJobTemplate

Use this method to create a job template.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format         | Description                                                        |
|------------|----------------|--------------------------------------------------------------------|
| connection | String         | The connection string. See [ConnectApp](xref:ConnectApp).          |
| template   | DMAJobTemplate | See [DMAJobTemplate](xref:DMAJobTemplate).                         |

## Output

| Item                     | Format | Description                         |
|--------------------------|--------|-------------------------------------|
| CreateJobTemplateResult  | String | The ID of the created job template. |
