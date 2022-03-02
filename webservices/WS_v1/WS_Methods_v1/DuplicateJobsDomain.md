---
uid: DuplicateJobsDomain
---

# DuplicateJobsDomain

Use this method to duplicate a jobs domain. Available from DataMiner 10.0.10 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| Domain | Array of DMASectionDefinition | The section definitions used by the domain. See [DMASectionDefinition](xref:DMASectionDefinition). |

## Output

| Item                       | Format | Description                   |
|----------------------------|--------|-------------------------------|
| DuplicateJobsDomain­Result | String | The ID of the new job domain. |
