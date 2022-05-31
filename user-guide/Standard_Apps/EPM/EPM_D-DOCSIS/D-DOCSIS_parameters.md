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
- **Cable Interface**: Calculated. The fiber node cable interface name. Calculated by associating the MAC domain with the interface name in the interfaces table.
- **DS Service Group Name**: Calculated. The downstream service group name. Calculated by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **US Service Group Name**: Calculated. The upstream service group name. Calculated by associating the fiber node name to the port information returned from Smart PHY to get the service group name.
- **Service Template**: Calculated. The fiber node service template. Calculated by associating the fiber node name to the port template information returned from Smart PHY to get the service group name.
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

### RPD KPIs & KQIs

- **Number CM**: Calculated. The number of cable modems (CMs) the RPD is managing. Calculated by counting the number of CMs connected to the RPD.
- **Percentage CM Offline**: Calculated. The percentage of CMs linked to the RPD that are offline.
- **Percentage CM DS Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with DS partial service channels. Calculated based on the CMs with DS channels in the CM impaired table on the CCAP.
- **Number CM DS Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with DS partial service channels. Calculated by counting the CMs with DS channels in the CM impaired table on the CCAP.
- **Percentage CM US Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels. Calculated based on the CMs with US channels in the CM impaired table on the CCAP.
- **Number CM US Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels. Calculated by counting the CMs with US channels in the CM impaired table on the CCAP.
- **Percentage CM TX LVL OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have the power status OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with Rx power that is OOS.
- **Percentage CWERR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have post-FEC OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with post-FEC that is OOS.
- **Percentage SNR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have signal noise OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with SNR that is OOS.
- **Percentage Time Offset OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have high resolution timing offset OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with high resolution timing offset that is OOS.
- **DS SCQAM Utilization**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD. Calculated based on the DS QAM utilization of channels associated to CMs managed by the RPD.
- **US ATDMA Utilization**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD. Calculated based on the US QAM utilization of channels associated to CMs managed by the RPD.
- **OFDMA Utilization**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD. Calculated based on the US OFDM utilization of channels associated to CMs managed by the RPD.
- **Number L2TPv3 Session in Error**: Calculated. The number of L2TPv3 sessions that are in error. Calculated by counting the number of sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".
- **Percentage L2TPv3 Session in Errortre21q**: Calculated. The percentage of L2TPv3 sessions that are in error. Calculated based on the sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".
- **Destination IF In Utilization**: Calculated. The In (Upstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the RPD up to a CIN device (i.e. Layer 2 Switch). Calculated by mapping the In utilization (calculated using the change in input octets) of the external interface(s) connected to the RPD.
- **Destination IF Out Utilization**: Calculated. The Out (Downstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the CIN device (i.e. Layer 2 Switch) to the RPD interface(s). Calculated by mapping the Out utilization (calculated using the change in output octets) of the external interface(s) connected to the RPD.
- **Number CM OFDM CH 1 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).
- **Number CM OFDM CH 1 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).
- **Number CM OFDM CH 1 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).
- **Number CM OFDM CH 1 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).
- **Percentage CM OFDM CH 1 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).
- **Percentage CM OFDM CH 1 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).
- **Percentage CM OFDM CH 1 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).
- **Percentage CM OFDM CH 1 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).
- **Number CM OFDM CH 2 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).
- **Number CM OFDM CH 2 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).
- **Number CM OFDM CH 2 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).
- **Number CM OFDM CH 2 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).
- **Percentage CM OFDM CH 2 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).
- **Percentage CM OFDM CH 2 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).
- **Percentage CM OFDM CH 2 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).
- **Percentage CM OFDM CH 2 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).
- **Average OFDM CH 1 Utilization**: Calculated. The average channel 1 utilization for the RPD's CMs. Calculated by averaging the utilization (OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.20) for all CH 1 instances reported by the RPD's CMs.
- **Number MTA**: Calculated. The total number of Multimedia Terminal Adapters (MTAs) for the level.
- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level.
- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.
- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.
- **Aux Status**: Calculated. The Aux Core RPD State for the first active auxiliary (non-principle) core. Calculated by retrieving the Aux Core RPD State value (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12, Table: RPD CCAP Cores) for the first active (core mode) auxiliary (non-principal) core and mapping it to the corresponding RPD.
- **\# 3.1 CM**: Calculated. The total number of CMs that are currently running DOCSIS 3.1. Calculated based on the base CLI call "show cable modem docsis device-class".
- **\# CM OFDM**: Calculated. The number of CMs using OFDM. Calculated by counting the number of CMs with OFDM Status equal to Active.
- **Percentage CM OFDM**: Calculated. The percentage of CMs using OFDM. Calculated based on the CMs with OFDM Status equal to Active.
- **Number CM OFDM Partial**: Calculated. The number of CMs using OFDM in a partial state. Calculated by counting the number of CMs actively using OFDM with DS Service Status equal to Partial.
- **Percentage CM OFDM Partial**: Calculated. The percentage of CMs using OFDM in a partial state. Calculated based on the CMs actively using OFDM with DS Service Status equal to Partial.
- **Number CM OFDM Profile Downgrade**: Calculated. The number of CMs that have downgraded to a lower OFDM profile for at least one channel. Calculated by counting the number of CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to Downgrade.
- **Percentage CM OFDM Profile Downgrade**: Calculated. The percentage of CMs that have downgraded to a lower OFDM profile for at least one channel. Calculated based on the CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to Downgrade.
- **Nearcast Video Interface**: Calculated. The Nearcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video Service Group**: Calculated. The Nearcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video Controller**: Calculated. The Nearcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video DEPI**: Calculated. The Nearcast Video DEPI, calculated using the RPD cores interface to the Nearcast interface to retrieve the address.
- **Nearcast Video Controller Profile**: Calculated. The Nearcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Interface**: Calculated. The Broadcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Service Group**: Calculated. The Broadcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Controller**: Calculated. The Broadcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video DEPI**: Calculated. The Broadcast Video DEPI, calculated using the RPD cores interface to the Nearcast interface to retrieve the address.
- **Broadcast Video Controller Profile**: Calculated. The Broadcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **US AVG Post-FEC**: Calculated. The average of the US AVG Post-FEC for all associated CMs.
- **US Number Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels. Calculated based on the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).
- **US Percent Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels. Calculated by counting the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).
- **US AVG Power**: Calculated. The average of the US AVG Power for all associated CMs.
- **US AVG SNR**: Calculated. The average of the US AVG SNR for all associated CMs.
- **Out of Band Interface**: Calculated. The Out of Band Interface, calculated by retrieving the cores using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Number Cores**: Calculated. The number of cores, including remote, associated with the RPD. The value is obtained by counting unique Core MAC associations from the RPD CCAP Cores table (MIB OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12) and the RPD RPM Cores table (Vecima RPM Apigee: rpd/mac-address;rpd/ccap-cores/ccap-core/state).

