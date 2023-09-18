---
uid: Connector_help_Ciena_8700_Packetwave_Platform
---

# Ciena 8700 Packetwave Platform

The **Ciena 8700 Packetwave Platform** is a multi-terabit programmable Ethernet-over-coherent DWDM packet switch. The 8700 is optimized for 10 GbE to 100 GbE switching and aggregation, and therefore delivers higher-rate ports, services and connections.

## About

This connector uses an SNMP connection to obtain relevant information from **Ciena 8700 Packetwave Platform** devices.

### Version Info

| **Range**     | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version              | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Correct bit rate calculation | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

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

This page displays the system information parameters, such as the **Description**, **Object ID** and **Up Time** of the device. The page also contains the **Availability** parameters, which show the availability of the device based on connectivity monitoring.

### Interface

This page contains the **Interfaces Table**, which displays information about the interfaces connected to the device. It also allows you to change the **Admin Status** and to set a new **Alias** for each interface.

### Chassis

This page displays relevant information about the **Fans**, **Power Supply**, **Memory Usage** and **CPU**.

### Statistics

This page displays the **Interface Statistics** such as the total in- and outbound traffic, the total in- and outgoing unicast, multicast and broadcast packets, and some total error counts.
