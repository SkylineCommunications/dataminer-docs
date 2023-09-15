---
uid: Connector_help_Riverbed_Steelhead
---

# Riverbed Steelhead

This connector can be used to monitor the Riverbed Steelhead management system.

## About

The connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description**                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                 | No                  | No                      |
| 1.1.0.x          | New MIBs used.                                                   | No                  | No                      |
| 2.0.0.x          | New range for SNMP version 3, based on previous version 1.1.0.1. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.6.2b \#6                  |
| 1.1.0.x          | 9.2.1b \#1 x86_64           |
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.90.140.200*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as the **Model**, **Serial Number**, **IP Address**, **System Health**, **Service Status**, **System Temperature** and **CPU Utilization**.

### Connection status

This page displays information about the existing and possible connections of this appliance.

### Interfaces table

This page shows the **Interfaces Table**, which contains statistics for the network interfaces in this system. It also contains a toggle button to enable or disable polling of the table.

### Ping Function

This page displays information about the **Ping Queries**, such as **Ping Status**, **Average** **Success**, **Average** **RTT**, **Availability** and **Percentage of Packet Loss**. It also contains a toggle button to enable or disable **Ping Queries**, and other editable properties of the queries, such as **Cycle**, **Timeout**, **Requests** **per** **Cycle** and **Requests** **History**.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
