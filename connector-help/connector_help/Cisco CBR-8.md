---
uid: Connector_help_Cisco_CBR-8
---

# Cisco CBR-8

The Cisco CBR-8 is a next-generation Evolved Converged Cable Access Platform (CCAP) that delivers multigigabit and Internet-of-Everything services at a lower TOC to cable operators.

## About

This connector provides a general overview of the Cisco CBR-8 device and mainly displays the upstream details. It uses the SNMPv2 protocol to communicate with the device.

The connector uses regular timers that trigger every 60 and 120 seconds, as well as a timer that triggers every 30 minutes to perform data cleaning.

### Version Info

| **Range**            | **Description**                                                                         | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x              | Initial version.                                                                        | No                  | No                      |
| 1.0.2.x              | Implemented changes on the Physical Upstream Channel Table and Upstream Bounding table. | No                  | No                      |
| 1.0.3.x              | Index of the Measurement Upstream Channel table changed to the instance of the channel. | No                  | Yes                     |
| 1.0.4.x              | DCF feature added.                                                                      | Yes                 | Yes                     |
| 2.0.0.x \[SLC Main\] | Connector review. Added CCAP parameters.                                                | No                  | Yes                     |

### Supported firmware versions

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 1.0                    |
| 1.0.2.x   | 1.0                    |
| 1.0.3.x   | 1.0                    |
| 1.0.4.x   | 1.0                    |
| 2.0.0.x   | 1.0                    |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

## Usage (Range 1.0.x.x)

### General

This page displays the system information, main rate usage or memory and CPU usage, a summary of cable modem information, and rate information on upstream and downstream channel utilization, transmission, and capacity.

The page contains a number of page buttons:

- **Power Supplies**: Displays information on the power supplies of the device.
- **Processors**: Displays the 1-min CPU total utilization.
- **Temperature**: Displays information on the temperature of the device.

### Configuration - Upstream Channels

This page displays general information related to the upstream channels: **Name**, **Description**, **Frequency**, **Bandwidth**, **Modulation**, **Timing Offset**, and **Ranging Backoff**.

### Measurement - Upstream Channels

This page displays detailed information related to the upstream channels, including whether **cable modems are online, offline or initializing**, the **online delta**, the **percentage offline**, **SNR**, **consecutive SNR readings** in periods of 15 min against 35 dB, rate of **Unerrored**, **Corrected** and **Uncorrected**, **CER** and **Loss**, **Modulation**,and **RF Utilization**.

### Measurement - Gigabit Interfaces

This page displays the **Input and Output Errors** that occurred within a custom time interval.

### RF Interfaces

This page displays the **RF Interfaces Table** and the **Mpeg Output Stats Table**.

### CAS

This page displays the **Mpeg Input TS Table**, the **Mpeg Input Prog Table**, the **Mpeg Output Prog Table**,and the **Mpeg Video Session Table**.

### Offload

This page displays the **Interfaces table**.

Via the **Interface Extended** button, you can access the **Interfaces Extended table**, **HCOctects Extended table**, and **Interface Errors table**.

The **Signal Quality** button provides access to the Signal Quality table.

### Device Web Page

This page provides access to the internal webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 2.0.0.x)

### General

This page displays general and system information for the Cisco CBR-8 device. The page also displays five page buttons, which lead to the following subpages:

- **Alarms**: Displays several tables with specific alarm information.
- **Power Supplies**: Displays the **Power** **Supply Table**, with specific information about the monitored Cisco CBR-8 power supplies.
- **CPU**: Displays the **CPU** **Table**, with specific information about the CPU.
- **Temperature**: Displays the **Temperature** **Table**, with specific information about the temperature of the Cisco CBR-8 device.
- **Fans**: Displays information on the fan status.

### Interface Overview

This page contains the **Interface Overview** table, which displays information on each interface, such as the **Description**, **Type**, **Bandwidth**, **Operational Status**, **Input Errors**, **Output Errors**, **Last Change**, **Input and Output Unicast Packets**, etc.

This page also displays two page buttons, which lead to the following subpages:

- **Interface Selection**: Allows you to select the interfaces to be monitored. After you have selected the desired interfaces, click the **Update Interfaces** button to fill in the table.
- **Ifx Table**: Displays a table with additional interface information.

### Video QAM Channels

This page contains the **Video QAM Channel** **Table**, with information about the characteristics of the video channels, such as the frequency (**Channel Frequency**), the used modulation (**Channel Modulation**) and the power (**Channel Power**) in dBm.

This **table remains empty** until you have made a selection of interfaces to show on the **Interface Selection** page by marking them as "Displayed" and then clicking the **Update Interfaces** button.

### Physical Interfaces

This page contains the **Physical Interfaces** **Table**, which displays specific information such as the **Description**, **Software Revision**, **Serial Number**, and **Model Name** for all physical interfaces. This page also displays the **Modules table** with operational and administrative status information for manageable components of physical interfaces.

### Service Groups

This page contains a table with information about the **Bit Rates**, **Utilization**,and **Total Bandwidth** for each service group.

### Virtual Edge

This page displays information about the virtual edges present on the Cisco CBR-8 device. It also displays bit rates, the total bandwidth, and the usage percentage per virtual edge (**Bit Rate**, **Total Bandwidth**,and **Utilization**).

### RF Ports

This page contains the **RF Port** table, which displays a counter for interfaces that are down, the administrator status per RF port and the number of DTV subscribers per RF port. The table also displays bit rates, the total bandwidth, and the usage percentage per RF port (**Bit Rate**, **Total Bandwidth**, and **Utilization**).

### Video Streams

This page contains the **MPEG** table, which stores basic information on all video streams.
