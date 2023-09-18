---
uid: Connector_help_Evertz_5782XPS
---

# Evertz 5782XPS

This connector is used to monitor and control the Evertz 5782XPS decoder.

An SNMP connection is used in order to successfully retrieve information and configure the device. There are also different possibilities available for alarm monitoring and trending.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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

- **Port number**: The port of the connected device, by default *161*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **System Network**: This page contains general settings information, including the control ports and time source configuration.
- **System Management**: This page contains system information, including licence control and product features.
- **NMOS**: This page contains the NMOS table.
- **System Monitoring**: This page includes system monitoring parameters, the threshold table, and system monitoring faults.
- **System Security**: This page contains Zen Master SSH certificate information.
- **System Image**: This page includes additional information about system images.
- **Decoder Input**: This page contains information about the decoder main and backup configuration.
- **Decoder Control**: This page contains information about decoder control, including audio select and intellitrak information.
- **Decoder Output**: This page contains information about decoder output and loss of video control, as well as IP output.
- **Decoder Monitor**: This page is used for decoder monitoring (input, video, audio VANC, error monitoring).
- **Decoder Notifications**: This page is used to monitor incoming traps.
