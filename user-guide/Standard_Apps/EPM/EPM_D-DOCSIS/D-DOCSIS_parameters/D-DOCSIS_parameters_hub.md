---
uid: D-DOCSIS_parameters_hub
---

# D-DOCSIS parameters – Hub

## KPIs & KQIs

- **Total CCAP**: Calculated. The number of CCAPs in the level.
- **Total RPD**: Calculated. The number of RPDs monitored by every CCAP in the level.
- **Percent RPD Offline**: Calculated. The percentage of RPDs in the level that are offline.
- **Total CIN Devices**: Calculated. The total number of CIN devices, including Spine (NCS), Core Node (DPA), and Core Leaf (RPA).
- **Percent CIN Devices Offline**: Calculated. The percentage of CIN devices in the level that are offline.
- **Total CM**: Calculated. The total number of CMs in every CCAP in the level.
- **Percent CM Offline**: Calculated. The percentage of CMs that are offline in every CCAP the level.
- **Number Ports Over-Utilized**: Calculated. The total number of ports that are over-utilized in the level.
- **Percent Ports Over-Utilized**: Calculated. The percentage of ports that are over-utilized in the level.
- **Number MTA**: Calculated. The number of Multimedia Terminal Adapters (MTAs) for the level.
- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level.
- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.
- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.
- **Last Updated**: Calculated. The last time an update was completed. This is the last time the EPM workflow was fully completed, which is set when IDs are fully received and sent.
- **Status**: Calculated. The current status of the EPM workflow.

## System parameters

- **Name**: Converted. The fiber node name. This is the node status table index converted to ASCII format.
- **Number CM**: Calculated. The total number of CMs from the node segments in the level.
- **Number CM Offline**: Calculated. The total number of offline CMs from the node segments in the level.
- **DS QAM Utilization**: Calculated. The DS QAM utilization of the fiber node. This is the average of the DS QAM utilization from the node segments of the fiber node.
- **US QAM Utilization**: Calculated. The US QAM utilization of the fiber node. This is the average of the US QAM utilization from the node segments of the fiber node.
- **DS OFDM Utilization**: Calculated. The DS OFDM utilization of the fiber node. This is the average of the DS OFDM utilization from the node segments of the fiber node.
- **US OFDMA Utilization**: Calculated. The US OFDMA utilization of the fiber node. This is the average of the US OFDMA utilization from the node segments of the fiber node.
- **Number RPD**: Calculated. The number of RPDs using the fiber node. This is the sum of the number of node segments associated with the fiber node ID.
- **Cable Interface**: Calculated. The fiber node cable interface name. Calculated by associating the MAC domain with the interface name in the interfaces table.
- **DS Service Group Name**: Calculated. The downstream service group name. Calculated by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **US Service Group Name**: Calculated. The upstream service group name. Calculated by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **Service Template**: Calculated. The fiber node service template. Calculated by associating the fiber node name to the port template information returned from Smart PHY to get the service group name.
- **CCAP Core Name**: Calculated. The name of the CCAP associated with the fiber node, based on the name of the CCAP Core element.
- **Hub**: Calculated. The parent hub of the fiber node.
- **Market**: Calculated. The parent market of the fiber node.
