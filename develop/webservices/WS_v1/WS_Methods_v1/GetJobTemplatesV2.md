---
uid: GetJobTemplatesV2
---

# GetJobTemplatesV2

Use this method to retrieve all the job templates available in a specific domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String | The domain ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobTemplatesV2Result | Array of [DMAJobTemplate](xref:DMAJobTemplate) | The available job templates. |
