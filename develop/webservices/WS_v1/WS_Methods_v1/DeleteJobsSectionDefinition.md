---
uid: DeleteJobsSectionDefinition
---

# DeleteJobsSectionDefinition

This method is no longer supported.<!-- No longer supported from DataMiner 10.0.9 onwards. -->

To delete a job section definition, use [DeleteJobsSectionDefinitionFromDomain](xref:DeleteJobsSectionDefinitionFromDomain) instead.

> [!NOTE]
> The default job section definition cannot be deleted.

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

| Item | Format | Description |
|--|--|--|
| DeleteJobsSectionDefinitionResult | Boolean | Returns “true” if the job section definition has been fully deleted, or “false” if the job section definition has been hidden instead, because it has already been used previously. |
