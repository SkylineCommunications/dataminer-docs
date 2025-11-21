---
uid: GetJobsSectionDefinitions
---

# GetJobsSectionDefinitions

Use this method to retrieve all job section definitions.

Can only be used in case there is only one job domain. Otherwise, use [GetJobsSectionDefinitionsV2](xref:GetJobsSectionDefinitionsV2).

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionsResult | Array of [DMASectionDefinition](xref:DMASectionDefinition) | All job section definitions in the system. |
