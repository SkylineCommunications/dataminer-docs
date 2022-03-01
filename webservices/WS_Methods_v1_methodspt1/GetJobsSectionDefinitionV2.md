---
uid: GetJobsSectionDefinitionV2
---

# GetJobsSectionDefinitionV2

Use this method to retrieve a job section definition from a specific domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| Connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| SectionDefinitionID | String | The job section definition ID.                       |
| DomainID            | String | The domain ID.                                       |

## Output

| Item                              | Format                                                                                                        | Description                           |
|-----------------------------------|---------------------------------------------------------------------------------------------------------------|---------------------------------------|
| GetJobsSectionDefi­nitionV2Result | Array of DMASectionDefini­tion (see [DMASectionDefinition](xref:DMASectionDefinition)) | The requested job section definition. |

