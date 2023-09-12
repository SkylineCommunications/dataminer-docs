---
uid: Connector_help_Graphite_Beacon_HTTP_Trap_Receiver
---

# Graphite Beacon HTTP Trap Receiver

This driver processes incoming traps and displays the resulting information in a table.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## How to use

On the **Beacon Alerts** page, a table shows all the data received from the device.

Via a button, you can configure the automatic cleanup of the table. You can set the maximum number of rows that should be saved in the table, or configure the maximum lifespan of an entry.

On the right side of the page, a button is available that allows you to clear the entire table in one click.
