---
uid: Connector_help_Alcatel_SR_Manager
---

# Alcatel SR Manager

The **Alcatel-Lucent 7750 Service Router** is an industry-leading multi-service edge router designed for the concurrent delivery of advanced residential, business, and mobile services on a common IP edge platform.

This connector can be used to control and monitor the services via **SNMPv2**. The connector has a secondary SNMPv2 connection to provide **device redundancy**.

## About

### Version Info

| **Range** | **Description** | **Based on** | **System Impact** |
|--|--|--|--|
| 1.0.0.x | Initial version. | \- | \- |
| 2.0.0.x | Specific branch version with DCF support. | \- | \- |
| 2.0.1.x | Specific branch version with display key changes. | \- | \- |
| 2.0.2.x | Branch with Provision mode in interface filtering. Needs InterApp to work. **Minimum DataMiner version raised to 9.6.3.0 - 8092.** | 2.0.1.5 | \- |
| 2.0.3.x | Improvements in accounting files - support for legacy devices (firmware versions 6.0.R8 - 11.0.R15) and implementation of SAP files. Improvements in bitrate calculation. Creation of new foreign keys. Creation of display key selectors for multiple tables. | 2.0.2.3 | \- |
| 2.0.4.x (obsolete) | Improved Accounting Files logic and removed the Statistics Tables. Removed Interface Filtering. Changed multiple tables to use multipleGetBulk instead of SNMP Get method to improve performance. Added SAP Base and SAP Ingress/Egress Filtering. Added toggle button for TMNX Event and Event App tables. Changed the InterApp Message to filter interfaces. Data structure now supports JSON that can contain filtering for multiple tables. Column IDX change because of new column in tables 4100, 7300, 7400, 7450, 10100 and 10200 because of table filtering. Fixed DCF exposed table from 4400 to 4100. Added a parameter to change the default timeout of FTP connection. Support for SDP Accounting Files. Changed parameter 3404 and 3405 from Mb to Octet. Added toggle buttons for tables 7200, 10100 and 10200. Added cleanup feature for SAP ingress and egress tables. | 2.0.3.2 | \- |
| 2.0.5.x (obsolete) | Improved bitrate calculation feature. | 2.0.4.3 | You will need to add *renci.sshnet.dll* to the folder *C:/Skyline DataMiner/Protocol Scripts*. |
| 2.0.6.x (obsolete) | Added new columns to SAP Ingress QoS Queue Table. | 2.0.5.8 | \- |
| 2.0.7.x \[SLC Main\] | Fixed case where Legacy General Statistics were poorly calculated. Implemented a fix for the 7210 SAS-X and SAS-R models when using SAP filtering. Updated bitrate calculation logic to handle cases where the element goes into timeout. Support for extra columns in BGP Tables. Added support for alternate accounting file source (VSFTP). Added table vRtrPimNgGrpSrcTable. Added TMNX tables. Added option to switch between Static Router and INET Static Router Data. SAP filter entries were not cleared when inter-app message had no interfaces. Polling Configuration table included. Fixed Polling Configuration table operation mode. Changed default SFTP connection timeout to avoid cases where the logic could be stuck. Fixed situation where SAP and SDP accounting file processing did not calculate rates. Updated Accounting File processing to reduce load on SLDataGateway. The polling of the tables in the TMNX debug page is disabled when the page is not visible. Added calculated time since last change columns to the interface, SAP Base, SDP Base, SDP Info, Service Base Info, and TMNX Ports tables. Bit rates are no longer set to 0 during the first polling cycle after startup. Included VPRN ID and Vrtr Name as a parameter in BGP Tables 10700 and 10900. Fixed situation where interface rates go to zero before going to N/A if the element goes into timeout but interface data is polled before. Added toggle button to enable timeout handling outside of standard procedure. Fixed issue with polling control logic. Default polling is now disabled for TMX VDO GRP tables. Fix calculation for Port Last Change parameters. Fixed a memory leak related to XmsSerializer usage. Fixed an exception with DateTime parsing. Fixed an exception in Stream Viewer with PortQueuesSumTable. Fixed an issue where polling table logic was stuck behind other groups, causing the table to be polled significantly slower then intended. Fixed an issue where rates were halved in the interface table. TMNX Debug tables are now disabled on startup if the collective toggle button (23010) is disabled. Polling for TMNS VDO GRP tables is now by default disabled because they can cause some devices to break temporarily. Added encryption key group tables. Exception value (N/A) is now shown when counters wrap for accounting files, because of edge cases that would be difficult to predict otherwise (device restart, counters reset, etc.). Interface Table Polling Interval and Polling Interval Overrun parameters added. Multiplied exception values to avoid issues with trending exception values with decimals. | 2.0.6.8 | \- |

