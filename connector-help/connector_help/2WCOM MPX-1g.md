---
uid: Connector_help_2WCOM_MPX-1g
---

# 2WCOM MPX-1g

The MPX-1g is a multifunctional, modular MPX generator in a 19-inch/1U housing that can generate a multiplex signal (IP, analog and digital) from different signal sources.

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

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]
- **Bus address**: \[The bus address of the device.\]

### Initialization

No additional initialization needed

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

**General Page:**The General Page provides a comprehensive list of general system information and details about its interfaces.

**Internet Eth Status:**Monitor the real-time status of interfaces on the Internet Eth Status table.

**RDS and Stereo Encoder Pages:**Dedicated pages for in-depth information about Stereo and RDS functionalities.
**Interface Settings Page:**Allows for interface settings customization on this page. Contains subpages housing DTE, GPI, and GPO tables for more control.

**Network Settings Page:**Configure essential aspects on the Network Settings page. Monitors Ctrl, Data1, and Data2 Services tables. Also it's possible to configure and monitor the TCP/IP, NTP, and External APIs connections.
**Alarms Page:**Access alarms related to Hardware, Networks, External Clock, Inputs, Outputs, UECP Data Sources, and UECP MECs on this dedicated page.

**Device Status Page:**Comprehensive view of the device's power units and NTP status through the Device Status page.

**Web Interface Page:**Directly access the Web UI environment through the Web Interface page.


