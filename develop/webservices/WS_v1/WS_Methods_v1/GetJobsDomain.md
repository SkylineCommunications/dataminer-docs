---
uid: GetJobsDomain
---

# GetJobsDomain

Use this method to retrieve a job domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
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
