---
uid: Connector_help_Vidispine_API_Client
---

# Vidispine API Client

The **Vidispine API Client** driver is an API-based media asset management platform. Vidispine API integrates with another workflow application by using a RESTful API.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | 5.1.pre-gffdc30a9b8-725 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **General** page, the **Username** and **Password** must be specified.

### Redundancy

There is no redundancy defined.

## How to use

At the moment, it is only possible to monitor information with the driver. The **Overview** pages show information in a tree view where appropriate.

All the content is available in tables on the remaining pages.
