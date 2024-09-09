---
uid: GetJobsSectionDefinition
---

# GetJobsSectionDefinition

Use this method to retrieve a particular job section definition. Can only be used in case there is only one job domain. Otherwise, use [GetJobsSectionDefinitionV2](xref:GetJobsSectionDefinitionV2).

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| sectionDefinitionID | String | The job section definition ID.                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionResult | [DMASectionDefinition](xref:DMASectionDefinition) | The requested job section definition. |
