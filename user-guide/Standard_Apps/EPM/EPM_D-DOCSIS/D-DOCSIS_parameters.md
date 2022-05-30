---
uid: D-DOCSIS_parameters
---

# Available parameters in D-DOCSIS

This section lists the available parameters for each topology level in the D-DOCSIS branch of the EPM Solution.

## Network

### Network KPIs & KQIs

- **MAC Address**: Direct value. The media access control address of the cable modem (CM). If the CM has multiple MAC addresses, this is the MAC address associated with the MAC domain interface. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.
- **IPv4 Address**: Converted. The cable modem internet protocol version 4 address. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.
- **Status**: Converted. The operational status of the cable modem. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6.
- **Manufacturer**: Converted. The cable modem manufacturer. Based on the OUI data from the CM MAC address.
- **Operational Mode**: Direct value. The operational registration version. Retrieved using a call to show the cable modem DOCSIS device class.
- **Last Reg Time**: Converted. The last time the CM registered with the CCAP Core. Based on OID 1.3.6.1.4.1.4491.2.1.20.1.3.1.14, converted to datetime format.
- **Last Successful Poll**: Calculated. The last time the CM data flow was completed.
- **Managing RPD**: Direct value. The RPD name. OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.
- **RPD MAC Address**: Converted. The media access control address. Based on the index of the RPD table, converted to a hexadecimal value.
- **RPD Status**: Direct value. The RPD Status. Retrieved from the Smart PHY API using the call "v1/smartphycache/rpd/details/active/1".
- **RPD Vendor**: Direct value. The RPD vendor. OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.
- **Fiber Node**: Calculated. The fiber node name. Calculated by linking the service group ID from the CM to the fiber node.
- **Service Group**: Calculated. The service group name. Calculated using the fiber node name to get the service group.
- **US QAM**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD.
- **DS QAM**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD.
- **US OFDM**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD.
- **DS OFDM**: Calculated. The average percentage of DS OFDM utilization of CMs linked to the RPD.
- **Market**: Calculated. The market containing the CM. This is the market where the parent CCAP is found.
- **Hub**: Calculated. The hub containing the CM. This is the hub where the parent CCAP is found.
- **CCAP**: Calculated. The CCAP managing the CM. This is the name of the parent CCAP element - the first part of the sysName (OID 1.3.6.1.2.1.1.5.0).
- **CCAP Interface**: Direct value. The interface on the CCAP connected to the RPD, as reported by Smart PHY.
- **Core IP**: Calculated. The connected core IP. Retrieved by calculating the principal DOCSIS core IP connected to the RPD and then correlating it to the CM.
- **DPIC Aggregator**: Calculated. The connected DPA.
- **RPD Aggregator**: Calculated. The connected RPA.

## Market

## Hub

### Hub KPIs & KQIs

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

### Hub system parameters

- **Name**: Converted. The fiber node name. This is the node status table index converted to ASCII format.
- **Number CM**: Calculated. The total number of CMs from the node segments in the level.
- **Number CM Offline**: Calculated. The total number of offline CMs from the node segments in the level.
- **DS QAM Utilization**: Calculated. The DS QAM utilization of the fiber node. This is the average of the DS QAM utilization from the node segments of the fiber node.
- **US QAM Utilization**: Calculated. The US QAM utilization of the fiber node. This is the average of the US QAM utilization from the node segments of the fiber node.
- **DS OFDM Utilization**: Calculated. The DS OFDM utilization of the fiber node. This is the average of the DS OFDM utilization from the node segments of the fiber node.
- **US OFDMA Utilization**: Calculated. The US OFDMA utilization of the fiber node. This is the average of the US OFDMA utilization from the node segments of the fiber node.
- **Number RPD**: Calculated. The number of RPDs using the fiber node. This is the sum of the number of node segments associated with the fiber node ID.
- **Cable Interface**: Calculated. The fiber node cable interface name. Retrieved by associating the MAC domain with the interface name in the interfaces table.
- **DS Service Group Name**: Calculated. The downstream service group name. Retrieved by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **US Service Group Name**: Calculated. The upstream service group name. Retrieved by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **Service Template**: Calculated. The fiber node service template. Retrieved by associating the fiber node name to the port template information returned from Smart PHY to get the service group name.
- **CCAP Core Name**: Calculated. The name of the CCAP associated with the fiber node, based on the name of the CCAP Core element.
- **Hub**: Calculated. The parent hub of the fiber node.
- **Market**: Calculated. The parent market of the fiber node.

## CCAP Core

### CCAP Core KPIs & KQIs

