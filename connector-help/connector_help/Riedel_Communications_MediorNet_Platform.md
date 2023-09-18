---
uid: Connector_help_Riedel_Communications_MediorNet_Platform
---

# Riedel Communications MediorNet Platform

The **Riedel Communications ST2110 - SDI Gateway** is used to encapsulate or de-encapsulate SDI data from/to IP ST2110. This connector can be used to monitor the encapsulation and de-encapsulation process. Each process uses flows and formatting values that are relevant when executed. The connector is based on Embox3u and Embox6 device data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the following data pages:

- **General:** Contains general information about the device.
- **Interfaces:** Contains information about the interfaces that the device uses.
- **Reference Clock:** Contains information about the status and controls of the device reference clocks.
- **Flows:** Contains information about each flow type (video, audio, or ancillary).
- **LLDP:** Contains Link Layer Discovery Protocol (LLDP) information (i.e. chassis, port, and TTL).
- **Devices:** Contains devices information (label, type, node ID, etc.) and each device type table (Sources, Senders, and Receivers).
- **Devices Flows:** Contains device flow communication data (engine ID, type, packet counter, and sequence error counter).
- **Ports:** Contains port configuration data and ports telemetry (temperature, Tx power, and Rx power).
- **SDI:** Contains SDI configuration data for each SDI type (Input, Audio, and Output).
