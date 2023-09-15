---
uid: Connector_help_Brocade_VDX6740
---

# Brocade VDX6740

The Brocade VDX6740 and the Brocade VDX family of switches deliver the performance, flexibility, and efficiency required by modern data centers, including cloud and highly virtualized environments. The Brocade VDX 6740 offers 48 10 Gigabit Ethernet (GbE) SFP+ ports and four 40 GbE QSFP+ ports. Each 40 GbE port can be broken out into four independent 10 GbE SFP+ ports, providing an additional 16 10 GbE SFP+ ports. In addition, the switch features low power consumption, consuming 1 watt per 10 GbE port.

## About

This connector uses SNMP to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.0.1a.                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *200*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **System Description**, **Contacts**, and **Locations.**

### Interface

This page displays the **Interface Table**.

### TCP (Transmission Control Protocol)

This page displays the **Transmission Control Algorithm**, **Minimum Retransmission Timeout**, **Maximum Retransmission Timeout**, **Attempt Fails**, etc. The page also includes a page button that displays the **Connection Table**.

### UDP (User Datagram Protocol)

This page displays several parameters related to the **User Datagram Protocol**. The page also includes a page button that displays the **UDP Table**.

### IP

This page displays several IP-related parameters. The page also includes a number of page buttons: **V6 Router Table**, **Addressing Table**, **Network to Media Table**, **Route Table**, and **Addressing Table**.

### FRU (Field Replaceable Unit Table)

This page displays the **Field Replaceable** **Unit Table**, and contains a page button that displays the table **History**.

### Connectivity Unit

This page displays the **Connectivity Unit Table**. It also contains the **Sensor**, **Revision**, **Port** and **Event** page buttons.
