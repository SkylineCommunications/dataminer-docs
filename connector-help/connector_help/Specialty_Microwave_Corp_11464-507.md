---
uid: Connector_help_Specialty_Microwave_Corp_11464-507
---

# Specialty Microwave Corp 11464-507

This driver uses serial communication to communicate with a switching module. This module powers to up to four low-noise amplifiers (LNB) and provides redundancy protection switching logic for the LNBs.

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

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device. Default: *49*. Range: *33* - *126.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can find the information retrieved by the connector, such as the **Operation State** of the **Power Switches**, the **Switches**, and the **LNBs**.

You can also change the **Switch Positions** and set the **Unit State**.
