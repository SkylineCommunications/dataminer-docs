---
uid: Connector_help_Harris_Matrix_Telnet
---

# Harris Matrix Telnet

The Harris Matrix Telnet is a matrix HD-SDI video router.

This connector uses a **smart-serial** connection to communicate with the Harris Matrix device over **Telnet**.

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
  - **Bus address**: The bus address of the device, by default *0* (range: from *0* to *15*).

### Initialization

To make sure information can be retrieved from the device, log in on the **General** page of the element. When the **Logged In** status parameter shows "Yes", the login has been successful.

### Redundancy

There is no redundancy defined.

## How to use

### General

On this page, you can connect to the device by **logging in**. This page also displays the **Logged In status** and the **Level Dimensions**, and it allows you to **Restart** the device.

### Inputs/Outputs

This page contains the **Outputs** and **Inputs tables**. These allow you to change the names of the outputs/inputs and to connect/disconnect an output to an input.

Note: The input/output label names have to be unique, as otherwise the name change will not work.

### Matrix

This page displays a matrix that clearly shows the connected inputs and outputs. It also allows you to connect or disconnect inputs/outputs.

Note: The dimensions of the matrix will scale to the dimensions of the level visible on the General page.
