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

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Incorrect modulation value in DS QAM Channel dashboard [ID_37135]

In DS QAM Channel dashboards, it could occur that the modulation type indicated for the node segment was different from the one reported by the CMs. The value options for the Modulation parameter have now been adjusted to prevent this.
