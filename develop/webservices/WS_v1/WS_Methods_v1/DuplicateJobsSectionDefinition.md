---
uid: DuplicateJobsSectionDefinition
---

# DuplicateJobsSectionDefinition

Use this method to duplicate a section definition from one jobs domain to another.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The ID of the domain to which the job section should be duplicated. |
| sourceDomainID | String | The ID of the domain from which the job section should be duplicated. |
| sectionDefinition | [DMASectionDefinition](xref:DMASectionDefinition) | The section definition. |

## Output

| Item                                 | Format | Description                                   |
|--------------------------------------|--------|-----------------------------------------------|
| DuplicateJobsSectionDefinitionResult | String | The ID of the created job section definition. |
