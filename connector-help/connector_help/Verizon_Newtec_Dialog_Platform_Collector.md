---
uid: Connector_help_Verizon_Newtec_Dialog_Platform_Collector
---

# Verizon Newtec Dialog Platform Collector

The **Verizon Newtec Dialog Platform Collector** collects and organizes the data from the Newtec Dialog Platform.

## About

This is an **HTTP** connector that communicates with the **Newtec Dialog System** via the **Restful API** provided by the system and via the native **SOAP API** provided by DataMiner. The data collected from both sources are placed strategically within the connector, allowing users to easily monitor the different systems controlled by the **Newtec Dialog Platform**.

### Version Info

| **Range**     | **Description**                                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version The initial version in this range is deprecated. Use version **1.0.0.2** of this range instead. | No                  | Yes                     |
| 1.0.1.x              | Improvements to the faults functionality                                                                        | No                  | Yes                     |
| 1.1.1.x              | Adapted to new firmware version 2.1.2.                                                          | No                  | Yes                     |
| 1.1.2.x \[SLC Main\] | Adapted to work with DMS.                                                                       | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.1                       |
| 1.0.1.x          | 2.1.1                       |
| 1.1.1.x          | 2.1.2                       |
| 1.1.2.x          | 2.1.2                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION 0:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

HTTP CONNECTION 1:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

HTTP CONNECTION 2:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

HTTP CONNECTION 3:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

Note: In **version 1.1.2.x** of this protocol, the **IP address specified in the element editor does not matter**, as all polling IPs are specified in the Polling Configuration table and will be dynamic switched to poll all available data. See "Configuration" section below.

## Usage

### General

This page contains basic information on what is going on in the connector, such as **Active Remotes**, **Networks** and **Hub Forward**.

### Remotes

This page contains critical information regarding the **Remotes** within the **Circuits**. This information is retrieved via the **Restful API**.

Remotes are important as they are used in the connector's **import/export** feature, which populates some of the fields in the Circuits Overview Table. They are the main part of the Circuits.

The overview table on this page contains among others the **Modem Type**, **Monitoring Type** and **Lock State** columns.

### Advanced Remotes Instance

This page contains critical information regarding the **Advanced Remotes** within the **Circuits**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **Modem Operational Mode**, **Active Beam**, **Latitude** and **Longitude** columns.

### Standard Remotes Instance

This page contains critical information regarding the **Standard Remotes** within the **Circuits**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **Operational State**, **Critical Data Forward Throughput** and **Real-Time Return Throughput** columns.

### RI Alarms

This page contains a table listing all the alarms related to the **Remotes** within the connector. The information in the table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Remotes Certification Instance

This page contains information regarding the **Remotes Certification** corresponding with the **Remotes** within the connector. This information is retrieved via the **SOAP API**.

The page contains a table displaying the **Primary Spectrum**, **Primary LBand Switch**, **Measurement Channel**, etc.

### RCRT Alarms

This page contains a table listing all the alarms related to the **Remotes Certification** within the connector. The information in the table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Remotes Mobility

This page contains critical information regarding the **Remotes Mobility** corresponding with the **Remotes** within the connector. This information is retrieved via the **SOAP API**.

The page contains the **Remotes Mobility**, **Remotes Mobility Terminal** and **Remotes Mobility Satellite Network** tables, which include parameters such as **Accessible**, **Ongoing** and **Located**.

### RM Alarms

This page contains a table listing all the alarms related to the **Remotes Mobility** within the connector. The information in the table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Hub Networks

This page contains a table that collects information from different tables in the connector such as **Hub Forward**, **Hub Return**, **Satellite Network**, **Hub Module**, and **Remotes.** The collected information is then used in calculations that are placed in a table that provides an overview of the **Networks** within the connector. The table on this page displays the **Hub Return Symbol Rate**, **Hub Forward Booked Bandwidth**, **Nominal MODCOD**, etc.

### Hub Forward

This page contains a table that collects information from different tables in the connector such as **Forward Link**, **Forward Carrier** and **Forward Pool.** The collected information is then used in calculations that are placed in a table that provides an overview of the **Hub Forward** within the connector. The table on this page displays the **Symbol Rate**, **Uplink Center Frequency**, **Power**, etc.

### Hub Return

This page contains a table that collects information from different tables in the connector such as **Return Link**, **Return Carrier**, and **Return Pool**. The collected information is then used in calculations that are placed in a table that provides an overview of the **Hub Return** within the connector. The table on this page displays the **Free Slots**, **Booked Bandwidth**, **Slot Usage**, etc.

### Circuits

This page contains a table that collects information from the **import/export** feature, which exports a configuration file with a list of **Remotes** present in the connector to the **VSAT Database** and imports a provisioning file from the **VSAT Database** based on the exported file.

