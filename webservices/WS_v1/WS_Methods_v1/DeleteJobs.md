---
uid: DeleteJobs
---

# DeleteJobs

Use this method to delete several jobs at the same time. If any of the specified jobs cannot be found, these will be skipped.

## Input

| Item       | Format          | Description                                          |
|------------|-----------------|------------------------------------------------------|
| Connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DomainID   | String          | The ID of the job domain.                            |
| JobIDs     | Array of string | The IDs of the jobs.                                 |

## Output

| Item             | Format          | Description                                                                     |
|------------------|-----------------|---------------------------------------------------------------------------------|
| DeleteJobsResult | Array of string | A list of the successfully removed jobs and the jobs that failed to be removed. |
