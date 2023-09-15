---
uid: Connector_help_Capella_Systems_Cambria_FTC
---

# Capella Systems Cambria FTC

Cambria FTC imports and exports widely used professional digital video formats, including H.264, MPEG-2, DNxHD and HEVC.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.4.0.48460            |

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
- **IP port**: The IP port of the destination (default: *8647*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

With this connector, you can monitor the general and system information for your Capella Systems.

You can also look for the latest jobs and check the status, progress, and much more.

The element contains a tree control with the Path Parent Folders and also the file names available for each folder. In there you can check how many jobs have started, how many have been completed successfully, and how many have failed.