This table also collects information from different tables within the connector such as **Hub Forward**, **Hub Return** and **Hub Network**, which provides an overview of the **Circuits** within the connector.

The table on this page displays the **Hub Forward Traffic**, **Hub Return C/No**, **Antenna Size**, etc.

### Configuration

This page allows you to configure the following critical functionality of the connector:

- **Authentication:** In this section, the username and password must be specified that allow the data to be retrieved from the **Newtec Dialog System**.
- **Import/export configuration**: Allows you to export a configuration file to the **VSAT Database**, which will then create a **provisioning file**. This file can then be imported using the **import** feature, so that specific fields within the **Circuits Table** can be populated.
- **Ping configuration**: Allows you to enable the ping feature, which pings each **Remote** present in the connector. You can also select the **VLAN** that you want to ping and the **Processing Time**, in order to determine how often the ping will occur.
- **Other settings:** Includes the **File Handling**, which is associated with the **Import/Export Configuration** feature. This allows you to control whether the **import** and **export file** are processed by the connector. The **Circuit Request Size** allows you to specify how many **Circuits** will be retrieved in a single call.
- **SLA & fault configuration:** Allows you to enable or disable the ability to update SLA & fault configuration parameters automatically. This section also includes a timer that allows you to select how frequently the updates should occur.

#### Version 1.1.2.x and higher

In this version, the **Authentication** section is replaced with a **Polling Configuration** table, which allows you to enter information for the **different DMAs within a DMS** by right-clicking the table and selecting the option to add in the context menu. Among the fields that can be specified are **DMA ID**, **Username**, **Password**, **IP Address**, **Name**, etc. Once these fields have been added in the table, you can also edit them in Cube. The right-click menu also allows you to **delete an entry or clear all entries** from the table.

### Fault Settings

This page contains the **Faults Overview** table, which includes the **Alarm Condition**, **Mask** and **Clear Condition** columns.

### SLA Settings

This page contains the **SLA Overview** table, which includes the **Maintenance Option**, **Timer Group,** and **Ticket TM Workgroup Field** columns.

### Beam

This page contains information regarding the **Beams** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Orbital Position**, **Signaled Name,** and **West-East Flag** columns.

### CPM RCG

This page contains information regarding the **CPM Return Capacity Group** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Total Bandwidth**, **Locked** and **Amp Instance ID** columns.

### HRC MXDMA RCG

This page contains information regarding the **HRC-MXDMA Return Capacity Group** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Login Symbol Rate**, **Logon Mode** and **Max Bandwidth** columns.

### HRC SCPC RCG

This page contains information regarding the **HRC SCPC Return Capacity Group** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **EIRP Tracking Static Margin**, **Max MODCOD,** and **Locked** columns.

### S2 RCG

This page contains information regarding the **S2 Return Capacity Group** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Name**, **Return Link Name** and **Locked** columns.

### Forward Pool

This page contains critical information regarding the **Forward Pool** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **CIR**, **Weight** and **Type** columns.

### Forward Pool Instance

This page contains critical information regarding the **Forward Pool** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Forward Class Pool**, **PIR,** and **Dedicated** columns.

### FP Alarms

This page contains a table listing all the alarms related to the **Forward Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### L1 FPL Alarms

This page contains a table listing all the alarms related to the **Forward Pool L1** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### L1 FPCI Alarms

This page contains a table listing all the alarms related to the **Forward Pool Class L1** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Return Pool

This page contains critical information regarding the **Return Pool** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **PIR**, **Weight** and **Return Technology** columns.

### Return Pool Instance

This page contains critical information regarding the **Return Pool** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **CPM Return Class Pools** and **HRC MXDMA Class Pools tables**, which include parameters such as **Real-Time CIR**, **Real-Time EIR Shaping Ratio** and **Critical Data CIR Congestion.**

### RPI Alarms

This page contains a table listing all the alarms related to the **Return Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### CPM RPI Alarms

This page contains a table listing all the alarms related to the **CPM Return Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### HRC MXDMA RPI Alarms

This page contains a table listing all the alarms related to the **HRC MXDMA Return Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### HRC SCPC RPI Alarms

This page contains a table listing all the alarms related to the **HRC SCPC Return Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### S2 RPI Alarms

This page contains a table listing all the alarms related to the **S2 Return Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Forward Link

This page contains critical information regarding the **Forward Link** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Linear Predistortion**, **Max Symbol Rate** and **Merging Slicing Mode** columns.

### Forward Link Instance

This page contains critical information regarding the **Forward Link** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Control Symbol Rate**, **Unicast Send Bitrate** and **Unicast Dropped Bitrate** columns.

### FLI Alarms

This page contains a table listing all the alarms related to the **Forward Link** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### RLI Alarms

