---
uid: Connector_help_Miteq_RSU-B
---

# Miteq RSU-B

This driver uses serial communication to allow monitoring of the Miteq RSU-B.

## About

### Version Info

| **Range**            | **Key Features**                                                                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                                          | \-           | \-                |
| 1.1.0.x \[SLC Main\] | On these devices, the response starts by repeating the original command, followed by the normal response. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device (possible values: even, odd).
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device (range: 95 - 64).

## Usage

On the **General** page of the element, you can find the following information:

- Unit A: Fault status of converter unit A.
- Unit B: Fault status of converter unit B.
- Status: Indicates which of the two available inputs is connected to the output.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).
