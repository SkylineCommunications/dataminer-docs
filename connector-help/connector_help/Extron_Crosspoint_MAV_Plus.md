---
uid: Connector_help_Extron_Crosspoint_MAV_Plus
---

# Extron Crosspoint MAV Plus

The Extron Crosspoint MAV Plus matrix switcher family distributes any audio/video input to any combination of outputs.
The switcher can route multiple input/output combinations simultaneously.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.02                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Telnet Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device is required. The default value is 23.
- **Bus address**: The bus address of the device is not required.

## How to use

This connector contains the following pages:

- **General**: Displays general parameters such as the **model**, **firmware version** and **number of inputs and outputs**. Also contains the **Security** page button.
- **Operational Status**: Displays the operational status of BME 0. Note that other BMEs cannot be retrieved with the corresponding API command.
- **Matrix**: Displays the matrix. Note that this is compatible with devices with audio/video or audio only with a different number of inputs/outputs.
- **Input/Output**: Displays the Input Table and the Output Table.
- **Labels**: Displays a table with the matrix labels.
- **Locks**: Displays a table with the matrix locks.
- **States**: Displays a table with the matrix states.
- **Web Interface**: Provides access to the web interface of the Extron Crosspoint MAV Plus. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
