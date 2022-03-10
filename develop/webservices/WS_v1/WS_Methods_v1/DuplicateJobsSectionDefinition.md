---
uid: DuplicateJobsSectionDefinition
---

# DuplicateJobsSectionDefinition

Use this method to duplicate a section definition from one jobs domain to another. Available from DataMiner 10.0.10 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DomainID | String | The ID of the domain to which the job section should be duplicated. |
| sourceDomainID | String | The ID of the domain from which the job section should be duplicated. |
| SectionDefinition | [DMASectionDefinition](xref:DMASectionDefinition) | The section definition. |

## Output

| Item                                  | Format | Description                                   |
|---------------------------------------|--------|-----------------------------------------------|
| DuplicateJobsSection­DefinitionResult | String | The ID of the created job section definition. |
