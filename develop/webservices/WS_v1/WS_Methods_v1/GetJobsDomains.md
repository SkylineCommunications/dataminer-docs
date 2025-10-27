---
uid: GetJobsDomains
---

# GetJobsDomains

Use this method to retrieve all available job domains.

<!-- Available from DataMiner 10.0.9 onwards. -->

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsDomainsResult | Array of [DMAJobDomainLite](xref:DMAJobDomainLite) | The available job domains. |
