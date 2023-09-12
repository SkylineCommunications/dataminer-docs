---
uid: Connector_help_2WCOM_MPX-1g
---

# 2WCOM MPX-1g

The MPX-1g is a multifunctional, modular MPX generator in a 19-inch/1U housing that can generate a multiplex signal (IP, analog, and digital) from different signal sources.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination
- **Bus address**: The bus address of the device.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has the following data pages:

- **General**: Provides a comprehensive list of general system information and details about its interfaces.
- **Internet Eth Status**: Allows you to monitor the real-time status of interfaces in the Internet Eth Status table.
- **RDS** and **Stereo Encoder**: Dedicated pages with in-depth information about stereo and RDS functionalities.
- **Interface Settings**: Allows you to customize interface settings. Contains subpages with DTE, GPI, and GPO tables for more control.
- **Network Settings**: Allows you to configure essential network settings. You can monitor the Ctrl, Data1, and Data2 Services tables, as well as configure and monitor the TCP/IP, NTP, and External APIs connections.
- **Alarms**: Displays alarms related to Hardware, Networks, External Clock, Inputs, Outputs, UECP Data Sources, and UECP MECs.
- **Device Status**: Provides a comprehensive overview of the power units and NTP status of the device.
