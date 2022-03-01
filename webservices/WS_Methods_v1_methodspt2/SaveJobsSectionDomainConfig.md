---
uid: SaveJobsSectionDomainConfig
---

# SaveJobsSectionDomainConfig

Use this method to save the configuration of a job section domain.

Obsolete from DataMiner 10.0.9 onwards. Replaced by UpdateDomainSectionDefinitionConfiguration. See [UpdateDomainSectionDefinitionConfiguration](xref:UpdateDomainSectionDefinitionConfiguration).

## Input

| Item          | Format                           | Description                                                                       |
|---------------|----------------------------------|-----------------------------------------------------------------------------------|
| Connection    | String                           | The connection ID. See [ConnectApp](xref:ConnectApp) .  |
| DomainID      | String                           | The jobs domain ID.                                                               |
| Configuration | Array of DMASection­DomainConfig | See [DMASectionDomainConfig](xref:DMASectionDomainConfig). |

## Output

None.

