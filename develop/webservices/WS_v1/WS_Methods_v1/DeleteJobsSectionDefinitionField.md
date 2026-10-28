---
uid: DeleteJobsSectionDefinitionField
---

# DeleteJobsSectionDefinitionField

Use this method to delete a job section definition field.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
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
