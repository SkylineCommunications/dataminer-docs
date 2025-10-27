---
uid: DeleteJobsSectionDefinition
---

# DeleteJobsSectionDefinition

This method is no longer supported.<!-- No longer supported from DataMiner 10.0.9 onwards. -->

To delete a job section definition, use [DeleteJobsSectionDefinitionFromDomain](xref:DeleteJobsSectionDefinitionFromDomain) instead.

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
