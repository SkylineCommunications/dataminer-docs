---
uid: UpdateDomainSectionDefinitionConfiguration
---

# UpdateDomainSectionDefinitionConfiguration

Use this method to update all client info of section definitions in a domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The jobs domain ID. |
| configuration | Array of [DMASectionDomainConfig](xref:DMASectionDomainConfig) | The job section domain configuration. |

## Output

None.
