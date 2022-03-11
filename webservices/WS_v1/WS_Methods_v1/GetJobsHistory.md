---
uid: GetJobsHistory
---

# GetJobsHistory

Use this method to retrieve all changes that were made to a job, with the most recent changes first. Available from DataMiner 10.0.11 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| JobID      | String | The job ID.                                          |

## Output

| Item                  | Format                        | Description                                                  |
|-----------------------|-------------------------------|--------------------------------------------------------------|
| GetJobsHistoryResult  | Array of DMAJobHistory­Change  | The changes that were made to the specified job in the past. |
