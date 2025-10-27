---
uid: GetJobTemplates
---

# GetJobTemplates

Use this method to retrieve all the job templates available in the system. Can only be used in case there is only one job domain. Otherwise, use [GetJobTemplatesV2](xref:GetJobTemplatesV2).

<!-- Available from DataMiner 9.6.6 onwards. -->

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobTemplatesResult | Array of [DMAJobTemplate](xref:DMAJobTemplate) | The available job templates. |
