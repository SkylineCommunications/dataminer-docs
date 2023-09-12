---
uid: Connector_help_AMWA_NMOS_IS-05
---

# AMWA NMOS IS-05

AMWA IS-05 specifies how to allow a device in an NMOS-compatible system to connect to other devices, by means of the devices' senders and receivers.

IS-05 is intended to be used in conjunction with an IS-04 NMOS Discovery & Registration deployment, but it will provide useful functionality even in the absence of such a system.

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
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## How to Use

On the **General** page, you can find the Senders and Receivers tables with all the relevant information.

The connector adds the information by parsing an **HTTP** response.
