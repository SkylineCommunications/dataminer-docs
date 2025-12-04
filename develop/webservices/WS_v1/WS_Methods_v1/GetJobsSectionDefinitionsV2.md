---
uid: GetJobsSectionDefinitionsV2
---

# GetJobsSectionDefinitionsV2

Use this method to retrieve all job section definitions from a specific domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
