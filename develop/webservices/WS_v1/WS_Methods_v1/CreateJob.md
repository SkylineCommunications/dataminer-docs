---
uid: CreateJob
---

# CreateJob

Use this method to create a job.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| domainID   | Integer | The job domain ID. |
| job        | [DMAJob](xref:DMAJob) | The ID, name, start time and end time of the job, as well as the various job sections. |

## Output

| Item             | Format | Description                |
|------------------|--------|----------------------------|
| CreateJobResult  | String | The ID of the created job. |
