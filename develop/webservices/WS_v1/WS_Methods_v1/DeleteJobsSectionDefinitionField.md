---
uid: DeleteJobsSectionDefinitionField
---

# DeleteJobsSectionDefinitionField

Use this method to delete a job section definition field.

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
| fieldID             | String | The ID of the job section definition field.          |

## Output

| Item | Format | Description |
|--|--|--|
| DeleteJobsSectionDefinitionFieldResult | Boolean | Returns “true” if the job section definition field has been fully deleted, or “false” if the job section definition field has been hidden instead, because it has already been used previously. |