## Configuration

### Connections

#### Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, for instance *192.168.0.1*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

#### SNMP Redundancy Connection

This connector uses a redundant Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, for instance: *192.168.0.1*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage - Range 1.0.0.x and 2.0.0.x

### General

This page displays general system information (e.g. System Up Time, System CPU Usage, System Memory Available, etc.).

The following subpages are available:

- General FAN: Contains the TMNX Chassis Fan table, which displays information about the fan trays.
- General Hardware: Contains the TMNX Hardware table, which has an entry for each managed hardware component in the Alcatel-Lucent SROS series system's chassis.
- General PSU: Contains the TMNX Chassis Power Supply table, which displays information about power supply trays, also known as PEMs (Power Entry Modules).

### Service

This page displays an overview of the service information.

### Ports

This page displays a table overview of the TMNX ports on each IOM card in each chassis in the TMNX system.

The following subpage is available:

- Port Statistics: Overview of the Alcatel-Lucent SROS series network port ingress statistics.

### SAP

This page displays a table overview with basic SAP information.

The following subpage is available:

- SAP Counters: Overview of the basic SAP statistics.

### SDP

This page displays a table with basic SDP information.

The following subpages are available:

- SDP Counters: Overview of the basic SDP statistics.
- SDP Bindings: Overview of the SDP bindings with their respective services.

### SVC-SAP/SDP

This page displays an overview of the internal linking.

### Static Route

This page displays two tables with static route information.

There is also a Poll Static Route Only toggle button. Set this button to Enabled to only poll the information related to these two tables.

### Virtual Interfaces

This page displays an overview of the DCF interfaces.

## Usage - range 2.0.1.x and 2.0.2.x

From version **2.0.1.2** onwards, the layout of the data pages has changed to accommodate new tables.

### General

This page is similar to the General page in previous ranges but shows additional general information (e.g. System Software Version, System Memory Used, etc.).

It also allows you to save the SSI config.

### Ports

This page is similar to the Ports page in previous ranges, but has the following new subpages:

- **Port Raw Statistics**: Overview of the port net ingress/egress statistics.
- **Port Ethernet**: Overview of the Ethernet ports.

### SAP

This page displays basic SAP information.

The following subpages are available:

- **SAP Counters**: Overview of the basic SAP statistics.
- **SAP Policies**: Overview of the SAP ingress policies.
- **SAP FC**: Overview of the SAP forwarding classes traffic.
- **SAP Queue**: Overview of the SAP ingress/egress queues.
- **SAP QOS Ing**: Overview of the SAP QOS ingress statistics.
- **SAP QOS Egr**: Overview of the SAP QOS egress statistics.

### SDP

This page is the same as in previous ranges.

### Virtual Router

This page displays the **virtual router interfaces** and statistics.

### Digital Diag

This page displays an overview of the **SFF monitoring**.

### Logging

This page displays the logging from the Alcatel.

### Events

This page displays the Alcatel events.

Via a page button, you can access the **Event App** subpage, which displays an overview of the event applications.

### Trap Destination

This page displays an overview of the trap destinations.

### SVC-SAP/SDP

This page is the same as in previous ranges.

### Static Route

This page is the same as in previous ranges.

### EtherLike

This page displays the **Ethernet-Like interfaces**.

### Virtual Interfaces

This page is the same as in previous ranges.

### BGP

This page displays an overview of the BGP instances and statistics.

### Network

The page displays the **Network Queues**.

### OSPF

The page displays an overview of the OSPF interfaces and states.

### RIP

The page displays an overview of the RIP statistics.

### Accounting

This page displays the **SAA and SAP Monitoring** tables from both devices with newer firmware and devices with older (i.e. legacy) firmware. It also shows the **Last Check Date** and **Last Entry Date**, which indicate the last time XML files were requested and the most recent date of the parsed XML files, respectively. The monitoring table uses the data parsed from XML files that fills the statistics table. It groups the tests by name and allows trending.

This page contains the following buttons:

