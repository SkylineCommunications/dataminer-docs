---
uid: D-DOCSIS_parameters_market
---

# D-DOCSIS parameters – Market

This page contains an overview of the Market parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Total CCAP**: Calculated. The total number of CCAPs.

  Sum of the hub statistics from the EPM Hub Overview.

- **Total RPD**: Calculated. The total number of RPDs.

  Sum of the hub statistics from the EPM Hub Overview.

- **Percent RPD Offline**: Calculated. The percentage of RPDs that are offline.

  Sum of the hub statistics from the EPM Hub Overview.

- **Total CIN Devices**: Calculated. The total number of CIN devices.

  Sum of the hub statistics from the EPM Hub Overview.

- **Percent CIN Devices Offline**: Calculated. The percentage of CIN devices that are offline.

  Sum of the hub statistics from the EPM Hub Overview.

- **Total CM**: Calculated. The total number of cable modem devices.

  Sum of the hub statistics from the EPM Hub Overview.

- **Percent CM Offline**: Calculated. The percentage of cable modem devices that are offline.

  Sum of the hub statistics from the EPM Hub Overview.

- **Number Ports Over-Utilized**: Calculated. The total number of ports that are over-utilized.

  Sum of the hub statistics from the EPM Hub Overview.

- **Percent Ports Over-Utilized**: Calculated. The percentage of ports that are over-utilized.

  Sum of the hub statistics from the EPM Hub Overview.

- **Number MTA: Calculated**. The total number of Multimedia Terminal Adapters (MTAs) for the level.

- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level.

- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.

- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level

- **Number CIN Entity**: Calculated. The total number of CIN entities associated with the given market that comply with the function description Core Leaf, Spine, or Node Leaf. The function is found in the specific entity type table (e.g. Spine table).

- **Percentage CIN Entity Offline**: Calculated. The percentage of CIN entities associated with the given market reporting a connection status equal to "Unreachable".

- **Last Updated**: Calculated. The last time an update was completed.

  This is the last time the EPM workflow was fully completed, which is set when IDs are fully received and sent.

- **Status**: Calculated. The current status of the EPM workflow.

## System parameters

- **Name**: Converted. The fiber node name.

  This is the Node Status table index converted to ASCII characters.

  Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **Number CM**: Calculated. The number of CMs in the level.

  This is the sum of the number of CMs from node segments.

- **Number CM Offline**: Calculated. The number of CMs that are offline in the level.

  This is the sum of the number of offline CMs from node segments.

- **DS QAM Utilization**: Calculated. The DS QAM utilization of the fiber node.

  This is the sum of the DS QAM utilization of the fiber node from the node segments.

- **US QAM Utilization**: Calculated. The US QAM utilization of the fiber node.

  This is the sum of the US QAM utilization of the fiber node from the node segments.

- **DS OFDM Utilization**: Calculated. The DS OFDM utilization of the fiber node.

  This is the sum of the DS OFDM utilization of the fiber node from the node segments.

- **US OFDMA Utilization**: Calculated. The US OFDMA utilization of the fiber node.

  This is the sum of the US OFDMA utilization of the fiber node from the node segments.

- **Number RPD**: Calculated. The number of RPDs utilizing the fiber node.

  This is the sum of the number of node segments associated with the fiber node ID.

- **Cable Interface**: Calculated. The fiber node cable interface name.

  Calculated by associating the MAC domain with the interface name in the interfaces table.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - Interface name column OID: 1.3.6.1.2.1.31.1.1.1.1.
  - MAC domain retrieved from the first part of the string in the Node Status table primary key, OID: 1.3.6.1.4.1.4491.2.1.20.1.12.1.1.

- **DS Service Group Name**: Calculated. The downstream service group name.

  Calculated by associating the fiber node name with the port information returned from Smart PHY to get the service group name.

  The fiber node name is converted to ASCII from the Node Status table index. Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

  Smart PHY request: v1/smartphycache/rpd/details/active/1

- **US Service Group Name**: Calculated. The upstream service group name.

  Calculated by associating the fiber node name with the port information returned from Smart PHY to get the service group name.

  The fiber node name is converted to ASCII from the Node Status table index. Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

  Smart PHY request: v1/smartphycache/rpd/details/active/1

- **Service Template**: Calculated. The fiber node service template.

  Calculated by associating the fiber node name with the port template information returned from Smart PHY to get the service group name.

  The fiber node name is converted to ASCII from the Node Status table index. Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

  Smart PHY request: v1/smartphycache/rpd/details/active/1

- **CCAP Core Name**: Calculated. The name of the CCAP associated with the fiber node, based on the name of the CCAP core element.

- **Hub**: Calculated. The parent hub of the fiber node.

- **Market**: Calculated. The parent market of the fiber node.