### RPD system parameters

- **Name**: Direct value. The RPD name. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.
- **Uptime**: Direct value. The RPD uptime. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.1.1.2.
- **Device Type**: Direct value. The RPD type. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.6.
- **Vendor**: Direct value. The RPD vendor. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.
- **Serial Number**: Direct value. The RPD serial number. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.4.
- **Model**: Direct value. The RPD model. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.3.
- **Software Version**: Direct value. The RPD software version. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.8.
- **IP**: Converted. The RPD IPv6 address. Extracted from RPD IP table index (OID 1.3.6.1.4.1.4491.2.1.30.1.3.6.1.1).
- **City**: Direct value. The city of the RPD location. Retrieved from the custom property *Location City*.
- **Site**: Direct value. The site of the RPD location. Retrieved from the custom property *Location Site*.
- **Service Template**: Direct value. The RPD service template. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Status**: Direct value. The RPD status. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Sensors**: Direct value. The RPD Sensors table. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.2.
- **Interfaces**: Direct value. The RPD Interfaces table. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.4.
- **Sessions**: Direct value. The RPD DEPI sessions table. Retrieved using the call "show cable rpd depi".
- **RPD Tunnel Summary**: Direct value. The RPD Sessions Tunnel summary. Retrieved by the RPD Tunnel Summary table from CLI (call: show cable rpd depi).
- **Latitude**: Direct value. The RPD latitude. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Longitude**: Direct value. The RPD longitude. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Remote Cores Connected**: Direct value. The remote cores connected to the RPD. Retrieved from the Vecima Apigee API (call:/rpm/V1/restconf/data/entra/r-phy/rpds?fields=rpd/mac-address;rpd/ccap-cores/ccap-core/state) and Ceeview (call: /rpds/1/details Query: Rpm = ""fields=mac-address;state;ccap-cores/ccap-core/state"", Ceeview = ""glassCore,modelNumber,vendorName,deviceAlias,connectedCores,isConnected,bootTime,bootTimeUTC,uptime,disConnectedAt,connectedAt,glassCoreMAC,rpdEndpoint""").
- **Cores Connected**: Direct value. The cores connected to the RPD. These are the RPD CCAP Core rows from the RPD CCAP Cores table (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4).
- **US Channels**: Direct value. The RPD's upstream channels. Retrieved by filtering the Upstream Channels table (1.3.6.1.4.1.4491.2.1.20.1.4) to the RPD.

### RPD data layer parameters

- **Number CM**: The number of cable modems (CMs).
- **Number CM Offline**: The number of CMs with MAC Status in Offline state.
- **Percentage CM Offline**: The percentage of CMs with MAC Status in Offline state.
- **Number CM DS Partial Service**: The number of CMs with DS Service Status in Partial state.
- **Percentage CM DS Partial Service**: The percentage of CMs with DS Service Status in Partial state.
- **Number CM US Partial Service**: The number of CMs with US Service Status in Partial state.
- **Percentage CM US Partial Service**: The percentage of CMs with US Service Status in Partial state.
- **Number CM US SNR OOS**: The number of CMs with US SNR in OOS state.
- **Percentage CM US SNR OOS**: The percentage of CMs with US SNR in OOS state.
- **Number CM US Time Offset OOS**: The number of CMs with US Time Offset in OOS state.
- **Percentage CM US Time Offset OOS**: The percentage of CMs with US Time Offset in OOS state.
- **Number CM US Power OOS**: The number of CMs with US Power in OOS state.
- **Percentage CM US Power OOS**: The percentage of CMs with US Power in OOS state.
- **Number CM US Post-FEC OOS**: The number of CMs with US Post-FEC in OOS state.
- **Percentage CM US Post-FEC OOS**: The percentage of CMs with US Post-FEC in OOS state.
- **DOCSIS DS QAM Utilization**: The average DOCSIS DS QAM Channels Utilization.
- **DOCSIS US QAM Utilization**: The average DOCSIS US QAM Channels Utilization.
- **DOCSIS DS OFDM Utilization**: The average DOCSIS DS OFDM Channels Utilization.
- **DOCSIS US OFDM Utilization**: The average DOCSIS US OFDM Channels Utilization.
- **L2TP Session Status**: The RPD overall L2TP session status. This value is derived from the RPD DEPI table (CLI). The status *OK* means all associated sessions are in the state *UP*. The status *NOK* means at least one associated session is in a state other than *UP*.
- **Number L2TP Session in Error**: The number of RPD L2TP sessions with a status other than *UP*.
- **Percentage L2TP Session in Error**: The percentage of RPD L2TP sessions with a status other than *UP*.
- **MAC**: The media access control address.
- **Service Template**: The service template associated with the RPD. Retrieved using the call "service-catalog-topology/get-service-template-list", parameter: rpdServiceTemplate ("command not found").
- **Status**: The status of the RPD. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Status.
- **CCAP Core**: The CCAP core associated with the RPD. Retrieved using the call "rpd-pairing/query-rpd-pairing", parameter: CCAP Core.
- **CCAP Core Interface**: The CCAP core interface associated with the RPD. Retrieved using the call "rpd-pairing/query-rpd-pairing", parameter: CCAP Core Interface.
- **Fiber Node ID**: The fiber node ID associated with the RPD. Retrieved using the call "show cable rpd \<rpdmac> md-association"
- **Fiber Node**: The fiber node associated with the RPD. Retrieved using the call "show cable rpd \<rpdmac> md-association"
- **Cable Interface**: The CCAP core cable interface serving the RPD. Retrieved using the call "show cable rpd \<rpdmac> md-association"
- **DS Data Service Group**: The downstream data service group. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Downstream Data Service Group.
- **DS Data Controller**: The downstream data controller. Retrieved using the call "show cable rpd \<rpdmac> md-association".
- **DS Data DEPI**: The downstream external PHY interface. Retrieved using the call "show cable rpd depi".
- **US Data Service Group**: The upstream data service group. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Upstream Data Service Group.
- **US Data Controller**: The upstream data controller. Retrieved using the call "show cable rpd \<rpdmac> md-association".
- **NC Video Interface**: The narrowcast video interface. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Narrowcast Video Interface.
- **NC Video Service Group**: The narrowcast video service group. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Narrowcast Video Service Group.
- **NC Video Controller**: The narrowcast video controller. Retrieved by matching the interface profile using the CLI property, parameter: Narrowcast Video Profile.
- **NC Video DEPI**: The narrowcast video downstream external PHY interface. Retrieved using the call "show cable rpd depi".
- **NC Video Controller Profile**: The narrowcast video controller profile ID. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: NCV Controller Profile.
- **BC Video Interface**: The broadcast video interface. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Broadcast Video Interface.
- **BC Video Service Group**: The broadcast video service group. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Broadcast Video Service Group.
- **BC Video Controller**: The broadcast video controller. Retrieved by matching the interface profile using the CLI property, parameter: Narrowcast Video Profile.
- **BC Video DEPI**: The broadcast video downstream external PHY interface. Retrieved using the call "show cable rpd depi".
- **BC Video Controller Profile**: The broadcast video controller profile ID. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: BCV Controller Profile.
- **OOB Video Interface**: The out-of-band video interface. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Out Of Band Interface.
- **Additional Cores**: The IPv6 of the additional core interfaces. Retrieved using the call "rpd-pairing/query-rpd-name-pairing", parameter: Additional Cores.
- **Latitude**: The RPD location latitude. Retrieved using the call "show Rpd Location".
- **Longitude**: The RPD location longitude. Retrieved using the call "show Rpd Location".
- **Market**: The market associated with the RPD CCAP core. Retrieved using the call "virtual element from summarytable".
- **Hub**: The hub associated with the RPD CCAP core. Retrieved using the call "virtual element from summarytable".
- **RPD Relations**: Table displaying all known CIN relations from the perspective of the RPD. The source in the table will list all known RPDs, and the destinations all connections/relations within the CIN. The relations are learned via LLDP or similar protocol.
- **Destination Hop**: Incremental counter of the known relations from the given source to destinations of the same function. Note that multiple connections (interfaces) between a source and a destination are counted as a single hop as the hop count is only affected by the existence of at least one connection between the source and the given destination. For example, if a source is known to be connected to 2 destinations with function "Node Leaf", then there will be 2 incremental hops for the source.

## CM

### CM KPIs & KQIs

- **MAC State**: Direct value. The state of the cable modem as reported by the media access layer. Retrieved using the call "show cable modem docsis device-class".
- **US Time Offset Status**: Calculated. The CM US time offset status based on the existence of offending upstream channels. This is calculated if any channels in the cable modem have a high resolution timing offset that is out of spec.
- **Primary SID**: Direct value. The primary service identifier (SID) of the cable modem. Retrieved using the call "show cable modem docsis device-class".
- **Reg Priv**: Direct value. Indicates whether Baseline Privacy Interface (BPI) or BPI Plus (BPI+) encryption is enabled for the CM. Retrieved using the call "show cable modem docsis device-class".
- **Device Class**: Direct value. Displays the device class information for the PacketCable device (using the call "show cable modem docsis device-class"). The modem can report its device class type during registration. Some of the possible values are:

  - CM or eCM: A standalone cable modem or embedded CM.
  - ePS: Embedded portal services.
  - eMTA: Embedded multimedia terminal adapter.
  - eSTB: Embedded set-top box.
  - unavailable: The CM has not reported its device class.

### CM system parameters

- **Manufacturer**: Calculated. The CM manufacturer. Calculated based on the OUI data from the CM MAC address.
- **Fiber Node System ID**: Calculated. The fiber node system ID. Calculated by linking the MAC domain of the CM to the fiber node.
- **Interface**: Direct value. The cable interface linked to the DS/US controllers serving the CM. Retrieved using the call "show cable modem docsis device-class".
- **OFDM Status**: Calculated. The operational status of the OFDM function according to support and availability:

  - Active: The CM supports OFDM (""Reg Version"" greater or equal to 3.1) and at least 1 profile is assigned to it (""based on OFDM Profile ID List"").
  - Inactive: The CM supports OFDM, but there is no profile assigned to it.
  - Not Supported: The CM does not support OFDM (""Reg Version"" less than 3.1).

- **OFDM CH 1 IF**: Calculated. The name of the OFDM channel 1 interface. Calculated using the CM 3.1 registration DS profile ID list, by converting the first four hex bytes to decimal, and matching them with the index of the interfaces table to get the name.
- **OFDM CH 2 IF**: Calculated. The name of the OFDM channel 2 interface. Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal, and matching them with the index of the interfaces table to get the name.
- **DS Service Group**: Calculated based on the call "v1/smartphycache/rpd/details/active/1".
- **US Service Group**: Calculated based on the call "v1/smartphycache/rpd/details/active/1".
- **OFDM CH 1**: Calculated. The ID of OFDM channel 1. Calculated using the CM 3.1 registration DS profile ID list, by converting the first four parts to decimal, and matching them with the OFDM DS Channels table to find the channel index.
- **OFDM CH 1 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible status values:

  - OK: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - Downgraded: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 1 Profiles**: Calculated. The list of channel 1 profiles. Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.
- **OFDM CH 1 Current Profile**: Direct value. The current channel 1 profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 1 Downgrade Profile**: Direct value. The current channel 1 downgrade profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 1 Preferred Profile**: Direct value. The current channel 1 preferred profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2**: Calculated. The ID of OFDM channel 2. Calculated using the CM 3.1 registration DS profile ID list, by converting the second four parts (after the first channel profiles) to decimal, and matching them with the OFDM DS Channels table to find the channel index.
- **OFDM CH 2 Profile Status**: Calculated. The operational status of the CM from the perspective of the chanel profile quality. Profiles below the recommended one represent a degradation of the service. Possible status values:

  - OK: The CM has remained on the same profile between the last and the current polling cycle for the given channel.
  - Downgraded: The CM has changed its profile to a lower one. A lower profile is determined by its numerical decrease from the preferred profile for the given channel.

- **OFDM CH 2 Profiles**: Calculated. The list of channel 2 profiles. Calculated using the CM 3.1 registration DS profile ID list, by converting the fifth hex to decimal (x). The next x hex bytes represent the list of profiles.
- **OFDM CH 2 Current Profile**: Direct value. The current channel 2 profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2 Downgrade Profile**: Direct value. The current channel 2 downgrade profile. Retrieved using the call "show cable modem phy ofdm".
- **OFDM CH 2 Preferred Profile**: Direct value. The current channel 2 preferred profile. Retrieved using the call "show cable modem phy ofdm".
- **MAC**: The media access control address of the CM. If the CM has multiple MAC addresses, this is the MAC address associated with the MAC Domain interface. MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.
- **US Power Status**: The CM US power status, based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US power threshold. Users can set a threshold, which will be used to determine the US Power Status. *OK* means the US power is at or below the threshold. *OOS* means the US power is above the threshold.
- **US AVG Power**: The averaged power of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).
- **US Post-FEC Status**: The CM US Post-FEC status based on the existence of at least one associated upstream channel (CM Upstream Channels SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2) that is above the US Post-FEC threshold. Users can set a threshold, which will be used to determine the US Post-FEC Status. *OK* means the US Post-FEC is at or below the threshold. *OOS* means the US Post-FEC is above the threshold.
- **US AVG Post-FEC**: The averaged Post-FEC of all US channels associated with the CM as reported on the CM upstream channels (SNMP MIB: 1.3.6.1.4.1.4491.2.1.20.1.4.1.2).

## DPIC

- **Name**: Direct value. The name of the interface. Retrieved by mapping the physical interface name to the primary key of the module table.
- **Description**: Direct value. The description of the device. Retrieved by mapping the physical interface description to the primary key of the module table.
- **Admin Status**: Direct value. The admin status of the module. OID 1.3.6.1.4.1.9.9.117.1.2.1.1.1.
- **Operational Status**: Direct value. The operational status of the module. OID 1.3.6.1.4.1.9.9.117.1.2.1.1.2.
- **Reset Reason**: Direct value. The reason for the last reset. OID 1.3.6.1.4.1.9.9.117.1.2.1.1.3.
- **Status Last Change Time**: Direct value. The value of sysUpTime at the time the status is changed. MIB OID 1.3.6.1.4.1.9.9.117.1.2.1.1.4.
- **Up Time**: Direct value. The uptime of the module since it was last re-initialized. MIB OID 1.3.6.1.4.1.9.9.117.1.2.1.1.8.
- **Bandwidth**: Direct value. An estimate of the interface's current bandwidth. MIB OID 1.3.6.1.2.1.31.1.1.1.15.
- **Utilization**: Calculated. The total module bandwidth utilization. Calculated by using the interface (Bitrate/Bandwidth) * 100.

## DPIC Interface

- **Name**: Direct value. The description of the interface. MIB OID 1.3.6.1.2.1.2.2.1.2.
- **Admin Status**: Direct value. The desired state of the interface. MIB OID 1.3.6.1.2.1.2.2.1.7.
- **Operational Status**: Direct value. The current operational state of the interface. MIB OID 1.3.6.1.2.1.2.2.1.8.
- **In Rate**: Calculated. The input bit rate. Calculated using the change in the number of input octets - OID: 1.3.6.1.2.1.2.2.1.10.
- **Out Rate**: Calculated. The output bit rate. Calculated using the change in the number of output octets - OID: 1.3.6.1.2.1.2.2.1.10.
- **Total Error**: Calculated. The total number of errors. Calculated by adding up the In Errors and Out Errors for the given polling cycle.

## US Controller

- **Name**: Converted. The name of the controller, including associated CCAP. Based on the name from the physical interfaces.
- **System Name**: Direct value. The name of the controller interface. OID 1.3.6.1.2.1.47.1.1.1.1.7.
- **DPIC Interface Name**: Calculated. The DPIC interface name, including associated CCAP. Calculated by getting the interface name using the numbers to match to the interface table depending on the controller name.

## DS Controller

- **Name**: Converted. The name of the controller, including associated CCAP. Based on the name from the physical interfaces.
- **System Name**: Direct value. The name of the controller interface. OID 1.3.6.1.2.1.47.1.1.1.1.7.
- **DPIC Interface Name**: Calculated. The DPIC interface name, including associated CCAP. Calculated by getting the interface name using the numbers to match to the interface table depending on the controller name.

## Fiber Node

### Fiber Node KPIS & KQIs

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

### Fiber Node data layer parameters

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

## Node Segment

### Node Segment KPIs & KQIs

- **Number CM**: Calculated. The number of cable modems (CMs) the RPD is managing. Calculated by counting the number of CMs connected to the RPD.
- **Percentage CM Offline**: Calculated. The percentage of CMs linked to the RPD that are offline.
- **Percentage CM DS Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with DS partial service channels. Calculated based on the CMs with DS channels in the CM impaired table on the CCAP.
- **Number CM DS Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with DS partial service channels. Calculated by counting the CMs with DS channels in the CM impaired table on the CCAP.
- **Percentage CM US Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels. Calculated based on the CMs with US channels in the CM impaired table on the CCAP.
- **Number CM US Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels. Calculated by counting the CMs with US channels in the CM impaired table on the CCAP.
- **Percentage CM TX LVL OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have the power status OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with Rx power that is OOS.
- **Percentage CWERR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have post-FEC OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with post-FEC that is OOS.
- **Percentage SNR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have signal noise OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with SNR that is OOS.
- **Percentage Time Offset OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have high resolution timing offset OOS. Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with high resolution timing offset that is OOS.
- **DS SCQAM Utilization**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD. Calculated based on the DS QAM utilization of channels associated to CMs managed by the RPD.
- **US ATDMA Utilization**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD. Calculated based on the US QAM utilization of channels associated to CMs managed by the RPD.
- **OFDMA Utilization**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD. Calculated based on the US OFDM utilization of channels associated to CMs managed by the RPD.
- **Number L2TPv3 Session in Error**: Calculated. The number of L2TPv3 sessions that are in error. Calculated by counting the number of sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".
- **Percentage L2TPv3 Session in Error**: Calculated. The percentage of L2TPv3 sessions that are in error. Calculated based on the sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".
- **Temperature**: The temperature of the RPD. Calculated by scaling the value from the RPD Sensors table.
- **Destination IF In Utilization**: Calculated. The In (Upstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the RPD up to a CIN device (i.e. Layer 2 Switch). Calculated by mapping the In utilization (calculated using the change in input octets) of the external interface(s) connected to the RPD.
- **Destination IF Out Utilization**: Calculated. The Out (Downstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the CIN device (i.e. Layer 2 Switch) to the RPD interface(s). Calculated by mapping the Out utilization (calculated using the change in output octets) of the external interface(s) connected to the RPD.
- **Number CM OFDM CH 1 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).
- **Number CM OFDM CH 1 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).
- **Number CM OFDM CH 1 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).
- **Number CM OFDM CH 1 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).
- **Percentage CM OFDM CH 1 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).
- **Percentage CM OFDM CH 1 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).
- **Percentage CM OFDM CH 1 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).
- **Percentage CM OFDM CH 1 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).
- **Number CM OFDM CH 2 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).
- **Number CM OFDM CH 2 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).
- **Number CM OFDM CH 2 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).
- **Number CM OFDM CH 2 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).
- **Percentage CM OFDM CH 2 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).
- **Percentage CM OFDM CH 2 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).
- **Percentage CM OFDM CH 2 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).
- **Percentage CM OFDM CH 2 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).
- **Average OFDM CH 1 Utilization**: Calculated. The average channel 1 utilization for the RPD's CMs. Calculated by averaging the utilization (OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.20) for all CH 1 instances reported by the RPD's CMs.
- **Number MTA**: Calculated. The total number of Multimedia Terminal Adapters (MTAs) for the level.
- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level.
- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.
- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.
- **Aux Status**: Calculated. The Aux Core RPD State for the first active auxiliary (non-principle) core. Calculated by retrieving the Aux Core RPD State value (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12, Table: RPD CCAP Cores) for the first active (core mode) auxiliary (non-principal) core and mapping it to the corresponding RPD.
- **\# 3.1 CM**: Calculated. The total number of CMs that are currently running DOCSIS 3.1. Calculated based on the base CLI call "show cable modem docsis device-class".
- **\# CM OFDM**: Calculated. The number of CMs using OFDM. Calculated by counting the number of CMs with OFDM Status equal to Active.
- **Percentage CM OFDM**: Calculated. The percentage of CMs using OFDM. Calculated based on the CMs with OFDM Status equal to Active.
- **Number CM OFDM Partial**: Calculated. The number of CMs using OFDM in a partial state. Calculated by counting the number of CMs actively using OFDM with DS Service Status equal to Partial.
- **Percentage CM OFDM Partial**: Calculated. The percentage of CMs using OFDM in a partial state. Calculated based on the CMs actively using OFDM with DS Service Status equal to Partial.
- **Number CM OFDM Profile Downgrade**: Calculated. The number of CMs that have downgraded to a lower OFDM profile for at least one channel. Calculated by counting the number of CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to Downgrade.
- **Percentage CM OFDM Profile Downgrade**: Calculated. The percentage of CMs that have downgraded to a lower OFDM profile for at least one channel. Calculated based on the CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to Downgrade.
- **Nearcast Video Interface**: Calculated. The Nearcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video Service Group**: Calculated. The Nearcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video Controller**: Calculated. The Nearcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Nearcast Video DEPI**: Calculated. The Nearcast Video DEPI, calculated using the RPD cores interface to the Nearcast interface to retrieve the address.
- **Nearcast Video Controller Profile**: Calculated. The Nearcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Interface**: Calculated. The Broadcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Service Group**: Calculated. The Broadcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video Controller**: Calculated. The Broadcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Broadcast Video DEPI**: Calculated. The Broadcast Video DEPI, calculated using the RPD cores interface to the Nearcast interface to retrieve the address.
- **Broadcast Video Controller Profile**: Calculated. The Broadcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **US AVG Post-FEC**: Calculated. The average of the US AVG Post-FEC for all associated CMs.
- **US Number Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels. Calculated based on the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).
- **US Percent Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels. Calculated by counting the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).
- **US AVG Power**: Calculated. The average of the US AVG Power for all associated CMs.
- **US AVG SNR**: Calculated. The average of the US AVG SNR for all associated CMs.
- **Out of Band Interface**: Calculated. The Out of Band Interface, calculated by retrieving the cores using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.
- **Number Cores**: Calculated. The number of cores, including remote, associated with the RPD. The value is obtained by counting unique Core MAC associations from the RPD CCAP Cores table (MIB OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12) and the RPD RPM Cores table (Vecima RPM Apigee: rpd/mac-address;rpd/ccap-cores/ccap-core/state).

### Node Segment system parameters

- **Name**: Direct value. The RPD name. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.
- **Uptime**: Direct value. The RPD uptime. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.1.1.2.
- **Device Type**: Direct value. The RPD type. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.6.
- **Vendor**: Direct value. The RPD vendor. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.
- **Serial Number**: Direct value. The RPD serial number. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.4.
- **Model**: Direct value. The RPD model. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.3.
- **Software Version**: Direct value. The RPD software version. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.8.
- **IP**: Converted. The RPD IPv6 address. Extracted from RPD IP table index (OID 1.3.6.1.4.1.4491.2.1.30.1.3.6.1.1).
- **City**: Direct value. The city of the RPD location. Retrieved from the custom property *Location City*.
- **Site**: Direct value. The site of the RPD location. Retrieved from the custom property *Location Site*.
- **Service Template**: Direct value. The RPD service template. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Status**: Direct value. The RPD status. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Sensors**: Direct value. The RPD Sensors table. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.2.
- **Interfaces**: Direct value. The RPD Interfaces table. SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.4.
- **Sessions**: Direct value. The RPD DEPI sessions table. Retrieved using the call "show cable rpd depi".
- **RPD Tunnel Summary**: Direct value. The RPD Sessions Tunnel summary. Retrieved by the RPD Tunnel Summary table from CLI (call: show cable rpd depi).
- **Latitude**: Direct value. The RPD latitude. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Longitude**: Direct value. The RPD longitude. Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).
- **Remote Cores Connected**: Direct value. The remote cores connected to the RPD. Retrieved from the Vecima Apigee API (call:/rpm/V1/restconf/data/entra/r-phy/rpds?fields=rpd/mac-address;rpd/ccap-cores/ccap-core/state) and Ceeview (call: /rpds/1/details Query: Rpm = ""fields=mac-address;state;ccap-cores/ccap-core/state"", Ceeview = ""glassCore,modelNumber,vendorName,deviceAlias,connectedCores,isConnected,bootTime,bootTimeUTC,uptime,disConnectedAt,connectedAt,glassCoreMAC,rpdEndpoint""").
- **Cores Connected**: Direct value. The cores connected to the RPD. These are the RPD CCAP Core rows from the RPD CCAP Cores table (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4).
- **US Channels**: Direct value. The RPD's upstream channels. Retrieved by filtering the Upstream Channels table (1.3.6.1.4.1.4491.2.1.20.1.4) to the RPD.
- **MLD**: Information on the Multicast Listener Discovery (MLD) Neighbors. Retrieved using the call "show mld group | no-more".

