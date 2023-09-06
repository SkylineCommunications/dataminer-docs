---
uid: Connector_help_Casa_Systems_C100G
---

# Casa Systems C100G

The **Casa Systems C100G** connector uses **SNMPv2** to monitor and control the Casa Systems C100G. This device is a **CCAP**, which means it combines the functions of a **CMTS** and **edge QAM** into a single platform.

## About

The **Casa Systems C100G** is a chassis that has separate modules for downstream and upstream traffic, switching, etc.

### Version Info

| **Range**            | **Description**                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                                                                   | No                  | Yes                     |
| 2.0.0.x \[Obsolete\] | Changed the "Display Column" into the Measurement Upstream and Downstream tables.                                                                 | No                  | No                      |
| 2.0.1.x              | Display key and namingFormat option in Docs If Signal Quality Table.                                                                              | No                  | No                      |
| 2.1.0.x              | Spectrum analyzer functionality for logical and physical upstream interfaces.                                                                     | No                  | No                      |
| 3.0.0.x \[SLC Main\] | Specific layout focusing on Edge QAM functionalities.                                                                                             | No                  | Yes                     |
| 5.0.0.x              | Specific Lite version, focused on performance. Polling of big tables is filtered and performed by QActions.                                       | No                  | Yes                     |
| 5.0.1.x              | DCF feature added.                                                                                                                                | Yes                 | Yes                     |
| 6.0.0.x              | Custom version developed for Unity Media. Lite version of Casa Systems C100G version 3.0.0.x polling interfaces, QAM streams, and QAM interfaces. | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                                                                        |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 2.1.0.x   | Hardware revision 1.1 Software version 6.5.2                                                                                                                                                                  |
| 3.0.0.x   | Hardware revision 1.8 CFE version 12.4.11 Software release version 7.1.4, Ver 1, build53ba System SSM Firmware: Major rev 1, Minor rev 8; Rel 7.1.4, Ver 1, build53ba, Thu Mar 23 21:02:10 EDT 2017, (relmgr) |

## Configuration

### Connections

#### SNMPv2 main connection

This connector uses a Simple Network Management Protocol version 2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### SNMPv2 spectrum analyzer connection (range 2.1.0.1)

To use the spectrum analyzer (range 2.1.0.1), configure a second SNMP connection using the same values as for the primary SNMP connection.

#### SNMPv2 connection (range 5.0.0.1)

When you use the custom version, you should set the timeout of the element to 10 seconds in order to avoid unnecessary timeouts.

If a restart of the element is necessary, stop the element and wait a few seconds before restarting it; there can be blockages in the equipment if it is not allowed to finish previously requested actions.

## Usage (Range 1.0.0.x and 2.0.0.x)

### General

This page displays general information about the device. This information is divided into several groups:

- **General Info**: System information, such as the **System Name**, **System Up Time**, etc.
- **Cable Modems Info**: Information about the cable modems managed by the device.
- **Upstream/Downstream Info**: Capacity and bitrate upstream and downstream information.

### Spectrum Settings

This page allows you to configure the spectrum analyzer interface.

Three options for tracing can be selected with the **Measurement Trace Selection** parameter:

- *Absolute*: Based on physical type interface power values.
- *Relative*: Based on logical type interface power values.
- *Disabled*: Default option. Disables the data tracing process.

In combination with the sweep time, the **Retrieval Time Control** adjusts the time to acquire the data via SNMP using a second connection.

Below this, you can select an interface based on what is selected for the Trace Selection parameter.

### Configuration

This section contains two pages: one for the upstream and one for the downstream channel configuration:

- The **Configuration -- Upstream Channels** page displays the **Configuration - Upstream Channels table**. This table contains the configuration data for the different upstream channels of the Casa Systems C100G, for example the **US Frequency**, **US Width**, etc.
- The **Configuration -- Downstream Channels** page is similar to the Configuration -- Upstream Channels page but displays the **Configuration - Downstream Channels table**. This table contains all configuration data for the downstream channels on the Casa Systems C100G.

### Measurements

This section also contains a page for the downstream channels and one for the upstream channels:

