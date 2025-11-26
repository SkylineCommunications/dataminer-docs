---
uid: DeleteJobsSectionDefinitionFromDomain
---

# DeleteJobsSectionDefinitionFromDomain

Use this method to delete a job section definition from a specific job domain. Note that the job section definition will still exist, but the link with the domain will be removed.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID            | String | The domain ID.                                       |
| sectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item | Format | Description |
|--|--|--|
| DeleteJobsSectionDefinitionFromDomainResult | Boolean | Returns “true” if the job section definition has been fully deleted, or “false” if the job section definition has been hidden instead, because it has already been used previously. |
