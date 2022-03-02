---
uid: UpdateDomainSectionDefinitionConfiguration
---

# UpdateDomainSectionDefinitionConfiguration

Use this method to update all client info of section definitions in a domain. Replaces SaveJobsSectionDomainConfig from DataMiner 10.0.9 onwards (see [SaveJobsSectionDomainConfig](xref:SaveJobsSectionDomainConfig)).

## Input

| Item          | Format                           | Description                                                                       |
|---------------|----------------------------------|-----------------------------------------------------------------------------------|
| Connection    | String                           | The connection ID. See [ConnectApp](xref:ConnectApp).  |
| DomainID      | String                           | The jobs domain ID.                                                               |
| Configuration | Array of DMASection­DomainConfig | See [DMASectionDomainConfig](xref:DMASectionDomainConfig). |

## Output

None.
