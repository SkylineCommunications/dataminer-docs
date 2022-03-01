---
uid: GetJob
---

# GetJob

Use this method to retrieve a specific job.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DomainID   | String | The ID of the job domain.                            |
| JobID      | String | The ID of the job.                                   |

## Output

| Item         | Format                                       | Description        |
|--------------|----------------------------------------------|--------------------|
| GetJobResult | [DMAJob](xref:DMAJob) | The requested job. |

