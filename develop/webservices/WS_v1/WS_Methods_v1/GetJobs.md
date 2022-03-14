---
uid: GetJobs
---

# GetJobs

Use this method to retrieve all jobs in the domain matching a particular filter.

## Input

| Item                | Format                     | Description                                                                     |
|---------------------|----------------------------|---------------------------------------------------------------------------------|
| Connection          | String                     | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| DomainID            | String                     | The ID of the job domain.                                                       |
| Filter.SearchText   | String                     | The text that the job suggestions should match.                                 |
| Filter.FieldFilters | Array of DMAJobFieldFilter | See [DMAJobFieldFilter](xref:DMAJobFieldFilter).         |
| Filter.DateFrom     | Long integer               | The earliest date the jobs in the job suggestions can be planned.               |
| Filter.DateTill     | Long integer               | The latest date the jobs in the job suggestions can be planned.                 |
| Filter.CurrentPage  | Integer                    | The ID of the page of jobs to be retrieved, in case there are multiple pages.   |
| Filter.PageSize     | Integer                    | The size of the page of jobs to be retrieved, in case there are multiple pages. |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsResult | Array of [DMAJob](xref:DMAJob) | The jobs matching the specified filter. |