- The **Measurements -- Upstream Channels** page displays the **Measurements - Upstream Channels** **table**. This table contains the measurement information for the upstream channels. The table has an entry for each upstream channel. The **US CM Total** column will for example display how many cable modems use that particular interface.
- The **Measurements -- Downstream Channels** page is very similar to the Measurements -- Upstream Channels page, but this page displays the **Measurements - Downstream Channels table**, which displays the downstream measurements.
- The **Measurements -- Ethernet and Configuration -- Ethernet** page displays the **Gigabit Interface Table.** This table contains the Ethernet interfaces to monitor the traffic used.

### Performance

This section has several tables distributed over different pages:

- **Performance**: This page contains the **Power and Fan Status Tables**.
- **Temperature**: This page shows the **Temperature Status Table**.
- **CPU Status**: This page displays the **CPU Status Table**.
- **Memory Status**: This page contains the **Memory Status Table**.

### Extra

This section consists of several pages: **Cable Modems**, **Service Flow**, **Ping Function** and **Flap List**.

- The **Cable Modems** page can be used to access information about the cable modems managed by the **Casa Systems C100G**. This page displays the **CM Table** and **CM Registration Table**. You can find more detailed information by clicking the **CM CPE** or **CM Status Ext** page buttons.

- The **Service Flow** page displays the **Service Flow Table**. This table describes the set of **DOCSIS-QOS Service Flows** in the managed device.

- The **Offload US/DS Channels** page can be used to offload the **interface data** to a semicolon-separated text file. The **location** and the **interval** to create these files can be specified on this page. This page also contains page buttons that can be used to access more detailed information about the **interfaces**, **modules**, etc. The **Redetect Config** button can be used to clear the upstream or downstream information from the different tables.

- The **Offload Topology** page can be used to offload 6 topology files: CM.csv, CMTS.csv, DSSG.csv, FNCMTS.csv, SG.csv and USSG.csv. These topology files contain information about the Cable Modems (CM.csv), Fiber Nodes (FNCMTS.csv), Service Groups (SG.csv) and DS/US Service Groups (USSG.csv and DSSG.csv) managed by the **Cable Systems C100G**. When the button **Get Topology** is pressed, the 6 files are created and stored in a folder with the name of the CMTS, inside the directory specified in the parameter **Local Location.**

- The **Ping Function** page can be used to ping devices. If **Ping Query** is *Enabled* and the **IP addresses** are filled in, the devices will be pinged and the **status** and **RTT** of the ping will be displayed. You can also provide a file containing the IP addresses of the devices you want to ping. In that case, the connector will ping the IP addresses in the **provisioning file**.

- The **Flap List** page displays the **Flap List Table**. This table displays more information about some of the cable modems managed by the **Cable Systems C100G**. The **Flap List Table** displays for example the number of **Flap Hits**, **Flap Misses**, etc.

- By default, the **Flap List** table is not polled by the connector, but polling can be enabled via the **Flap List Control** page. To access this page, click the **Flap List Control** page button. The **Flap List Control** subpage will also display extra information about the Flap List, like the **Flap List Current Size** and some **Thresholds**. You can also **reset** or **clear** the Flap List. If you only want the table polled once, click the **Refresh Flap List** button above the Flap List Table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access to the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 3.0.0.x)

### General

This page contains general information about the device. It displays the **System Description**, **System Name**, **System Location** and **System Contact**.

It also contains several page buttons leading to tables with the **System** **Status** (**Power** **Modules**, **Power** and **Fan** **Status**), **System** **Monitoring** (**Power**, **Fan** and **Temperature** **Monitoring**) and **CPU Utilization.**

### Interface Overview

On this page, the **Interface Table** displays information for each interface, such as the **Description**, **Type**, **Bandwidth**, status information (**Admin Status** and **Operational Status**) and information about errors and discarded packets (**Inbound Discards**, **Inbound Errors**, **Outbound Discards**, **Outbound Errors**).

The page displays the **Number of Displayed Interfaces**, i.e. the number of interfaces that are currently being displayed in the table.

It also contains a number of page buttons:

