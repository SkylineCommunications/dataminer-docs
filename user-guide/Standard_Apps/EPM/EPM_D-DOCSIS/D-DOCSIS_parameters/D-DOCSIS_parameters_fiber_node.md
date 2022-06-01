---
uid: D-DOCSIS_parameters_fiber_node
---

# D-DOCSIS parameters – Fiber Node

## KPIs & KQIs

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

## Data layer parameters

- **Cable Interface**: The cable interface. Retrieved from IFXtable. MIB OID 1.3.6.1.2.1.31.1.1.1.1.
- **Node Name**: The node status name. Retrieved from IFXtable. MIB OID 1.3.6.1.2.1.31.1.1.1.1.
- **Service Group**
- **QAM DS Utilization**: The quadrature amplitude modulation downstream utilization. Calculated based on GetUtilization() method.
- **QAM US Utilization**: The quadrature amplitude modulation upstream utilization. Calculated based on GetUtilization() method.
- **OFDM DS Utilization**: The orthogonal frequency division multiple access downstream utilization. Calculated based on GetUtilization() method.
- **OFDMA US Utilization**: The orthogonal frequency division multiple access upstream utilization. Calculated based on GetUtilization() method.
- **Modem Count**: The number of modems. Calculated based on the CM MAC domain interface.
- **RPD Count**: The number of RPDs. Calculated using a counter based on the unique RPD ID attached to the CM.
- **Offline Modems**: The percentage of modems offline. Calculated based on the number of unregistered modems compared to the modem count.
- **Instance**: Internal ID used to synchronize data to EPM.
- **Name**: Internal name used for EPM.
- **System ID**: The system fiber node ID.
- **System Name**: Unique period-separated data on the fiber node.
- **MAC Domain**: MAC domain information of the fiber node.
- **Cable Interface**: Based on mapping the MAC domain of the fiber node to the InterfaceX.
- **SG System ID**: The service group associated with the fiber node.
- **SG ID**: Internal ID used to synchronize data with EPM.
- **SG Name**: The service group name associated with the fiber node.
- **DS SG System ID**: The DS service group ID associated with the fiber node.
- **DS SG ID**: Internal ID used to synchronize data with EPM.
- **DS SG Name**: The DS service group name associated with the fiber node.
- **US Controller ID**: Internal ID used to synchronize data with EPM.
- **US Controller Name**: The US controller associated with the fiber node.
- **US SG System ID**: The US service group ID associated with the fiber node.
- **US SG ID**: Internal ID used to synchronize data with EPM
- **US SG Name**: The US service group name associated with the fiber node.
- **DS Controller ID**: Internal ID used to synchronize data with EPM
- **DS Controller Name**: The DS controller associated with the fiber node.
