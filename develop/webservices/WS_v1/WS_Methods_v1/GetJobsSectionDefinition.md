---
uid: GetJobsSectionDefinition
---

# GetJobsSectionDefinition

Use this method to retrieve a particular job section definition. Can only be used in case there is only one job domain. Otherwise, use [GetJobsSectionDefinitionV2](xref:GetJobsSectionDefinitionV2).

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| sectionDefinitionID | String | The job section definition ID.                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionResult | [DMASectionDefinition](xref:DMASectionDefinition) | The requested job section definition. |
