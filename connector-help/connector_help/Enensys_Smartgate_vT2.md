---
uid: Connector_help_Enensys_Smartgate_vT2
---

# Enensys Smartgate vT2

The **SmartGate vT2** is ENENSYS's software-based gateway for DVB-T2 single-frequency network operation.

This connector provides a **table with all available alarms**. It sends **REST** requests directly to the gateway in order to return the available data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.2.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

In order for the connector to gather and display the alarms, the credentials need to be correctly filled in on the **Authentication** page.

## How to use (1.0.0.x range)

The element created using this connector contains the following pages:

- **Alarms**: Displays a table with all the alarms, sorted from the most recent to the oldest.
- **Authentication**: The login credentials have to be filled in here. Also contains information regarding the connection and authentication status.
