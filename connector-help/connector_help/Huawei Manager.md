---
uid: Connector_help_Huawei_Manager
---

# Huawei Manager

With the Huawei Manager, you can configure and monitor **Huawei switches**.

Because multiple device types are supported, monitoring can be enabled or disabled for each specific type.

## About

The Huawei Manager retrieves data via **SNMP** and **SSH** from version 1.0.3.x onwards.

### Version Info

| **Range**            | **Key Features**                                                                              | **Based on** | **System Impact**                                                                                   |
|----------------------|-----------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                               | \-           | \-                                                                                                  |
| 1.0.1.x              | Driver review. Removal of JScript QActions and tables as string parameter.                    | 1.0.0.14     | Unknown                                                                                             |
| 1.0.2.x              | DCF integration.                                                                              | 1.0.1.1      | Unknown                                                                                             |
| 1.0.3.x \[obsolete\] | Added SSH connection and PTP data.                                                            | 1.0.2.16     | Unknown                                                                                             |
| 1.0.4.x \[obsolete\] | Changed PTP Interfaces table layout. Moved Port State column to the left, next to the "Name". | 1.0.3.5      | Trend data for this table could be lost. Automation scripts may need to be reviewed for this table. |
| 1.0.5.x \[SLC Main\] | Optical module table was changed. Columns removed and Column order changed.                   | 1.0.4.14     | Trend data for this table could be lost. Automation scripts may need to be reviewed for this table. |

### Product Info

| **Range** | **Supported Firmware**                         |
|-----------|------------------------------------------------|
| 1.0.0.x   | 5.1                                            |
| 1.0.1.x   | 5.1                                            |
| 1.0.2.x   | 5.1 or higher (see note below on General page) |
| 1.0.3.x   | 5.1 or higher (see note below on General page) |
| 1.0.4.x   | 5.1 or higher (see note below on General page) |
| 1.0.5.x   | 5.1 or higher (see note below on General page) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.4.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.5.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## How to Use

### General

This page displays an overview of general device settings, such as **System Name**, **Software Description**, **IP Address**, etc., as well as the **CPU** and **Memory usage**.

The page contains the following page buttons:

- **SSH Files Server:** Allows you to establish a connection with an **SSH server** through **SFTP** protocol, in order to copy a file to this server. Every field on this page must be filled in correctly in order to successfully establish the connection. If the Username and Password are not configured, no information will be polled through this connection.

- **TCP/UDP** **Statistics**: Displays the **TCP Segments Total Sent**, **TCP Segments Total Received**, **UDP Datagrams Sent**, etc.
  Contains two page buttons that display the **UDP Listener Table** and **TCP Connection Table**, respectively.

- **ICMP** **Statistics**: Displays **ICMP Received/Sent Messages**, **ICMP Echo Requests/Replies**, etc.

- **IP Statistics:** Displays **IP Forwarding**, **IP Datagrams Received**, **IP Requests Sent**, etc.

- **MAC Address Table**

- **Physical Entities Table**

- **Polling Configurations**: Contains toggle buttons that enable/disable polling for the following data in the driver:

- Address Translation Table
  - ARP Table
  - BGP Table
  - ICMP Statistics
  - IP Route Table
  - IP Statistics
  - MAC Address Table
  - Physical Entities Table
  - TCP/UDP Statistics
  - Huawei VLAN Table

**NOTE**: It is possible to configure the bitrate polling time on this page. For device firmware version 5.1, 10 seconds is used as the default value.
If the connector is used with **newer firmware versions (e.g. 8.190), a 1-minute timer should be used to avoid spikes in bitrates**, as the counters (IfTable and IfXTable) are only updated every minute.

In range 1.0.2.x, the parameter **Counter Type Mode** has been added, which allows you to select to *Always use 64 bits*. When you do so, 64 bits will be used for bitrate calculations. You should consider using this option with firmware version 8.1.90 or higher.

### Detailed Interface Info, Detailed Interface Info - Rx and Detailed Interface Info - Tx

These pages contain the **Interface Table**, as well as parameters such as **Bitrate**, **Bandwidth Utilization**, **Packet Rate**, **Error Rate**, **Collisions**, etc.

**Detailed Interface Info - Rx** contains a detailed interface table with **inbound data information**, while **Detailed Interface Info - Tx** displays the **outbound data information**.

**IF Info Test** contains extra interface information that can be retrieved via SNMP, such as **Input and Output Bitrates/Packet Rates**, **MTU**, **Frame Type**, and the operation mode for each interface (Layer 2 or Layer 3).

### System Power

This page displays the **System Power Table**, which contains information about the power state of system and boards.

It also contains page buttons to subpages displaying the **Power Used Info Table** and **Power Status** **Table**.

### Fan

This page contains the **Fan Status Table**, which displays information about the register and status of all fans in the system.

### VLAN

This page displays the **Huawei** **VLAN Table** of the device.

### IP Routing Info

This page contains the **IP Routing Table**, as well as the following page buttons and corresponding parameters:

- **Address Translations Table**
- **ARP Table**
- **BGP Peer Table**
