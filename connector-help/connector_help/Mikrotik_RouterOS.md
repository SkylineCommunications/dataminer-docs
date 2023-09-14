---
uid: Connector_help_Mikrotik_RouterOS
---

# Mikrotik RouterOS

This is an **SNMP** connector that is used to monitor and configure the **Mikrotik Router** equipment.

## About

This connector retrieves the information on tables and parameters via SNMP polling.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains basic information about the device, such as the **Model**, **Serial Number** and **System Up Time**.

It also displays more specific information about the router, including the **Voltage**, **Temperature** and **Fan Speed.**

You can also **reboot** the device here and **turn off the USB Power**.

### Detailed Interface Info

This page displays a table containing the **Bandwidth Speed**, **Total Utilization**, **MTU**, **Last Change**, and the number of **Errors In** **and Out**.

### Detailed Interface Info - Rx

This page contains the Rx Table, which displays **Bitrate Calculations**, **Bitrate Percent**, **Total Packets**, **Packet Rate**, **Discarded Packets**, **Too Long**, **Align Errors** and **Unknown Packets**.

### Detailed Interface Info - Tx

This page contains the Tx Table, which displays **Bitrate Calculations**, **Bitrate Percent**, **Total Packets**, **Packet Rate**, **Discarded**, **Too Short**, **Pause** and **Received FCS Errors**.

### Wireless Interfaces

This page contains four tables related to the device: **Station Mode**, **Registration**, **Access Points**, and **Wireless CAPSMAN**.

### Neighbor Table

This page displays the Neighbor Table, with the **Platform** (name), **IP Address**, **Mac Address**, **Version**, **Identity** and **Software ID**.

### Partition Table

This page contains a table that shows if the device is partitioned in any way. The table shows the **Size** of the partition in MB, the **Version**, **Partition Status** and the **Partition** **State**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
