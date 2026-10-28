---
uid: GetJobsDomain
---

# GetJobsDomain

Use this method to retrieve a job domain.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                                                             |
|------------|--------|-----------------------------------------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp).                                   |
| domainID   | String | The job domain ID. If no ID is specified, the first available domain will be retrieved. |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobsDomainResult | Array of DMASectionDefinition | The job domain, consisting of an array of [DMASectionDefinition](xref:DMASectionDefinition). |
