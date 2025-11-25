---
uid: CreateJobsDomain
---

# CreateJobsDomain

Use this method to create a job domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domain     | Array of [DMASectionDefinition](xref:DMASectionDefinition) | The section definitions used by the domain. |

## Output

| Item                   | Format | Description                       |
|------------------------|--------|-----------------------------------|
| CreateJobsDomainResult | String | The ID of the created job domain. |