- **Refresh Table**: Forces a refresh of the table using the current settings on the **Table Configuration** page.
- **Get Files:** Tries to get XML files before the next timer.
- **Table Configuration:** Opens a subpage that allows you to define how the SAA Statistics table should be cleaned up, i.e. by number of rows or by entry age, how many rows should be cleaned up each time, and the time window for the first poll.
- **SAA Accounting Files**: Opens a subpage with the statistics tables for the SAA accounting files.
- **SAP Accounting Files**: Opens a subpage with the statistics tables for the SAP accounting files.
- **FTP Configuration:** Opens a subpage where you can define the credentials to access the FTP server as well as the folder where the files should be found. Also contains status information on the connection.
  The URL specified on the FTP Configuration subpage must be the folder containing the XML files to be parsed.
  The XML files must have the following name structure: *act0202-**yyyymmdd-hhmmss**.xml.gz* (SAP) or *act5050-**yyyymmdd-hhmmss**.xml.gz* (SAA).

## Usage - range 2.0.7.x

### General

This page displays general system information (e.g. System Up Time, System CPU Usage, System Memory Available, etc.).

The following subpages are available:

- **General FAN**: Contains the **TMNX Chassis Fan** table, which displays information about the fan trays.
- **General Hardware**: Contains the **TMNX Hardware** table, which has an entry for each managed hardware component in the Alcatel-Lucent SROS series system's chassis.
- **General PSU**: Contains the **TMNX Chassis Power Supply** table, which displays information about power supply trays, also known as **PEMs** (Power Entry Modules).

### Polling Configuration

This page displays the configuration options for the polling operation of the connector.

- **Handle SNMP Rates on Timeout**: Allows you to configure the rate calculation behavior for when the element is in timeout.
- **Interface Polling Interval (and overrun)**: Allows you to monitor the polling performance of the connector. Trending and alarm monitoring can be enabled for this.
- **Polling Configuration**: You can configure the individual table polling times, for example to meet operational requirements or optimize connector or network performance.

### Interfaces

This page displays the available interfaces. To improve polling performance, GetBulk retrieval has been implemented here instead of filtering.

### Service

This page displays an overview of the service information.

### Ports

This page displays a table overview of the **TMNX ports** on each **IOM** card in each **chassis** in the TMNX system.

The following subpages are available:

- **Port Statistics:** Overview of the Alcatel-Lucent SROS series network port egress and ingress statistics.
- **Statistics:** The sum of queues for each port.
- **Ethernet:** Maximum egress and ingress rates per Ethernet interface.

### SAP

This page displays a table overview with basic SAP information.

To reduce the SNMP load when polling a lot of SAP interfaces, a filtered selection can be polled. Filters can be applied manually or via provisioning (InterApp).

To reduce the polling load further, instead of using hidden tables, the filtered SAP Base Info table is used to generate the indexes for the subtable filtering performed on the SAP Egress and Ingress tables.

The following subpages are available:

- **Stats Egress:** Contains the SAP QoS queue egress statistics subtable, which retrieves QoS queues from SAPs currently populated in SAP Base Info.
- **Stats Ingress:** Contains the SAP QoS queue ingress statistics subtable, which retrieves QoS queues from SAPs currently populated **in** **SAP Base Info**.
- **Queues**: Contains SAP ingress and egress policies queue information.
- **SAP Counters**: Provides an overview of the basic SAP statistics.
- **Forwarding Classes**: Contains mapping of forward class traffic into specified queues.
- **Policies**: Displays SAP ingress policies.

### SDP

This page displays a table with basic SDP information.

The following subpages are available:

- **SDP Counters:** Overview of the basic SDP statistics.
- **SDP Bindings:** Overview of the SDP bindings with their respective services.

### Virtual Router

This page displays virtual router statistics.

The following subpages are available:

- **Addresses**: Contains the virtual router to IP address mapping.
- **Configuration**: Contains virtual router configuration options.

### Digial Diag

This page can be used for SFF monitoring.

### Logging

This page contains log identification and filter parameters.

### Events

This page contains TiMOS events that can be generated.

The following subpages are available:

- **Applications**: Displays applications that can create TiMOS events.

### Trap Destination

This page contains SNMP trap configuration options.

### SVC-SAP/SDP

This page displays an overview of the internal linking.

### Static Route

This page displays two tables with static route information.

There is also a **Poll Static Route Only** toggle button. Set this button to *Enabled* to only poll the information related to these two tables.

### EtherLike

This page contains statistics for a collection of Ethernet-like interfaces attached to a particular system.

### TMNX VDO GRP

This page displays video group statistics.

This page also has a **Debug Tables** toggle button, which is disabled by default. If you enable this, the **TMNX Debug Tables** page becomes available.

### TMNX Debug Tables

This page displays various TMNX debug tables including **TMNX VDO Interface**, **TMNX Chassis**, and **TMNX Card.**

This page is only available when the toggle button **Debug Tables** (on the TMNX VDO GRP page) is set to *Enabled***.**

### Virtual Interfaces

This page displays an overview of the DCF interfaces.

