---
uid: UpdateDomainSectionDefinitionConfiguration
---

# UpdateDomainSectionDefinitionConfiguration

Use this method to update all client info of section definitions in a domain.

<!-- Replaces [SaveJobsSectionDomainConfig](xref:SaveJobsSectionDomainConfig) from DataMiner 10.0.9 onwards. -->

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The jobs domain ID. |
| configuration | Array of [DMASectionDomainConfig](xref:DMASectionDomainConfig) | The job section domain configuration. |

## Output

None.
