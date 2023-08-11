---
uid: EPM_6.1.8_I-DOCSIS
---

# EPM 6.1.8 I-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Alarm suppression at lower levels via alarm template conditions for Amplifier and Tap level [ID_36780]

To make sure events at lower levels in the topology do not become too numerous, making it difficult to analyze the points of failure, alarm suppression at lower levels has been implemented via alarm template conditions. This will suppress events at Amplifier and Tap level when higher-level events are detected.

The alarm template conditions have been applied on Amplifier and Tap level, and they make use of foreign key relations between the tables. This means that the Skyline EPM Platform DOCSIS connector also had to be modified to assign the Node ID for all amplifiers in the Amplifier table.

#### Alarm suppression at lower levels via alarm template conditions for routes, distributions, and FAT levels [ID_36784]

In order to suppress alarms for routes, distributions, and FAT levels, the alarm template has been modified to include conditions for these levels. The alarm will be suppressed if the following conditions are met:

- The route reports that 100% of its ONTs are offline.
- The route has more than 3 ONTs.

Both of these conditions must be met for the alarm to be suppressed.

The Skyline EPM Platform GPON has been modified to calculate the percentage of ONTs that are offline. This information is used to determine if the alarm should be suppressed.

#### Aggregated KPIs from Node Segment level now also available at higher levels [ID_36939]

Aggregated KPIs that previously only existed at Node Segment level are now also available at all levels up to the Network Topology level. This means that the US QAM RX Power OOS, US QAM TX Power OOS, DS QAM RX Power OOS count, US QAM SNR OOS, and DS QAM SNR OOS count and percentage KPIs are now available at the US/DS Port, US/DS Linecard, CCAP Core, Hub, Market, and Network levels.

#### Maps added at CPE level [ID_36985]

Maps are now also available at the CPE level in the topology. They will show the CPE location, with a pop-up on selection that shows the related taps and amplifiers along with the associated KPIs. The maps have a dropdown menu where you can select *Tap* or *Amplifier* or both. Once a selection has been made, the location of the selected device will be shown on the map.

#### GPON maps integration [ID_36995]

The QUICK topology now allows access to GPON system maps, with the following three levels: Route, Distribution, and FATs.

- At Route level, the map displays subscribers and the split FATs connected to them. Because no latitude and longitude information is available for distribution, this is not shown on this map.
- At Distribution level, the map displays subscribers and associated split FATs.
- At FAT level, the map shows the connected subscribers.

When you click any shape on the map, a pop-up will show device-specific information. For subscriber shapes, it shows the following information:

- ONT Serial
- ONT Slot Name
- ONT Port Name
- OLT Name
- ONT State
- ONT Rx Power State
- ONT Tx Power State

For a split FAT shape, the pop-up shows the following information:

- Total ONT
- ONT Offline
- Percentage ONT Offline

## Changes

### Enhancements

#### EPM front end removed from passive logic workflow [ID_36356]

To improve performance, the EPM front-end element is no longer involved in retrieving the passive data in the system.

#### Improved ID assignment for cable modems [ID_36781]

The *Skyline EPM Platform* front-end element now no longer needs to create unique IDs for all cable modems in the system. This will improve the turnaround for new IDs, and new entities in the system will appear more quickly.

#### QAM Channels and CM Trending dashboards [ID_36782]

After the migration of the QAM Channels and Cable Modem KPIs to dashboards, it was no longer possible to view some trended parameters. These parameters are now available in the QAM Channels and CM Trending dashboards.

#### Number ONT KPI improved [ID_37024]

The logic that calculates the Number ONT KPI at network level has been adjusted to provide a more accurate count of the ONTs in the system.

#### Improved EPM front-end ID request flow [ID_37036]

To improve the EPM front-end ID request flow, so that new entities are available to the user more quickly, the EPM front-end element now no longer has to assign IDs to the GPON CPE devices.

### Fixes

#### Huawei 5688-5800 CCAP Platform: Incorrect Percentage DS and US values [ID_36248]

In the Interface table, it could occur that values above 100% were shown for the utilization percentage. To correct this, a new way to calculate the bitrate has been implemented, which uses the [SLC SDF Bitrate calculations library](xref:ConnectionsSnmpBitRateCalculations).

With this new implementation, the following columns are no longer needed in the Interface Extended Overview and Interfaces tables: InUtilization, OutUtilization, and TotalUtilization. The latter will be renamed to Utilization.

#### Generic DOCSIS CM Collector: Missing CCAP Core ID info in Cable Modem Overview table [ID_36761]

On the Cable Modems page of elements running the connector *Generic DOCSIS CM Collector*, it could occur that some rows in the Cable Modem Overview table incorrectly did not show any information in the CCAP Core ID column.

#### QAM tables not fully populated [ID_37100]

In some cases, it could occur that QAM tables were not fully populated because incorrect values were being processed.

#### 0% memory utilization incorrectly shown for CCAPs in Visual Overview [ID_37119]

In Visual Overview, it could occur that CCAPs incorrectly showed 0% memory utilization.
