---
uid: Connector_help_Viavi_Solutions_ONMSi
---

# Viavi Solutions ONMSi

Viavi Solutions ONMSi is a Remote Fiber Test System (RFTS), which detects and locates fiber degradation, alerting operators and managers with the details of faults.

This connector acts as a monitoring platform for this product, where the user can see the relevant information retrieved from the system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.90.0.2               |

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
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector acts as a monitoring platform, allowing you to see the relevant information retrieved from the system regarding the **OTUs** (Optical Transport Units), **Links**, **Ports**, and the corresponding **Events** (alarms).

This information is organized in a tree view.
