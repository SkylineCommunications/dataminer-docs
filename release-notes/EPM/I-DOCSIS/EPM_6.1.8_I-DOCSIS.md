---
uid: EPM_6.1.8_I-DOCSIS
---

# EPM 6.1.8 I-DOCSIS

## New features

#### Alarm suppression at lower levels via alarm template conditions for Amplifier and Tap level [ID_36780]

To make sure events at lower levels in the topology do not become too numerous, making it difficult to analyze the points of failure, alarm suppression at lower levels has been implemented via alarm template conditions. This will suppress events at Amplifier and Tap level when higher-level events are detected.

The alarm template conditions have been applied on Amplifier and Tap level, and they make use of foreign key relations between the tables. This means that the Skyline EPM Platform DOCSIS connector also had to be modified to assign the Node ID for all amplifiers in the Amplifier table.

#### Aggregated KPIs from Node Segment level now also available at higher levels [ID_36939]

Aggregated KPIs that previously only existed at Node Segment level are now also available at all levels up to the Network Topology level. This means that the US QAM RX Power OOS, US QAM TX Power OOS, DS QAM RX Power OOS count, US QAM SNR OOS, and DS QAM SNR OOS count and percentage KPIs are now available at the US/DS Port, US/DS Linecard, CCAP Core, Hub, Market, and Network levels.

#### Maps added at CPE level [ID_36985]

Maps are now also available at the CPE level in the topology. They will show the CPE location, with a pop-up on selection that shows the related taps and amplifiers along with the associated KPIs. The maps have a dropdown menu where you can select *Tap* or *Amplifier* or both. Once a selection has been made, the location of the selected device will be shown on the map.

## Changes

### Enhancements

#### Improved ID assignment for cable modems [ID_36781]

The *Skyline EPM Platform* front-end element now no longer needs to create unique IDs for all cable modems in the system. This will improve the turnaround for new IDs, and new entities in the system will appear more quickly.

#### QAM Channels and CM Trending dashboards [ID_36782]

After the migration of the QAM Channels and Cable Modem KPIs to dashboards, it was no longer possible to view some trended parameters. These parameters are now available in the QAM Channels and CM Trending dashboards.

### Fixes

#### Generic DOCSIS CM Collector: Missing CCAP Core ID info in Cable Modem Overview table [ID_36761]

On the Cable Modems page of elements running the connector *Generic DOCSIS CM Collector*, it could occur that some rows in the Cable Modem Overview table incorrectly did not show any information in the CCAP Core ID column.

#### 0% memory utilization incorrectly shown for CCAPs in Visual Overview [ID_37119]

In Visual Overview, it could occur that CCAPs incorrectly showed 0% memory utilization.