This page contains a table listing all the alarms related to the **Return Link** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Service Profile

This page contains critical information regarding the **Service Profile** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Type**, **Forward Acceleration Best Effort** and **Locked** columns.

### Classification Profile

This page contains critical information regarding the **Classification Profile** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

This page contains the **Classification Profile** and **Classification Rules** tables, which include parameters such as **Packing Marking Mode**, **Remote Side QoS Classification** and **Traffic Class.**

### Calibration

This page contains critical information regarding the **Calibration** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **CO Mean**, **NO Mean** and **Locked** columns.

### HRC MCD Frequency Slot

This page contains critical information regarding the **HRC MCD Frequency Slot** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Start Frequency**, **Stop Frequency** and **Locked** columns.

### Accounting

This page contains critical information regarding the **Accounting** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **Terminals Unicast Traffic**, **Terminal Multicast Circuits** and **Producers** tables, which includes parameters such as **Forward Volume**, **Return Packet** and **Active.**

### Accounting Alarms

This page contains a table listing all the alarms related to the **Accounting** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Accounting Aggregator

This page contains critical information regarding the **Accounting Aggregator** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **File Name**, **Status** and **Frequency** columns.

### AA Alarms

This page contains a table listing all the alarms related to the **Accounting Aggregator** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Redundancy Controller

This page contains critical information regarding the **Redundancy Controller** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **Single Device** and **Server Redundancy** tables, which include parameters such as **Server Status**, **HPS,** and **Virtual Machine.**

### RC Alarms

This page contains a table listing all the alarms related to the **Redundancy Controller** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Hub Module

This page contains critical information regarding the **Hub Module** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Version**, **Type,** and **Locked** columns.

### Enclosure Device

This page contains critical information regarding the **Enclosure Device** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Asset Tag**, **Spare Part Number** and **Server Blade Presence** columns.

### Enclosure Device Alarms

This page contains a table listing all the alarms related to the **Enclosure Device** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### MS Servers

This page contains critical information regarding the **Microsoft Server** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **MS Server**, **Processors**, and **Ports List tables**, which include parameters such as **Total Handles**, **Total Threads,** and **Last Time Sync.**

### MSS Alarms

This page contains a table listing all the alarms related to the **Microsoft Server** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### LX Servers

This page contains critical information regarding the **Linux Server** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **Linux Server** and **Storage Table** tables, which include parameters such as **Total Memory Usage** and **Type.**

### LXS Alarms

This page contains a table listing all the alarms related to the **Linux Server** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Modulator

This page contains critical information regarding the **Modulator** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **Data Active Interface**, **Data Link Redundancy** and **Power Supply** columns.

### Modulator Alarms

This page contains a table listing all the alarms related to the **Modulator** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### MCD6000 Demodulator

This page contains critical information regarding the **MCD6000 Demodulator** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **Data Active Interface**, **Data Link Redundancy** and **Power Supply** columns.

### MCD7000 Demodulator

This page contains critical information regarding the **MCD7000 Demodulator** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **Product**, **CPU Load** and **Memory Use** columns.

### Demodulator Alarms

This page contains a table listing all the alarms related to the **Demodulator** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Switch

This page contains critical information regarding the **Switch** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The overview table on this page contains among others the **CPU Usage**, **Memory Size,** and **Total RX** columns.

### Switch Alarms

This page contains a table listing all the alarms related to the **Switch** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### RF Switch

This page contains critical information regarding the **RF Switch** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **RF Switch Overview**, **Network Interface Settings** and **Raw Mode** tables, which include parameters such as **Bucket Name**, **Redundancy Mode**, **IP Address**, **Full Switch** and **Switch Position.**

### RF Switch Alarms

This page contains a table listing all the alarms related to the **RF Switch** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### CSE Shaper

This page contains critical information regarding the **CSE Shaper** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Receive Bitrate**, **Drop Bitrate** and **Average Delay** columns.

### CSES Alarms

This page contains a table listing all the alarms related to the **CSE Shaper** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### CPMCTL Controller

This page contains critical information regarding the **CPMCTL Controller** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **CPMCTL Controller**, **Shaping Nodes** and **Slot Pool Container** tables, which include parameters such as **Input Counter**, **Total OK Slots**, **Outstanding Volume**, **EIR Shaping,** and **Average Lost Volume.**

### CPMCTLC Alarms

This page contains a table listing all the alarms related to the **CPMCTL Controller** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### HRCCTL Controller

This page contains critical information regarding the **HRCCTL Controller** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **HRCCTL Controller** and **HRCCTL Shaping Nodes** tables, which include parameters such as **System Noise Too Low**, **PTP Out of Lock**, **EIR Shaping Ratio** and **Requested Rate.**

### HRCCTLC Alarms

This page contains a table listing all the alarms related to the **HRCCTL Controller** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### DCP Decapsulator

