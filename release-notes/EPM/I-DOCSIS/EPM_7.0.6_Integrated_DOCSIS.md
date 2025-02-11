---
uid: EPM_7.0.6_Integrated_DOCSIS
---

# EPM 7.0.6 Integrated DOCSIS

## New features

#### Skyline EPM platform: New Automatic CMTS Removal toggle button [ID 40401]

In the front-end element, you can now enable or disable automatic CMTS removal using a toggle button. This button is available both on the data and visual pages. By default, it is set to disabled for new installations.

#### Skyline EPM Platform DOCSIS: New 'Automatic CMTS Removal' toggle button [ID 40432]

In the back-end elements, you can now enable or disable automatic CMTS removal using a toggle button. This button is available both on the data and visual pages. By default, it is set to disabled for new installations.

## Changes

### Enhancements

#### Integrated DOCSIS dashboards improvements [ID 40334]

The dashboards of the Integrated DOCSIS Solution now no longer include Skyline and DataMiner logos, creating extra space for the other components of the dashboards.

In addition, the extra table on the OFDM Channels (Node Segment) is now no longer included.

#### CISCO CBR-8 CCAP Platform: Additional configuration parameters on visual page [ID 40444]

On the CISCO CBR-8 CCAP Platform visual page, the *Poll OFDM/OFDMA* and *Service Group Naming Convention* configuration parameters have been added.

### Fixes

#### Incorrect PNM column headers in CM US QAM dashboard [ID 40355]

In the EPM_I_DOCSIS_GQI_GET_ALL_CM_US_QAM_DATA dashboard, the column headers incorrectly showed PreNMTER and PostNMTER instead of PreMTTER and PostMTTER. This has been corrected.