- **Interface Selection**: Displays the **Interface Selection Table**, which determines which interfaces are displayed in the **Interface Table**. You can filter the interfaces that are displayed using the **Description Filter** and **Type Filter**, and use the toggle buttons in the **Displayed** column of the Interface Selection table to enable or disable displaying particular interfaces in the Interface Table. Interfaces can also be enabled or disabled for display via the table's context menu.
- **IF Mapping**: Displays the **Interface Mapping Table**.
- **Eth Port Mng**: Displays the **Gigabit Ethernet Ports Management Table**.

### Video QAM Interfaces

This page contains the **Video Downstream Channels** table, with information about the characteristics of the channels, such as the frequency (**Channel Frequency**), the used modulation (**Channel Modulation**) and the power (**Channel Power**) in dBm.

### Physical Interfaces

This page contains the **Physical Entities Table**, with information regarding the available physical entities of the device. It also contains the **Module Table**, with information on each module in the chassis.

### RF Ports

This page contains the **RF Port Table**, which displays a counter for interfaces that are down, as well as the administrator status per RF port (**Interfaces Down** and **Admin Status**). Like previous tables, this table displays bit rates, the total maximum bandwidth, and the usage percentage per RF port (**Bit Rate**, **Total Max Bandwidth** and **Utilization**). The table also displays information regarding the number of **DTV Subscribers** and contains a column where you can set a customizable description for the RF port (**Custom Description**).

### QAM Streams

This page contains the **QAM Streams** table. This table contains information regarding the Network identifier (**Network ID**), the transport stream identifier (**Transport ID**), etc. It also contains four columns that are filled in by another element: **HFC-Segment**, **QAM VOD Cluster**, **DTV Subscribers** and **HFC-Segment Group**.

### Service Groups

This page contains a table with information such as the **Bit Rates** and **Maximum Bandwidth** for each service group.

### Virtual Edge

This page displays information about the virtual edges present on the Casa Systems C100G device. The **Virtual Edge** table contains information about each virtual edge, such as the **Operational Status** and **IP Addresses**. It also includes information regarding the bit rates and the total maximum bandwidth per virtual edge (**In Bit Rate**, **Out Bit Rate** and **Bandwidth**).

### CAS

This page contains the following tables:

- The **ECMG Status** table, with all the active sessions and CW message counter.
- The **Video SimulCrypt Connections** table, listing the simulCrypt ECMG instances.

### EIS

This page contains the **SimulCrypt EIS** table. This table contains the textual **Description** of the module that the SimulCrypt EIS connects to, the **IP Address** and **TCP Port**, the amount of time since the EIS connection was established (**Uptime**) and each connection's **Status**.

### MPEG

This page contains several tables:

- The **MPEG Input and Output Program** tables show the bit rates and requested bandwidth per video channel.
- The **MPEG Input and Output Program Video Session** tables contain the status of the video sessions per program.
- The **MPEG Decrypt Session** table displays only the video sessions that need decryption.

### Video Streams

This page displays different tables with information regarding the video streams.

- The **Video Streams** table shows all the events that have occurred with the transport streams.
- The **In Streams Per Module** table contains not only the **source and destination IP addresses** and **UDP ports**, but also the **bit rates** of each input stream.
- The **Out Streams per Channel** table displays detailed information for each channel that exists in the streams, such as the **Frequency**, **Number of Programs**, **Status**, etc.
- The **Out Programs** table contains detailed info on each output program, such as **source and destination IP addresses and UDP ports**, **counters of packets sent and received**, the **buffer length**, etc.
- The **PIDs per Out Program** table shows PID details of each program.

### Video Control Page

This page contains several parameters that allow you to define certain values for the SimulCrypt-related parameters. It is possible to define the **Video SimulCrypt Crypto Period**, the **ECMG Timeout** and **Retries** time and the **SimulCrypt Load Balancing**.

## Usage (Range 5.0.0.x)

### General

This page contains general information about the device. It displays the **System Chassis Serial**, **System Name**, **Current Running Flash**, **IP Address** and **System Contact**.

Via a page button on this page, you can delete all custom tables in the element.

### Fan

