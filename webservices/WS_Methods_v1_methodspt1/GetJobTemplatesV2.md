---
uid: GetJobTemplatesV2
---

# GetJobTemplatesV2

Use this method to retrieve all the job templates available in a specific domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DomainID   | String | The domain ID.                                       |

## Output

| Item                     | Format                                                                                       | Description                  |
|--------------------------|----------------------------------------------------------------------------------------------|------------------------------|
| GetJobTemplatesV2­Result | Array of DMAJobTem­plate (see [DMAJobTemplate](xref:DMAJobTemplate) ) | The available job templates. |

