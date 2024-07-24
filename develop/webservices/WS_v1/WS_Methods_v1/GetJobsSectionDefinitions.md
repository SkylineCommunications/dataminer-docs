---
uid: GetJobsSectionDefinitions
---

# GetJobsSectionDefinitions

Use this method to retrieve all job section definitions.

Can only be used in case there is only one job domain. Otherwise, use [GetJobsSectionDefinitionsV2](xref:GetJobsSectionDefinitionsV2).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionsResult | Array of [DMASectionDefinition](xref:DMASectionDefinition) | All job section definitions in the system. |