This page contains information about the fan status and configuration. **Speed**, **Threshold** and **Slot** can be monitored.

### Temperature

This page contains relevant information about the temperature. **Threshold High, Threshold Low** and **Status** can be monitored, in addition to the current **Temperature.**

### Power

This page contains a table that allows you to monitor the system power supply. **State**, **Source** and **Slot** can be monitored.

### Ethernet

This page contains the **Ethernet Table**, which allows you to monitor Ethernet interfaces, with general and specific information such as **Interface Name, Bandwidth, Utilization, Port Link Status, In Bitrate** and **Out Bitrate.**

### Upstream

This page contains the **Upstream Channel Table**, which allows you to monitor upstream interfaces, with general and specific information from different sources, such as **Cable Modem Online, Cable Modem Offline, Cable Modem Registered, Cable Modem Unregistered, Rate Uncorrectable, SNR, Bitrates, Utilization, Channel Status, Modulation, Capacity** and more

### Downstream

This page contains the **Downstream Channel Table**, which allows you to monitor downstream interfaces, with general and specific information from different sources, such as **Cable Modem Online, Cable Modem Offline, Cable Modem Registered, Cable Modem Unregistered, Rate Uncorrectable, SNR, Bitrates, Utilization, Channel Status, Modulation, Capacity** and more.

## Usage (Range 6.0.0.x)

### General Page

This page contains general information about the device. It displays the **System Description**, **System Name**, **System Location** and **System Contact**.

### Interfaces Page

This page contains information on the interfaces of the Arris E6000 device.

The **Interface Table** shows information for each interface, such as the **Description**, **Type**, **MTU**, **Speed**, **Physical Address**, status information (**Admin Status** and **Operational Status**), information about errors and discarded packets (**Inbound Discards**, **Inbound Errors**, **Outbound Discards**, **Outbound Errors**) and interface utilization (**Utilization In** and **Utilization Out**).

The **Number of Displayed Interfaces** parameter indicates how many interfaces are currently displayed in the table.

Via the **Interface Selection** page button, you can configure which interfaces are displayed in the Interface Table:

- The **Description Filter** and **Type Filter** parameters allow you to filter the interfaces. By clicking the **Enable** or **Disable** button below these filters, you can enable or disable displaying interfaces according to the filters.
- In the **Interface Selection** table, **toggle buttons** are also available that allow you to configure whether an interface is displayed.

### QAM Streams Page

This page contains two tables, the **QAM Streams** table and the **QAM Streams Status** table, which both use the **QAM Channel Name** as an identifier.

- The **QAM Streams** table contains information regarding the MPEG transport stream identifier (**MPEG TS ID**), the index of the outgoing transport stream (**Out TS ID**), the retransmission interval for PAT and PMT tables (**PAT Interval** and **PMT Interval**), the associated service groups and virtual edges of each QAM Channel (**Service Group Name** and **VE Name**), etc. This table also contains four columns that are filled in by another element: **HFC-Segment**, **QAM VOD Cluster**, **DTV Subscribers** and **HFC-Segment Group**.
- The **QAM Streams Status** table contains information regarding the total number of unique PAT tables that have been generated per QAM channel (**Total PATs Tx**), as well as the current, the maximum and the total number of programs transmitted (**Current Programs Tx**, **Peak Programs Tx** and **Total Programs Tx**). Information related to the requested and the peak bandwidth (**Requested Bandwidth** and **Peak Bandwidth**) is also displayed.

### QAM Interfaces Page

This page contains the **Video Downstream Channels** table, with information about the characteristics of the channels, such as the frequency (**Channel Frequency**), the used modulation (**Channel Modulation**) and the power (**Channel Power**) in dBm.

### RF Ports Page

This page contains the **RF Port Table**, which displays a counter for interfaces that are down, as well as the administrator status per RF port (**Interfaces Down** and **Admin Status**). This table displays bit rates, the total maximum bandwidth, and the usage percentage per RF port (**Bit Rate**, **Total Max Bandwidth** and **Utilization**). The table also displays information regarding the number of **DTV Subscribers** and contains a column where you can set a customizable description for the RF port (**Custom Description**).
