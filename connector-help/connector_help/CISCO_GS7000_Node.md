---
uid: Connector_help_CISCO_GS7000_Node
---

# CISCO GS7000 Node

The **CISCO GS7000 Node** four-port node is designed to enable broadband video network operators to easily scale services to meet customer demand and generate more bandwidth for more customers as the need for new services increases.

## About

This connector was designed to monitor **optical information and RF cable modem information** for the node.

For most of the tables in the connector, a control is available to enable or disable polling.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.7.0 Build 26 CxC 3.9.17   |

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

This page displays general parameters, such as **Description**, **Hardware** and **Firmware Revision**, **Serial Number**, **Manufacturer**, and **Model**.

### Optical Control

This page contains the **Optical Transmitter** and **Optical Receiver Control** tables, where you can mount/unmount the transmitters and receivers, the **Redundancy Control** table, and the **A/B Switch** table, where you can configure the switches.

### Optical Information

This page displays the **Power**, **Current** and **Wavelength**, as well as other parameters related to the **Transmitters** and **Receivers**.

### RF Control

This page displays information about the **RF Ports**, including the **Control** **Type**, **Level**, **Current** and **Control Level**.

### Device

This page displays general information about the physical device.

It also includes three page buttons to subpages with additional information: **Event**, **Access** and **Physical**.

### Network

On this page, you can monitor information related to the network interfaces, such as the **Packets**, network **Bandwidth**, **IP Addresses**, etc.

The page also contains a number of page buttons: **ICMP**, **IP**, **Dot 1**, **Dot 3**, **UDP**, **IP Datagram** and **Interface Extended**.

### Transponder

This page displays the **Cable Modem** status and **CM Upstream Service Queue.**

The page also contains a page button that opens the **Cable Modem Information** subpage. Note that it is possible that in some cases the information of the cable modem is displayed even if the protocol parameters are "*Not initialized*" because the transponder is a separate entity inside this device.

### QOS

This page displays the **Quality of Service** table and **downstream** and **upstream** **Service Flow.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
