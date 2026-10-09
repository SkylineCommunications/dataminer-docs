---
uid: GetAffectedJobDomains
---

# GetAffectedJobDomains

Use this method to retrieve all domains that a specific section definition is linked to.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| sectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item                         | Format          | Description                                                                      |
|------------------------------|-----------------|----------------------------------------------------------------------------------|
| GetAffectedJobDomainsResult | Array of string | The names of the job domains that the specified section definition is linked to. |
