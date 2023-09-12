---
uid: Connector_help_ETL_Systems_Matrix
---

# ETL Systems Matrix

This connector is designed for the ETL Systems Matrix, a broad switch matrix/RF router range providing RF signal distribution for satellite communication with input and output gain control. The data transmission is achieved via serial communication. The ETL Matrix Router products are available as a distributive fan-out matrix for receive chains and as a combining fan-in matrix for transmit chains.

The connector supports matrices of sizes up to 256 inputs x 256 outputs.

## About

### Version Info

| **Range**            | **Key Features**                                                                       | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                        | \-           | \-                |
| 1.0.1.x \[SLC Main\] | New "Gains" page added. The input and output gains table have been moved to that page. | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial

This connector uses a serial connection and requires the following input during element creation.

Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device (default: *19200*).
- **Bus address**: The bus address of the device (default: *65*; range: *32* - *122*).
- **Databits**: Databits specified in the manual of the device (default: *8*).
- **Stopbits**: Stopbits specified in the manual of the device (default: *1*).
- **Parity**: Parity specified in the manual of the device (default: *no*).
- **FlowControl**: FlowControl specified in the manual of the device (default: *no*).

## How to use

The **General** page contains the list of power supplies of the device and their current alarm status. On this page, you can also extend or reduce the matrix size by modifying the **Number of Inputs/Outputs** parameter. If there is an input or an output in the matrix such that its index is a bigger number than the one configured in the Number of Inputs/Outputs parameter, then the parameter is ignored.

The **Matrix** page displays the current matrix configuration of the device, where you can visualize and configure the desired connections between the inputs (on the left) and the outputs (at the top).

The **Gains** page contains two tables: one for input and one for output gains. You can modify the gain levels too if supported by the device. You can turn off polling of gains on the **Configuration** page.

All data is received and set by using **serial communication**.
