---
uid: Connector_help_RCI_RC2500
---

# RCI RC2500

The RCI RC2500 is a satellite antenna controller that allows a dish to find and track a satellite for communication. With this driver, you can monitor and manipulate the antenna.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

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

- **Baudrate**: Baudrate specified in the manual of the device (default: *9600*; range: *300* - *9600*).
  - **Databits**: Databits specified in the manual of the device. Only the value *7* is supported.
  - **Stopbits**: Stopbits specified in the manual of the device (default: *1*).
  - **Parity**: Parity specified in the manual of the device (default: *even*).
  - **FlowControl**: FlowControl specified in the manual of the device (default: *no*).

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device (range: *49* - *111*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the data pages detailed below.

### Main View

This page contains information about the satellite that is currently being tracked, including the **Satellite Name** and **Position**, **Azimuth**, **Elevation**, **Polarotor Position**,and other dish-related data.

### General

This page is very similar to the Main View page but includes an **Alarm Status** and four page buttons with additional information: **Normalize Alarms**, **Satellite List**, **Parameter Offset** and **Zero Crossing**.

### Move Position

On this page, you can move the antenna to different satellites or reset the antenna. This can be done in various ways, which are available through different page buttons:

- **Satellite Name:** Point the antenna to a preset satellite using the defined satellite name. The available satellite names are retrieved from the non-volatile **memory of the RCI RC2500** dish.
- **Azimuth/Elevation:** Move the antenna by manually entering azimuth and elevation.
- **Rotating Feed:** Move the antenna by manually rotating the antenna.
- **Polarotor:** Move the antenna by manually changing the polarotor position.
- **Jog Antenna:** Move the antenna by indicating a **Jog Direction, Speed,** and **Duration**.

### Alarms

On this page, you can view the status of several important parameters, such as the Azimuth Clockwise Limit and Elevation Up Limit.