## Service Group

### Service Group KPIs & KQIs

- **Name**: Direct value. The CCAP core name concatenated with system name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **System ID**: Direct value. Last period-separated value in instance data. MIB OID 1.3.6.1.4.1.4491.2.1.20.1.12.
- **System Name**: Direct value. This is a similar string from the US and DS service group prefixed with the fiber node name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **FN Name**: Converted. The fiber node name. This is the node status table index converted to ASCII format.
- **DS SG Name**: Direct value. The DS service name from the RPD. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **US SG Name**: Direct value. The US service name from the RPD. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **CCAP Name**: Direct value. The name of the CCAP where the service group resides. Retrieved from OID 1.3.6.1.2.1.1.5.

## DS Service Group

### DS Service Group KPIs & KQIs

- **Name**: Direct value. The CCAP core name concatenated with system name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **System ID**: Direct value. Last period-separated value in instance data. MIB OID 1.3.6.1.4.1.4491.2.1.20.1.12.
- **System Name**: Direct value. This is a similar string from the US and DS service group prefixed with the fiber node name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **FN Name**: Converted. The fiber node name. This is the node status table index converted to ASCII format.
- **DS SG Name**: Direct value. The DS service name from the RPD. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **CCAP Name**: Direct value. The name of the CCAP where the service group resides. Retrieved from OID 1.3.6.1.2.1.1.5.

