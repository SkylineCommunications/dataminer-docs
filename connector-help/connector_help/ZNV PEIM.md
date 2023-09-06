---
uid: Connector_help_ZNV_PEIM
---

# ZNV PEIM

The ZNV PEIM (Power Environment Intelligent Management) platform is a solution designed to provide robust monitoring, management, and control capabilities for a wide range of software and hardware components located in physical environments such as premises, floors, equipment rooms, and data centers. The platform provides an API for retrieving the state of all its components.

## About

### Version Info

| **Range**            | **Key Features**                                                 | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Monitors the state of all available components. | \-           | \-                |

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

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, go to the General page and log in, so that the connector can access the information from the API.

## How to use

The primary function of the connector is to fetch the alarms from all components monitored by the PEIM system. You can access these alarms on the dedicated Alarms page.
