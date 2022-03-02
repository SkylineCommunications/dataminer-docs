---
uid: GetAffectedJobDomains
---

# GetAffectedJobDomains

Use this method to retrieve all domains that a specific section definition is linked to. Available from DataMiner 10.0.10 onwards.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| Connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| SectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item                         | Format          | Description                                                                      |
|------------------------------|-----------------|----------------------------------------------------------------------------------|
| GetAffectedJobDo­mainsResult | Array of string | The names of the job domains that the specified section definition is linked to. |
