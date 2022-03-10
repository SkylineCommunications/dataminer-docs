---
uid: UpdateJobsDomain
---

# UpdateJobsDomain

Use this method to update a jobs domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| Domain | Array of [DMASectionDefinition](xref:DMASectionDefinition) | The section definitions used by the domain. |

## Output

| Item                    | Format | Description                       |
|-------------------------|--------|-----------------------------------|
| UpdateJobsDomain­Result | String | The ID of the updated job domain. |
