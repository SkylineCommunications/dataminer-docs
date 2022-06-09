---
uid: D-DOCSIS_parameters_ccap_core
---

# D-DOCSIS parameters – CCAP Core

This page contains an overview of the CCAP Core parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Number RPD**: Calculated. The total number of Remote PHY Devices (RPDs).

  Calculated by counting the number of RPDs in the RPD Overview table.

  RPD table OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.

- **Percentage RPD Offline**: Calculated. The percentage of RPDs that are in an offline state.

  Status returned by smart PHY: v1/smartphycache/rpd/details/active/1.

- **Number CM**: Calculated. The number of cable modems (CMs).

  Calculated by counting the number of cable modems reported by the CCAP.

  CM table OID: 1.3.6.1.4.1.4491.2.1.20.1.3.

- **Percentage CM Offline**: Calculated. The percentage of CMs that are in an offline state.

  CM status OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6.

- **Redundancy**: Direct value. The current redundancy software state.

  Retrieved using the call "show redundancy".

- **Core Leaf (DPA) X Percentage IF (Links) Over-utilized**: Calculated. The percentage of CCAP core interfaces connected to the specific core Leaf (1, 2, etc.) that are currently over-utilized.

  This metric is obtained from the CCAP Core Relations KPIs table, by looking up the "Source Percentage IF Over-Utilized" for the CCAP in relation to the corresponding core leaf (e.g. Core Leaf 1 = Destination Hop 1).

- **CPU Utilization**: Direct value. The percentage of the CPU that is being utilized.

  OID: 1.3.6.1.4.1.9.2.1.58.0.

- **Memory Utilization**: Calculated. The percentage of processor memory in use.

  Calculated based on the used memory and free memory values.

  - Used Memory: OID 1.3.6.1.4.1.9.9.48.1.1.1.5.
  - Free Memory: OID 1.3.6.1.4.1.9.9.48.1.1.1.6.

- **Temperature**: Direct value. The value of the temperature inlet sensor.

  Retrieved from the Temperature Overview table with the filter \*INLET*.

  MIB OID 1.3.6.1.4.1.9.9.13.1.3.1.3.

- **Last Updated**: Calculated. The last time the element was updated.

  This is the last time the device was fully polled.

- **Status**: Calculated. The current overall operational status of the element.

- **Number MTA**: Calculated. The total number of Multimedia Terminal Adapters (MTAs) for the level.

- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level

- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.

- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.

## System parameters

- **Market**: Direct value. The region where the entity is physically located.

  Retrieved from the custom property *Location Region*.

- **Hub**: Direct value. The name of the physical location (also known as "Site") of the entity.

  Retrieved from the custom property *Location Name*.

- **Name**: Direct value. The DataMiner element name, which should correspond to the CCAP name.

  This is the first part of the sysName (OID: 1.3.6.1.2.1.1.5.0).

- **Uptime**: Direct value. The time since the network management system was last re-initialized.

  OID: 1.3.6.1.2.1.1.3.0.

- **Device Type**: Direct value. The entity type (also known as device type).

  Retrieved from the custom property *Entity Type*.

- **Serial Number**: Direct value. The vendor-specific serial number for the physical entity.

  OID: 1.3.6.1.2.1.47.1.1.1.1.11.

- **Model**: Direct value. The vendor-specific model name identifier associated with this physical component.

  OID: 1.3.6.1.2.1.47.1.1.1.1.13.

- **IP**: Direct value. The CCAP core polling IP.

  This is the IP specified for the first connection of the DataMiner element during element creation.

- **City**: Converted. The city where the entity is physically located.

  sysLocation OID 1.3.6.1.2.1.1.6.0.

- **Site**: Converted. The site where the entity is physically located.

  sysLocation OID 1.3.6.1.2.1.1.6.0.

- **Software Version**: Direct value. The version of software the CCAP is currently using.

  OID: 1.3.6.1.2.1.1.1.0.

- **Configuration Compliance**: Direct value. The configuration compliance status of the entity.

  - HTTP Prod Endpoint `https://api-oss.ccm.cox.net/v1/hpna/soap` \> List Device
  - HTTP Dev Endpoint `https://api-dev-oss.services.coxlab.net/v1/hpna/soap` \> List Device.

- **Sensors**: Direct value. The value of the temperature sensors.

  Retrieved from the Temperature Overview table. MIB OID: 1.3.6.1.4.1.9.9.13.1.3.1.3.

- **Interfaces**: Direct value. Information about the CCAP interfaces.

  Links to DPIC Interfaces visual page.

- **ARP**: Direct value. Address Resolution Protocol (ARP) information for the CCAP.

  OID: 1.3.6.1.2.1.3.1.

- **LLDP**: Direct value. Link Layer Discovery Protocol (LLDP) information for the CCAP.

  OID: 1.0.8802.1.1.2.1.4.1.

- **Sessions (L2TP)**: Direct value. Layer 2 Tunneling Protocol (L2TP) information for the CCAP.

  Retrieved using the call "show cable rpd depi".

- **Inventory**: Direct value. Inventory information for the CCAP.

  Retrieved using the call "show inventory".

- **DPIC Cards**: Direct value. Digital Physical Interface Card (DPIC) information for the CCAP.

  OID: 1.3.6.1.2.1.47.1.1.1.1.7.

- **DPIC Interfaces**: Calculated. Digital Physical Interface Card (DPIC) Interfaces information for the CCAP.

  Retrieved by getting the entries from the Interfaces table with a bandwidth greater than or equal to 10 GB.

- **Fiber Nodes**: Direct value. Fiber node information for the CCAP.

  Retrieved from the Node Status Table. OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

## Data layer parameters

- **Function**: Direct value. The function of the entity within the CIN topology (CCAP Core, Spine, Node Leaf, etc.).

  Retrieved from the custom property *IDP - CIN FUNCTION*, which is set when the element is created.

- **DPIC Interface**: The Digital Physical Interfaces, including the CIN-facing interfaces.
