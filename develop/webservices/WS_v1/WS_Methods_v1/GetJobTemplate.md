---
uid: GetJobTemplate
---

# GetJobTemplate

Use this method to retrieve a specific job template. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplateV2](xref:GetJobTemplateV2).

<!-- Available from DataMiner 9.6.6 onwards. -->

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| templateID | String | The ID of the job template.                          |

## Output

| Item                 | Format                                | Description                 |
|----------------------|---------------------------------------|-----------------------------|
| GetJobTemplateResult | [DMAJobTemplate](xref:DMAJobTemplate) | The requested job template. |
