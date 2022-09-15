---
uid: CreateJobsDomain
---

# CreateJobsDomain

Use this method to create a job domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domain | Array of [DMASectionDefinition](xref:DMASectionDefinition) | The section definitions used by the domain. |

## Output

| Item                    | Format | Description                       |
|-------------------------|--------|-----------------------------------|
| CreateJobsDomainResult | String | The ID of the created job domain. |
