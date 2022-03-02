---
uid: GetJobsDomain
---

# GetJobsDomain

Use this method to retrieve a job domain. Available from DataMiner 10.0.9 onwards.

## Input

| Item       | Format | Description                                                                             |
|------------|--------|-----------------------------------------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp).                                    |
| DomainID   | String | The job domain ID. If no ID is specified, the first available domain will be retrieved. |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsDomainResult | DMAJobsDomain | The job domain, consisting of an array of DMASectionDefinition. (See [DMASectionDefinition](xref:DMASectionDefinition)) |
