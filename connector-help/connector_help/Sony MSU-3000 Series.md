---
uid: Connector_help_Sony_MSU-3000_Series
---

# Sony MSU-3000 Series

The Sony MSU-3000 master setup unit is a multi-camera remote control panel for system cameras (horizontal type). It allows intuitive control and maintenance of the connected Sony HDC series cameras.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Supports all ember + parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.30                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *9000*).

### Initialization

No additional configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Ember+ calls are used to retrieve the device information.

With this connector, you can control the CCU/RCP assignment matrixes from the pages CCU/RCP Assignment. Keep in mind that if the "State" of the matrix is "Not Available", the respective matrix cannot be controlled. This state is displayed just above each of the matrixes.