### BGP

This page displays BGP-related statistics.

### Network

This page displays network queue mapping and configuration information.

### OSPF

This page displays OSPF-related statistics.

### RIP

This page displays RIP-related statistics.

### Encryption

This page displays NGE key group bindings and statistics.

### Accounting Files

Accounting files contain SAA, SAP, and SDP statistics for a 5-minute interval. Accounting files are retrieved every 2.5 minutes.

This page displays the **SAA, SAP, and SDP Monitoring** tables from both devices with newer firmware and devices with older (i.e. legacy) firmware (72xx). It also shows the **Last Check Date** and **Last Entry Date**, which indicate the last time XML files were requested and the most recent date of the parsed XML files, respectively. The monitoring table uses the data parsed from XML files that fills the statistics table. It groups the tests by name and allows trending.

This page contains the following buttons:

- **SAP Accounting Files Type:** Defines the SAP Accounting file structure to use. Legacy versions below 11.0

- **Table Start-up Window**: Determines the time interval before the connector should retrieve accounting files after the element is first started up or the accounting file configuration is modified.

- **Retrieve Files:** Attempts to retrieve to get XML files before the next timer.

- **FTP Configuration:** Opens a subpage where you can find the following parameters:

- The credentials to access the FTP server.
  - The folder where the files should be found. The XML files must have the following name structure: *act0202-**yyyymmdd-hhmmss**.xml.gz* (SAP), *act5050-**yyyymmdd-hhmmss**.xml.gz* (SAA), or *act0303-**yyyymmdd-hhmmss**.xml.gz* (SDP).
  - Status information on the connection. The URL specified on the FTP Configuration subpage must be the folder containing the XML files to be parsed.
  - The **LIST Directory Listing Format**, which can be set to *Alcatel SR Manager* or *VSFTP*. **Alcatel SR Manager** mode is for normal interaction with an actual device. **VSFTP** mode is for testing purposes, where accounting files can be acquired from a VSFTP server. The responses from an FTP LIST command are different.

- **Debug Params**: Opens a subpage that displays the current accounting files the connector has in its queue ready to be processed. This can be cleared with the **Clear Buffer** button. **Debug mode** can be enabled or disabled.

- **SAA Accounting Files**: Opens a subpage with the statistics tables for the SAA accounting files.

- **SAP Accounting Files**: Opens a subpage with the statistics tables for the SAP accounting files.

- **Legacy SAP Accounting Files**: Opens a subpage with the statistics tables for the SAP accounting files for the 72XX series of devices.

- **SDP Accounting Files**: Opens a subpage with the statistics tables for the SDP accounting files.

## DataMiner Connectivity Framework

From the **2.0.0.x** range of the Alcatel SR Manager connector onwards, the usage of DCF is supported. This can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed Interface

A single fixed interface named **Network Input** of type **input** is available.

#### Dynamic Interfaces

Virtual dynamic interfaces:

- For each **SAP Split Horizon Group** (for instance *SR Ingest*, *SR Outgest*, etc.), a virtual dynamic interface is created of type **inout**.
- For each SDP entry in the **SDP Info** table, a virtual dynamic interface is created in the **SDP Group** of type **inout.**
- For each entry in the **SDP Ingress Packets and Octets Monitoring** table, a virtual dynamic interface is created in **SDP Accounting** of type **inout**. Connections can be made from either SDP Ingress Packets and Octets Monitoring or SDP Egress Packets and Octets Monitoring, since the SDP bindings of both tables (16000 and 16100) are identical.

Physical dynamic interfaces:

- For each entry in the **TMNX Ports** table, a physical dynamic interface is created of type **inout**.

### Connections

#### Internal Connections

- Connections from the **Network Input** interface to all **SDPs** of which the operating state is up.

- **SDPid** connection property of type **generic** with the value of the **SDP ID**.

- Connections from the **SDP** interfaces to the **Split Horizon Groups** of the same **service** when both the SDP and the service are up.

- **SDPsrv** connection property of type **generic** with the value of the **SDP service**.

- Between all the **SAP Split Horizon Group Interfaces** within one and the same **service**, an internal connection is created with the following property:

- **IsSHG** connection property of type **generic** with the value **False**.

- In case a **TMXN Port** is related to a certain **SAP Split Horizon Group** of a **service** and in case the service, port and SAP are up, an internal connection is created with the following properties:

- **IsSHG** connection property of type **generic** with the value **True** or **False**, depending on whether the SAP Split Horizon Group is a Split Horizon Group.
  - **VLAN** connection property of type **generic** with a value containing the ports **Vlan IDs**.