- **Number RPD**: Calculated. The total number of Remote PHY Devices (RPDs). Calculated by counting the number of RPDs in the RPD Overview table.
- **Percentage RPD Offline**: Calculated. The percentage of RPDs that are in an offline state.
- **Number CM**: Calculated. The number of cable modems (CMs). Calculated by counting the number of cable modems reported by the CCAP.
- **Percentage CM Offline**: Calculated. The percentage of CMs that are in an offline state.
- **Redundancy**: Direct value. The current redundancy software state. Retrieved using the call "show redundancy".
- **Core Leaf (DPA) X Percentage IF (Links) Over-utilized**: Calculated. The percentage of CCAP core interfaces connected to the specific core Leaf (1, 2, etc.) that are currently over-utilized.
- **CPU Utilization**: Direct value. The percentage of the CPU that is being utilized. OID: 1.3.6.1.4.1.9.2.1.58.0.
- **Memory Utilization**: Calculated. The percentage of processor memory in use. Calculated based on the used memory and free memory values.
- **Temperature**: Direct value. The value of the temperature inlet sensor. Retrieved from the Temperature Overview table OID 1.3.6.1.4.1.9.9.13.1.3.1.3 with the filter \*INLET*.
- **Last Updated**: Calculated. The last time the element was updated. Calculated based on the last time the device was fully polled.
- **Status**: Calculated. The current overall operational status of the element.
- **Number MTA**: Calculated. The total number of Multimedia Terminal Adapters (MTAs) for the level.
- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level
- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.
- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.

### CCAP Core system parameters

- **Market**: Direct value. The region where the entity is physically located. Retrieved from the custom property *Location Region*.
- **Hub**: Direct value. The name of the physical location (also known as "Site") of the entity. Retrieved from the custom property *Location Name*.
- **Name**: Direct value. The DataMiner element name, which should correspond to the CCAP name. This is the first part of the sysName (OID: 1.3.6.1.2.1.1.5.0).
- **Uptime**: Direct value. The time since the network management system was last re-initialized. OID: 1.3.6.1.2.1.1.3.0.
- **Device Type**: Direct value. The entity type (also known as device type). Retrieved from the custom property *Entity Type*.
- **Serial Number**: Direct value. The vendor-specific serial number for the physical entity. OID: 1.3.6.1.2.1.47.1.1.1.1.11.
- **Model**: Direct value. The vendor-specific model name identifier associated with this physical component. OID: 1.3.6.1.2.1.47.1.1.1.1.13.
- **IP**: Direct value. The CCAP core polling IP. This is the IP specified for the first connection of the DataMiner element during element creation.
- **City**: Converted. The city where the entity is physically located. Based on sysLocation OID 1.3.6.1.2.1.1.6.0.
- **Site**: Converted. The site where the entity is physically located. Based on sysLocation OID 1.3.6.1.2.1.1.6.0.
- **Software Version**: Direct value. The version of software the CBR-8 is currently using. OID: 1.3.6.1.2.1.1.1.0.
- **Configuration Compliance**: Direct value. The configuration compliance status of the entity. Retrieved from HTTP Prod Endpoint `https://api-oss.ccm.cox.net/v1/hpna/soap` \> List Device, and HTTP Dev Endpoint `https://api-dev-oss.services.coxlab.net/v1/hpna/soap` \> List Device.
- **Sensors**: Direct value. The value of the temperature sensors. Retrieved from the Temperature Overview table (OID: 1.3.6.1.4.1.9.9.13.1.3.1.3).
- **Interfaces**: Direct value. Information about the CCAP interfaces. Links to DPIC Interfaces visual page.
- **ARP**: Direct value. Address Resolution Protocol (ARP) information for the CCAP. OID: 1.3.6.1.2.1.3.1.
- **LLDP**: Direct value. Link Layer Discovery Protocol (LLDP) information for the CCAP. OID: 1.0.8802.1.1.2.1.4.1.
- **Sessions (L2TP)**: Direct value. Layer 2 Tunneling Protocol (L2TP) information for the CCAP. Retrieved using the call "show cable rpd depi".
- **Inventory**: Direct value. Inventory information for the CCAP. Retrieved using the call "show inventory".
- **DPIC Cards**: Direct value. Digital Physical Interface Card (DPIC) information for the CCAP. OID: 1.3.6.1.2.1.47.1.1.1.1.7.
- **DPIC Interfaces**: Calculated. Digital Physical Interface Card (DPIC) Interfaces information for the CCAP. Based on the Interfaces table, more specifically the entries with a bandwidth greater than or equal to 10 GB.
- **Fiber Nodes**: Direct value. Fiber node information for the CCAP. Retrieved from the Node Status Table (OID: 1.3.6.1.4.1.4491.2.1.20.1.12).

### CCAP Core data layer parameters

- **Function**: Direct value. The function of the entity within the CIN topology (CCAP Core, Spine, Node Leaf, etc.). Retrieved from the custom property *IDP - CIN FUNCTION*, which is set when the element is created.
- **DPIC Interface**: The Digital Physical Interfaces, including the CIN-facing interfaces.

## RPD