## US Service Group

### US Service Group KPIs & KQIs

- **Name**: Direct value. The CCAP core name concatenated with system name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **System ID**: Direct value. Last period-separated value in instance data. MIB OID 1.3.6.1.4.1.4491.2.1.20.1.12.
- **System Name**: Direct value. This is a similar string from the US and DS service group prefixed with the fiber node name. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **FN Name**: Converted. The fiber node name. This is the node status table index converted to ASCII format.
- **US SG Name**: Direct value. The US service name from the RPD. Retrieved using the call "v1/smartphycache/rpd/details/active/1".
- **CCAP Name**: Direct value. The name of the CCAP where the service group resides. Retrieved from OID 1.3.6.1.2.1.1.5.

## Core Leaf

### Core Leaf KPIs & KQIs

- **Number IF Down**: Calculated. The number of Interfaces that were once known to be up to DataMiner, but which are currently down. Calculated by counting the number of qualifying DCF Interfaces with Operational Status equal to Down.
- **Number IF Over-Utilized**: Calculated. The number of interfaces that are over-utilized according to the Utilization Threshold configuration. Calculated by counting the number of DCF interfaces above the utilization threshold.
- **Number IF with Errors**: Calculated. The number of interfaces with 1 or more errors (In/Out). Calculated by counting the number of DCF interfaces with errors.
- **Number CCAP Unreachable**: Calculated. The number of CCAP cores that are unreachable to the core leaf. The calculation is based on the implicated IF interfaces operational statuses, which can be UP (Unreachable) or Down (Reachable). A CCAP is considered unreachable if there is not at least one pair of interfaces with Operation Status equal to UP allowing for a connection between the core leaf and the CCAP.
- **Redundancy**: Calculated. The redundancy configuration of the entity. Calculated by retrieving the redundancy value (MIB OID: 1.3.6.1.4.1.2636.3.1.14.1.7) of the first entry in the Redundancy table (MIB OID: 1.3.6.1.4.1.2636.3.1.14).
- **CPU Utilization**: Direct value. The CPU utilization percentage of the flexible PIC concentrator. MIB OID 1.3.6.1.4.1.2636.3.1.13.1.8.*.
- **Memory Utilization**: Direct value. The percentage of kernel memory used for this subject. MIB OID 1.3.6.1.4.1.2636.3.1.13.1.11.*.
- **Temperature**: Direct value. The temperature sensors values. Retrieved from the Sensors/Operation Overview table. MIB OID 1.3.6.1.4.1.2636.3.1.13.
- **BGP Status: Calculated**. The global status of the Border Gateway Protocol (BGP) interfaces:

  - Fail: At least one entry in the State column (BGP M2 Peers table) is empty.
  - OK: All entries in the State column (BGP M2 Peers table) are populated.

