---
uid: EPM_6.1.9_I-DOCSIS
---

# EPM 6.1.9 I-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### US QAM Ch Bitrate and DS QAM Ch Bitrate trending added for CCAP connectors [ID_37134]

​The following parameters have been added to the trend template for the CCAP connectors:

- QAM US Channels: US QAM Ch Bitrate
- QAM DS Channels: DS QAM Ch Bitrate

#### New OFDM/OFDMA information available [ID_37202]

In the CISCO CBR-8 CCAP Platform connector, a new *OFDM/OFDMA* page has been added containing parameters related to channels from the device. These channels are also linked to the associated node segments and service groups. When you view either of those entities in the topology, new KPIs are displayed with the total number of OFDM and OFDMA channels and the average utilization. There is also a link to a dashboard displaying all channels associated with the entity.

#### CM overview dashboard for node segment and service group entities [ID_37203]

When you navigate to the node segment or service group entities in the topology visual overview, and you click the *# CM* KPI, a link is now displayed to a dashboard that shows all cable modems associated with the entity.

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Incorrect modulation value in DS QAM Channel dashboard [ID_37135]

In DS QAM Channel dashboards, it could occur that the modulation type indicated for the node segment was different from the one reported by the CMs. The value options for the Modulation parameter have now been adjusted to prevent this.
