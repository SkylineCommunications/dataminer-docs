---
uid: DeleteJobsSectionDefinitionFromDomain
---

# DeleteJobsSectionDefinitionFromDomain

Use this method to delete a job section definition from a specific job domain. Note that the job section definition will still exist, but the link with the domain will be removed.

Available from DataMiner 10.0.9 onwards.

## Input

| Item                | Format | Description                                          |
|---------------------|--------|------------------------------------------------------|
| Connection          | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DomainID            | String | The domain ID.                                       |
| SectionDefinitionID | String | The ID of the job section definition.                |

## Output

| Item | Format | Description |
|--|--|--|
| DeleteJobsSection­DefinitionFromDomain­Result | Boolean | Returns “true” if the job section definition has been fully deleted, or “false” if the job section definition has been hidden instead, because it has already been used previously. |
