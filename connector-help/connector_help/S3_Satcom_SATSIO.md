---
uid: Connector_help_S3_Satcom_SATSIO
---

# S3 Satcom SATSIO

This protocol monitors the activity of the S3 Satcom SATSIO device. Communication with the device happens via a proprietary serial protocol.

The S3 Satcom SATSIO is an antenna controller unit capable of both NORAD tracking and conventional step tracking of small antennas.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1.xx and v2.xx        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this protocol has the following data pages:

- **General**: Displays general information such as the **Current Satellite** being tracked, the **Beacon Receiver Level** and the satellite position.
- **Antenna Controller**: Allows you to configure the antenna controller, e.g. set the **Tracking Mode** or select the **Satellite**.
- **Setup-1**: Allows you to set the **Site Coordinates**, and configure the **Beacon Options** and **Tracking Options**.
- **Setup-2**: Displays the **Motors** and **Polarisation Options** and **Encoder Offsets and Soft Limits**.
- **Parallel I-O**: Displays the **Opto-Isolated Inputs** and the **Relay Outputs** Tables.
- **Environmental Status**: Displays environmental alarms and data of the device.