- **ISIS Neighbors Status**: Calculated. The global status of the Intermediate System-to-Intermediate System Protocol (ISIS) Neighbors interfaces:

  - Fail: At least one entry in the State column (ISIS Neighbors table) has a value other than "Enabled".
  - OK: All entries in the State column (ISIS Neighbors table) are equal to "Enabled".

- **PIM Neighbors Status**: Calculated. The global status of the Protocol-Independent Multicast (PIM) Neighbors interfaces:

  - Fail: No neighbors are found, which means that the PIM Neighbors table will be empty.
  - OK: At least one neighbor is found in the PIM Neighbors table.

- **MLD Status**: Calculated. The global status of the Multicast Listener Discovery (MLD) Neighbors:

  - Fail: No neighbors are found, which means that the MLD Neighbors table will be empty
  - OK: At least one neighbor is found in the MLD Neighbors table.

- **Last Updated**: Calculated. The last time the CLI was updated This is updated to the current time after the CLI finishes polling.
- **Status**: Calculated. Indication of whether the protocol is actively polling the CLI interface. This is updated to the current status of CLI polling.

### Core Leaf system parameters

- **Name**: Direct value. The DataMiner element name. Retrieved from OID 1.3.6.1.2.1.1.5.
- **Hub**: Direct value. The name of the physical location (also known as "Site") of the entity. Retrieved from the custom property *Location Name*.
- **Market**: Direct value. The region where the entity is physically located. Retrieved from the custom property *Location Region*.
- **System Description**: Direct value. The system description of the entity (also known as "Software Description" or "Software Version"). Requires trending for integration with IDP. SNMP MIB: 1.3.6.1.2.1.1.1.0.
- **Uptime**: Direct value. The time since the network management part of the system was last re-initialized. MIB OID: 1.3.6.1.2.1.1.3.0
- **Entity Type**: Direct value. The entity type (also known as device type), retrieved from the associated *ENTITY TYPE* custom property.
- **Serial Number**: Direct value. The entity serial number. MIB OID: 1.3.6.1.4.1.2636.3.1.13.
- **Model**: Direct value. The device model. MIB OID 1.3.6.1.2.1.1.2.0.
- **IP**: Direct value. The IP address of the device. Retrieved from the element configuration.
- **City**: Direct value. The city of the system location. Retrieved from the custom property *Location City*.
- **Site**: Direct value. The site of the system location. Retrieved from the custom property *Location Site*.
- **Last Config Change**: Direct value. The date and time when the configuration was last changed. MIB OID 1.3.6.1.4.1.2636.3.18.1.3.0.
- **Software Version**: Direct value. The system software version. MIB OID 1.3.6.1.2.1.25.6.3.1.2.2.
- **Sensors**: Direct value. The entity sensors information. SNMP OID: 1.3.6.1.4.1.2636.3.1.13.
- **Interfaces**: Direct value. The entity interfaces details. SNMP OID: 1.3.6.1.2.1.2.2.
- **ARP**: Direct value. The entity address resolution protocol (ARP) details. SNMP OID: 1.3.6.1.2.1.4.22.
- **LLDP**: Direct value. The entity Link Layer Discovery Protocol details. SNMP OID: 1.0.8802.1.1.2.1.4.1.
- **Inventory**: Direct value. The entity inventory details. Retrieved using the call "show chassis hardware | no-more".
- **IPv4**: Direct value. The entity IPv4 statistics. SNMP MIB: 1.3.6.1.2.1.4.x.x.
- **IPv6**: Direct value. The entity IPv6 statistics. SNMP MIB: 1.3.6.1.4.1.2636.3.11.1.1.x.x.
- **OPTIC**: Direct value. The entity optics details. Retrieved using the call "show interfaces diagnostics optics | no-more".
- **STATS**: Calculated. The interface statistics. This is a combination of the ifTable (SNMP OID 1.3.6.1.2.1.2.2) and ifXTable (SNMP OID 1.3.6.1.2.1.31.1.1) filtered to bandwidths larger than 10000 Mbps.
- **LLDP**: Direct value. The remote LLDP connections. SNMP OID: 1.0.8802.1.1.2.1.4.1.

