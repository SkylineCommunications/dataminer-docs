---
uid: GetJobTemplateV2
---

# GetJobTemplateV2

Use this method to retrieve a specific job template from a domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| TemplateID | String | The ID of the job template.                          |
| DomainID   | String | The domain ID.                                       |

## Output

| Item                    | Format                                                       | Description                 |
|-------------------------|--------------------------------------------------------------|-----------------------------|
| GetJobTemplateV2­Result | [DMAJobTemplate](xref:DMAJobTemplate) | The requested job template. |

