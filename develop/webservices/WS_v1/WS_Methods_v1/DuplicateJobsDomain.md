---
uid: DuplicateJobsDomain
---

# DuplicateJobsDomain

Use this method to duplicate a jobs domain. Available from DataMiner 10.0.10 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domain | Array of [DMASectionDefinition](xref:DMASectionDefinition) | The section definitions used by the domain. |

## Output

| Item                       | Format | Description                   |
|----------------------------|--------|-------------------------------|
| DuplicateJobsDomainResult | String | The ID of the new job domain. |
