---
uid: GetJobsSectionDefinitionsV2
---

# GetJobsSectionDefinitionsV2

Use this method to retrieve all job section definitions from a specific domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DomainID | String | The domain ID |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsSectionDefinitionsV2Result | Array of [DMASectionDefinition](xref:DMASectionDefinition) | All job section definitions in the domain. |
