---
uid: Connector_help_Viaccess_VO_DRM_-_Security_Services
---

# Viaccess VO DRM - Security Services

The Viaccess VO DRM - Security Services driver allows monitoring of multimedia services running on the connected devices. VO DRM and Security services monitor features for a multi-platform media player for premium live and VOD content, streamed or downloaded, providing end-to-end DRM content protection solutions for connected devices.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has the following data pages:

- **General**: Allows you to control polling for the data on the other pages.
- **NPVR Services**: Displays parameters related to Content Services, Program Services, Recording Integration Services, Recording Services and Session Management.
- **Personal Continuous Watching**: Contains the Personal Continuous Watching Status parameter.
- **Compass Services**: Displays information about the compass services, e.g. Server ID, Version, etc.
- **RighTV:** Contains parameters related to RighTV JBOSS services and Admin RighTV.
- **Security:** Contains the KMS Status parameter.
- **UI Optimizer:** Contains the UI optimizer parameters (added in 1.0.0.2 version).

For all groups on all pages, a polling control toggle button is available.
