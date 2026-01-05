---
uid: DuplicateJobsSectionDefinition
---

# DuplicateJobsSectionDefinition

Use this method to duplicate a section definition from one jobs domain to another.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
