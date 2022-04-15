---
uid: GetJobs
---

# GetJobs

Use this method to retrieve all jobs in the domain matching a particular filter.

## Input

| Item                | Format                     | Description                                                                     |
|---------------------|----------------------------|---------------------------------------------------------------------------------|
| connection          | String                     | The connection ID. See [ConnectApp](xref:ConnectApp).                            |
| domainID            | String                     | The ID of the job domain.                                                       |
| filter.SearchText   | String                     | The text that the job suggestions should match.                                 |
| filter.FieldFilters | Array of DMAJobFieldFilter | See [DMAJobFieldFilter](xref:DMAJobFieldFilter).         |
| filter.DateFrom     | Long integer               | The earliest date the jobs in the job suggestions can be planned.               |
| filter.DateTill     | Long integer               | The latest date the jobs in the job suggestions can be planned.                 |
| filter.CurrentPage  | Integer                    | The ID of the page of jobs to be retrieved, in case there are multiple pages.   |
| filter.PageSize     | Integer                    | The size of the page of jobs to be retrieved, in case there are multiple pages. |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsResult | Array of [DMAJob](xref:DMAJob) | The jobs matching the specified filter. |
