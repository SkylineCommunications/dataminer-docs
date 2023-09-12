---
uid: Connector_help_SeaLevel_Systems_SEAIO-410
---

# SeaLevel Systems SEAIO-410

This connector uses a **serial** connection to communicate with the SeaLevel device over TCP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. *This must match the MODBUS address of the device.*

## How to use

### Isolated Inputs

This page contains the **Isolated Inputs** table.

### Relay Outputs

This page contains the **Relay Outputs** table.

### Polling Configuration

This page displays a polling configuration table where you can define the polling interval. The acceptable range is from 1 s up to 1000 s. Use the **Reset Default** button to assign the default frequency, and use the **Disable** button to assign an exception value (-1) to the group that disables polling.
