---
uid: DeleteJobsSectionDefinition
---

# DeleteJobsSectionDefinition

Use this method to delete a job section definition. No longer supported from DataMiner 10.0.9 onwards. Use DeleteJobsSectionDefinitionFromDomain instead (see [DeleteJobsSectionDefinitionFromDomain](xref:DeleteJobsSectionDefinitionFromDomain)).

> [!NOTE]
> The default job section definition cannot be deleted.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| sectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item | Format | Description |
|--|--|--|
| DeleteJobsSectionDefinitionResult | Boolean | Returns “true” if the job section definition has been fully deleted, or “false” if the job section definition has been hidden instead, because it has already been used previously. |
