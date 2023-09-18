---
uid: Connector_help_Meinberg_Lantime_M300
---

# Meinberg Lantime M300

With this connector, you can gather and view information of the device **Meinberg Lantime M300**, as well as configure the device.

## About

This SNMP connector is used to monitor and configure the **Meinberg Lantime M300** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.1.x              | Initial version | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | DCF integration | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**          |
|------------------|--------------------------------------|
| 1.0.1.x          | 6.20.012 (see "Notes" section below) |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

#### SCP connection

This connector uses an SCP connection, which is maintained internally by the connector:

SCP CONNECTION:

- **IP address**: The polling IP or URL of the destination.
- **IP Port**: 22.

## Usage

### General Page

This page displays general information about the device, e.g. **System Description**, **Up Time**, **Firmware Version**.

The page also contains the following page buttons:

- **SCP Credentials**: Allows you to define the username and password for the SCP connection.
- **PSU**: Shows the available power supply unit and its state.
- **Fan**: Shows the available fans and their state.
- **Ref. Clock**: Shows the available reference clocks and parameters related to these.

### Network Page

On this page, you can configure and monitor the device's network settings, e.g. **Ethernet Hostname**, **Ethernet IPv4 Gateway**, **Link Mode**.

The page also contains three page buttons:

- **Services**: Allows you to enable or disable a service provided by an interface.
- **Interfaces**: Allows you to configure the interfaces of the device.
- **Interfaces Statistics**: Displays the statistics of the interfaces.

### Notification Page

On this page, you can configure the notifications sent by the device, with parameters such as **Syslog Address 1** and **Mail Address 1**.

### Security Page

On this page, you can configure the security parameters of the device, such as **Disable Root Login** and **SSH Shell Timeout**.

### SNMP Page

On this page, you can configure the SNMP settings of the device, such as **SNMP Contact** and **SNMP Activated Versions**.

The page also contains one page button, which opens the **Trap Config** subpage, where you can configure the traps.

### NTP Page

On this page, you can configure and monitor the NTP settings of the device, such as **NTP Trusttime,** **Time Scale** and **PPS.**

The page also contains four page buttons with more NTP settings:

- **NTP Broadcast**
- **External NTP**
- **NTP Multicast**
- **NTP Manycast**

### System Page

On this page, you can configure general settings of the device.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Meinberg Lantime M300** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **RefOut**: Physical interface of type **out**.

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **Ethernet**: All interfaces that are available in the **Interface Table** on the **Interfaces Statistics Page**. All these interfaces are of type **inout**.

### Connections

#### Internal Connections

- The Reference Clock in the **Ref. Clock Table** on the **Ref. Clock Page** for which the **Usage** is **Primary** is connected to the physical interface **RefOut**.

## Notes

A problem can occur with the **Usage** in the **Ref. Clock Table** on the **Ref. Clock Page** for firmware versions **prior to** **6.20.012**, so it is possible that DCF will not work properly with those firmware versions.
