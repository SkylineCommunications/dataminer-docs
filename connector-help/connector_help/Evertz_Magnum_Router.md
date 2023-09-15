---
uid: Connector_help_Evertz_Magnum_Router
---

# Evertz Magnum Router

The **Evertz Magnum Router** protocol drives the Evertz Magnum application. It allows DataMiner to act as any other router panel connected to the Evertz Magnum application.

## About

The **Evertz Magnum Router** contains a matrix in which any input and any output for the router can be connected. Serial commands are used to get the data from the device.
These serial commands use the QUARTZ protocol to successfully communicate with the Evertz Magnum application.

In order to use this connector, it is necessary to also **configure the Magnum application** itself, so that an extra router panel can take control over a certain matrix. Inside the Magnum application this will translate into a virtual router (with x inputs and y outputs) that will be made available on a certain IP/PORT. It is these IP/PORT settings that need to be configured during creation of the DataMiner element using the Evertz Magnum Router protocol.

### Version Info

| **Range**     | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version    | No                  | Yes                     |
| 2.0.0.x              | Customer-specific  | No                  | Yes                     |
| 2.0.1.x \[SLC Main\] | Added external DCF | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Magnum Server               |
| 2.0.0.x          | Magnum Server               |
| 2.0.1.x          | Magnum Server               |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection to request data from the router. This connection requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

### Configuration of the matrix

On the **Matrix Configuration** page, the input and output size must be set to a correct value to receive labels to resize the matrix and to receive labels for each input.

## Usage

### Matrix

This page contains the **matrix** that is used to link **inputs and outputs** for this router at **crosspoints**.

### Matrix configuration

On this page, you can change the **size** of the matrix.

After the first startup, resize the matrix to an adequate size to receive labels for each input.

### Input

This page contains a table where you can specify a **custom name** for the **inputs** and indicate what the **connected** **outputs** are.

### Output

This page contains a table where you can specify a **custom name** for the **outputs** and indicate what the **connected** **input** is for that output.

### Logging

This page displays the changes that where done to the in- and outputs. It also registers changes done by third-party programs.
