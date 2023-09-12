---
uid: Connector_help_SSC_BR23L
---

# SSC BR23L

Satellite Systems (SSC) Model BR23L is a fully agile satellite tracking receiver designed to provide a linear DC reference voltage proportional to the received signal level of a satellite beacon or other SCPC carrier.

## About

The SSC BR23L driver uses a serial protocol to communicate with the BR23L device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | L.4A32                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device. If the bus address is empty, communication goes through the RS-232 protocol, otherwise RS-485 is used.

## How to use

This driver consists of only one page, the **General** page. This page contains the monitored system parameters used in the satellite carrier tracking process, the **carrier input frequency,** the **current reference level**, the **current DC reference voltage** and the **carrier tracking status**.
