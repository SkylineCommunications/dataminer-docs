---
uid: Connector_help_Ciena_5170_Packetwave_Platform
---

# Ciena 5170 Packetwave Platform

The **Ciena 5170 Packetwave Platform** is a multi-terabit programmable Ethernet-over-coherent DWDM packet switch. The 5170 is optimized for 10 GbE to 100 GbE switching and aggregation, and therefore delivers higher-rate ports, services and connections.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays the system information parameters, such as the **Description**, **Object ID** and **Up Time** of the device. The page also contains the **Availability** parameters, which show the availability of the device based on connectivity monitoring.
- **Interface**: Contains the **Interfaces Table**, which displays information about the interfaces connected to the device. It also allows you to change the **Admin Status** and to set a new **Alias** for each interface.
- **Chassis**: Displays information about the **Power Supply**, **Memory Usage** and **CPU**.
- **Statistics**: Displays the **Interface Statistics**, such as the total in- and outbound traffic, the total in- and outgoing unicast, multicast and broadcast packets, and some total error counts.
