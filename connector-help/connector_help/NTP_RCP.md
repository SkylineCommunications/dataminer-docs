---
uid: Connector_help_NTP_RCP
---

# NTP RCP

The NTP RCP connector is used to control/monitor a router control device.

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

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600 (specified in the device manual).
  - **Databits**: 8 (specified in the device manual).
  - **Stopbits**: 1 (specified in the device manual).
  - **Parity**: No (specified in the device manual).
  - **FlowControl**: No (specified in the device manual).

- Interface connection:

  - **IP address/host**: The IP address of the device.
  - **IP port**: The IP port of the device.

## How to use

The **General** page shows basic information about the device such as **Version, Number of Users, Matrices, Macros, Virtual GPIs, Levels, Sources**, and **Destinations**. It also includes a **Refresh** button, which refreshes the matrix information. With the **Park Input** parameter you can configure to which input an output should be connected when a crosspoint is disconnected.

The **Logical Lines** page contains **Sources** and **Destinations** tables.
