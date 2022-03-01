---
uid: CreateJobsDomain
---

# CreateJobsDomain

Use this method to create a job domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format                        | Description                                                                                                               |
|------------|-------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| Connection | String                        | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                      |
| Domain     | Array of DMASectionDefinition | The section definitions used by the domain. See [DMASectionDefinition](xref:DMASectionDefinition). |

## Output

| Item                    | Format | Description                       |
|-------------------------|--------|-----------------------------------|
| CreateJobsDomain­Result | String | The ID of the created job domain. |