### Core Leaf data layer parameters

**Part State**: The current part state. MIB OID 1.3.6.1.4.1.2636.3.1.13.1.6.
**Name**: The interface name. MIB OID 1.3.6.1.2.1.2.2.1.2. Retrieves SNMP data from PID 202.
**Local Interface Description**: The Link Layer Discovery Protocol Interface Description. MIB OID 1.0.8802.1.1.2.1.4.1.1.10. Retrieves SNMP data from PID 33308.
**Remote Interface Description**: The value used to identify the port component associated with the remote system. MIB OID 1.0.8802.1.1.2.1.4.1.1.7.
**Remote System Name**: The value used to identify the system name of the remote system. MIB OID 1.0.8802.1.1.2.1.4.1.1.9.
**Remote System Description**: The system description of the remote system. MIB OID 1.0.8802.1.1.2.1.4.1.1.10.
**Name (IDX)**:The inventory item name (show chassis hardware | no-more).
**Function**: Calculated. The element CIN function as specified in the associated *CIN FUNCTION* property.
**Core Leaf**: Calculated. Table displaying all CIN (Converged Interconnect Network) entities operating as core leaves, which means they should be directly connected to at least one CCAP core. The table displays all CIN entities with Function equal to Core Leaf.
**Core Leaf Relations**: Calculated. Table displaying all known CIN relations from the perspective of the core Leaves. The source in the table will list all known core leaves, and the destinations all connections/relations within the CIN. The relations are learned via LLDP or similar protocol.
**Destination Hop**: Calculated. Incremental counter of the known relations from the given source to destinations of the same function. Note that multiple connections (interfaces) between a source and a destination are counted as a single hop as the hop count is only affected by the existence of at least one connection between the source and the given destination. For example, if a source is known to be connected to 10 destinations with function "CCAP Core", then there will be 10 incremental hops for the source.
**CIN Interface**: Calculated. CIN facing interfaces to be used by EPM towards CIN entities relations and KPI reporting. These are the CIN facing interfaces as provisioned through EPM.
**Source IF Operational Status**: Calculated. The operational status of core leaf interface(s) connected to other CIN entities.
**Destination IF Operational Status**: Calculated. The operational status of external interface(s) connected to the core leaf.
**Utilization Status**: Calculated. The utilization status of the interface (retrieved from the CIN Interface table), which can be *OK* or *Overutilized*. This status is based on the utilization threshold set for each entity type.
**Connection Status**: Calculated. The connection status (OK/Unreachable) according to ping result. The ping is performed against the IP address reported in the CIN Overview table. The frequency of the ping is determined by the virtual interval.
**BGP**: Information on the Border Gateway Protocol (BGP) interfaces. MIB OID: 1.3.6.1.4.1.2636.5.1.1.2.1.1.
**ISIS**: Information on the Intermediate System-to-Intermediate System Protocol (ISIS) Neighbors interfaces. MIB OID: 1.3.6.1.2.1.138.1.6.1.
**PIM**: Information on the Protocol-Independent Multicast (PIM) Neighbors interfaces. Retrieved using the call "show pim neighbors | no-more".

## Spine
