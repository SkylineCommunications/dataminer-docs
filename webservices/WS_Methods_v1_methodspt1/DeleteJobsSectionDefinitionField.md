---
uid: DeleteJobsSectionDefinitionField
---

# DeleteJobsSectionDefinitionField

Use this method to delete a job section definition field.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| Connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DomainID            | String | The domain ID.                                       |
| SectionDefinitionID | String | The ID of the job section definition.                |
| Field ID            | String | The ID of the job section definition field.          |

## Output

| Item                                    | Format  | Description                                                                                                                                                                                     |
|-----------------------------------------|---------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DeleteJobsSection­DefinitionFieldResult | Boolean | Returns “true” if the job section definition field has been fully deleted, or “false” if the job section definition field has been hidden instead, because it has already been used previously. |

