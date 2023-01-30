---
uid: DuplicateJobsSectionDefinition
---

# DuplicateJobsSectionDefinition

Use this method to duplicate a section definition from one jobs domain to another. Available from DataMiner 10.0.10 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The ID of the domain to which the job section should be duplicated. |
| sourceDomainID | String | The ID of the domain from which the job section should be duplicated. |
| sectionDefinition | [DMASectionDefinition](xref:DMASectionDefinition) | The section definition. |

## Output

| Item                                  | Format | Description                                   |
|---------------------------------------|--------|-----------------------------------------------|
| DuplicateJobsSectionDefinitionResult | String | The ID of the created job section definition. |
