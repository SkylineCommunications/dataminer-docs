---
uid: Connector_help_Generic_Virtual_IP_Device
---

# Generic Virtual IP Device

This connector is used to create virtual elements and connect these to IP Cloud elements. It allows you to indicate if a device is a single- or dual-IP device.

The parameters that indicate the values of the IP addresses are used both for configuration purposes and to provide the necessary info to communicate with the device address and port.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Linked connectors

| **Name** | **Range** |
|-----------------|-----------|
| SKY UK IP Cloud | 1.0.1.x   |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

The General page contains several parameters that can be used to configure the virtual IP device.

There are two destination addresses, **Destination Address A** and **Destination Address B.** There are also two ports that are linked to these addresses, **Destination Port A** and **Destination Port B**. For the destinations, the **Device Output Configuration** parameter allows you to indicate if the virtual IP device has a **Single-** or **Dual**-IP connection.

There are also two source addresses **Source Address A** and **Source Address B**, with the corresponding ports **Source Port A** and **Source Port B**. For the sources, the **Device Input Configuration** parameter allows you to indicate if the virtual IP device has a **Single-**or **Dual**-IP connection.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the **Generic Virtual IP Device** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- The output of IP connection A: The virtual connection **Output A** is of type **out**.
- The output of IP connection B: The virtual connection **Output B** is of type **out**.
- The input of IP connection A: The virtual connection **Input A** is of type **in**.
- The input of IP connection B: The virtual connection **Input B** is of type **in**.

## Revision History

1.0.0.1 Initial version
