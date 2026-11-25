---
uid: GetJobsSectionDefinitionsV2
---

# GetJobsSectionDefinitionsV2

Use this method to retrieve all job section definitions from a specific domain.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The domain ID |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionsV2Result | Array of [DMASectionDefinition](xref:DMASectionDefinition) | All job section definitions in the domain. |
