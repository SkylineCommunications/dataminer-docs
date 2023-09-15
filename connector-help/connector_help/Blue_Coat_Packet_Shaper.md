---
uid: Connector_help_Blue_Coat_Packet_Shaper
---

# Blue Coat Packet Shaper

The **Blue Coat Packet Shaper** is a Traffic Shaper used for network monitoring and management.

## About

SNMP connector for the **Blue Coat Packet Shaper.**

## Configuration

### Creation

#### SNMP Connection - Main

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### Monitor

The **Monitor** page displays a tree view of the following tables:

- **Links Table**
- **Partitions Table**
- **Classes Table**

### Links

The **Links** page displays the Links Table with parameters such as:

- **Link Byte Count**
- **Link Total Rx Bytes**
- **Link Total Tx Bytes** etc.

### Partitions

The **Partitions** page display the Partitions table with parameters such as:

- **Partition Byte Count**
- **Partition Pkts**
- **Partition Data Pkts** etc.

### Classes

The **Classes** page displays the Classes Table with parameters such as:

- **Class Byte Count**
- **Class Rate**
- **Class Current Rate** etc.

### Alarms

The **Alarms** page displays all alarm related parameters, such as:

- **Packet Shaper Operational Status**
- **Alarm Config File Status**
- **Alarm Measurement Engine Status** etc.

### Webpage

Displays the device's Webpage.
