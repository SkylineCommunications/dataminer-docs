---
uid: SaveJobsSectionDomainConfig
---

# SaveJobsSectionDomainConfig

Use this method to save the configuration of a job section domain.

Obsolete from DataMiner 10.0.9 onwards. Replaced by [UpdateDomainSectionDefinitionConfiguration](xref:UpdateDomainSectionDefinitionConfiguration).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The jobs domain ID. |
| configuration | Array of [DMASectionDomainConfig](xref:DMASectionDomainConfig) | The job section domain configuration. |

## Output

None.
