---
uid: EPM_7.0.6_Integrated_DOCSIS
---

# EPM 7.0.6 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Generic KAFKA Consumer: New Certificate Authentication parameter [ID_40342]

On the Brokers/Authentication page of the Generic KAFKA Consumer connector, a new *Certificate Authentication* parameter is now available, which can be used to enable or disable verification for the SSL certificate.

#### New Automatic CMTS Removal toggle button [ID_40401]

In the front-end element, you can now enable or disable automatic CMTS removal using a toggle button. This button is available both on the data and visual pages. By default, it is set to disabled for new installations.

## Changes

### Enhancements

#### Integrated DOCSIS dashboards improvements [ID_40334]

The dashboards of the Integrated DOCSIS Solution now no longer include Skyline and DataMiner logos, creating extra space for the other components of the dashboards.

In addition, the extra table on the OFDM Channels (Node Segment) is now no longer included.

### Fixes

#### Incorrect PNM column headers in CM US QAM dashboard [ID_40355]

In the EPM_I_DOCSIS_GQI_GET_ALL_CM_US_QAM_DATA dashboard, the column headers incorrectly showed PreNMTER and PostNMTER instead of PreMTTER and PostMTTER. This has been corrected.
