---
uid: Connector_help_Wilhelm_Winter_MSK07
---

# Wilhelm Winter MSK07

The **Wilhelm Winter MSK07** is a basic antenna controller without tracking functionality. The corresponding driver implements control and monitoring of **azimuth** and **elevation**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

Serial communication is used to communicate with the device through a serial gateway.

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required. The value depends on the port of the serial gateway the device is connected to.
  - **Bus address**: The bus address of the device. Required. Hardware-adjustable between 1 and 9.

### Initialization

When setting up the element, make sure the bus address is filled in according to the hardware configuration specified in the device manual.

## How to Use

### General

This page contains basic information about the **current position** of the dish, as well as information about the **status** returned by the device.

### Control

The device uses a set of **10 saved angles** to do automatic movements towards an azimuth or elevation position. You can save these values on the ACU by setting the parameter **Target Angle** in the **Target Positions** table.

To drive either the **azimuth** or the **elevation** to a previously selected position, use the **buttons** in the **Target Positions** table.

In the top-right corner of this page, you can find the **jogging/creeping** functionality of the device.

To ensure monitoring during operations, in the lower right corner, you can find **calculated movement status parameters**. In addition, there is also a button that allows you to interrupt the movement.

There can be a small discrepancy between the **device** reporting **In Position** (on the General page) and the **driver calculation** of when the antenna is **stationary**.

### Configuration

On this page, you can set configuration parameters that are useful **during operation**.
