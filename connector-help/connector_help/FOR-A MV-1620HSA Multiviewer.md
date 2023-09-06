---
uid: Connector_help_FOR-A_MV-1620HSA_Multiviewer
---

# FOR-A MV-1620HSA Multiviewer

This driver is used to monitor a 3G/HD/SD/Analog Mixed High-Resolution Multi-Viewer (16 Channels, Dual-Screen Output).

## About

The MV-1620HSA 3G/HD/SD/Analog Mixed High-Resolution Multi-Viewer from For-A is a multi-viewer that accepts up to 16 channels of mixed 3G/HD/SD-SDI or analog composite signals for monitoring on one or two screens. It can be cascaded with other units to display up to 64 sources at once.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### Unit

This page displays **mv16 Unit Info** parameters and **mv16 Unit Status** parameters.

### Input

This page displays **mv16 Output Status** parameters, as well as the **mv16 Input Status Table**.
