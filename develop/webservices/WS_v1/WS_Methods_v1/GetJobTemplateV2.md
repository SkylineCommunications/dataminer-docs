---
uid: GetJobTemplateV2
---

# GetJobTemplateV2

Use this method to retrieve a specific job template from a domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| templateID | String | The ID of the job template.                          |
| domainID   | String | The domain ID.                                       |

## Output

| Item                    | Format                                                       | Description                 |
|-------------------------|--------------------------------------------------------------|-----------------------------|
| GetJobTemplateV2Result | [DMAJobTemplate](xref:DMAJobTemplate) | The requested job template. |