This page contains critical information regarding the **DCP Decapsulator** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Receive Bitrate**, **Receive Packet Rate** and **Send Bitrate** columns.

### DCPD Alarms

This page contains a table listing all the alarms related to the **DCP Decapsulator** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### DEM Application

This page contains critical information regarding the **DEM Application** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **DEM Application**, **External Interface Statistics**, **TAS Interface Statistics,** and **Neighbors Information** tables, which include parameters such as the **External RTN Rate**, **External FWD Rate**, **Interface**, **FWD Data Rate**, **RTN Data Rate**, **FWD Packet Rate**, **Number of Learned Routes** and **Neighbor IP.**

### DEMA Alarms

This page contains a table listing all the alarms related to the **DEM Application** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Tellinet

This page contains critical information regarding the **Tellinet** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **Tellinet** and **Tellinet Statistics** tables, which include parameters such as **Running on Server**, **Number of TCP Connection**, **Number of Associations** and **Tellinet Instance ID.**

### Tellinet Alarms

This page contains a table listing all the alarms related to the **Tellinet** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### TCS Monitoring

This page contains critical information regarding the **TCS Monitoring** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

In the table on this page, you can among others find the **Protobuf Version**, **First Request Config Time** and **Terminal Name** columns.

### TCSM Alarms

This page contains a table listing all the alarms related to the **TCS Monitoring** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Hub Multicast Circuit

This page contains critical information regarding the **Hub Multicast Circuit** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

This page contains the **Hub Multicast Circuit** and **Satellite Network Hub Multicast Circuit** tables, which include parameters such as **Locked**, **Multicast Address** and **Name.**

### Satellite Network

This page contains critical information regarding the **Satellite Network** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Authentication**, **Beam Name** and **RF Terminal Position Altitude** columns.

### Tellinet Instance

This page contains critical information regarding the **Tellinet Instance** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Server Address**, **Satellite Network Name** and **TAS Role** columns.

### Transponder

This page contains critical information regarding the **Transponder** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Transponder Delta Frequency**, **Name** and **Locked** columns.

### Device Role

This page contains critical information regarding the **Device Role** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Free**, **Consumer Name** and **Type** columns.

### Firmware Multicast

This page contains critical information regarding the **Firmware Multicast** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Data Port**, **Data Speed** and **In The Air** columns.

### Network

This page contains critical information regarding the **Network** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **MTU**, **Routing Protocol** and **Name** columns.

### Network Alarms

This page contains a table listing all the alarms related to the **Network** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### Domain

This page contains critical information regarding the **Domain** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Type**, **Skip Certification** and **Locked** columns.

### Gateway

This page contains critical information regarding the **Gateway** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Location**, **Name** and **Locked** columns.

### Firewall Profile

This page contains critical information regarding the **Firewall Profile** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Type**, **Start** and **Limit** columns.

### IPv4 Address Pool

This page contains critical information regarding the **IPv4 Address Pool** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Locked**, **Service Label** and **Name** columns.

### IPv4 API Alarms

This page contains a table listing all the alarms related to the **IPv4 Address Pool** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value.**

### IPv6 Address Pool

This page contains critical information regarding the **IPv6 Address Pool** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **LAN Prefixes**, **Name** and **Service Label** columns.

### Multicast Circuit

This page contains critical information regarding the **Multicast Circuit** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Capacity Request Margin**, **CIR** and **Hub Forwarding** columns.

### Multicast VLAN

This page contains critical information regarding the **Multicast VLAN** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **IP Address**, **Prefix Length** and **Locked** columns.

### User

This page contains critical information regarding the **User** of the **Newtec Dialog System**. This information is retrieved via the **Restful API**.

The overview table on this page contains among others the **Max Advanced Modems**, **Credentials Domain Locked** and **Credentials Domain Type** columns.

### Dialog Integration

This page contains information about the **integration of protocols and elements** within the connector.

### Dialog Config Instance

This page contains critical information regarding the **Dialog Config** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The table on this page contains among others a **Name** column.

### DCI Alarms

This page contains a table listing all the alarms related to the **dialog config** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value**.

### Dialog Provisioning Instance

This page contains critical information regarding the **dialog provisioning** of the **Newtec Dialog System**. This information is retrieved via the **SOAP API**.

The page contains the **Functionality Overview**, **DMA**, **Provisioning Progress** and **Provisioning Queue** tables, which include parameters such as **Name**, **Connection Type**, **Agent Name**, **Agent IP**, **Status**, **Times Processed**, **Message Queue Data** and **Message Queue Type**.

### DPI Alarms

This page contains a table listing all the alarms related to the **dialog provisioning** within the connector. The information in this table includes the **Element Name**, **Parameter ID** and **Display Value**.
