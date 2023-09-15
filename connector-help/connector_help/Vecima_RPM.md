---
uid: Connector_help_Vecima_RPM
---

# Vecima RPM

Vecima RPM is a management system for Remote PHY devices.

The Vecima RPM connector fetches information from managed Remote PHY devices. The PHY cores information will be shown in custom requested tables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.5.10                 |

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
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (default: *ByPassProxy).*

## How to use

To communicate with the RPM device, fill in the **Username** and **Password** on the main page. Once this is done, information on the RPD cores will be polled and displayed on the **RPD Cores** page.
