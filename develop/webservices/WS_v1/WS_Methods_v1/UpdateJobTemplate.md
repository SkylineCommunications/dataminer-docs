---
uid: UpdateJobTemplate
---

# UpdateJobTemplate

Use this method to update an existing job template.

## Input

| Item       | Format         | Description                                                                          |
|------------|----------------|--------------------------------------------------------------------------------------|
| connection | String         | The connection string. See [ConnectApp](xref:ConnectApp). |
| template   | [DMAJobTemplate](xref:DMAJobTemplate) | The job template configuration. |

## Output

| Item                     | Format | Description                         |
|--------------------------|--------|-------------------------------------|
| UpdateJobTemplateResult | String | The ID of the updated job template. |
