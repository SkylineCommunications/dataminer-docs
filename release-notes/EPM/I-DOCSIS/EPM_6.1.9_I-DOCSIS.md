---
uid: EPM_6.1.9_I-DOCSIS
---

# EPM 6.1.9 I-DOCSIS

## New features

#### US QAM Ch Bitrate and DS QAM Ch Bitrate trending added for CCAP connectors [ID_37134]

​The following parameters have been added to the trend template for the CCAP connectors:

- QAM US Channels: US QAM Ch Bitrate
- QAM DS Channels: DS QAM Ch Bitrate

#### New OFDM/OFDMA information available [ID_37202]

In the CISCO CBR-8 CCAP Platform connector, a new *OFDM/OFDMA* page has been added containing parameters related to OFDM/OFDMA channels from the device. Currently this information is only available at node segment level. These channels are also linked to the associated node segments and service groups. When you view either of those entities in the topology, new KPIs are displayed with the total number of OFDM and OFDMA channels and the average utilization. There is also a link to a dashboard displaying all channels associated with the entity.

#### CM overview dashboard for node segment and service group entities [ID_37203]

When you navigate to the node segment or service group entities in the topology visual overview, and you click the *# CM* KPI, a link is now displayed to a dashboard that shows all cable modems associated with the entity.

#### New DOCSIS 1.x counter parameter on all levels [ID_37204]

On all levels of the topology, a new DOCSIS 1.x counter parameter has been added, similar to the existing DOCSIS 3.0 and DOCSIS 3.1 counter parameters.

#### Creating new CCAP/CM pairs from a CSV file [ID_37262]

It is now possible to create CCAP/CM pairs based on a CSV file.

The existing script *EPM_I_DOCSIS_AddNewCcapCmPair* has been expanded with the possibility to specify the path to a CSV file and then create the CCAP/CM pairs based on that file. The CSV file must have the following structure: *ElementName, Be_DMA, Collector_DMA, Protocol , IpAddress, CommunityString, Network, Market, Hub, SystemUser, SystemPass*.

#### Topology chains can now be hidden [ID_37516]

The Skyline EPM Platform connector has been updated so that administrators can now hide entire topology chains or specific fields such as DOCSIS Market, CM, CCAP Core, etc. To access this feature, as a DataMiner administrator, navigate to the Chain and Fields selection page of the EPM front-end element. There you can toggle the visibility of fields reflected in the topology chain in the sidebar on the left.

## Changes

### Enhancements

#### EPM_I_DOCSIS_AddNewCcapCmPair script updated to allow installation of CCAP and CM collector on different DMAs [ID_37192]

The deployment script that creates the CCAP-CM pair (*EPM_I_DOCSIS_AddNewCcapCmPair*) has been updated so that it is now possible to create the CM collector on a different DMA than the CCAP.

#### ID request batching [ID_37300]

To improve performance of the EPM Solution, ID assignment requests are now handled in batches.

#### KPIs in the topology and in the documentation aligned [ID_37301]

As the KPI values in the EPM I-DOCSIS documentation did not fully align with the KPIs accessible in the topology levels, the following changes have now been made:

- Ping Unreachable KPIs have been integrated in Visual Overview
- The EPM I-DOCSIS documentation has been updated.

#### Skyline EPM Platform data pages adjusted [ID_37418]

To address differences between the data pages of the Skyline EPM Platform and the topology overview, these data pages have now been adjusted. Under *DATA*, you can now find the Network Overview page, while under *BELOW THIS NETWORK*, you will find the Market Overview.

### Fixes

#### Incorrect modulation value in DS QAM Channel dashboard [ID_37135]

In DS QAM Channel dashboards, it could occur that the modulation type indicated for the node segment was different from the one reported by the CMs. The value options for the Modulation parameter have now been adjusted to prevent this.

#### Discrepancy between total number of CMs from CCAP and collector [ID_37299]

In some cases, it could occur that the total number of CMs in the CCAP topology did not match the total number of CMs from the collector. The aggregated values from both sources will now always line up.
