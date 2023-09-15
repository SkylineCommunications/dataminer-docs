---
uid: Connector_help_Cisco_GS7000_Hub
---

# Cisco GS7000 Hub

The **Cisco GS7000 Hub** provides multiple options for optical amplification, filtering, splitting, and combining, in a field-proven model GS7000 station. This connector can be used to monitor this device.

## About

The connector uses an SNMP connection to monitor a **Cisco GS7000 Hub** device. It allows you to view information about the cable modem, DC power, switch, amplifier, etc.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
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
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information, such as the **Model number**, **Serial Number**, **Vendor Information**, etc.

### Network

This page contains the tables **IP Address** and **Interface**. It also contains seven page buttons:

- **Interface Extended**
- **IP**
- **ICMP**
- **IGMP**
- **UDP**
- **Dot1**
- **Dot3**

### Transponder

This page contains seven tables with information about the cable modem:

- **CM MAC**
- **Bpi2 CM Base**
- **CM Status**
- **Bpi2 CM TEK**
- **CM Service**
- **Bpi2 CM Device Certificate**
- **Bpi2 CM Cryptographic Suit**

This page also contains two page buttons: **Cable Modem Information** and **Cable Modem.**

### QOS

This page contains four tables:

- **QOS Parameter Set**
- **QOS Service Flow**
- **QOS Service Flow Statistics**
- **QOS Dynamic Service Statistics**

### Device

This page contains general information about the software and server. It also contains four page buttons:

- **Identity**
- **Event**
- **Access**
- **Physical**

### Alarm Log

This page contains the **Alarm Log** table and a series of related parameters.

### DC Power

This page contains the **DC Power** table and a series of related parameters.

### Switch

This page contains the **Optical Switch** and **Switch Input** tables.

### Amplifier

This page contains the **Amplifier Input Laser**, **Amplifier Input Data** and **Amplifier Input** tables.

### Vo IP

This page contains the **Vo IP Test Control** and **VO IP Test Result** tables**.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

- For each of the tables in the connector, a **Polling** parameter allows you to enable or disable the polling of the table.
- In all tables, there is a **Description** column, where you can specify a description, and a **Custom Description** column, which concatenates the **Index** of the table and the **Description** column.
