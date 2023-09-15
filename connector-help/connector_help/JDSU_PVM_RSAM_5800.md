---
uid: Connector_help_JDSU_PVM_RSAM_5800
---

# JDSU PVM RSAM 5800

With this connector, it is possible to monitor **JDSU PVM RSAM 5800** devices with SNMP.

## About

The **JDSU PVM RSAM 5800** will monitor the JDSU PVM RSAM 5800 Video Monitor using the **HTTP** protocol.

When **SNMP** **traps** are received, the element will update the corresponding tables.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                             | No                  | Yes                     |
| 2.0.0.x          | Branch version based on 1.0.0.x (see below) | No                  | Yes                     |
| 2.1.0.x          | New firmware based on 2.0.0.x (see below)   | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | VSA Monitor API version 2.6 |
| 2.0.0.x          | VSA Monitor API version 2.6 |
| 2.1.0.x          | VSA Monitor API version 3.1 |

## Installation and configuration

### Creation

This is an HTTP connector. The IP and port need to be configured during creation of the element. An SNMP connection is needed to receive traps.

HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. By default *80.*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

SNMP Traps connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page displays information about the PVM device.

### Test Point Page

This page displays a table with information about the RSAM Test Points.

### Channels Page

This page displays a table with information about the monitored channels.

### Programs Page

This page displays a table with information about the monitored programs.

### Overview Page

This page displays a tree view with the test points as the root.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
