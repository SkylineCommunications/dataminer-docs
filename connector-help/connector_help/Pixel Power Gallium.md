---
uid: Connector_help_Pixel_Power_Gallium
---

# Pixel Power Gallium

Pixel Power Gallium is a highly integrated and scalable scheduling, asset management and automation system. It hosts web services that provide asset, data, playout, render, report, schedule and schedule emitter functions.

The **Pixel Power Gallium** driver is used to retrieve and monitor channels, alarm reports and asset availability reports.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.61.0.1               |

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
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays general parameters such as the Uptime, Version and License.
- **Channels**: Contains a table that displays the status of all channels. Also allows you to assign a backup channel to a main channel and to set the backup channel to be master or slave.
- **Asset Availability**: Contains a list of missing and existing assets in tables.
- **Alarms Report**: Contains the New Critical, Critical and Old Alarm Reports in tables. Via a page button, you can view the corresponding **Parameters** of the alarms.
