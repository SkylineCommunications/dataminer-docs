---
uid: GetAffectedJobDomains
---

# GetAffectedJobDomains

Use this method to retrieve all domains that a specific section definition is linked to.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
