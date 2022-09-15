---
uid: UpdateJobsDomain
---

# UpdateJobsDomain

Use this method to update a jobs domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domain | Array of [DMASectionDefinition](xref:DMASectionDefinition) | The section definitions used by the domain. |

## Output

| Item                    | Format | Description                       |
|-------------------------|--------|-----------------------------------|
| UpdateJobsDomainResult | String | The ID of the updated job domain. |
