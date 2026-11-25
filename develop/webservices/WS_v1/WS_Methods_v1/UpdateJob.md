---
uid: UpdateJob
---

# UpdateJob

Use this method to update a specific job.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| domainID | Integer | The job domain ID. |
| job | [DMAJob](xref:DMAJob) | The ID, name, start time and end time of the job, as well as the various job sections. |

## Output

None.
