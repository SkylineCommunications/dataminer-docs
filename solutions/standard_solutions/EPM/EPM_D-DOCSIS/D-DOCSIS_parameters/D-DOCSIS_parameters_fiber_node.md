---
uid: D-DOCSIS_parameters_fiber_node
---

# D-DOCSIS parameters – Fiber Node

This page contains an overview of the Fiber Node parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Name**: Converted. The fiber node name.

  This is the Node Status table index converted to ASCII format.

  Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **Number CM**: Calculated. The total number of CMs from the node segments in the level.

  Calculated by aggregating the number of CMs from node segments.

- **Number CM Offline**: Calculated. The total number of offline CMs from the node segments in the level.

  Calculated by aggregating the number of offline CMs from node segments.

- **DS QAM Utilization**: Calculated. The DS QAM utilization of the fiber node.

  Calculated by aggregating the DS QAM utilization of the fiber node from the node segments.

- **US QAM Utilization**: Calculated. The US QAM utilization of the fiber node.

  Calculated by aggregating the US QAM utilization of the fiber node from the node segments.

- **DS OFDM Utilization**: Calculated. The DS OFDM utilization of the fiber node.

  Calculated by aggregating the DS OFDM utilization of the fiber node from the node segments.

- **US OFDMA Utilization**: Calculated. The US OFDMA utilization of the fiber node.

  Calculated by aggregating the US OFDMA utilization of the fiber node from the node segments.

- **Number RPD**: Calculated. The number of RPDs using the fiber node.

  Calculated by aggregating the number of node segments associated with the fiber node ID.

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

## Data layer parameters

- **Cable Interface**: The cable interface.

  Retrieved from IFXtable, MIB OID 1.3.6.1.2.1.31.1.1.1.1.

- **Node Name**: The node status name.

  Retrieved from IFXtable, MIB OID 1.3.6.1.2.1.31.1.1.1.1.

- **Service Group**

- **QAM DS Utilization**: The quadrature amplitude modulation downstream utilization.

  Calculated based on GetUtilization() method.

- **QAM US Utilization**: The quadrature amplitude modulation upstream utilization.

  Calculated based on GetUtilization() method.

- **OFDM DS Utilization**: The orthogonal frequency division multiple access downstream utilization.

  Calculated based on GetUtilization() method.

- **OFDMA US Utilization**: The orthogonal frequency division multiple access upstream utilization.

  Calculated based on GetUtilization() method.

- **Modem Count**: The number of modems.

  Calculated based on the CM MAC domain interface.

- **RPD Count**: The number of RPDs.

  Calculated using a counter based on the unique RPD ID attached to the CM.

- **Offline Modems**: The percentage of modems offline.

  Calculated based on the number of unregistered modems compared to the modem count.

- **Instance**: Internal ID used to synchronize data to EPM.

  Requested from the EPM Manager.

- **Name \[IDX]**: Internal name used for EPM.

  This is the CCAP core concatenated with the system name.

- **System ID**: The system fiber node ID.

  This is a character conversion of the node index period-separated indices 2 with length -1.

- **System Name**: Unique period-separated data on the fiber node.

  MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **MAC Domain**: MAC domain information of the fiber node.

  This is the first period-separated value from the node instance.

- **Cable Interface**: Based on mapping the MAC domain of the fiber node to the InterfaceX.

  MIB OID: 1.3.6.1.2.1.31.1.1.1.1.

- **SG System ID**: The service group associated with the fiber node.

  This is the last period-separated value from the node instance.

- **SG ID**: Internal ID used to synchronize data with EPM.

  Requested from the EPM Manager.

- **SG Name**: The service group name associated with the fiber node.

  Retrieved by finding the similar string from the DS and US service group names.

- **DS SG System ID**: The DS service group ID associated with the fiber node.

  MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.12.1.3.

- **DS SG ID**: Internal ID used to synchronize data with EPM.

  Requested from the EPM Manager.

- **DS SG Name**: The DS service group name associated with the fiber node.

  Retrieved with pattern matching using the fiber node ID, controller, and service group in the CLI property.

- **US Controller ID**: Internal ID used to synchronize data with EPM.

  Requested from the EPM Manager.

- **US Controller Name**: The US controller associated with the fiber node.

  Retrieved using the call "sh run | sec cable fiber-node {ID}".

- **US SG System ID**: The US service group ID associated with the fiber node.

  MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.12.1.3.

- **US SG ID**: Internal ID used to synchronize data with EPM

  Requested from the EPM Manager.

- **US SG Name**: The US service group name associated with the fiber node.

  Retrieved with pattern matching using the fiber node ID, controller, and service group in the CLI property.

- **DS Controller ID**: Internal ID used to synchronize data with EPM

  Requested from the EPM Manager.

- **DS Controller Name**: The DS controller associated with the fiber node.

  Retrieved using the call "sh run | sec cable fiber-node {ID}".
