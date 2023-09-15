---
uid: Connector_help_Grass_Valley_8900_General_Platform
---

# Grass Valley 8900 General Platform

The Grass Valley GeckoFlexT 8900 Signal Processing System is a family of con-version, distribution, timing and processing modules, intended for signal processing applications. This range of products provides a flexible frame environment within a single frame, with a large selection of analog, digital and high-definition video and audio modular products. A full range of signal processing products exists for configuring and operating modules, from single or multi-function modular products to an Ethernet-based control system.

## About

This is an **SNMP** connector that exports the protocol **Grass Valley 8900 Slot**. It connects to the frame controller, retrieves information about the 8947 and 8949 boards, and filters out the empty slots

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version  | No                  | Yes                     |
| 1.0.1.x          | DVE custom names | No                  | Yes                     |
| 1.0.2.x          | Added DCF        | Yes                 | Yes                     |

### Product Info

| **Range**        | **Device Firmware Version**                    |
|-------------------------|------------------------------------------------|
| 1.0.0.x 1.0.1.x 1.0.2.x | Software version: 4.0.0 Hardware revision: 01A |

### Exported connectors

| **Exported Connector**  | **Description**       |
|------------------------|-----------------------|
| Grass Valley 8900 Slot | 8947 and 8949 modules |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Frame Status

This page contains parameters related to the **general functioning** of the frame, such as the bus status summary, the **general frame status**, **temperature**, **fan** and **power supplies status**.

### General NetCard

This page contains general information about the devices, such as the **serial number**, **software** and **hardware versions** and **frame model**. You can also **reboot** the equipment here.

### Slots

This page contains a table with the list of cards in the frame, which is used to export the DVEs.

### Web Interface

This page provides access to the equipment's web interface. Note that the client has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.2.x** connector range of the **Grass Valley 8900 General Platform** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.
