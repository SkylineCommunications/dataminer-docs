---
uid: Connector_help_Nagios_Connector
---

# Nagios Connector

This DataMiner connector can be used to retrieve status information for all hosts and services available on a Nagios XI platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Main branch.     | \-           | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Before you can use the element, you need to fill in the API key on the **Configuration** page. You can obtain this key from the user account page of the Nagios XI web interface.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page displays a tree view with status information of all hosts that are being monitored by the Nagios XI system. When you expand a node in this tree view, all services belonging to that node are displayed.
