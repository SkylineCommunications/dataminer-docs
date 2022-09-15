---
uid: DeleteJobsSectionDefinitionField
---

# DeleteJobsSectionDefinitionField

Use this method to delete a job section definition field.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID            | String | The domain ID.                                       |
| sectionDefinitionID | String | The ID of the job section definition.                |
| fieldID            | String | The ID of the job section definition field.          |

## Output

| Item | Format | Description |
|--|--|--|
| DeleteJobsSectionDefinitionFieldResult | Boolean | Returns “true” if the job section definition field has been fully deleted, or “false” if the job section definition field has been hidden instead, because it has already been used previously. |
