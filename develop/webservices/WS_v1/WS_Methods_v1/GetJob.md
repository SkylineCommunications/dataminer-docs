---
uid: GetJob
---

# GetJob

Use this method to retrieve a specific job.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String | The ID of the job domain.                            |
| jobID      | String | The ID of the job.                                   |

## Output

| Item         | Format                | Description        |
|--------------|-----------------------|--------------------|
| GetJobResult | [DMAJob](xref:DMAJob) | The requested job. |
